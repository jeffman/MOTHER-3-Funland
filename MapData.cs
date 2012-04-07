using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Extensions;
using GBA;

namespace MOTHER3
{
	class MapData : M3Rom
	{
		public static int Num = 1000;

		public class RoomInfo
		{
			public static int Address = 0xD2E1D8 + 12;
			public static int Length = 28;
			public static RoomInfo[] RoomInfoEntries = new RoomInfo[Num];

			public int index = 0;
			public byte[] Data = new byte[Length];

			public static void Init()
			{
				Rom.Seek(Address);
				for (int i = 0; i < Num; i++)
				{
					var ri = new RoomInfo();
					ri.index = i;
					for (int j = 0; j < Length; j++)
						ri.Data[j] = Rom.ReadByte();
					RoomInfoEntries[i] = ri;
				}
			}

			public int Width
			{
				get
				{
					int ch = Data[20] & 7;
					ch++;
					ch <<= 4;
					return ch;
				}
			}

			public int Height
			{
				get
				{
					int ch = Data[24] & 0x3F;
					ch >>= 3;
					ch++;
					ch <<= 4;
					return ch;
				}
			}
		}

		public class RoomGfxPal
		{
			public static int Address = 0xD34F44 + 12;
			public static int Length = 26;
			public static RoomGfxPal[] RoomGfxPalEntries = new RoomGfxPal[Num];

			public int index = 0;
			public byte[] Data = new byte[Length];

			public static void Init()
			{
				Rom.Seek(Address);
				for (int i = 0; i < Num; i++)
				{
					var rgp = new RoomGfxPal();
					rgp.index = i;
					for (int j = 0; j < Length; j++)
						rgp.Data[j] = Rom.ReadByte();
					RoomGfxPalEntries[i] = rgp;
				}
			}

			public ushort GetGfxIndex(int index)
			{
				return Data.ReadUShort(index << 1);
			}

			public short Pal
			{
				get
				{
					return Data.ReadShort(24);
				}
			}
		}

		public class RoomGfx
		{
			public const int Address = 0xD3B4E0;

			public static int GetGfxAddress(ushort index)
			{
				return Rom.ReadInt(Address + 4 + (index << 2)) + Address;
			}

			public static byte[] GetGfx(ushort index)
			{
				byte[] output;
				int result = LZ77.Decompress(Rom, GetGfxAddress(index), out output);
				return output;
			}

			public static byte[][] GetTilesets(RoomGfxPal rGfxPal)
			{
				byte[][] gfx = new byte[12][];
				for (int i = 0; i < 12; i++)
				{
					ushort ch = rGfxPal.GetGfxIndex(i);
					if (ch < (Num * 3))
						gfx[i] = RoomGfx.GetGfx(rGfxPal.GetGfxIndex(i));
					else
						gfx[i] = null;
				}
				return gfx;
			}
		}

		public class RoomPal
		{
			public static int Address = 0xF3C344;
			public static short Entries = -1;

			public static void Init()
			{
				Entries = Rom.ReadShort(Address);
			}

			public static MPalette GetPalette(int index)
			{
				int a = Rom.ReadInt(Address + 4 + (index << 2));
				if (a == 0) return null;
				return Rom.ReadPals(16, Address + a);
			}
		}

		public class RoomTiles
		{
			public const int Address = 0x104D9CC;

			public static byte[] GetTiles(int room)
			{
				byte[] output;
				int result = LZ77.Decompress(Rom, Rom.ReadInt(Address + 4 + (room << 2)) + Address, out output);
				return output;
			}
		}

		public class RoomMap
		{
			public const int Address = 0xF9003C;

			public static byte[] GetMap(int room, int layer)
			{
				byte[] output;
				int result = LZ77.Decompress(Rom, Rom.ReadInt(Address + 4 + (((room * 3) + layer) << 2)) + Address, out output);
				return output;
			}
		}

		public class RoomSprites
		{
			public static int Address = 0x1132B58;
			public static int Entries = -1;
			public static RoomSprites[][] Sprites = null;

			private int room;
			private int index;
			public byte Script;
			public byte Direction;
			public short X;
			public short Y;
			public ushort Sprite;

			public static void Init()
			{
				Entries = Rom.ReadUShort(Address);
				Sprites = new RoomSprites[Entries / 5][];

				for (int i = 0; i < Sprites.Length; i++)
				{
					int a1 = GetPointer((i * 5) - 1);
					int a2 = GetPointer((i * 5));

					if ((a1 == -1) || (a2 == -1)) continue;

					int num = (a2 - a1) / 24;

					Sprites[i] = new RoomSprites[num];
					Rom.Seek(a1);

					for (int j = 0; j < num; j++)
					{
						var s = new RoomSprites();
						s.room = i;
						s.index = j;

						Rom.SeekAdd(4);

						s.Script = Rom.ReadByte();

						Rom.SeekAdd(4);

						byte ch = Rom.ReadByte();
						s.Direction = (byte)((ch >> 1) & 7);

						Rom.SeekAdd(6);

						s.Sprite = Rom.ReadUShort();

						ch = Rom.ReadByte();
						s.X = (short)((ch << 4) + 8);

						ch = Rom.ReadByte();
						s.Y = (short)((ch << 4) + 15);

						Rom.SeekAdd(4);

						Sprites[i][j] = s;
					}
				}
			}

