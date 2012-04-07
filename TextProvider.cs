using System;
using System.Text;
using System.Collections.Generic;
using Extensions;

namespace MOTHER3
{
    // TODO: Control codes for EnglishShort

    public class TextProvider : M3Rom
    {    
        public static Encoding SJIS = Encoding.GetEncoding(932);
        public static Encoding Unicode = Encoding.Unicode;

        public static char[] EnglishMap = new char[256];
        public static Dictionary<char, byte> EnglishMapInverse = new Dictionary<char, byte>();

        public static ushort[] JapaneseMap = new ushort[7332];
        public static Dictionary<ushort, ushort> JapaneseMapInverse = new Dictionary<ushort, ushort>();

        public static ushort[] JapaneseAsciiMap = new ushort[128];

        public static void Init()
        {    
            #region EnglishMap
            EnglishMap[0] = '\uFEFF';
            EnglishMap[1] = '!';
            EnglishMap[2] = '\"';
            EnglishMap[3] = '•';
            EnglishMap[4] = '$';
            EnglishMap[5] = '%';
            EnglishMap[6] = '&';
            EnglishMap[7] = '\'';
            EnglishMap[8] = '(';
            EnglishMap[9] = ')';
            EnglishMap[10] = '*';
            EnglishMap[11] = '+';
            EnglishMap[12] = ',';
            EnglishMap[13] = '-';
            EnglishMap[14] = '.';
            EnglishMap[15] = '/';
            EnglishMap[16] = '0';
            EnglishMap[17] = '1';
            EnglishMap[18] = '2';
            EnglishMap[19] = '3';
            EnglishMap[20] = '4';
            EnglishMap[21] = '5';
            EnglishMap[22] = '6';
            EnglishMap[23] = '7';
            EnglishMap[24] = '8';
            EnglishMap[25] = '9';
            EnglishMap[26] = ':';
            EnglishMap[27] = ';';
            EnglishMap[28] = '<';
            EnglishMap[29] = '=';
            EnglishMap[30] = '>';
            EnglishMap[31] = '?';
            EnglishMap[32] = '@';
            EnglishMap[33] = 'A';
            EnglishMap[34] = 'B';
            EnglishMap[35] = 'C';
            EnglishMap[36] = 'D';
            EnglishMap[37] = 'E';
            EnglishMap[38] = 'F';
            EnglishMap[39] = 'G';
            EnglishMap[40] = 'H';
            EnglishMap[41] = 'I';
            EnglishMap[42] = 'J';
            EnglishMap[43] = 'K';
            EnglishMap[44] = 'L';
            EnglishMap[45] = 'M';
            EnglishMap[46] = 'N';
            EnglishMap[47] = 'O';
            EnglishMap[48] = 'P';
            EnglishMap[49] = 'Q';
            EnglishMap[50] = 'R';
            EnglishMap[51] = 'S';
            EnglishMap[52] = 'T';
            EnglishMap[53] = 'U';
            EnglishMap[54] = 'V';
            EnglishMap[55] = 'W';
            EnglishMap[56] = 'X';
            EnglishMap[57] = 'Y';
            EnglishMap[58] = 'Z';
            EnglishMap[59] = 'α';
            EnglishMap[60] = 'β';
            EnglishMap[61] = 'γ';
            EnglishMap[62] = 'Ω';
            EnglishMap[63] = '◯';
            EnglishMap[64] = ' ';
            EnglishMap[65] = 'a';
            EnglishMap[66] = 'b';
            EnglishMap[67] = 'c';
            EnglishMap[68] = 'd';
            EnglishMap[69] = 'e';
            EnglishMap[70] = 'f';
            EnglishMap[71] = 'g';
            EnglishMap[72] = 'h';
            EnglishMap[73] = 'i';
            EnglishMap[74] = 'j';
            EnglishMap[75] = 'k';
            EnglishMap[76] = 'l';
            EnglishMap[77] = 'm';
            EnglishMap[78] = 'n';
            EnglishMap[79] = 'o';
            EnglishMap[80] = 'p';
            EnglishMap[81] = 'q';
            EnglishMap[82] = 'r';
            EnglishMap[83] = 's';
            EnglishMap[84] = 't';
            EnglishMap[85] = 'u';
            EnglishMap[86] = 'v';
            EnglishMap[87] = 'w';
            EnglishMap[88] = 'x';
            EnglishMap[89] = 'y';
            EnglishMap[90] = 'z';
            EnglishMap[91] = '{';
            EnglishMap[92] = '♪';
            EnglishMap[93] = '}';
            EnglishMap[94] = '~';
            
            //95-157
            for (int i = 95; i <= 157; i++)
                EnglishMap[i] = '?';
            
            EnglishMap[158] = ' ';
            EnglishMap[159] = '@';
            EnglishMap[160] = '!';
            EnglishMap[161] = '\"';
            EnglishMap[162] = '•';
            EnglishMap[163] = '$';
            EnglishMap[164] = '%';
            EnglishMap[165] = '&';
            EnglishMap[166] = '\'';
            EnglishMap[167] = '(';
            EnglishMap[168] = ')';
            EnglishMap[169] = '*';
            EnglishMap[170] = '+';
            EnglishMap[171] = ',';
            EnglishMap[172] = '-';
            EnglishMap[173] = '.';
            EnglishMap[174] = '/';
            EnglishMap[175] = '?';
            EnglishMap[176] = '0';
            EnglishMap[177] = '1';
            EnglishMap[178] = '2';
            EnglishMap[179] = '3';
            EnglishMap[180] = '4';
            EnglishMap[181] = '5';
            EnglishMap[182] = '6';
            EnglishMap[183] = '7';
            EnglishMap[184] = '8';
            EnglishMap[185] = '9';
            EnglishMap[186] = ':';
            EnglishMap[187] = ';';
            EnglishMap[188] = '<';
            EnglishMap[189] = '=';
            EnglishMap[190] = '>';
            EnglishMap[191] = '?';
            EnglishMap[192] = '?';
            EnglishMap[193] = 'A';
            EnglishMap[194] = 'B';
            EnglishMap[195] = 'C';
            EnglishMap[196] = 'D';
            EnglishMap[197] = 'E';
            EnglishMap[198] = 'F';
            EnglishMap[199] = 'G';
            EnglishMap[200] = 'H';
            EnglishMap[201] = 'I';
            EnglishMap[202] = 'J';
            EnglishMap[203] = 'K';
            EnglishMap[204] = 'L';
            EnglishMap[205] = 'M';
            EnglishMap[206] = 'N';
            EnglishMap[207] = 'O';
            EnglishMap[208] = 'P';
            EnglishMap[209] = 'Q';
            EnglishMap[210] = 'R';
            EnglishMap[211] = 'S';
            EnglishMap[212] = 'T';
            EnglishMap[213] = 'U';
            EnglishMap[214] = 'V';
            EnglishMap[215] = 'W';
            EnglishMap[216] = 'X';
            EnglishMap[217] = 'Y';
            EnglishMap[218] = 'Z';
            EnglishMap[219] = 'α';
            EnglishMap[220] = 'β';
            EnglishMap[221] = 'γ';
            EnglishMap[222] = 'Ω';
            EnglishMap[223] = '?';
            EnglishMap[224] = '?';
            EnglishMap[225] = '?';
            EnglishMap[226] = '?';
            EnglishMap[227] = '?';
            EnglishMap[228] = '→';
            EnglishMap[229] = '←';
            EnglishMap[230] = '↑';
            EnglishMap[231] = '↓';
            EnglishMap[232] = ' ';
            EnglishMap[233] = ' ';
            EnglishMap[234] = '?';
            EnglishMap[235] = '\uFEFF';
            EnglishMap[236] = '♥';
            #endregion
            
            for (int i = 0; i < EnglishMap.Length; i++)
            {
                if (!EnglishMapInverse.ContainsKey (EnglishMap[i]))
                    EnglishMapInverse.Add (EnglishMap[i], (byte)i);
            }
            
            for (ushort i = 0; i < JapaneseMap.Length; i++)
            {
                // There's no space character...
                if (i == 0xAC)
                    JapaneseMap[i] = 0x8140; //0x4081;
                else
                {
                    ushort ch = Rom.ReadUShort(0xCE39F8 + (i * 22));
                    JapaneseMap[i] = (ushort)(((ch & 0xFF) << 8) | ((ch & 0xFF00) >> 8));
                }

                if (!JapaneseMapInverse.ContainsKey (JapaneseMap[i]))
                    JapaneseMapInverse.Add (JapaneseMap[i], i);
            }

            #region ASCII to SJIS map

            // Initialize with spaces
            for (int i = 0; i < 0x80; i++)
                JapaneseAsciiMap[i] = 0x8140;

            JapaneseAsciiMap[0x21] = 0x8149; // !
            JapaneseAsciiMap[0x22] = 0x818D; // "
            JapaneseAsciiMap[0x23] = 0x8194; // #
            JapaneseAsciiMap[0x24] = 0x8190; // $
            JapaneseAsciiMap[0x25] = 0x8193; // %
            JapaneseAsciiMap[0x26] = 0x8195; // &
            JapaneseAsciiMap[0x27] = 0x818C; // '
            JapaneseAsciiMap[0x28] = 0x8169; // (
            JapaneseAsciiMap[0x29] = 0x816A; // )
            JapaneseAsciiMap[0x2A] = 0x8196; // *
            JapaneseAsciiMap[0x2B] = 0x817B; // +
            JapaneseAsciiMap[0x2C] = 0x8143; // ,
            JapaneseAsciiMap[0x2D] = 0x817C; // -
            JapaneseAsciiMap[0x2E] = 0x8144; // .
            JapaneseAsciiMap[0x2F] = 0x815E; // /

            // Numbers
            for (int i = 0; i < 10; i++)
                JapaneseAsciiMap[i + 0x30] = (ushort)(0x824F + i);

            JapaneseAsciiMap[0x3A] = 0x8146; // :
            JapaneseAsciiMap[0x3B] = 0x8147; // ;
            JapaneseAsciiMap[0x3C] = 0x8183; // <
            JapaneseAsciiMap[0x3D] = 0x8181; // =
            JapaneseAsciiMap[0x3E] = 0x8184; // >
            JapaneseAsciiMap[0x3F] = 0x8148; // ?
            JapaneseAsciiMap[0x40] = 0x8197; // @

            // Upper-case letters
            for (int i = 0; i < 26; i++)
                JapaneseAsciiMap[i + 0x41] = (ushort)(0x8260 + i);

            JapaneseAsciiMap[0x5B] = 0x816D; // [
            JapaneseAsciiMap[0x5C] = 0x815F; // \
            JapaneseAsciiMap[0x5D] = 0x816E; // ]
            JapaneseAsciiMap[0x5E] = 0x814F; // ^
            JapaneseAsciiMap[0x5F] = 0x8151; // _
            JapaneseAsciiMap[0x60] = 0x814D; // `

            // Lower-case letters
            for (int i = 0; i < 26; i++)
                JapaneseAsciiMap[i + 0x61] = (ushort)(0x8281 + i);

            JapaneseAsciiMap[0x7B] = 0x816F; // {
            JapaneseAsciiMap[0x7C] = 0x8162; // |
            JapaneseAsciiMap[0x7D] = 0x8170; // }
            JapaneseAsciiMap[0x7E] = 0x8160; // ~

            #endregion
        }

