using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using MOTHER3;
using MOTHER3Funland;

namespace Extensions
{
    public static class DataOps
    {
        public static int Offset = 0;
        
        public static void Seek(this byte[] rom, int offset)
        {
            Offset = offset;
        }
        
        public static void SeekAdd(this byte[] rom, int offset)
        {
            Offset += offset;
        }

        public static byte DecodeByte(this byte[] rom, int offset, bool obfuscated)
        {
            byte ch = rom[offset];
            if (!obfuscated) return ch;

            if ((offset & 1) == 0)
            {
                // Even
                ch -= 7;
                byte ch2 = rom[0x1FAC000 + (((offset | 0x8000000) >> 1) % 0x3A20)];
                ch ^= ch2;
                ch += 3;
            }
            else
            {
                // Odd
                ch += 89;
                byte ch2 = rom[M3Rom.DecodeAddress + (((offset | 0x8000000) >> 1) % M3Rom.DecodeMod)];
                ch ^= ch2;
                ch -= 8;
            }
            return ch;
        }

        public static ushort DecodeUShort(this byte[] rom, int offset, bool obfuscated)
        {
            return (ushort)(DecodeByte(rom, offset, obfuscated) + (DecodeByte(rom, offset + 1, obfuscated) << 8));
        }

        public static byte ReadByte(this byte[] rom)
        {
            return rom[Offset++];
        }

        public static byte[] ReadBytes(this byte[] rom, int length)
        {
            byte[] ret = new byte[length];
            Array.Copy(rom, Offset, ret, 0, length);
            Offset += length;
            return ret;
        }

        public static void WriteByte(this byte[] rom, byte data)
        {
            rom[Offset++] = data;
        }

        public static sbyte ReadSByte(this byte[] rom)
        {
            return (sbyte)ReadByte(rom);
        }

        public static void WriteSByte(this byte[] rom, sbyte data)
        {
            WriteByte(rom, (byte)data);
        }

        public static short ReadShort(this byte[] rom)
        {
            short ret = ReadShort (rom, Offset);
            Offset += 2;
            return ret;
        }
        
        public static short ReadShort(this byte[] rom, int offset)
        {
            return (short)(rom[offset] | (rom[offset + 1] << 8));
        }

        public static void WriteShort(this byte[] rom, short data)
        {
            WriteShort(rom, Offset, data);
            Offset += 2;
        }

        public static void WriteShort(this byte[] rom, int offset, short data)
        {
            rom[offset] = (byte)(data & 0xFF);
            rom[offset + 1] = (byte)((data >> 8) & 0xFF);
        }

        public static ushort ReadUShort(this byte[] rom)
        {
            ushort ret = ReadUShort (rom, Offset);
            Offset += 2;
            return ret;
        }
        
        public static ushort ReadUShort(this byte[] rom, int offset)
        {
            return (ushort)ReadShort (rom, offset);
        }

        public static void WriteUShort(this byte[] rom, ushort data)
        {
            WriteUShort(rom, Offset, data);
            Offset += 2;
        }

        public static void WriteUShort(this byte[] rom, int offset, ushort data)
        {
            WriteShort(rom, offset, (short)data);
        }

        public static int Read24(this byte[] rom)
        {
            int ret = Read24(rom, Offset);
            Offset += 3;
            return ret;
        }

        public static int Read24(this byte[] rom, int offset)
        {
            return rom[offset] | (rom[offset + 1] << 8) |
                (rom[offset + 2] << 16);
        }

        public static void Write24(this byte[] rom, int data)
        {
            Write24(rom, Offset, data);
            Offset += 3;
        }

        public static void Write24(this byte[] rom, int offset, int data)
        {
            rom[offset] = (byte)(data & 0xFF);
            rom[offset + 1] = (byte)((data >> 8) & 0xFF);
            rom[offset + 2] = (byte)((data >> 16) & 0xFF);
        }

        public static int ReadInt(this byte[] rom)
        {
            int ret = ReadInt (rom, Offset);
            Offset += 4;
            return ret;
        }
        
        public static int ReadInt(this byte[] rom, int offset)
        {
            return rom[offset] | (rom[offset + 1] << 8) |
                (rom[offset + 2] << 16) | (rom[offset + 3] << 24);
        }

        public static void WriteInt(this byte[] rom, int data)
        {
            WriteInt(rom, Offset, data);
            Offset += 4;
        }

        public static void WriteInt(this byte[] rom, int offset, int data)
        {
            rom[offset] = (byte)(data & 0xFF);
            rom[offset + 1] = (byte)((data >> 8) & 0xFF);
            rom[offset + 2] = (byte)((data >> 16) & 0xFF);
            rom[offset + 3] = (byte)((data >> 24) & 0xFF);
        }