			public static int GetPointer(int index)
			{
				int a = Rom.ReadInt(Address + 4 + (index << 2));
				if (a == -1) return -1;
				return Address + a;
			}
		}

		public static void Init()
		{
			RoomInfo.Init();
			RoomGfxPal.Init();
			RoomPal.Init();
			RoomSprites.Init();
		}

		public static Bitmap GetMap(int room, int flags, bool drawsprites)
		{
			var rInfo = RoomInfo.RoomInfoEntries[room];
			var rGfxPal = RoomGfxPal.RoomGfxPalEntries[room];

			// Get the width and height (in 16*16 tiles)
			int w = rInfo.Width;
			int h = rInfo.Height;

			// Create the bitmap
			Bitmap bmp = new Bitmap(w << 4, h << 4, PixelFormat.Format8bppIndexed);
			BitmapData bd = bmp.LockBits(ImageLockMode.WriteOnly);

			// Get the graphics
			var gfx = RoomGfx.GetTilesets(rGfxPal);
			int hash = gfx.GetHashCode();

			// Get the tiles
			var tiles = RoomTiles.GetTiles(room);
			if (tiles == null) return null;

			// Get the map
			var map = new byte[3][];
			for (int i = 0; i < 3; i++)
				map[i] = RoomMap.GetMap(room, i);

			// Get the palette
			var pal = RoomPal.GetPalette(rGfxPal.Pal);
			bmp.CopyPalette(pal, true);

			// For each layer...
			for (int layer = 2; layer >= 0; layer--)
			{
				// Check if it's in the flags for rendering this layer
				if (((flags & (1 << layer)) != 0) && (map[layer] != null))
				{
					// Make sure the map is big enough: some of them aren't!
					if (map[layer].Length >= (w * h * 2))
					{
						// We're drawing it, so for each entry in the map...
						for (int mapy = 0; mapy < h; mapy++)
						{
							for (int mapx = 0; mapx < w; mapx++)
							{
								// Get the 16x16 tile number
								ushort ch = map[layer].ReadUShort((mapx + (mapy * w)) * 2);
								ushort tile16 = (ushort)(ch & 0x3FF);

								if ((tile16 >> 6) < 12)
								{
									int tpal = (ch >> 10) & 0xF;

									bool tflipx = (ch & 0x4000) != 0;
									bool tflipy = (ch & 0x8000) != 0;

									// For this tile... get the four 8x8 subtiles
									int[,] tile8 = new int[2, 2];
									bool[,] sflipx = new bool[2, 2];
									bool[,] sflipy = new bool[2, 2];

									uint magic = tiles.ReadUInt(tile16 * 8);

									tile8[0, 0] = tiles[(tile16 * 8) + 4];
									tile8[0, 1] = tiles[(tile16 * 8) + 5];
									tile8[1, 0] = tiles[(tile16 * 8) + 6];
									tile8[1, 1] = tiles[(tile16 * 8) + 7];

									for (int i = 0; i < 2; i++)
										for (int j = 0; j < 2; j++)
										{
											sflipx[i, j] = (tile8[i, j] & 0x40) != 0;
											sflipy[i, j] = (tile8[i, j] & 0x80) != 0;

											tile8[i, j] &= 0x3F;
											tile8[i, j] |= (ch & 0x3C0);
										}

									// magic appears to contain some sort of tile mask...
									uint mask = (magic >> 16) & 0xF;
									if ((mask & 0x1) == 0) tile8[0, 0] = -1;
									if ((mask & 0x2) == 0) tile8[0, 1] = -1;
									if ((mask & 0x4) == 0) tile8[1, 0] = -1;
									if ((mask & 0x8) == 0) tile8[1, 1] = -1;

									// For each of these subtiles...
									for (int tiley = 0; tiley < 2; tiley++)
									{
										for (int tilex = 0; tilex < 2; tilex++)
										{
											if (tile8[tiley, tilex] >= 0)
											{
												int tileset = tile8[tiley, tilex] >> 6;
												int subtile = tile8[tiley, tilex] & 0x3F;

												int tileoffset = subtile << 5;

												var pixels = gfx[tileset].Read4BppTile(tileoffset);

												int tx = tflipx ? 1 - tilex : tilex;
												int ty = tflipy ? 1 - tiley : tiley;

												GfxProvider.RenderToBitmap(bd, pixels,
													(mapx << 4) + (tx << 3),
													(mapy << 4) + (ty << 3),
													sflipx[tiley, tilex] ^ tflipx,
													sflipy[tiley, tilex] ^ tflipy,
													tpal, true);
											}
										}
									}
								}
							}
						}
					}
				}
			}

			// Draw the sprites
			/*if (drawsprites)
			{
				for (int i = 0; i < RoomSprites.Sprites[room + 1].Length; i++)
				{
					var rs = RoomSprites.Sprites[room + 1][i];
					if ((rs.Sprite == 0) || (rs.Sprite == 0xC0)) continue;

					var si = SpriteInfo.InfoEntries[0][rs.Sprite];
					var s = si.Sprites[rs.Direction % si.Sprites.Length];
					GfxProvider.RenderSprites(bd, rs.X, rs.Y, s.Sprites,
						Rom, SpriteGfx.GetPointer(0, rs.Sprite),
						SpritePalettes.GetPalette(rs.Sprite));
				}
			}*/

			bmp.UnlockBits(bd);
			return bmp;
		}
	}
}