        public static string GetText(int offset, TextType texttype, bool ignorecc)
        {
            return GetText(offset, 1024, texttype, ignorecc);
        }

        public static string GetText(int offset, int length, TextType texttype, bool ignorecc)
        {
            string ret = string.Empty;

            switch (texttype)
            {
                case TextType.Japanese:
                    List<byte> stringBytes = new List<byte>();

                    for (int i = 0; i < length; i++)
                    {
                        ushort ch = Rom.ReadUShort(offset);

                        if (ch == 0xFFFF)
                        {
                            if (!ignorecc) stringBytes.AppendString("[FFFF]");
                            break;
                        }

                        offset += 2;

                        if (ch >= 0xEF00)
                        {
                            if (!ignorecc)
                            {
                                stringBytes.AppendString("[" + ch.ToString("X4"));
                                if (ch == 0xff22)
                                {
                                }
                                if (M3CC.CCLookup.ContainsKey(ch))
                                {
                                    CC c = M3CC.CCLookup[ch];
                                    for (int j = 0; j < c.args; j++)
                                    {
                                        stringBytes.AppendString(" " + Rom.ReadUShort(offset).ToString("X4"));
                                        offset += 2;
                                    }
                                }
                                stringBytes.AppendString("]");
                            }

                            if ((ch == 0xFF01) || (ch == 0xFF32) || (ch == 0xFF03))
                            {
                                // Newline
                                stringBytes.AppendString(Environment.NewLine);
                            }

                            continue;
                        }

                        ch = (ushort)(ch % JapaneseMap.Length);
                        ushort code = JapaneseMap[ch];
                        stringBytes.Add((byte)((code >> 8) & 0xFF));
                        stringBytes.Add((byte)(code & 0xFF));
                    }

                    byte[] converted = Encoding.Convert(SJIS, Unicode, stringBytes.ToArray());
                    ret = Unicode.GetString(converted);
                    break;

                case TextType.EnglishWide:
                    for (int i = 0; i < length; i++)
                    {
                        ushort ch = Rom.ReadUShort(offset);

                        if (ch == 0xFFFF)
                            break;

                        offset += 2;

                        if (ch >= 0xEF00)
                        {
                            if (ignorecc)
                            {
                                if ((ch == 0xFF01) || (ch == 0xFF32) || (ch == 0xFF03))
                                {
                                    // Newline
                                    ret += Environment.NewLine;
                                }
                            }

                            else
                            {
                                ret += "[" + ch.ToString("X4") + "]";
                            }

                            continue;
                        }

                        ch &= 0xFF;
                        ret += EnglishMap[ch];
                    }
                    break;

                case TextType.EnglishShort:
                    for (int i = 0; i < length; i++)
                    {
                        byte ch = Rom.DecodeByte(offset);

                        // Check for control codes
                        if (ch == 0xEF)
                        {
                            // EF is a custom control code
                            ret += "[EF";
                            ret += Rom.DecodeByte(offset + 1).ToString("X2") + "]";
                            offset++;
                        }

                        else if (ch >= 0xF0)
                        {
                            // Special case: 0xFF = end
                            if (ch == 0xFF)
                            {
                                ret += "[FFFF]";
                                break;
                            }

                            // Else: get the cc length
                            int cclen = ch & 0xF;

                            // Get the control byte
                            byte ccbyte = Rom.DecodeByte(offset + 1);
                            bool doNewLine = ((ccbyte == 0x01) || (ccbyte == 0x32) || (ccbyte == 0x03));

                            // Print the result
                            ret += "[FF" + ccbyte.ToString("X2");

                            // Get the arguments
                            ushort[] args = new ushort[cclen];
                            for (int j = 0; j < cclen; j++)
                                ret += " " + Rom.DecodeUShort(offset + 2 + (j << 1)).ToString("X4");

                            ret += "]";

                            if (doNewLine) ret += Environment.NewLine;

                            offset += 1 + (cclen << 1);
                        }

                        else
                        {
                            ret += EnglishMap[ch];
                        }

                        offset++;
                    }
                    break;
            }

            return ret;
        }

