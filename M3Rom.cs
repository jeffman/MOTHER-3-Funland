using System;
using System.Linq;
using System.IO;
using Extensions;
using System.Drawing;

namespace MOTHER3
{
    public class M3Rom
    {
        public static bool IsLoaded = false;
        public static bool IsModified = false;
        public static byte[] Rom = null;
        public static RomVersion Version;

        public static int DecodeAddress = -1;
        public static int DecodeMod = -1;

        public static int LoadRom(string filename)
        {
            if (!File.Exists(filename))
                return -1;

            try
            {
                Rom = File.ReadAllBytes(filename);
            }
            catch
            {
                return -2;
            }

            if (Rom.Length != 0x2000000)
                return -3;

            string header = "MOTHER3\0\0\0\0\0A3UJ";
            string headerTest = string.Empty;
            for (int i = 0xA0; i < 0xB0; i++)
                headerTest += (char)Rom[i];
            if (!header.Equals(headerTest))
                return -4;

            IsLoaded = true;
            Version = (Rom[0x124C18] == 0x9C) ? RomVersion.English : RomVersion.Japanese;

            if (Rom[0x1DB4] == 0x73)
            {
                DecodeAddress = 0x13C5F2;
                DecodeMod = 0x10E;
            }
            else
            {
                DecodeAddress = 0x13C5D8;
                DecodeMod = 0x126;
            }

            GfxProvider.RomTileCache.Clear();

            M3CC.Init();
            TextProvider.Init();
            TextItemNames.Init();
            TextEnemyNames.Init();
            TextEnemyShortNames.Init();
            TextMusicNames.Init();
            TextItemDescriptions.Init();
            TextEnemyDescriptions.Init();
            TextBattle.Init();
            TextMain.Init();
            TextMapNames.Init();
            TextPsiNames.Init();
            TextCharNames.Init();
            TextDontCareNames.Init();

            GfxBattleTable.Init();
            GfxBattleSprites.Init();
            GfxItems.Init();
            GfxBattleAnimations.Init();
            GfxBattleBgTable.Init();
            GfxBattleBg.Init();
            GfxTownMaps.Init();
            GfxLogoTitle.Init();

            SpriteData.Init();

            MusicPlayerTable.Init();
            ActionTable.Init();

            SongTable.Init();

            return 0;
        }
    }
    
    public enum RomVersion
    {
        Japanese,
        English
    }
}

