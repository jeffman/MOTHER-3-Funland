using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MOTHER3Funland
{
    [Serializable]
    public class M3Settings
    {
        public static M3Settings MainSettings;

        public string RomDirectory = string.Empty;
        public SerializableDictionary<string, FormParams> FormParams = new SerializableDictionary<string, FormParams>();
        public FormParams MainFormParams;
        public GfxImportSettings GfxImportSettings;
    }

    [Serializable]
    public struct FormParams
    {
        public Point WindowLoc;
        public Size WindowSize;
        public FormWindowState WindowState;

        public int[] ItemIndex;

        public FormParams(Point wLoc, Size wSize, FormWindowState wState, int[] iIndex)
        {
            this.WindowLoc = wLoc;
            this.WindowSize = wSize;
            this.WindowState = wState;
            this.ItemIndex = iIndex;
        }
    }

    [Serializable]
    public struct GfxImportSettings
    {
        public FormParams GfxFormParams;
        public bool UseTileset;
        public bool UseFlips;
        public bool UsePalette;
        public bool UseTransparency;
        public string TransparentColorS
        {
            get
            {
                return
                    TransparentColor.A + ", " +
                    TransparentColor.R + ", " +
                    TransparentColor.G + ", " +
                    TransparentColor.B;
            }
            set
            {
                try
                {
                    string[] s = value.Split(',');
                    byte a = byte.Parse(s[0]);
                    byte r = byte.Parse(s[1]);
                    byte g = byte.Parse(s[2]);
                    byte b = byte.Parse(s[3]);
                    TransparentColor = Color.FromArgb(a, r, g, b);
                }
                catch
                {
                    TransparentColor = default(Color);
                }
            }
        }

        [XmlIgnore]
        public Color TransparentColor;

        public GfxImportSettings(FormParams gfxFormParams, bool useTileset, bool useFlips, bool usePalette, bool useTransparency, Color transparentColor)
        {
            this.GfxFormParams = gfxFormParams;
            this.UseTileset = useTileset;
            this.UseFlips = useFlips;
            this.UsePalette = usePalette;
            this.UseTransparency = useTransparency;
            this.TransparentColor = transparentColor;
        }
    }
}