        public static void SetText(int offset, int length, TextType texttype, string str)
        {
            switch (texttype)
            {
                case TextType.Japanese:

                    // Get the string as bytes
                    byte[] b = Unicode.GetBytes(str);

                    // Convert to SJIS
                    byte[] s = Encoding.Convert(Unicode, SJIS, b);

                    // Replace ASCII with SJIS
                    List<byte> bb = new List<byte>();
                    for (int i = 0; i < s.Length; i++)
                    {
                        byte ch = s[i];
                        if (ch < 0x80)
                        {
                            // ASCII
                            ushort us = JapaneseAsciiMap[ch];

                            // Write it as big-endian
                            bb.Add((byte)((us >> 8) & 0xFF));
                            bb.Add((byte)(us & 0xFF));
                        }
                        else
                        {
                            // SJIS
                            bb.Add(ch);
                            bb.Add(s[i + 1]);
                            i++;
                        }
                    }

                    // Get the original character values
                    ushort[] u = new ushort[bb.Count >> 1];
                    for (int i = 0; i < u.Length; i++)
                    {
                        ushort uu = (ushort)((bb[i << 1] << 8) | (bb[(i << 1) | 1]));
                        if (JapaneseMapInverse.ContainsKey(uu))
                        {
                            u[i] = JapaneseMapInverse[uu];
                        }
                        else
                        {
                            u[i] = 0;
                        }
                    }

                    // Write them
                    for (int i = 0; i < Math.Min(length, u.Length); i++)
                    {
                        Rom.WriteUShort(offset + (i << 1), u[i]);
                    }

                    for (int i = Math.Min(length, u.Length); i < length; i++)
                    {
                        Rom.WriteUShort(offset + (i << 1), 0xFFFF);
                    }

                    break;

                case TextType.EnglishWide:

                    // Write each character straight-up G
                    for (int i = 0; i < Math.Min(length, str.Length); i++)
                    {
                        char c = str[i];
                        if (EnglishMapInverse.ContainsKey(c))
                        {
                            Rom.WriteUShort(offset + (i << 1), EnglishMapInverse[c]);
                        }
                        else
                        {
                            Rom.WriteUShort(offset + (i << 1), 0);
                        }
                    }

                    for (int i = Math.Min(length, str.Length); i < length; i++)
                    {
                        Rom.WriteUShort(offset + (i << 1), 0xFFFF);
                    }

                    break;

                case TextType.EnglishShort:

                    break;

                default:
                    return;
            }
        }
    }
    