        public static uint ReadUInt(this byte[] rom)
        {
            uint ret = ReadUInt (rom, Offset);
            Offset += 4;
            return ret;
        }
        
        public static uint ReadUInt(this byte[] rom, int offset)
        {
            return (uint)ReadInt (rom, offset);
        }

        public static void WriteUInt(this byte[] rom, uint data)
        {
            WriteUInt(rom, Offset, data);
            Offset += 4;
        }

        public static void WriteUInt(this byte[] rom, int offset, uint data)
        {
            WriteInt(rom, offset, (int)data);
        }

        public static int ReadPtr(this byte[] rom, int offset)
        {
            return ReadInt (rom, offset) & 0x1FFFFFF;
        }

        public static void WritePtr(this byte[] rom, int offset, int ptr)
        {
            WriteInt(rom, offset, ptr | 0x8000000);
        }

        public static void AppendString(this List<byte> data, string str)
        {
            for (int i = 0; i < str.Length; i++)
                data.Add((byte)(str[i]));
        }

        public static void Copy4BppTile(this byte[] data, int srcOffset, byte[,] dest, int destX, int destY)
        {
            for (int y = destY; y < (destY + 8); y++)
            {
                int xx = destX;
                for (int x = 0; x < 4; x++)
                {
                    byte ch = data[srcOffset++];
                    dest[xx++, y] = (byte)(ch & 0xF);
                    dest[xx++, y] = (byte)((ch >> 4) & 0xF);
                }
            }
        }

        public static void Copy8BppTile(this byte[] data, int srcOffset, byte[,] dest, int destX, int destY)
        {
            for (int y = destY; y < (destY + 8); y++)
                for (int x = destX; x < (destX + 8); x++)
                    dest[x, y] = data[srcOffset++];
        }

        public static byte[,] Read4BppTile(this byte[] data, int srcOffset)
        {
            byte[,] ret = new byte[8, 8];
            Copy4BppTile(data, srcOffset, ret, 0, 0);
            return ret;
        }

        public static byte[,] Read8BppTile(this byte[] data, int srcOffset)
        {
            byte[,] ret = new byte[8, 8];
            Copy8BppTile(data, srcOffset, ret, 0, 0);
            return ret;
        }

        public static void Set4BppTile(this byte[] data, int destOffset, byte[,] src, int srcX, int srcY)
        {
            for (int y = srcY; y < (srcY + 8); y++)
            {
                int xx = srcX;
                for (int x = 0; x < 4; x++)
                {
                    byte ch = (byte)(
                        (src[xx, y] & 0xF) |
                        ((src[xx + 1, y] & 0xF) << 4));
                    data[destOffset++] = ch;
                    xx += 2;
                }
            }
        }

        public static void Write4BppTile(this byte[] data, int destOffset, byte[,] src)
        {
            Set4BppTile(data, destOffset, src, 0, 0);
        }

        public static Color ReadColor(this byte[] data, int srcOffset, int colIndex = 0)
        {
            ushort ch = data.ReadUShort(srcOffset + (colIndex << 1));
            int r = (ch & 0x1F);
            int g = ((ch >> 5) & 0x1F);
            int b = ((ch >> 10) & 0x1F);
            return Color.FromArgb(r << 3, g << 3, b << 3);
        }

        public static MPalette ReadPals(this byte[] data, int num)
        {
            var ret = data.ReadPals(num, Offset);
            Offset += (num << 5);
            return ret;
        }

        public static MPalette ReadPals(this byte[] data, int num, int offset)
        {
            var ret = new MPalette(num);
            for (int i = 0; i < num; i++)
                data.CopyPal(offset + (i << 5), ret, i << 4);
            return ret;
        }

        public static MPalette ReadPal(this byte[] data)
        {
            var ret = ReadPal(data, Offset);
            Offset += 32;
            return ret;
        }

        public static MPalette ReadPal(this byte[] data, int srcOffset)
        {
            var ret = new MPalette(1);
            data.CopyPal(srcOffset, ret);
            return ret;
        }

        public static void CopyPal(this byte[] data, int srcOffset, MPalette dest, int destIndex = 0)
        {
            for (int i = 0; i < 16; i++)
                dest.SetColorAt(i + destIndex, data.ReadColor(srcOffset, i));
        }

        public static void WriteColor(this byte[] data, int destOffset, Color c, int colIndex = 0)
        {
            ushort ch = (ushort)(
                ((c.R & 0xF8) >> 3) |
                ((c.G & 0xF8) << 2) |
                ((c.B & 0xF8) << 7));
            data.WriteUShort(destOffset + (colIndex << 1), ch);
        }

