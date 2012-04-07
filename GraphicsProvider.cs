using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using Extensions;
using GBA;

namespace MOTHER3
{
    class GfxProvider
    {
        public static Dictionary<int, byte[,]> RomTileCache = new Dictionary<int, byte[,]>();

        public static MPalette DefaultPal = new MPalette();

        static GfxProvider()
        {
            Color[] c = new Color[16];
            for (int i = 0; i < 16; i++)
            {
                c[i] = Color.FromArgb(i << 4, i << 4, i << 4);
            }
            DefaultPal.Add(c);
        }

        public static byte[,] GetTile(int address, bool usecache)
        {
            if (usecache && RomTileCache.ContainsKey(address))
                return RomTileCache[address];
            else
            {
                byte[,] b = M3Rom.Rom.Read4BppTile(address);
                if (usecache && !RomTileCache.ContainsKey(address))
                    RomTileCache.Add(address, b);
                return b;
            }
        }

        unsafe public static void RenderToBitmap(BitmapData bd, byte[,] data, int destX, int destY,
            bool flipX, bool flipY, int palette, bool transparent)
        {
            byte* ptr = (byte*)bd.Scan0;
            palette <<= 4;
            for (int y = 0; y < 8; y++)
            {
                int offset = ((destY + y) * bd.Stride) + destX;
                int actualY = flipY ? (7 - y) : y;
                for (int x = 0; x < 8; x++)
                {
                    int actualX = flipX ? (7 - x) : x;

                    if (!(transparent && (data[actualX, actualY] == 0)))
                    {
                        ptr[offset] = (byte)(data[actualX, actualY] + palette);
                    }

                    offset++;
                }
            }
        }

        public static Bitmap RenderSprites(OamSprite[] oam, byte[] gfxData, MPalette palette)
        {
            return RenderSprites(oam, gfxData, 0, palette);
        }

        public static void RenderSprites(BitmapData canvas, int center_x, int center_y, OamSprite[] oam, byte[] gfxData, int gfxPointer, MPalette palette, bool transparent = true)
        {
            for (int priority = 3; priority >= 0; priority--)
            {
                for (int oamIndex = 0; oamIndex < oam.Length; oamIndex++)
                {
                    var o = oam[oamIndex];
                    if (o.Priority == priority)
                    {
                        // Draw the subsprite
                        int tilePointer = o.Tile << 5;
                        for (int y = 0; y < o.Height; y += 8)
                        {
                            int actualY = o.FlipV ? (o.Height - y - 8) : y;

                            for (int x = 0; x < o.Width; x += 8)
                            {
                                byte[,] pixelData = gfxData.Read4BppTile(gfxPointer + tilePointer);
                                tilePointer += 0x20;

                                int actualX = o.FlipH ? (o.Width - x - 8) : x;

                                GfxProvider.RenderToBitmap(canvas, pixelData,
                                    (o.CoordX + center_x) + actualX,
                                    (o.CoordY + center_y) + actualY,
                                    o.FlipH, o.FlipV,
                                    o.Palette, transparent);
                            }
                        }
                    }
                }
            }
        }

        public static Bitmap RenderSprites(OamSprite[] oam, byte[] gfxData, int gfxPointer, MPalette palette, bool transparent = true)
        {
            if (oam.Length < 1) return null;

            // Figure out the relative min/max for X/Y
            short minX = oam[0].CoordX;
            sbyte minY = oam[0].CoordY;
            int maxX = minX + oam[0].Width;
            int maxY = minY + oam[0].Height;
            for (int j = 1; j < oam.Length; j++)
            {
                var o = oam[j];

                if (o.CoordX < minX)
                    minX = o.CoordX;

                if (o.CoordY < minY)
                    minY = o.CoordY;

                if ((o.CoordX + o.Width) > maxX)
                    maxX = o.CoordX + o.Width;

                if ((o.CoordY + o.Height) > maxY)
                    maxY = o.CoordY + o.Height;
            }

            int width = maxX - minX;
            int height = maxY - minY;

            // Construct the bitmap
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            bmp.CopyPalette(palette, transparent);
            BitmapData bd = bmp.LockBits(ImageLockMode.WriteOnly);

            if (Helpers.IsLinux) Helpers.FillBitmap(bd);

            RenderSprites(bd, -minX, -minY, oam, gfxData, gfxPointer, palette, transparent);

            bmp.UnlockBits(bd);
            return bmp;
        }

        public static Bitmap RenderArrangement(ArrEntry[] arr, int tileWidth, int tileHeight,
            byte[] gfxData, int gfxDataOffset, MPalette palette, bool usecache, bool transparent)
        {
            // Construct the bitmap
            Bitmap bmp = new Bitmap(tileWidth << 3, tileHeight << 3, PixelFormat.Format8bppIndexed);
            
            // Create the palette
            bmp.CopyPalette(palette, transparent);

            // Lock and render
            BitmapData bd = bmp.LockBits(ImageLockMode.WriteOnly);
            RenderArrangement(bd, arr, tileWidth, tileHeight, gfxData, gfxDataOffset, usecache, transparent);
            bmp.UnlockBits(bd);
            return bmp;
        }