    public class TextItemNames : M3Rom
    {
        public static int Address = -1;
        public static int Length = -1;
        public static int Entries = -1;
        
        public static void Init()
        {
            Address = Rom.ReadInt (0xD1EE84) + 0xD1EE78;
            Length = Rom.ReadUShort(Address);
            Entries = Rom.ReadUShort(Address + 2);
        }
        
        public static string GetName(int index)
        {
            return TextProvider.GetText (Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }

        public static void SetName(int index, string str)
        {
            TextProvider.SetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, str);
        }
    }
    
    public class TextEnemyNames : M3Rom
    {
        public static int Address = -1;
        public static int Length = -1;
        public static int Entries = -1;

        public static void Init()
        {
            Address = Rom.ReadInt (0xD1EE98) + 0xD1EE78;
            Length = Rom.ReadUShort(Address);
            Entries = Rom.ReadUShort(Address + 2);
        }
        
        public static string GetName(int index)
        {
            return TextProvider.GetText (Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }

        public static void SetName(int index, string str)
        {
            TextProvider.SetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, str);
        }
    }

    public class TextEnemyShortNames : M3Rom
    {
        public static int Address = -1;
        public static int Length = -1;
        public static int Entries = -1;

        public static void Init()
        {
            if (Version == RomVersion.English)
            {
                Address = 0xD23494;
                Length = Rom.ReadUShort(Address);
                Entries = Rom.ReadUShort(Address + 2);
            }
        }

