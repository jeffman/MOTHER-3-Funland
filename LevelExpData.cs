using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace MOTHER3
{
    /* Charnum from 0 to F
     * CD928: Level-up experience tables
     * To get the table for character X:
     * Load byte at CC4E8 + (charnum * 0x144) (this byte always == charnum, so we can skip this step)
     * Multiply this byte (charnum) by 0x190
     * Add to CD928 to get the exp table address.
     * Each entry in the table is 0x190 bytes, including 4-byte header;
     * this leaves level-up data for 99 levels!
     */
    class LevelExpData : M3Rom
    {
        public static int Address = 0xCD928;
        public static int Length = 0x190;
        public static int Entries = 16;
        public static LevelExpData[] LevelExpEntries = new LevelExpData[Entries];

        private int index;
        public uint Header;
        public uint[] Data = new uint[99];

        public static void Init()
        {
            Rom.Seek(Address);
            for (int i = 0; i < Entries; i++)
            {
                var led = new LevelExpData();

                led.index = i;

                led.Header = Rom.ReadUInt();
                for (int j = 0; j < 99; j++)
                    led.Data[j] = Rom.ReadUInt();

                LevelExpEntries[i] = led;
            }
        }

        public void Save()
        {
            Rom.Seek(Address + (this.index * Length));
            Rom.WriteUInt(this.Header);
            for (int i = 0; i < 99; i++)
                Rom.WriteUInt(this.Data[i]);

            M3Rom.IsModified = true;
        }
    }
}
