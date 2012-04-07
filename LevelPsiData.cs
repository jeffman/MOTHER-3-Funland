using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace MOTHER3
{
    /*
     * CC830 - CC897: Lucas PSI learning table
     * CCAB8 - CCB2B: Kumatora PSI learning table
     */
    class LevelPsiData : M3Rom
    {
        public class ValuePair
        {
            public int cindex;
            public int pindex;

            public ushort First;
            public ushort Second;

            public void Save()
            {
                Rom.Seek(Address[cindex] + (pindex << 2));
                Rom.WriteUShort(First);
                Rom.WriteUShort(Second);

                M3Rom.IsModified = true;
            }
        }

        public static int[] Address = { 0xCC830, 0xCCAB8 };
        public static int[] Entries = { 0x1A, 0x1D };
        public static int Length = 4;
        public static ValuePair[][] LevelPsiEntries =
            new ValuePair[2][];

        public static void Init()
        {
            for (int i = 0; i < 2; i++)
            {
                Rom.Seek(Address[i]);
                LevelPsiEntries[i] = new ValuePair[Entries[i]];

                for (int j = 0; j < Entries[i]; j++)
                {
                    var pd = new ValuePair();
                    pd.First = Rom.ReadUShort();
                    pd.Second = Rom.ReadUShort();
                    pd.cindex = i;
                    pd.pindex = j;

                    LevelPsiEntries[i][j] = pd;
                }
            }
        }
    }
}