        public static string GetName(int index)
        {
            return TextProvider.GetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }

        public static void SetName(int index, string str)
        {
            TextProvider.SetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, str);
        }
    }

    public class TextMusicNames : M3Rom
    {
        public static int Address = -1;
        public static int Entries = -1;

        public static void Init()
        {
            Address = Rom.ReadPtr(0x1C8F38C);
            Entries = Rom.ReadUShort(Address + 8);
        }

        public static string GetName(int index)
        {
            int a = Address + 12 + (index << 1);

            int addr = Rom.ReadUShort(a);
            if (Version == RomVersion.English)
                addr <<= 1;

            addr += Address;

            return TextProvider.GetText(addr,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }
    }

    public class TextItemDescriptions : M3Rom
    {
        public static int Address = -1;
        public static int Entries = 256;

        public static void Init()
        {
            Address = Rom.ReadInt(0xD1EE88) + 0xD1EE78;
        }

        public static string GetDescription(int index)
        {
            int a = Address + (index << 1);
            int addr = Rom.ReadUShort(a);
            addr += Address + (Entries << 1);

            return TextProvider.GetText(addr, 1024,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }
    }

    public class TextEnemyDescriptions : M3Rom
    {
        public static int Address = -1;
        public static int Entries = 257;

        public static void Init()
        {
            Address = Rom.ReadInt(0x1B90134) + 0x1B8FFBE;
        }

        public static string GetDescription(int index)
        {
            int a = Address + (index << 1);
            int addr = Rom.ReadUShort(a);
            addr += Address + (Entries << 1);

            return TextProvider.GetText(addr, 1024,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }
    }

    public class TextBattle : M3Rom
    {
        public static int Address = -1;
        public static int Entries = -1;

        public static void Init()
        {
            Address = Rom.ReadPtr(0x1C92698) + 0x1C90960;
            Entries = Rom.ReadUShort(Address + 8);
        }

        public static string GetText(int index)
        {
            int a = Address + 12 + (index << 1);

            int addr = Rom.ReadUShort(a);
            if (Version == RomVersion.English)
                addr <<= 1;

            addr += Address;

            return TextProvider.GetText(addr, 1024,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }
    }

    // This is how the game assigns a speaker name for each sprite
    // It's not entirely accurate though, so we won't use it
    public class TextSpriteNames : M3Rom
    {
        public static string GetName(int index)
        {
            if (index < 0x100)
                return TextCharNames.GetName(index);

            else if ((index >= 0x100) && (index < 0x26C))
                return TextEnemyNames.GetName(index - 0x100);

            else if ((index >= 0x26C) && (index < 0x2BB))
            {
                if (index == 0x287)
                    return "Kumatora (Pigmask in water)";

                else if (index == 0x289)
                    return "Lucas (holding a hammer)";

                else if (index == 0x28A)
                    return "Flint (injured, no hat)";

                else
                {
                    index -= 0x16C;
                    short ch = 0;
                    for (int i = 0; ; i++)
                    {
                        ch = Rom.ReadShort(0xCDB8BC + (i << 2));
                        if (ch == -1) break;
                        else if (ch == index)
                            return TextPCharNames.GetName(Rom.ReadUShort(0xCDB8BE + (i << 2)));
                    }
                    return TextCharNames.GetName(index);
                }
            }

            else if (index == 0x2CF)
                return "Flint (picking himself up)";

            else
                return "(Empty)";
        }
    }

    public class TextCharNames : M3Rom
    {
        public static int Address = -1;
        public static int Length = -1;
        public static int Entries = -1;

        public static void Init()
        {
            Address = Rom.ReadInt(0xD1EE90) + 0xD1EE78;
            Length = Rom.ReadUShort(Address);
            Entries = Rom.ReadUShort(Address + 2);
        }

        public static string GetName(int index)
        {
            return TextProvider.GetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }

        public static void SetName(int index, string str)
        {
            TextProvider.SetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, str);
        }
    }

    public class TextPCharNames : M3Rom
    {
        public static int Address = 0xD28F30;
        public static int Length = 9;
        public static int Entries = 16;

        public static string GetName(int index)
        {
            return TextProvider.GetText(Address + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }

        public static void SetName(int index, string str)
        {
            TextProvider.SetText(Address + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, str);
        }
    }

    public class TextDontCareNames : M3Rom
    {
        public static int Address = -1;
        public static int Length = -1;
        public static int Entries = -1;

        public static void Init()
        {
            Address = Rom.ReadInt(0xD1EEAC) + 0xD1EE78;
            Length = Rom.ReadUShort(Address);
            Entries = Rom.ReadUShort(Address + 2);
        }

        public static string GetName(int index)
        {
            return TextProvider.GetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }

        public static void SetName(int index, string str)
        {
            TextProvider.SetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, str);
        }
    }

    public class TextMain : M3Rom
    {
        public static int Address = 0x136A6F4;
        public static int Entries = -1;
        public static int[] Lines;

        public static void Init()
        {
            Entries = Rom.ReadUShort(Address) >> 1;
            Lines = new int[Entries];

            for (int i = 0; i < Entries; i++)
                Lines[i] = GetNumLines(i);
        }

        public static int GetNumLines(int room)
        {
            // Get the main pointer
            int a = Rom.ReadInt(Address + 4 + (room << 3));
            if (a == 0) return -1;
            a += Address;

            // Scan the table until we hit -1
            ushort e = 0;
            int num = -1;
            Rom.Seek(a);
            while (e != 0xFFFF)
            {
                e = Rom.ReadUShort();
                num++;
            }

            return num;
        }

        public static string GetLine(int room, int line)
        {
            if (Lines[room] == -1) return null;

            // Get the main pointer
            int a = Rom.ReadInt(Address + 4 + (room << 3));
            if (a == 0) return null;
            a += Address;

            int addr = Rom.ReadUShort(a + (line << 1));
            addr += a + (Lines[room] << 1);

            return TextProvider.GetText(addr, 0x7FFFFFFF,
                (M3Rom.Version == RomVersion.Japanese ? TextType.Japanese : TextType.EnglishShort), false);
        }
    }

    public class TextMapNames : M3Rom
    {
        public static int Address = 0xD1EEBE;
        public static int Entries = -1;
        private static int EndAddress = -1;

        public static void Init()
        {
            ushort ch = 0;
            Rom.Seek(Address);
            Entries = -1;
            while (ch != 0xFFFF)
            {
                ch = Rom.ReadUShort();
                Entries++;
            }
            EndAddress = DataOps.Offset;
        }

        public static string GetName(int index)
        {
            int a = Rom.ReadUShort(Address + (index << 1));
            a += EndAddress;
            return TextProvider.GetText(a, 1024,
                (M3Rom.Version == RomVersion.Japanese ? TextType.Japanese : TextType.EnglishWide), true);
        }
    }

    public class TextPsiNames : M3Rom
    {
        public static int Address = -1;
        public static int Length = -1;
        public static int Entries = -1;

        public static void Init()
        {
            Address = Rom.ReadInt(0xD1EE9C) + 0xD1EE78;
            Length = Rom.ReadUShort(Address);
            Entries = Rom.ReadUShort(Address + 2);
        }

        public static string GetName(int index)
        {
            return TextProvider.GetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, true);
        }

        public static void SetName(int index, string str)
        {
            TextProvider.SetText(Address + 4 + (index * Length * 2), Length,
                (Version == RomVersion.Japanese) ? TextType.Japanese : TextType.EnglishWide, str);
        }
    }

    public enum TextType
    {
        Japanese,
        EnglishWide,
        EnglishShort
    }
}