        public static void RenderArrangement(BitmapData bd, ArrEntry[] arr, int tileWidth, int tileHeight,
            byte[] gfxData, int gfxDataOffset, bool usecache, bool transparent)
        {
            // Mono on linux does some freaky stuff with uninitialized bitmaps, so let's fill it first if we need to
            if (Helpers.IsLinux) Helpers.FillBitmap(bd);

            int arrindex = 0;
            for (int y = 0; y < tileHeight; y++)
            {
                for (int x = 0; x < tileWidth; x++)
                {
                    var a = arr[arrindex++];
                    byte[,] pixels;
                    if (usecache)
                        pixels = GetTile(gfxDataOffset + (a.TileNumber << 5), true);
                    else
                        pixels = gfxData.Read4BppTile(gfxDataOffset + (a.TileNumber << 5));

                    int pnum = a.Palette;

                    RenderToBitmap(bd, pixels, x << 3, y << 3, a.FlipH, a.FlipV, pnum, transparent);
                }
            }
        }

        unsafe public static byte[,] SetTile(BitmapData bd, int srcX, int srcY, Color[] palette)
        {
            int bytesPerPixel = bd.PixelFormat.NumBits() >> 3;

            byte* ptr = (byte*)bd.Scan0;
            byte[,] pixels = new byte[8, 8];

            // Get the pixel offset
            int offset = (srcY << 3) * bd.Stride;
            offset += (srcX << 3) * bytesPerPixel;

            for (int py = 0; py < 8; py++)
            {
                for (int px = 0; px < 8; px++)
                {
                    byte b = ptr[offset++];
                    byte g = ptr[offset++];
                    byte r = ptr[offset++];
                    byte a = 0xFF;
                    if (bytesPerPixel == 4) a = ptr[offset++];

                    // Find the closest palette value
                    double minDistance = DistanceSquared(r, g, b, palette[0]);
                    byte minIndex = 0;
                    for (byte i = 1; i < 16; i++)
                    {
                        double distance = DistanceSquared(r, g, b, palette[i]);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            minIndex = i;
                        }
                    }

                    pixels[px, py] = minIndex;
                }

                offset += bd.Stride;
                offset -= bytesPerPixel * 8;
            }

            return pixels;
        }