        public static void WritePal(this byte[] data, MPalette pal)
        {
            data.WritePal(Offset, pal);
            Offset += (pal.Count << 5);
        }

        public static void WritePal(this byte[] data, int destOffset, MPalette pal)
        {
            for (int i = 0; i < pal.ColorCount; i++)
                data.WriteColor(destOffset, pal.GetColorAt(i), i);
        }

        public static OamSprite ReadOam(this byte[] data, int srcOffset)
        {
            var ret = new OamSprite();

            ushort ch1 = data.ReadUShort(srcOffset);
            ushort ch2 = data.ReadUShort(srcOffset + 2);
            ushort ch3 = data.ReadUShort(srcOffset + 4);

            ret.CoordY = (sbyte)(ch1 & 0xFF);
            ret.RotScale = (ch1 & 0x100) != 0;
            ret.DblSizeDisable = (ch1 & 0x200) != 0;
            ret.ObjMode = (byte)((ch1 >> 10) & 3);
            ret.ObjMosaic = (ch1 & 0x1000) != 0;
            ret.Use8Bpp = (ch1 & 0x2000) != 0;
            ret.ObjShape = (byte)((ch1 >> 14) & 3);

            ret.CoordX = (short)(ch2 & 0x1FF);
            if ((ret.CoordX & 0x100) != 0)
            {
                // Sign-extend
                ret.CoordX = (short)((ushort)ret.CoordX | 0xFE00);
            }
            if (ret.RotScale)
                ret.RotScaleParam = (byte)((ch2 >> 9) & 0x1F);
            else
            {
                ret.RotScaleParam = (byte)((ch2 >> 9) & 7);
                ret.FlipH = (ch2 & 0x1000) != 0;
                ret.FlipV = (ch2 & 0x2000) != 0;
            }
            ret.ObjSize = (byte)((ch2 >> 14) & 3);

            ret.Tile = (ushort)(ch3 & 0x3FF);
            ret.Priority = (byte)((ch3 >> 10) & 3);
            ret.Palette = (byte)((ch3 >> 12) & 0xF);

            return ret;
        }

        public static void WriteOam(this byte[] data, int destOffset, OamSprite oam)
        {
            ushort ch1 = (ushort)(
                (oam.CoordY & 0xFF) |
                (oam.RotScale ? 0x100 : 0) |
                (oam.DblSizeDisable ? 0x200 : 0) |
                ((oam.ObjMode & 3) << 10) |
                (oam.ObjMosaic ? 0x1000 : 0) |
                (oam.Use8Bpp ? 0x2000 : 0) |
                ((oam.ObjShape & 3) << 14));

            ushort ch2 = (ushort)(
                (oam.CoordX & 0x1FF) |
                (oam.RotScale ?
                    ((oam.RotScaleParam & 0x1F) << 9) :
                    (((oam.RotScaleParam & 7) << 9) | (oam.FlipH ? 0x1000 : 0) | (oam.FlipV ? 0x2000 : 0))) |
                ((oam.ObjSize & 3) << 14));

            ushort ch3 = (ushort)(
                (oam.Tile & 0x3FF) |
                ((oam.Priority & 3) << 10) |
                ((oam.Palette & 0xF) << 12));

            data.WriteUShort(destOffset, ch1);
            data.WriteUShort(destOffset + 2, ch2);
            data.WriteUShort(destOffset + 4, ch3);
        }

        public static ArrEntry ReadArrEntry(this byte[] data)
        {
            var ret = ReadArrEntry(data, Offset);
            Offset += 2;
            return ret;
        }

        public static ArrEntry ReadArrEntry(this byte[] data, int srcOffset)
        {
            var ret = new ArrEntry();

            ushort ch1 = data.ReadUShort(srcOffset);

            ret.TileNumber = (ushort)(ch1 & 0x3FF);
            ret.FlipH = (ch1 & 0x400) != 0;
            ret.FlipV = (ch1 & 0x800) != 0;
            ret.Palette = (byte)((ch1 >> 12) & 0xF);

            return ret;
        }

        public static void WriteArrEntry(this byte[] data, ArrEntry arr)
        {
            data.WriteArrEntry(Offset, arr);
            Offset += 2;
        }

        public static void WriteArrEntry(this byte[] data, int destOffset, ArrEntry arr)
        {
            ushort ch1 = (ushort)(
                (arr.TileNumber & 0x3FF) |
                (arr.FlipH ? 0x400 : 0) |
                (arr.FlipV ? 0x800 : 0) |
                ((arr.Palette & 0xF) << 12));

            data.WriteUShort(destOffset, ch1);
        }
    }

