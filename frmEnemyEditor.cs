using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MOTHER3;
using Extensions;

namespace MOTHER3Funland
{
    public partial class frmEnemyEditor : M3Form
    {
        bool loading = false;
        bool loading2 = false;

        // Weakness stuff
        Label[] lblWeakness = new Label[20];
        TextBox[] txtWeakness = new TextBox[20];

        // Item stuff
        LinkLabel[] lblItem = new LinkLabel[3];
        Label[] lblItemChance = new Label[3];
        ComboBox[] cboItem = new ComboBox[3];
        TextBox[] txtItemChance = new TextBox[3];

        // Action stuff
        Label[] lblAction = new Label[8];
        ComboBox[] cboAction = new ComboBox[8];

        // Text cache
        string[] itemNames = new string[TextItemNames.Entries];
        string[] enemyNames = new string[TextEnemyNames.Entries];
        string[] enemyShortNames = null;
        string[] musicNames = new string[MusicPlayerTable.Entries];
        string[] actions = new string[ActionTable.Entries];
        string[] battletext = new string[TextBattle.Entries];

        public frmEnemyEditor()
        {
            InitializeComponent();

            this.Invalidate();

            Helpers.CheckFont(cboMusicSwirl);
            Helpers.CheckFont(cboMusicBattle);
            Helpers.CheckFont(cboMusicWin);
            Helpers.CheckFont(cboTextDeath);
            Helpers.CheckFont(cboTextEncounter);
            Helpers.CheckFont(cboEnemy);
            Helpers.CheckFont(txtName);
            Helpers.CheckFont(txtShortName);
            Helpers.CheckFont(txtDescription);
            cboEnemy.JapaneseSearch = M3Rom.Version == RomVersion.Japanese;
            txtShortName.ReadOnly = M3Rom.Version != RomVersion.English;

            // Load item names
            for (int i = 0; i < itemNames.Length; i++)
                itemNames[i] = TextItemNames.GetName(i);

            // Load the enemy names
            for (int i = 0; i < enemyNames.Length; i++)
                enemyNames[i] = TextEnemyNames.GetName(i);

            // Load the enemy short names
            if (M3Rom.Version == RomVersion.English)
            {
                enemyShortNames = new string[TextEnemyShortNames.Entries];
                for (int i = 0; i < enemyShortNames.Length; i++)
                    enemyShortNames[i] = TextEnemyShortNames.GetName(i);
            }
            else
            {
                txtShortName.Enabled = false;
            }

            // Load the music names
            for (int i = 0; i < musicNames.Length; i++)
            {
                musicNames[i] = TextMusicNames.GetName(i);
                string str = "[" + i.ToString("X2") + "] " + musicNames[i];
                cboMusicSwirl.Items.Add(str);
                cboMusicBattle.Items.Add(str);
                cboMusicWin.Items.Add(str);
            }

            // Load the action names
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i] = TextBattle.GetText(ActionTable.Actions[i].Data[0x12]);
            }

            // Load the battle text
            for (int i = 0; i < battletext.Length; i++)
            {
                battletext[i] = TextBattle.GetText(i);
                if (i < 0x100)
                {
                    string strb = "[" + i.ToString("X2") + "] " + battletext[i];
                    cboTextEncounter.Items.Add(strb);
                    cboTextDeath.Items.Add(strb);
                }
            }

            // Load the background list
            loading2 = true;
            for (int i = 0; i < GfxBattleBg.MasterEntries; i++)
            {
                cboBg.Items.Add(i.ToString("X2"));
            }
            loading2 = false;

            // Draw the weakness stuff
            string[] weaknesses = Properties.Resources.weaknesses.SplitN();
            for (int i = 0; i < 20; i++)
            {
                int colWidth = ((tabWeaknesses.ClientSize.Width - 12) / 2);

                Label l = new Label();

                l.AutoSize = true;
                l.Text = weaknesses[i];
                l.Left = ((i / 10) * colWidth) + 6;
                l.Top = ((i % 10) * 27) + 9;

                tabWeaknesses.Controls.Add(l);
                lblWeakness[i] = l;

                TextBox t = new TextBox();

                t.Width = 64;
                t.Left = l.Left + 96;
                t.Top = ((i % 10) * 27) + 7;
                t.MaxLength = 5;

                tabWeaknesses.Controls.Add(t);
                txtWeakness[i] = t;
            }