        // Returns the arrangement, palette, and a flag indicating whether or not colors were dropped
        unsafe public static object[] SetArrangement(Bitmap _bmp,
            byte[] gfxData, int gfxDataOffset, int tileCount, 
            bool useTileset, bool useFlipping,
            Color[] _pal, int palIndex,
            Color transparentColor, bool transparency
            )
        {
            // Convert to Format32bppArgb
            Bitmap bmp;
            if (_bmp.PixelFormat == PixelFormat.Format32bppArgb)
                bmp = _bmp;
            else
            {
                bmp = new Bitmap(_bmp.Width, _bmp.Height, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(_bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                }
                _bmp.Dispose();
            }

            int tilewidth = bmp.Width >> 3;
            int tileheight = bmp.Height >> 3;

            BitmapData bd = bmp.LockBits(ImageLockMode.ReadOnly);
            byte* ptr = (byte*)bd.Scan0;

            // First we need to make a palette
            Color[] pal;
            List<ColorCountPair> colorlist = new List<ColorCountPair>();
            int pcount = transparency ? 16 : 15;

            if (_pal == null)
            {
                // No reference palette given, so let's build one from the image
                pal = new Color[16];

                if (transparency)
                    pal[0] = transparentColor;
                else
                    pal[0] = Color.FromArgb(160, 160, 160);

                // Find the most common colors
                for (int y = 0; y < bd.Height; y++)
                {
                    int offset = bd.Stride * y;
                    for (int x = 0; x < bd.Width; x++)
                    {
                        int b = ptr[offset++] & 0xF8;
                        int g = ptr[offset++] & 0xF8;
                        int r = ptr[offset++] & 0xF8;
                        offset++;

                        Color c = Color.FromArgb(r, g, b);
                        bool hascolor = colorlist.Any(cp => cp.col.Equals(c));

                        if (!hascolor)
                        {
                            // This is a new color so add it to the list
                            colorlist.Add(new ColorCountPair(c));
                        }
                        else
                        {
                            // The color is already in the list, so grab a reference to it and increment its counter
                            var ccp = colorlist.First(cp => cp.col.Equals(c));
                            ccp.count++;
                        }
                    }
                }

                // If we hit the transparent color, remove it
                if (transparency && colorlist.Any(cp => cp.col.Equals(transparentColor)))
                    colorlist.Remove(colorlist.First(cp => cp.col.Equals(transparentColor)));

                // Sort the list by its .count fields
                colorlist.Sort();

                // Copy the top 15 into the palette
                for (int i = 0; i < Math.Min(15, colorlist.Count); i++)
                    pal[i + 1] = colorlist[i].col;

                // If we're under 15 colors, just make the rest black
                for (int i = Math.Min(15, colorlist.Count) + 1; i < 16; i++)
                    pal[i] = Color.Black;
            }
            else
            {
                pal = _pal;
            }

            // Create an arrangement
            ArrEntry[] arr = new ArrEntry[tileheight * tilewidth];

            // Start a list for our tile cache
            List<TileHashPair> tilecache = new List<TileHashPair>();

            useFlipping |= useTileset;

            // If we're using the current tileset, then populate the cache
            if (useTileset)
            {
                for (ushort i = 0; i < tileCount; i++)
                {
                    var pixels = gfxData.Read4BppTile(i << 5);
                    tilecache.Add(new TileHashPair(pixels, HashPixels(pixels, false, false), i));
                }
            }

            // Scan each tile
            for (int ty = 0; ty < tileheight; ty++)
            {
                for (int tx = 0; tx < tilewidth; tx++)
                {
                    ArrEntry a = new ArrEntry();
                    a.Palette = (byte)palIndex;

                    var pixels = SetTile(bd, tx, ty, pal);

                    // Hash this tile
                    uint[] hashes = {
                                        HashPixels(pixels, false, false),
                                        useFlipping ? HashPixels(pixels, true, false) : 0,
                                        useFlipping ? HashPixels(pixels, false, true) : 0,
                                        useFlipping ? HashPixels(pixels, true, true) : 0
                                    };

                    // See if we already have some version of it
                    bool hashmatch = tilecache.Any(th => th.HashMatch(hashes, useFlipping));

                    if (!useTileset && !hashmatch)
                    {
                        // We don't have it, so add it
                        var t = new TileHashPair(pixels, hashes[0], (ushort)tilecache.Count);
                        tilecache.Add(t);

                        a.TileNumber = t.tilenum;
                        a.FlipH = false;
                        a.FlipV = false;
                    }
                    else if (useTileset && !hashmatch)
                    {
                        throw new TileMismatchException("Tile has no match!", tx, ty);
                    }
                    else
                    {
                        // We do have it, so use it
                        var t = tilecache.First(th => th.HashMatch(hashes, useFlipping));
                        var hashflip = t.HashFlip(hashes);

                        a.TileNumber = t.tilenum;
                        a.FlipH = hashflip[0];
                        a.FlipV = hashflip[1];
                    }

                    arr[tx + (ty * tilewidth)] = a;
                }
            }

            bmp.UnlockBits(bd);

            // See if we've got too many tiles
            if (tilecache.Count > tileCount)
            {
                throw new TileCountException("Too many tiles!", tilecache.Count, tileCount);
            }

            // Write the tiles to the tileset
            if (!useTileset)
            {
                for (int i = 0; i < tilecache.Count; i++)
                {
                    var pixels = tilecache[i].pixels;
                    gfxData.Write4BppTile(i << 5, pixels);
                }
            }

            return new object[] { arr, pal, Math.Max(colorlist.Count - (transparency ? 16 : 15), 0) };
        }

        private static int DistanceSquared(Color c1, Color c2)
        {
            int rr = c1.R - c2.R;
            rr *= rr;

            int gg = c1.G - c2.G;
            gg *= gg;

            int bb = c1.B - c2.B;
            bb *= bb;

            return rr + gg + bb;
        }

        private static double DistanceSquared(byte r, byte g, byte b, Color c)
        {
            return DistanceSquared(Color.FromArgb(r, g, b), c);
        }

        private class ColorCountPair : IComparable<ColorCountPair>, IEquatable<ColorCountPair>
        {
            public Color col;
            public int count;

            public ColorCountPair(Color c)
            {
                this.col = c;
                this.count = 1;
            }

            public int CompareTo(ColorCountPair ccp)
            {
                // Negative because we want to sort from highest to lowest
                return -this.count.CompareTo(ccp.count);
            }

            public bool Equals(ColorCountPair ccp)
            {
                return this.col.Equals(ccp.col);
            }
        }

        private class TileHashPair
        {
            public byte[,] pixels;
            public uint hash;
            public ushort tilenum;

            public TileHashPair(byte[,] p, uint h, ushort tnum)
            {
                this.pixels = p;
                this.hash = h;
                this.tilenum = tnum;
            }

            public bool HashMatch(uint[] hashes, bool useFlipping)
            {
                for (int i = 0; i < (useFlipping ? 4 : 1); i++)
                    if (hashes[i] == hash) return true;
                return false;
            }

            public bool[] HashFlip(uint[] hashes)
            {
                for (int i = 0; i < 4; i++)
                    if (hashes[i] == hash) return new bool[] { (i & 1) == 1, (i & 2) == 2 };
                return null;
            }
        }

        private static uint HashPixels(byte[,] pixels, bool fliph, bool flipv)
        {
            uint crc = 0xFFFFFFFF;
            uint sum = 0;

            int xpos = fliph ? 7 : 0;
            int xstart = xpos;
            int xinc = fliph ? -1 : 1;

            int ypos = flipv ? 7 : 0;
            int yinc = flipv ? -1 : 1;

            for (int yct = 0; yct < 8; yct++)
            {
                xpos = xstart;
                for (int xct = 0; xct < 8; xct++)
                {
                    byte val = pixels[xpos, ypos];
                    sum += val;
                    xpos += xinc;

                    crc = Helpers.UpdateCrc32(val, crc);
                }
                ypos += yinc;
            }

            return crc;
        }
    }

    public class TileCountException : Exception
    {
        public int Tilecount;
        public int Tilelimit;