    public static class Helpers
    {
        public static void CheckFont(Control c)
        {
            if (M3Rom.Version == RomVersion.Japanese)
            {
                Font baseFont;
                if (c is ComboSearch)
                    baseFont = ((ComboSearch)c).GetFont();
                else
                    baseFont = c.Font;

                FontFamily fontFamily = null;

                // List of fonts to try using
                var fonts = new List<string>()
                {
                    "Arial Unicode MS",
                    "Microsoft JhengHei",
                    "Unifont"
                };

                foreach (string family in fonts)
                {
                    try
                    {
                        fontFamily = new FontFamily(family);
                        break;
                    }

                    catch
                    {
                        // Font not found, try the next
                    }
                }

                // We silently ignored the exceptions from missing fonts, so if fontFamily is still null, we're in trouble
                if (fontFamily == null)
                {
                    throw new Exception("You're missing all of the following fonts, at least one of which is required to display Unicode correctly:"
                        + Environment.NewLine + Environment.NewLine + string.Join(Environment.NewLine, fonts));
                }

                Font newFont = new Font(fontFamily, baseFont.Size * 1.1f);

                if (c is ComboSearch)
                    ((ComboSearch)c).SetFont(newFont);
                else
                    c.Font = newFont;
            }
        }

        public static Icon ToIcon(this Bitmap bmp)
        {
            return Icon.FromHandle(bmp.GetHicon());
        }

        public static BitmapData LockBits(this Bitmap bmp, ImageLockMode imageLockMode)
        {
            return bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), imageLockMode, bmp.PixelFormat);
        }

        public static void GraphicsSave(object sender, SaveFileDialog dlg)
        {
            var msave = sender as ToolStripMenuItem;
            var mgfx = msave.GetCurrentParent() as ContextMenuStrip;
            var p = mgfx.SourceControl as PictureBox;

            if (dlg.ShowDialog() == DialogResult.OK)
                p.Image.Save(dlg.FileName);
        }

        public static void GraphicsCopy(object sender)
        {
            var msave = sender as ToolStripMenuItem;
            var mgfx = msave.GetCurrentParent() as ContextMenuStrip;
            var p = mgfx.SourceControl as PictureBox;

            Clipboard.SetImage(p.Image);
        }

        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        unsafe public static void FillBitmap(BitmapData bd)
        {
            byte* ptr = (byte*)bd.Scan0;
            for (int i = 0; i < (bd.Height * bd.Stride); i++)
                ptr[i] = 0;
        }

        public static int NumBits(this PixelFormat pm)
        {
            switch (pm)
            {
                case PixelFormat.Format1bppIndexed:
                    return 1;

                case PixelFormat.Format4bppIndexed:
                    return 4;

                case PixelFormat.Format8bppIndexed:
                    return 8;

                case PixelFormat.Format16bppArgb1555:
                case PixelFormat.Format16bppGrayScale:
                case PixelFormat.Format16bppRgb555:
                case PixelFormat.Format16bppRgb565:
                    return 16;

                case PixelFormat.Format24bppRgb:
                    return 24;

                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format32bppRgb:
                    return 32;

                case PixelFormat.Format48bppRgb:
                    return 48;

                case PixelFormat.Format64bppArgb:
                case PixelFormat.Format64bppPArgb:
                    return 64;

                default:
                    return 0;
            }
        }

        public static string[] SplitN(this string str)
        {
            return str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static uint UpdateCrc32(uint value, uint crc)
        {
            crc ^= value;

            for (int i = 0; i < 8; i++)
            {
                if ((crc & 1) != 0)
                    crc = (crc >> 1) ^ 0xEDB88320;
                else
                    crc >>= 1;
            }

            return crc;
        }

        public static void CopyPalette(this Bitmap bmp, MPalette pal, bool transparent)
        {
            ColorPalette cp = bmp.Palette;
            
            for (int i = 0; i < Math.Min(256, pal.ColorCount); i++)
                cp.Entries[i] = pal.GetColorAt(i);
            for (int i = Math.Min(256, pal.ColorCount); i < 256; i++)
                cp.Entries[i] = Color.Black;

            if (transparent)
                cp.Entries[0] = Color.Transparent;

            bmp.Palette = cp;
        }

        public unsafe static Bitmap ToRaster(this Bitmap bmp)
        {
            var ret = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(ret);
            g.DrawImage(bmp, 0, 0);
            g.Dispose();
            return ret;
        }
    }
}

