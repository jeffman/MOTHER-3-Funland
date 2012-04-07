using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace MOTHER3
{
    class ShopData : M3Rom
    {
        public static int Address = 0xEBD08;
        public static int Length = 0x3C;
        public static int Entries = 0x24;
        public static ShopData[] Shops = new ShopData[Entries];

        public ushort[] Items = new ushort[Length >> 1];
        private int index;

        public static void Init()
        {
            Rom.Seek(Address);
            for (int i = 0; i < Entries; i++)
            {
                ShopData sd = new ShopData();

                for (int j = 0; j < sd.Items.Length; j++)
                    sd.Items[j] = Rom.ReadUShort();

                sd.index = i;

                Shops[i] = sd;
            }
        }

        public void Save()
        {
            Rom.Seek(Address + (this.index * Length));
            for (int i = 0; i < this.Items.Length; i++)
                Rom.WriteUShort(this.Items[i]);

            M3Rom.IsModified = true;
        }
    }
}