        public TileCountException(string message, int tcount, int tlimit) : base(message)
        {
            this.Tilecount = tcount;
            this.Tilelimit = tlimit;
        }
    }

    public class TileMismatchException : Exception
    {
        public int TileX;
        public int TileY;

        public TileMismatchException(string message, int tx, int ty)
            : base(message)
        {
            this.TileX = tx;
            this.TileY = ty;
        }
    }

    // Enemy sprites:
    // Entry = enemy num + 8
    // Address ends up pointing to "ccg " block; Gfx are at address+12

    // Enemy palette:
    // Entry = enemy num + 0x179
    // Address points directly to palette

    // Sprite arrangement:
    // Entry = enemy num + 0x2A4
    // Address points to "sob " block: each block has both a front and back sprite!
    //        Address + 0x08: offset to front-sprite OAM data
    //        Address + 0x0A: offset to back-sprite OAM data
    // Each front/backsprite OAM data has a 4-byte header:
    //        Byte 2/3: # of subsprites
    // After that is the actual OAM data (documented in gbatek)

    class GfxBattleSprites : M3Rom
    {
        public static int Address = 0x1C90960;
        public static int Entries = -1;

        public static void Init()
        {
            Entries = Rom.ReadInt(Address + 4);
        }

        private static int GetPointer(int index)
        {
            int a = Rom.ReadInt(Address + 8 + (index << 3));
            return Address + a;
        }

        public static MPalette GetPals(int index)
        {
            int palPointer = GetPointer(index + 0x179);
            var palette = Rom.ReadPal(palPointer);
            return palette;
        }

        unsafe public static Bitmap[] GetEnemySprite(int index)
        {
            Bitmap[] ret = new Bitmap[2];

            // Get gfx stuff
            int gfxPointer = GetPointer(index + 8) + 12;
            byte[] gfxData;
            if (LZ77.Decompress(Rom, gfxPointer, out gfxData) == -1) return null;

            // Bug with MOTHER 3: for the second Mole Cricket (index 0x3D),
            // it uses tiles that are out of bounds in the tile data!
            // So let's resize the tile buffer to 32KB (max addressable size)
            Array.Resize(ref gfxData, 0x8000);

            // Get pal stuff
            var palette = GetPals(index);

            // Get OAM stuff
            int oamPointer = GetPointer(index + 0x2A4);
            var oam = new OamSprite[2][];
            for (int i = 0; i < 2; i++)
            {
                // Get the front/back sprite pointer
                int subPointer = Rom.ReadUShort(oamPointer + 8 + (i << 1)) + oamPointer;

                // Get the number of sub-sprites
                ushort numSubSprites = Rom.ReadUShort(subPointer + 2);
                oam[i] = new OamSprite[numSubSprites];

                // Get the OAM data
                for (int j = 0; j < numSubSprites; j++)
                {
                    oam[i][j] = Rom.ReadOam(subPointer + 4 + (j << 3));

                    // Filter out the palette -- each enemy only has one palette, regardless of what the OAM entry says
                    // This is only an issue with enemy #0 anyway
                    oam[i][j].Palette = 0;
                }

                // Render the sprites
                Bitmap bmp = GfxProvider.RenderSprites(oam[i], gfxData, palette);
                ret[i] = bmp;
            }

            return ret;
        }
    }

    public class GfxItems : M3Rom
    {
        public static int Address = -1;

        public static void Init()
        {
            Address = Rom.ReadInt(0x1439388) + 0x14383E4;
        }

        public static Bitmap GetImage(int index)
        {
            // All item images are stored nice and linearly
            // Each item image is 3x3 tiles
            int tileAddress = Address + ((index * 9) << 5);
            var palette = Rom.ReadPal(GetPaletteAddress(index));

            Bitmap ret = new Bitmap(24, 24, PixelFormat.Format8bppIndexed);

            ColorPalette cp = ret.Palette;
            for (int i = 0; i < 16; i++)
                cp.Entries[i] = palette.Entries[0][i];
            ret.Palette = cp;

            BitmapData bd = ret.LockBits(ImageLockMode.WriteOnly);

            if (Helpers.IsLinux) Helpers.FillBitmap(bd);

            for (int y = 0; y < 24; y += 8)
            {
                for (int x = 0; x < 24; x += 8)
                {
                    byte[,] ch = Rom.Read4BppTile(tileAddress);
                    tileAddress += 0x20;

                    GfxProvider.RenderToBitmap(bd, ch, x, y, false, false, 0, true);
                }
            }

            ret.UnlockBits(bd);
            return ret;
        }

        public static int GetPaletteAddress(int index)
        {
            // Hack -- custom palette for the memory bell
            if ((Version == RomVersion.English) && (index == 0x90))
                return 0x1FABFE0;

            index += 0x2D0;
            index *= 12;

            int address = Rom.ReadInt(0x1433D80) + 0x1433D7C + index;
            int address2 = Rom.ReadInt(0x1A4154C) + 0x1A41548;

            address2 += ((Rom[address + 1] & 0xF) << 5);

            return address2;
        }
    }

    public class GfxBattleTable : M3Rom
    {
        public static int Address = 0x1E45C1C;
        public static int Entries = -1;

        public static void Init()
        {
            Entries = Rom.ReadInt(Address + 4);
        }

