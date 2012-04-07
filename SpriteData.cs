using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Extensions;
using GBA;

namespace MOTHER3
{
    class SpriteData : M3Rom
    {
        public static void Init()
        {
            SpriteGfx.Init();
            SpritePalettes.Init();
            SpriteInfo.Init();
        }

        public static Bitmap GetOam(int bank, int index, int subindex, int oam, int palnum = -1, bool transparent = true)
        {
            // Get the palette
            var pal = SpritePalettes.GetPalette(index, palnum);

            // Get the graphics pointer
            int gfxpointer = SpriteGfx.GetPointer(bank, index);

            // Get the sprite info
            var si = SpriteInfo.InfoEntries[bank][index].Sprites[subindex].Sprites[oam];

            // Bail out if we need to
            if ((pal == null) || (gfxpointer == -1) || (si == null))
                return null;

            return GfxProvider.RenderSprites(new OamSprite[] { si }, Rom, gfxpointer, pal, transparent);
        }

        public static Bitmap GetSprite(int bank, int index, int subindex, int palnum = -1, bool transparent = true)
        {
            // Get the palette
            var pal = SpritePalettes.GetPalette(index, palnum);

            // Get the graphics pointer
            int gfxpointer = SpriteGfx.GetPointer(bank, index);

            // Get the sprite info
            var si = SpriteInfo.InfoEntries[bank][index];

            // Bail out if we need to
            if ((pal == null) || (gfxpointer == -1) || (si == null))
                return null;

            // Render
            return GfxProvider.RenderSprites(si.Sprites[subindex].Sprites, Rom, gfxpointer, pal, transparent);
        }
    }

    class SpriteInfo : M3Rom
    {
        public static int[] Address = { 0x1A442A4, 0x1AE0638, 0x1AEE4C4, 0x1AF1ED0 };
        public static int[] Entries = new int[4];
        public static SpriteInfo[][] InfoEntries = new SpriteInfo[4][];

        private int bank;
        private int index;
        public ushort SpriteCount;
        public Sprite[] Sprites;

        public static void Init()
        {
            for (int i = 0; i < 4; i++)
            {
                Entries[i] = Rom.ReadInt(Address[i]);
                InfoEntries[i] = new SpriteInfo[Entries[i]];

                for (int j = 0; j < Entries[i]; j++)
                {
                    int a = GetPointer(i, j);
                    if (a == -1) continue;

                    var ie = new SpriteInfo();
                    ie.bank = i;
                    ie.index = j;

                    Rom.Seek(a);
                    Rom.SeekAdd(8);

                    ie.SpriteCount = Rom.ReadUShort();
                    ie.Sprites = new Sprite[ie.SpriteCount];
                    for (int k = 0; k < ie.SpriteCount; k++)
                    {
                        var s = new Sprite();
                        s.index = k;

                        s.SpriteCount = Rom.ReadUShort();
                        s.Sprites = new OamSprite[s.SpriteCount];
                        for (int m = 0; m < s.SpriteCount; m++)
                        {
                            var o = new OamSprite();

                            o.CoordY = Rom.ReadSByte();
                            o.CoordX = (short)Rom.ReadSByte();

                            ushort ch = Rom.ReadUShort();
                            o.Tile = (ushort)(ch & 0x3FF);
                            o.FlipH = (ch & 0x400) != 0;
                            o.FlipV = (ch & 0x800) != 0;
                            o.ObjSize = (byte)((ch >> 12) & 3);
                            o.ObjShape = (byte)((ch >> 14) & 3);

                            s.Sprites[m] = o;
                        }
                        Rom.SeekAdd(2);

                        ie.Sprites[k] = s;
                    }

                    InfoEntries[i][j] = ie;
                }
            }
        }

        public static int GetPointer(int bank, int index)
        {
            int a = Rom.ReadInt(Address[bank] + 4 + (index << 2));
            if (a == 0) return -1;
            return a + Address[bank];
        }

