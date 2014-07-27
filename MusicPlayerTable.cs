using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace MOTHER3
{
    class MusicPlayerTable : M3Rom
    {
        public static int Address = 0xECD40;
        public static int Length = 12;
        public static int Entries = 0xFB;
        public static MusicPlayerTable[] MusicTableEntries = new MusicPlayerTable[Entries];
        public static Dictionary<int, int> TableLookup = new Dictionary<int, int>();

        public int[] Data = new int[6];

        public static void Init()
        {
            TableLookup.Clear();
            TableLookup.Add(0, 0);

            Rom.Seek(Address);
            for (int i = 0; i < Entries; i++)
            {
                MusicTableEntries[i] = new MusicPlayerTable();
                for (int j = 0; j < 6; j++)
                {
                    int ch = Rom.ReadUShort();
                    MusicTableEntries[i].Data[j] = ch;
                    
                    if (j == 1)
                    {
                        TableLookup.Add(ch, MusicTableEntries[i].Data[0]);
                    }
                }
            }
        }
    }
}