        public static int[] GetEntry(int index)
        {
            // Returns an array with the pointer and the length
            int a = Address + 8 + (index << 3);
            return new int[] { Rom.ReadInt(a) + Address, Rom.ReadInt(a + 4) };
        }

        public static ArrEntry[] GetArr(int index)
        {
            int[] entry = GetEntry(index);
            byte[] bytes;
            int res = LZ77.Decompress(Rom, entry[0] + 12, out bytes);
            if (res == -1) return null;
            if (bytes.Length != 2048) return null;

            ArrEntry[] ret = new ArrEntry[1024];
            for (int i = 0; i < 1024; i++)
                ret[i] = bytes.ReadArrEntry(i << 1);

            return ret;
        }

        public static MPalette GetPalettes(int index)
        {
            int[] entry = GetEntry(index);
            var pal = Rom.ReadPals(entry[1] >> 5, entry[0]);
            return pal;
        }
    }

    public class GfxBattleAnimations : M3Rom
    {
        public static int Address = 0x1E40158;
        public static int Entries = 0x52;
        public static int[] Pointers = new int[Entries];
        public static GfxBattleAnimations[] AnimEntries = new GfxBattleAnimations[Entries];

        public int index;
        public int Length;
        public ushort[] ArrEntries;
        public ushort[] Frames;
        public ushort GfxEntry;
        public ushort PalEntry;

        public static void Init()
        {
            // Time to traverse a linked list
            Pointers[0] = Address + 0x10;
            for (int i = 1; i < Entries; i++)
            {
                int b = Rom.ReadInt(Pointers[i - 1] + 4);
                Pointers[i] = Pointers[i - 1] + ((b + 2) << 2);
            }

            // Load the data
            for (int i = 0; i < Entries; i++)
            {
                var pd = new GfxBattleAnimations();

                Rom.Seek(Pointers[i]);
                if (i == 69)
                {
                }
                pd.index = i;

                pd.GfxEntry = Rom.ReadUShort();
                pd.PalEntry = Rom.ReadUShort();
                pd.Length = Rom.ReadInt();

                pd.ArrEntries = new ushort[pd.Length];
                pd.Frames = new ushort[pd.Length];

                for (int j = 0; j < pd.Length; j++)
                {
                    pd.ArrEntries[j] = Rom.ReadUShort();
                    pd.Frames[j] = Rom.ReadUShort();
                }

                AnimEntries[i] = pd;
            }
        }

        public static int GetPointer(int index)
        {
            int address = 0x1E41668;
            int num = 0x5;

            for (int i = 0; i < num; i++)
            {
                int tmp = address + 0x10;
                ushort ch = Rom.ReadUShort(address + 0xA);

                if (ch != 0)
                {
                    do
                    {
                        tmp += Rom.ReadUShort(tmp);
                        ch--;
                    } while (ch != 0);
                }

                address = ((tmp - address) & 0xFFFF) + address;
            }

            return address;
        }

        public static Bitmap GetFrame(int index, int frame)
        {
            var pd = GfxBattleAnimations.AnimEntries[index];

            // Get the gfx pointer
            var gfxEntry = GfxBattleTable.GetEntry(pd.GfxEntry);

            // Get the arrangement
            var arr = GfxBattleTable.GetArr(pd.ArrEntries[frame]);

            // Get the palette
            var pal = GfxBattleTable.GetPalettes(pd.PalEntry);

            // Render
            return GfxProvider.RenderArrangement(arr, 32, 32, Rom, gfxEntry[0], pal, true, false);
        }
    }

    public class GfxBattleBg : M3Rom
    {
        public class MasterEntry
        {
            // Master entry format:
            // 0-1: Layer 1
            // 2-3: Layer 2
            // 4-5: Layer 1 alpha (0-0x10)
            // 6-7: Layer 2 alpha (0-0x10)
            // 8-B: ? (almost always 17 00 8C 00)

            public int index;
            public ushort[] Layer = new ushort[2];
            public ushort[] Alpha = new ushort[2];

            public void Save()
            {
                Rom.Seek(Address + 4 + (Entries * 0x90) + (index * 0xC));
                Rom.WriteUShort(Layer[0]);
                Rom.WriteUShort(Layer[1]);
                Rom.WriteUShort(Alpha[0]);
                Rom.WriteUShort(Alpha[1]);
                M3Rom.IsModified = true;
            }
        }

        public static int Address = 0x1D0BC9C;
        public static ushort Entries;
        public static ushort MasterEntries;
        public static GfxBattleBg[] Bgs;
        public static MasterEntry[] Masters;

        public int index;
        public ushort GfxEntry;
        public ushort ArrEntry;
        public MPalette Palette;
        public ushort PalDir;
        public ushort PalStart;
        public ushort PalEnd;
        public ushort PalDelay;

        // x_offset = (DriftH * t / 0x100) + AmplH * sin(2pi * WavenumH * ( [FreqH * t / 0x10000] + [y / 0x100] ))
        // y_offset = (DriftV * t / 0x100) + AmplV * sin(2pi * WavenumV * ( [FreqV * t / 0x10000] + [y / 0x100] ))

