using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

// Documentation: http://www.romhacking.net/documents/%5b462%5dsappy.txt

namespace MOTHER3
{
    class Song : M3Rom
    {
        public int Tracks;
        public int Priority;
        public bool EchoFeedback;
        public int EchoFeedbackValue;
        public int InstrumentPointer;
        public int[] TrackPointers;

        public Song(int address)
        {
            Tracks = Rom[address];
            Priority = Rom[address + 2];

            byte tmp = Rom[address + 3];
            EchoFeedback = (tmp >= 0x80);
            EchoFeedbackValue = (tmp & 0x7F);

            InstrumentPointer = Rom.ReadPtr(address + 4);

            TrackPointers = new int[Tracks];
            for (int i = 0; i < Tracks; i++)
            {
                TrackPointers[i] = Rom.ReadPtr(address + 8 + (i * 4));
            }
        }
    }
}
