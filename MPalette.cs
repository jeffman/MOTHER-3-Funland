using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace MOTHER3
{
    public class MPalette : ICloneable
    {
        public List<Color[]> Entries = new List<Color[]>();

        public int Count
        {
            get
            {
                return Entries.Count;
            }
        }

        public int ColorCount
        {
            get
            {
                return Count << 4;
            }
        }

        public MPalette()
        {
        }

        public MPalette(int num)
        {
            while ((num--) > 0)
            {
                Add(new Color[16]);
            }
        }

        public void Add(Color[] pal)
        {
            Entries.Add(pal);
        }

        public void AddRange(Color[][] pal)
        {
            Entries.AddRange(pal);
        }

        public Color GetColorAt(int i)
        {
            return Entries[i >> 4][i & 0xF];
        }

        public void SetColorAt(int i, Color c)
        {
            Entries[i >> 4][i & 0xF] = c;
        }

        public object Clone()
        {
            var ret = new MPalette(this.Count);
            for (int i = 0; i < this.ColorCount; i++)
                ret.SetColorAt(i, this.GetColorAt(i));
            return ret;
        }
    }
}