        public short DriftH;
        public short DriftV;
        public short AmplH;
        public short AmplV;
        public short WavenumH;
        public short WavenumV;
        public short FreqH;
        public short FreqV;

        public static void Init()
        {
            Rom.Seek(Address);
            Entries = Rom.ReadUShort();
            MasterEntries = Rom.ReadUShort();

            Bgs = new GfxBattleBg[Entries];
            Masters = new MasterEntry[MasterEntries];

            for (int i = 0; i < Entries; i++)
            {
                var bg = new GfxBattleBg();
                bg.index = i;
                bg.GfxEntry = Rom.ReadUShort();
                bg.ArrEntry = Rom.ReadUShort();
                bg.Palette = Rom.ReadPals(2);
                bg.PalDir = Rom.ReadUShort();

                Rom.SeekAdd(2);

                bg.PalStart = Rom.ReadUShort();
                bg.PalEnd = Rom.ReadUShort();
                bg.PalDelay = Rom.ReadUShort();

                Rom.SeekAdd(0x26);

                bg.DriftH = Rom.ReadShort();
                bg.DriftV = Rom.ReadShort();

                Rom.SeekAdd(4);

                bg.AmplH = Rom.ReadShort();
                bg.AmplV = Rom.ReadShort();
                bg.WavenumH = Rom.ReadShort();
                bg.WavenumV = Rom.ReadShort();
                bg.FreqH = Rom.ReadShort();
                bg.FreqV = Rom.ReadShort();

                Rom.SeekAdd(8);

                Bgs[i] = bg;
            }

            for (int i = 0; i < MasterEntries; i++)
            {
                Masters[i] = new MasterEntry();
                Masters[i].index = i;
                Masters[i].Layer[0] = Rom.ReadUShort();
                Masters[i].Layer[1] = Rom.ReadUShort();
                Masters[i].Alpha[0] = Rom.ReadUShort();
                Masters[i].Alpha[1] = Rom.ReadUShort();
                Rom.SeekAdd(4);
            }
        }

        public static void RotatePal(MPalette pal, GfxBattleBg bg)
        {
            if (bg.PalDir == 2)
            {
                // Forward
                Color tmp = pal.GetColorAt(bg.PalEnd);
                for (int j = bg.PalEnd; j > bg.PalStart; j--)
                    pal.SetColorAt(j, pal.GetColorAt(j - 1));
                pal.SetColorAt(bg.PalStart, tmp);
            }

            else
            {
                // Backward
                Color tmp = pal.GetColorAt(bg.PalStart);
                for (int j = bg.PalStart; j < bg.PalEnd; j++)
                    pal.SetColorAt(j, pal.GetColorAt(j + 1));
                pal.SetColorAt(bg.PalEnd, tmp);
            }
        }

        public static void UpdatePal(MPalette pal, GfxBattleBg bg, int t)
        {
            // Rotate pal to the t'th frame
            if ((t > 0) && (bg.PalDelay > 0))
            {
                t = t % (((bg.PalEnd - bg.PalStart) + 1) * bg.PalDelay);
                for (int i = bg.PalDelay; i < t; i += bg.PalDelay)
                {
                    RotatePal(pal, bg);
                }
            }
        }

        public static void GetLayer(Bitmap bmp, BitmapData bd, int index, int t = 0)
        {
            var bg = Bgs[index];
            var arr = GfxBattleBgTable.GetArr(bg.ArrEntry);
            var tmpPal = (MPalette)bg.Palette.Clone();

            // Rotate the palette
            UpdatePal(tmpPal, bg, t);

            for (int i = 0; i < arr.Length; i++)
                arr[i].Palette &= 1;

            // Set the palette
            bmp.CopyPalette(tmpPal, false);

            int gfxPointer = GfxBattleBgTable.GetEntry(bg.GfxEntry)[0];

            GfxProvider.RenderArrangement(bd, arr, 32, 32, Rom, gfxPointer, true, false);
        }

        public static Bitmap GetLayer(int index, int t = 0)
        {
            Bitmap ret = new Bitmap(256, 256, PixelFormat.Format8bppIndexed);
            if (index == 0) return ret;

            BitmapData bd = ret.LockBits(ImageLockMode.WriteOnly);

            GetLayer(ret, bd, index, t);

            ret.UnlockBits(bd);
            return ret;
        }

        public static Bitmap GetBg(int index, int layer)
        {
            int l = Masters[index].Layer[layer];
            return GetLayer(l);
        }

        public void Save()
        {
            Rom.Seek(Address + 4 + (this.index * 0x90));

            Rom.WriteUShort(this.GfxEntry);
            Rom.WriteUShort(this.ArrEntry);
            Rom.WritePal(this.Palette);
            Rom.WriteUShort(this.PalDir);

            Rom.SeekAdd(2);

            Rom.WriteUShort(this.PalStart);
            Rom.WriteUShort(this.PalEnd);
            Rom.WriteUShort(this.PalDelay);

            Rom.SeekAdd(0x26);

            Rom.WriteShort(this.DriftH);
            Rom.WriteShort(this.DriftV);

            Rom.SeekAdd(4);

            Rom.WriteShort(this.AmplH);
            Rom.WriteShort(this.AmplV);
            Rom.WriteShort(this.WavenumH);
            Rom.WriteShort(this.WavenumV);
            Rom.WriteShort(this.FreqH);
            Rom.WriteShort(this.FreqV);

            M3Rom.IsModified = true;
        }
    }

