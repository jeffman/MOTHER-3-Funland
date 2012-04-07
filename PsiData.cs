using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace MOTHER3
{
    class PsiData : M3Rom
    {
        public static int Address = 0xE1908;
        public static int Length = 0x38;
        public static int Entries = 0x64;
        public static PsiData[] PsiEntries = new PsiData[Entries];

        private int index;
        public byte Type;
        public ushort Pp;
        public byte Target;
        public ushort AmountLow;
        public ushort AmountHigh;
        public byte[] Animation = new byte[2];

        public static void Init()
        {
            Rom.Seek(Address);
            for (int i = 0; i < Entries; i++)
            {
                var pd = new PsiData();
                pd.index = i;

                Rom.SeekAdd(4);

                pd.Type = Rom.ReadByte();

                Rom.SeekAdd(7);

                pd.Pp = Rom.ReadUShort();

                Rom.SeekAdd(10);

                pd.Target = Rom.ReadByte();

                Rom.SeekAdd(5);

                pd.AmountLow = Rom.ReadUShort();
                pd.AmountHigh = Rom.ReadUShort();

                Rom.SeekAdd(13);

                pd.Animation[0] = Rom.ReadByte();
                pd.Animation[1] = Rom.ReadByte();

                Rom.SeekAdd(7);

                PsiEntries[i] = pd;
            }
        }

        public void Save()
        {
            Rom.Seek(Address + (Length * index));

            Rom.SeekAdd(4);

            Rom.WriteByte(this.Type);

            Rom.SeekAdd(7);

            Rom.WriteUShort(this.Pp);

            Rom.SeekAdd(10);

            Rom.WriteByte(this.Target);

            Rom.SeekAdd(5);

            Rom.WriteUShort(this.AmountLow);
            Rom.WriteUShort(this.AmountHigh);

            Rom.SeekAdd(13);

            Rom.WriteByte(this.Animation[0]);
            Rom.WriteByte(this.Animation[1]);

            M3Rom.IsModified = true;
        }
    }
}