            // Draw item stuff
            int vBase = txtDp.Top + 39;
            for (int i = 0; i < 3; i++)
            {
                LinkLabel l1 = new LinkLabel();

                l1.AutoSize = true;
                l1.Text = "Item " + (i + 1).ToString();
                l1.Left = 6;
                l1.Top = vBase + 2;
                l1.Tag = i;

                l1.LinkClicked += (s, e) =>
                {
                    LinkLabel ll = s as LinkLabel;
                    int index = (int)ll.Tag;

                    ModuleArbiter.ShowSelect(typeof(frmItemEditor), cboItem[index].SelectedIndex);
                };

                tabBasic.Controls.Add(l1);
                lblItem[i] = l1;

                ComboBox c = new ComboBox();

                Helpers.CheckFont(c);

                for (int j = 0; j < itemNames.Length; j++)
                    c.Items.Add("[" + j.ToString("X2") + "] " + itemNames[j]);

                c.Width = 160;
                c.DropDownStyle = ComboBoxStyle.DropDownList;
                c.Left = txtDp.Left;
                c.Top = vBase;

                tabBasic.Controls.Add(c);
                cboItem[i] = c;

                vBase += 27;

                Label l2 = new Label();
                l2.AutoSize = true;
                l2.Text = l1.Text + " %";
                l2.Left = 6;
                l2.Top = vBase + 2;

                tabBasic.Controls.Add(l2);
                lblItemChance[i] = l2;

                TextBox t = new TextBox();
                t.Width = 96;
                t.Left = txtDp.Left;
                t.Top = vBase;

                tabBasic.Controls.Add(t);
                txtItemChance[i] = t;

                vBase += 27;
            }

            // Draw the action stuff
            vBase = cboTextDeath.Top + 39;
            for (int i = 0; i < 8; i++)
            {
                Label l = new Label();

                l.AutoSize = true;
                l.Text = "Action " + (i + 1).ToString();
                l.Left = 6;
                l.Top = vBase + 2;

                tabBattle.Controls.Add(l);
                lblAction[i] = l;

                ComboBox c = new ComboBox();

                Helpers.CheckFont(c);
                for (int j = 0; j < actions.Length; j++)
                    c.Items.Add("[" + j.ToString("X3") + "] " + actions[j].Replace(Environment.NewLine, " "));

                c.Width = 320;
                c.DropDownStyle = ComboBoxStyle.DropDownList;
                c.Left = txtMusicWin.Left;
                c.Top = vBase;

                tabBattle.Controls.Add(c);
                cboAction[i] = c;

                vBase += 27;
            }

            // Load enemy data
            EnemyData.Init();