    public class GfxBattleBgTable : M3Rom
    {
        public static int Address = 0x1D1FB28;
        public static int Entries = -1;

        public static void Init()
        {
            Entries = Rom.ReadInt(Address + 4) >> 1;
        }

        public static int[] GetEntry(int index)
        {
            Rom.Seek(Address + 8 + (index << 3));
            return new int[] { Rom.ReadInt() + Address, Rom.ReadInt() };
        }

        public static ArrEntry[] GetArr(int index)
        {
            var entry = GetEntry(index);
            var ret = new ArrEntry[1024];
            for (int i = 0; i < 1024; i++)
                ret[i] = Rom.ReadArrEntry(entry[0] + (i << 1));
            return ret;
        }

        public static void SetArr(int index, ArrEntry[] arr)
        {
            var entry = GetEntry(index);
            if (arr.Length != (entry[1] >> 1))
                throw new Exception("Arrangement length is wrong!");

            for (int i = 0; i < arr.Length; i++)
                Rom.WriteArrEntry(entry[0] + (i << 1), arr[i]);
        }
    }

    public class GfxBattleSwirls : M3Rom
    {
        public static int Address = 0x1B0CA54;
        public static int Length = 4;
        public static int Entries = -1;

        public static int SequenceAddress = 0xC2A90;
        public static int SequenceEntries = 3;
        public static GfxBattleSwirls[] Sequences = new GfxBattleSwirls[SequenceEntries];

        public static MPalette[] Palettes = new MPalette[3];

        public int index;
        public byte GfxEntry;
        public byte PalEntry;
        public byte ArrStart;
        public byte ArrLen;
        public byte[] Lengths = new Byte[30];

        public static void Init()
        {
            Entries = Rom.ReadInt(Address);

            Rom.Seek(SequenceAddress);
            for (int i = 0; i < SequenceEntries; i++)
            {
                var s = new GfxBattleSwirls();
                s.index = i;

                s.GfxEntry = Rom.ReadByte();
                s.PalEntry = Rom.ReadByte();
                s.ArrStart = Rom.ReadByte();
                s.ArrLen = Rom.ReadByte();

                Sequences[i] = s;
            }

            for (int i = 0; i < SequenceEntries; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Sequences[i].Lengths[j] = Rom.ReadByte();
                }
            }

            // Read the palettes
            int[] palEntry = GetEntry(0);
            Rom.Seek(palEntry[0]);
            for (int i = 0; i < Palettes.Length; i++)
                Palettes[i] = Rom.ReadPals(1);
        }

        public static int[] GetEntry(int index)
        {
            int a = Rom.ReadInt(Address + 4 + (index << 2));
            int b = Rom.ReadInt(Address + 8 + (index << 2));

            if (a == 0) return null;

            return new int[] { Address + a, b - a };
        }