        private void WriteOam(OamSprite oam)
        {
            Rom.WriteSByte(oam.CoordY);
            Rom.WriteSByte((sbyte)oam.CoordX);

            ushort ch = (ushort)(
                (oam.Tile & 0x3FF) |
                (oam.FlipH ? 0x400 : 0) |
                (oam.FlipV ? 0x800 : 0) |
                ((oam.ObjSize & 3) << 12) |
                ((oam.ObjShape & 3) << 14));

            Rom.WriteUShort(ch);
        }

        public void Save(int sprite, int oam)
        {
            int a = GetPointer(this.bank, this.index);
            if (a == -1) return;

            Rom.Seek(a);
            Rom.SeekAdd(10);

            for (int i = 0; i < (sprite - 1); i++)
                Rom.SeekAdd((this.Sprites[i].SpriteCount + 1) << 2);

            Rom.SeekAdd(2);

            for (int i = 0; i < (oam - 1); i++)
                Rom.SeekAdd(4);

            var o = this.Sprites[sprite].Sprites[oam];
            WriteOam(o);

            M3Rom.IsModified = true;
        }

        public void Save()
        {
            int a = GetPointer(this.bank, this.index);
            if (a == -1) return;

            Rom.Seek(a);
            Rom.SeekAdd(10);

            for (int i = 0; i < this.SpriteCount; i++)
            {
                Rom.SeekAdd(2);
                for (int j = 0; j < this.Sprites[i].SpriteCount; j++)
                {
                    var o = this.Sprites[i].Sprites[j];
                    WriteOam(o);
                }
                Rom.SeekAdd(2);
            }

            M3Rom.IsModified = true;
        }

    }

    class Sprite : M3Rom
    {
        public int index;
        public ushort SpriteCount;
        public OamSprite[] Sprites;
    }

    class SpritePalettes : M3Rom
    {
        public static int AddressInfo = 0x1433D7C;
        public static int Address = 0x1A41548;
        public static int Entries = -1;
        public static MPalette[] DefaultPals = null;

        public static void Init()
        {
            Entries = Rom.ReadInt(Address);
            DefaultPals = new MPalette[16];
            for (int i = 0; i < 16; i++)
                DefaultPals[i] = Rom.ReadPal(GetPointer(0) + (i << 5));
        }

        public static int GetPointer(int spriteindex)
        {
            int index;

            if ((spriteindex > 0xFF) && (spriteindex < 0x26C))
            {
                // These sprites use the (spriteindex - 0xFF)th entry
                index = spriteindex - 0xff;
            }
            else
            {
                index = 0;
            }

            int a = Rom.ReadInt(Address + 4 + (index << 2));
            if (a == -1) return -1;

            return Address + a;
        }

        public static MPalette GetPalette(int spriteindex, int palnum = -1)
        {
            int a = GetPointer(spriteindex);
            if (a == -1) return null;

            if ((spriteindex > 0xFF) && (spriteindex < 0x26C))
            {
                // In this case, read one palette from a
                return Rom.ReadPals(1, a);
            }
            else
            {
                // In this case, read the pal index from another table
                if (palnum == -1) palnum = GetPalNum(spriteindex);

                // And return that palette from the default pals
                return DefaultPals[palnum];
            }
        }

        public static int GetPalNum(int spriteindex)
        {
            return Rom[AddressInfo + 1 + ((spriteindex + 1) * 12)] & 0xF;
        }

        public static void SetPalNum(int spriteindex, int num)
        {
            int a = AddressInfo + 1 + ((spriteindex + 1) * 12);
            byte b = (byte)(Rom[a] & 0xF0);
            b |= (byte)((num & 0xF));
            Rom[a] = b;

            M3Rom.IsModified = true;
        }
    }

    class SpriteGfx : M3Rom
    {
        public static int[] Address = { 0x14383E4, 0x194BC30, 0x1A012B8, 0x1A36AA0 };
        public static int[] Entries = new int[4];

        public static void Init()
        {
            for (int i = 0; i < 4; i++)
                Entries[i] = Rom.ReadInt(Address[i]);

            // The first bank has an extra entry for the item pics, so let's remove that
            Entries[0]--;
        }

        public static int GetPointer(int bank, int index)
        {
            int a = Rom.ReadInt(Address[bank] + 4 + (index << 2));
            if (a == -1) return -1;

            return Address[bank] + a;
        }
    }
}
