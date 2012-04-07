using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace MOTHER3
{
    class ActionTable : M3Rom
    {
        public static int Address = 0xD9D28;
        public static int Length = 0x30;
        public static int Entries = 650;
        public static ActionTable[] Actions = new ActionTable[Entries];
        
        // Entry 0x12 is the battle text number
        public ushort[] Data = new ushort[Length >> 1];

        public static void Init()
        {
            Rom.Seek(Address);
            for (int i = 0; i < Entries; i++)
            {
                ActionTable at = new ActionTable();

                for (int j = 0; j < at.Data.Length; j++)
                {
                    at.Data[j] = Rom.ReadUShort();
                }

                Actions[i] = at;
            }
        }
    }
}