        public static ArrEntry[] GetArr(int index)
        {
            int[] arrEntry = GetEntry(index);

            // Read the arrangement
            var ret = new ArrEntry[30 * 20];
            Rom.Seek(arrEntry[0]);
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    byte ch = Rom.ReadByte();
                    var a = new ArrEntry();
                    a.TileNumber = (ushort)(ch & 0x3F);
                    a.FlipH = (ch & 0x40) != 0;
                    a.FlipV = (ch & 0x80) != 0;
                    a.Palette = 0;
                    ret[x + (y * 30)] = a;
                }
            }

            return ret;
        }

        public static void SetArr(int index, ArrEntry[] arr)
        {
            int[] arrEntry = GetEntry(index);
            Rom.Seek(arrEntry[0]);
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    var a = arr[x + (y * 30)];
                    byte ch = (byte)(
                        (a.TileNumber & 0x3F) |
                        (a.FlipH ? 0x40 : 0) |
                        (a.FlipV ? 0x80 : 0));
                    Rom.WriteByte(ch);
                }
            }
        }

        public static void GetFrame(BitmapData bd, int index, int frame, int pal)
        {
            var s = Sequences[index];
            if (frame >= s.ArrLen) throw new Exception("Frame number exceeded max value!");

            int[] gfxEntry = GetEntry(s.GfxEntry);
            int[] palEntry = GetEntry(s.PalEntry);

            // Get the palette
            var palette = Palettes[pal];

            // Read the arrangement
            var arr = GetArr(s.ArrStart + frame);

            GfxProvider.RenderArrangement(bd, arr, 30, 20, Rom, gfxEntry[0], false, false);
        }

        public static Bitmap GetFrame(int index, int frame, int pal)
        {
            Bitmap ret = new Bitmap(30 * 8, 20 * 8, PixelFormat.Format8bppIndexed);
            BitmapData bd = ret.LockBits(ImageLockMode.WriteOnly);
            GetFrame(index, frame, pal);
            ret.UnlockBits(bd);
            return ret;
        }

        public void Save()
        {
            Rom.Seek(SequenceAddress + (Length * this.index));

            Rom.WriteByte(this.GfxEntry);
            Rom.WriteByte(this.PalEntry);
            Rom.WriteByte(this.ArrStart);
            Rom.WriteByte(this.ArrLen);

            Rom.Seek(SequenceAddress + 12 + (30 * this.index));
            for (int i = 0; i < 30; i++)
                Rom.WriteByte(this.Lengths[i]);

            M3Rom.IsModified = true;
        }
    }

    public class GfxTownMaps : M3Rom
    {
        public static int Address = 0x1B18308;
        public static int Entries = -1;

        public static void Init()
        {
            Entries = Rom.ReadInt(Address);
        }

        public static int[] GetEntry(int index)
        {
            int a = Rom.ReadInt(Address + 4 + (index << 2));
            int b = Rom.ReadInt(Address + 8 + (index << 2));

            if (a == 0) return null;

            return new int[] { Address + a, b - a };
        }

        public static ArrEntry[] GetArr(int index)
        {
            ArrEntry[] ret = new ArrEntry[64 * 64];
            
            int[] arrEntry = GetEntry(index);
            if (arrEntry[1] != (ret.Length << 1))
                return null;
            
            Rom.Seek(arrEntry[0]);
            for (int sy = 0; sy < 2; sy++)
                for (int sx = 0; sx < 2; sx++)
                    for (int ay = 0; ay < 32; ay++)
                        for (int ax = 0; ax < 32; ax++)
                            ret[ax + (sx * 32) + (ay * 64) + (sy * 2048)] = Rom.ReadArrEntry();

            return ret;
        }

        public static void SetArr(int index, ArrEntry[] arr)
        {
            int[] arrEntry = GetEntry(index);
            if (arrEntry[1] != (arr.Length << 1))
                return;

            Rom.Seek(arrEntry[0]);
            for (int sy = 0; sy < 2; sy++)
                for (int sx = 0; sx < 2; sx++)
                    for (int ay = 0; ay < 32; ay++)
                        for (int ax = 0; ax < 32; ax++)
                            Rom.WriteArrEntry(arr[ax + (sx * 32) + (ay * 64) + (sy * 2048)]);
        }

        public static MPalette GetPalette(int index)
        {
            int[] palEntry = GetEntry(index);
            return Rom.ReadPals(palEntry[1] >> 5, palEntry[0]);
        }
    }

    public class OamSprite : ICloneable
    {
        // 0 => 7:0
        public sbyte CoordY = 0;

        // 0 => 8
        public bool RotScale = false;

        // 0 => 9
        public bool DblSizeDisable = false;

        // 0 => 11:10
        public byte ObjMode = 0;

        // 0 => 12
        public bool ObjMosaic = false;

        // 0 => 13
        public bool Use8Bpp = false;

        // 0 => 15:14
        public byte ObjShape = 0;

        // 1 => 8:0
        public short CoordX = 0;

        // 1 => 13:9 (if RotScale == true)
        public ushort RotScaleParam = 0;

        // 1 => 12 (if RotScale == false)
        public bool FlipH = false;

        // 1 => 13 (if RotScale == false)
        public bool FlipV = false;

        // 1 => 15:14
        public byte ObjSize = 0;

        // 2 => 9:0
        public ushort Tile = 0;

        // 2 => 11:10 (priority of 0 is the highest/topmost)
        public byte Priority = 0;

        // 2 => 15:12
        public byte Palette = 0;

        private static byte[,] Widths = { { 8, 16, 32, 64 }, { 16, 32, 32, 64 }, { 8, 8, 16, 32 } };
        private static byte[,] Heights = { { 8, 16, 32, 64 }, { 8, 8, 16, 32 }, { 16, 32, 32, 64 } };

        /// <summary>
        /// Gets the width in pixels.
        /// </summary>
        public byte Width
        {
            get
            {
                return Widths[this.ObjShape, this.ObjSize];
            }
        }

        /// <summary>
        /// Gets the height in pixels.
        /// </summary>
        public byte Height
        {
            get
            {
                return Heights[this.ObjShape, this.ObjSize];
            }
        }

        public object Clone()
        {
            var ret = new OamSprite();
            ret.CoordX = this.CoordX;
            ret.CoordY = this.CoordY;
            ret.DblSizeDisable = this.DblSizeDisable;
            ret.FlipH = this.FlipH;
            ret.FlipV = this.FlipV;
            ret.ObjMode = this.ObjMode;
            ret.ObjMosaic = this.ObjMosaic;
            ret.ObjShape = this.ObjShape;
            ret.ObjSize = this.ObjSize;
            ret.Palette = this.Palette;
            ret.Priority = this.Priority;
            ret.RotScale = this.RotScale;
            ret.RotScaleParam = this.RotScaleParam;
            ret.Tile = this.Tile;
            ret.Use8Bpp = this.Use8Bpp;
            return ret;
        }
    }

    public class ArrEntry : ICloneable
    {
        // 9:0
        public ushort TileNumber;

        // 10
        public bool FlipH;

        // 11
        public bool FlipV;

        // 15:12
        public byte Palette;

        public object Clone()
        {
            ArrEntry ret = new ArrEntry();
            ret.TileNumber = this.TileNumber;
            ret.FlipH = this.FlipH;
            ret.FlipV = this.FlipV;
            ret.Palette = this.Palette;
            return ret;
        }
    }
}
