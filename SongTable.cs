using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace MOTHER3
{
    class SongTable : M3Rom
    {
        public static int Address = 0x120E94;
        public static int Length = 8;
        public static int Entries = 1968;
        public static Song[] Songs = new Song[Entries];

        public static void Init()
        {
            for (int i = 0; i < Entries; i++)
            {
                Songs[i] = new Song(Rom.ReadPtr(Address + (i * 8)));
            }
        }
    }
}