            loading = true;
            for (int i = 0; i < EnemyData.Entries; i++)
                cboEnemy.Items.Add("[" + i.ToString("X2") + "] " + enemyNames[i]);
            loading = false;
            cboEnemy.SelectedIndex = 0;
        }

        private void cboEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            int index = cboEnemy.SelectedIndex;
            var ed = EnemyData.Enemies[index];

            txtName.Text = enemyNames[index];
            if (M3Rom.Version == RomVersion.English)
                txtShortName.Text = enemyShortNames[index];
            txtDescription.Text = TextEnemyDescriptions.GetDescription(index + 1);

            txtLevel.Text = ed.Level.ToString();
            txtHp.Text = ed.Hp.ToString();
            txtPp.Text = ed.Pp.ToString();
            txtExp.Text = ed.Exp.ToString();
            txtDp.Text = ed.Dp.ToString();

            txtOff.Text = ed.Off.ToString();
            txtDef.Text = ed.Def.ToString();
            txtIq.Text = ed.Iq.ToString();
            txtSpeed.Text = ed.Speed.ToString();

            txtOffBack.Text = ed.OffBack.ToString();
            txtDefBack.Text = ed.DefBack.ToString();
            txtIqBack.Text = ed.IqBack.ToString();
            txtSpeedBack.Text = ed.SpeedBack.ToString();

            for (int i = 0; i < 20; i++)
                txtWeakness[i].Text = ed.Weaknesses[i].ToString();

            for (int i = 0; i < 3; i++)
            {
                cboItem[i].SelectedIndex = ed.Item[i];
                txtItemChance[i].Text = ed.ItemChance[i].ToString();
            }

            int ms = ed.MusicSwirl;
            int mb = ed.MusicBattle;
            int mw = ed.MusicWin;

            loading2 = true;
            txtMusicSwirl.Text = ms.ToString();
            txtMusicBattle.Text = mb.ToString();
            txtMusicWin.Text = mw.ToString();

            cboMusicSwirl.SelectedIndex =
                MusicPlayerTable.TableLookup.ContainsKey(ms) ? MusicPlayerTable.TableLookup[ms] : -1;

            cboMusicBattle.SelectedIndex =
                MusicPlayerTable.TableLookup.ContainsKey(mb) ? MusicPlayerTable.TableLookup[mb] : -1;

            cboMusicWin.SelectedIndex =
                MusicPlayerTable.TableLookup.ContainsKey(mw) ? MusicPlayerTable.TableLookup[mw] : -1;

            loading2 = false;

            for (int i = 0; i < 8; i++)
            {
                int a = ed.Action[i];
                if (a < actions.Length)
                    cboAction[i].SelectedIndex = a;
                else
                    cboAction[i].SelectedIndex = -1;
            }

            cboTextEncounter.SelectedIndex = ed.TextEncounter;
            cboTextDeath.SelectedIndex = ed.TextDeath;

            Bitmap[] bmpBattleSprites = GfxBattleSprites.GetEnemySprite(index);
            pFront.Image = bmpBattleSprites[0];
            pBack.Image = bmpBattleSprites[1];
            pFront.Refresh();
            pBack.Refresh();

            loading2 = true;
            if (cboShowLayer.SelectedIndex < 0) cboShowLayer.SelectedIndex = 0;
            cboBg.SelectedIndex = (ed.Bg < GfxBattleBg.MasterEntries) ? ed.Bg : -1; ;
            loading2 = false;

            cboShowLayer_SelectedIndexChanged(null, null);

            pSprite.Image = SpriteData.GetSprite(0, index + 0x100, 0);
        }

        private void cboMusicSwirl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            loading2 = true;
            txtMusicSwirl.Text = MusicPlayerTable.MusicTableEntries[cboMusicSwirl.SelectedIndex].Data[1].ToString();
            loading2 = false;
        }

        private void txtMusicSwirl_TextChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            loading2 = true;
            try
            {
                int m = int.Parse(txtMusicSwirl.Text);
                cboMusicSwirl.SelectedIndex = MusicPlayerTable.TableLookup[m];
            }
            catch
            {
            }
            loading2 = false;
        }

        private void cboMusicBattle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            loading2 = true;
            txtMusicBattle.Text = MusicPlayerTable.MusicTableEntries[cboMusicBattle.SelectedIndex].Data[1].ToString();
            loading2 = false;
        }

        private void txtMusicBattle_TextChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            loading2 = true;
            try
            {
                int m = int.Parse(txtMusicBattle.Text);
                cboMusicBattle.SelectedIndex = MusicPlayerTable.TableLookup[m];
            }
            catch
            {
            }
            loading2 = false;
        }

        private void cboMusicWin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            loading2 = true;
            txtMusicWin.Text = MusicPlayerTable.MusicTableEntries[cboMusicWin.SelectedIndex].Data[1].ToString();
            loading2 = false;
        }

        private void txtMusicWin_TextChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            loading2 = true;
            try
            {
                int m = int.Parse(txtMusicWin.Text);
                cboMusicWin.SelectedIndex = MusicPlayerTable.TableLookup[m];
            }
            catch
            {
            }
            loading2 = false;
        }

        private void HighlightControl(Control c)
        {
            var tp = c.Parent as TabPage;
            tabMain.SelectedTab = tp;
            c.Focus();

            if (c is TextBox)
            {
                var t = c as TextBox;
                t.SelectAll();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int index = cboEnemy.SelectedIndex;
            var ed = EnemyData.Enemies[index];

            loading = true;

            TextEnemyNames.SetName(index, txtName.Text);
            string newName = TextEnemyNames.GetName(index);
            enemyNames[index] = newName;
            cboEnemy.Items[index] = "";
            cboEnemy.Items[index] = "[" + index.ToString("X2") + "] " + newName;
            
            if (M3Rom.Version == RomVersion.English)
            {
                TextEnemyShortNames.SetName(index, txtShortName.Text);
                newName = TextEnemyShortNames.GetName(index);
                enemyShortNames[index] = newName;
            }

            loading = false;

            // Level
            try
            {
                ed.Level = ushort.Parse(txtLevel.Text);
            }
            catch
            {
                HighlightControl(txtLevel);
                return;
            }

            // HP
            try
            {
                ed.Hp = uint.Parse(txtHp.Text);
            }
            catch
            {
                HighlightControl(txtHp);
                return;
            }

            // PP
            try
            {
                ed.Pp = uint.Parse(txtPp.Text);
            }
            catch
            {
                HighlightControl(txtPp);
                return;
            }

            // Experience
            try
            {
                ed.Exp = uint.Parse(txtExp.Text);
            }
            catch
            {
                HighlightControl(txtExp);
                return;
            }

            // DP
            try
            {
                ed.Dp = uint.Parse(txtDp.Text);
            }
            catch
            {
                HighlightControl(txtDp);
                return;
            }

            // Offense
            try
            {
                ed.Off = byte.Parse(txtOff.Text);
            }
            catch
            {
                HighlightControl(txtOff);
                return;
            }

            // Defense
            try
            {
                ed.Def = byte.Parse(txtDef.Text);
            }
            catch
            {
                HighlightControl(txtDef);
                return;
            }

            // IQ
            try
            {
                ed.Iq = byte.Parse(txtIq.Text);
            }
            catch
            {
                HighlightControl(txtIq);
                return;
            }

            // Speed
            try
            {
                ed.Speed = byte.Parse(txtSpeed.Text);
            }
            catch
            {
                HighlightControl(txtSpeed);
                return;
            }

            // Offense back
            try
            {
                ed.OffBack = byte.Parse(txtOffBack.Text);
            }
            catch
            {
                HighlightControl(txtOffBack);
                return;
            }

            // Defense back
            try
            {
                ed.DefBack = byte.Parse(txtDefBack.Text);
            }
            catch
            {
                HighlightControl(txtDefBack);
                return;
            }

            // IQ back
            try
            {
                ed.IqBack = byte.Parse(txtIqBack.Text);
            }
            catch
            {
                HighlightControl(txtIqBack);
                return;
            }

            // Speed back
            try
            {
                ed.SpeedBack = byte.Parse(txtSpeedBack.Text);
            }
            catch
            {
                HighlightControl(txtSpeedBack);
                return;
            }

            // Weaknesses
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    ed.Weaknesses[i] = ushort.Parse(txtWeakness[i].Text);
                }
                catch
                {
                    HighlightControl(txtWeakness[i]);
                    return;
                }
            }

            // Items
            for (int i = 0; i < 3; i++)
            {
                ed.Item[i] = (byte)cboItem[i].SelectedIndex;
                try
                {
                    ed.ItemChance[i] = int.Parse(txtItemChance[i].Text);
                    if (ed.ItemChance[i] > 0xFFFFFF) ed.ItemChance[i] = 0xFFFFFF;
                    if (ed.ItemChance[i] < 0) ed.ItemChance[i] = 0;
                }
                catch
                {
                    HighlightControl(txtItemChance[i]);
                    return;
                }
            }

            // Background
            ed.Bg = (ushort)cboBg.SelectedIndex;

            // Music swirl
            try
            {
                ed.MusicSwirl = ushort.Parse(txtMusicSwirl.Text);
            }
            catch
            {
                HighlightControl(txtMusicSwirl);
                return;
            }

            // Music battle
            try
            {
                ed.MusicBattle = ushort.Parse(txtMusicBattle.Text);
            }
            catch
            {
                HighlightControl(txtMusicBattle);
                return;
            }

            // Music win
            try
            {
                ed.MusicWin = ushort.Parse(txtMusicWin.Text);
            }
            catch
            {
                HighlightControl(txtMusicWin);
                return;
            }

            // Actions
            for (int i = 0; i < 8; i++)
                ed.Action[i] = (ushort)cboAction[i].SelectedIndex;

            // Encounter/death text
            ed.TextEncounter = (byte)cboTextEncounter.SelectedIndex;
            ed.TextDeath = (byte)cboTextDeath.SelectedIndex;

            // Save changes
            ed.Save();

            // Refresh
            cboEnemy_SelectedIndexChanged(null, null);
        }

        private void mnuGraphicsSave_Click(object sender, EventArgs e)
        {
            Helpers.GraphicsSave(sender, dlgSaveImage);
        }

        private void mnuGraphicsCopy_Click(object sender, EventArgs e)
        {
            Helpers.GraphicsCopy(sender);
        }

        private void cboShowLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            int bg = cboBg.SelectedIndex;
            if (bg == -1) pBg.Image = null;
            else pBg.Image = GfxBattleBg.GetBg(bg, cboShowLayer.SelectedIndex);
        }

        private void cboBg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            cboShowLayer_SelectedIndexChanged(null, null);
        }

        private void lblBg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModuleArbiter.ShowSelect(typeof(frmBattleBgEntryEditor), cboBg.SelectedIndex);
        }

        public override void SelectIndex(int[] index)
        {
            cboEnemy.SelectedIndex = index[0];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboEnemy.SelectedIndex };
        }

        private void lblSprite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModuleArbiter.ShowSelect(typeof(frmSpriteEditor), new int[] { 0, cboEnemy.SelectedIndex + 0x100, 0 });
        }
    }
}
