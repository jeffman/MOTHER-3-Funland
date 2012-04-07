using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Timers;
using MOTHER3;
using Extensions;

namespace MOTHER3Funland
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            ModuleArbiter.MainForm = this;

            InitializeComponent();

            foreach (RowStyle r in panelMain.RowStyles)
                r.SizeType = SizeType.AutoSize;

            // Load config
            LoadSettings();

            // Build the module layout
            AddLabel("General");
            ModuleArbiter.AddModule("Compression", typeof(frmCompression));

            AddLabel("Character data");
            ModuleArbiter.AddModule("Level-up experience editor", typeof(frmLevelExpEditor));

            AddLabel("Items");
            ModuleArbiter.AddModule("Item editor", typeof(frmItemEditor));
            ModuleArbiter.AddModule("Shop editor", typeof(frmShopEditor));

            AddLabel("Enemies");
            ModuleArbiter.AddModule("Enemy editor", typeof(frmEnemyEditor));

            AddLabel("PSI");
            ModuleArbiter.AddModule("PSI editor", typeof(frmPsiEditor));
            ModuleArbiter.AddModule("PSI level-up editor", typeof(frmLevelPsiEditor));

            AddLabel("Graphics");
            ModuleArbiter.AddModule("Sprite viewer", typeof(frmSpriteEditor));
            ModuleArbiter.AddModule("Map viewer", typeof(frmMapViewer));
            ModuleArbiter.AddModule("Battle BG entry editor", typeof(frmBattleBgEntryEditor));
            ModuleArbiter.AddModule("Battle BG layer editor", typeof(frmBattleBgLayerEditor));
            ModuleArbiter.AddModule("Battle swirl editor", typeof(frmBattleSwirlEditor));
            ModuleArbiter.AddModule("Town map editor", typeof(frmTownMapEditor));

            AddLabel("Text");
            ModuleArbiter.AddModule("Main text viewer", typeof(frmMainTextViewer));
            ModuleArbiter.AddModule("Don't Care names editor", typeof(frmDontCareNamesEditor));
            ModuleArbiter.AddModule("Character names editor", typeof(frmCharNamesEditor));

            var ws = M3Settings.MainSettings.MainFormParams;
            if (ws.WindowSize == default(Size))
            {
                // If it's the first load, don't bother resizing to zero
            }
            else
            {
                this.WindowState = ws.WindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.Location = ws.WindowLoc;
                    this.Size = ws.WindowSize;
                }
            }
        }

        private void LoadSettings()
        {
            FileStream f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(M3Settings));
                f = File.OpenRead("config.xml");
                M3Settings.MainSettings = (M3Settings)xml.Deserialize(f);
            }
            catch
            {
                M3Settings.MainSettings = null;
            }
            finally
            {
                if (f != null) f.Close();
            }

            if (M3Settings.MainSettings == null)
                M3Settings.MainSettings = new M3Settings();
        }

        private void SaveSettings()
        {
            XmlSerializer xml = new XmlSerializer(typeof(M3Settings));
            xml.Serialize(File.Create("config.xml"), M3Settings.MainSettings);
        }

        private void AddLabel(string text)
        {
            Label l = new Label();
            l.AutoSize = false;
            l.Text = text;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Visible = true;

            l.BackColor = SystemColors.Control;
            l.Height = 20;
            l.Width = this.ClientSize.Width;
            l.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            l.Click += new EventHandler(LabelClick);

            panelMain.Controls.Add(l);
        }

        private void LabelClick(object sender, EventArgs e)
        {
            if (!M3Rom.IsLoaded) return;

            Label l = sender as Label;
            var c = panelMain.Controls;
            int index = c.IndexOf(l);
            bool newstate = false;

            if (l.Font.Bold)
            {
                l.Font = new Font(l.Font, FontStyle.Regular);
                l.ForeColor = Color.Black;
            }
            else
            {
                l.Font = new Font(l.Font, FontStyle.Bold);
                l.ForeColor = Color.Blue;
                newstate = true;
            }

            for (int i = index + 1; i < c.Count; i++)
            {
                if (c[i] is Button)
                {
                    c[i].Visible = newstate;
                }
                else
                {
                    break;
                }
            }
        }

        public void AddControl(Control c)
        {
            panelMain.Controls.Add(c);
        }

        private void OpenRom(string fname)
        {
            int res = M3Rom.LoadRom(fname);

            string romErr = "Error loading ROM";
            switch (res)
            {
                case -1:
                    MessageBox.Show("The file doesn't exist.", romErr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                case -2:
                    MessageBox.Show("Could not load the file. Is it in use by another process?", romErr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                case -3:
                    MessageBox.Show("The selected ROM is not 32MB.", romErr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                case -4:
                    MessageBox.Show("The selected ROM is not MOTHER 3.", romErr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            mnuFileSave.Enabled = true;
            mnuFileClose.Enabled = true;
        }

        private void SaveRom()
        {
            File.WriteAllBytes(dlgOpenRom.FileName, M3Rom.Rom);
            M3Rom.IsModified = false;
        }

        private bool CloseRom()
        {
            if (M3Rom.IsModified)
            {
                DialogResult res = MessageBox.Show("Save your changes?", "Save", MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        SaveRom();
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        return false;
                }
            }

            CloseEverything();

            M3Rom.Rom = null;
            M3Rom.IsModified = false;
            M3Rom.IsLoaded = false;

            return true;
        }

        private void CloseEverything()
        {
            ModuleArbiter.CloseForms();

            mnuFileSave.Enabled = false;
            mnuFileClose.Enabled = false;

            for (int i = 0; i < panelMain.Controls.Count; i++)
            {
                Control c = panelMain.Controls[i];
                if (c is Label)
                {
                    if ((c as Label).Font.Bold)
                        LabelClick(c, null);
                }
            }
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            dlgOpenRom.InitialDirectory = M3Settings.MainSettings.RomDirectory;
            if (dlgOpenRom.ShowDialog() == DialogResult.OK)
            {
                if (!CloseRom()) return;

                OpenRom(dlgOpenRom.FileName);

                FileInfo fi = new FileInfo(dlgOpenRom.FileName);
                M3Settings.MainSettings.RomDirectory = fi.DirectoryName;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseRom())
            {
                e.Cancel = true;
                return;
            }
            M3Settings.MainSettings.MainFormParams = new FormParams(this.Location, this.Size, this.WindowState, null);
            SaveSettings();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            SaveRom();
            MessageBox.Show("Saved!");
        }

        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            CloseRom();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            string str =
                "MOTHER 3 Funland v" + Application.ProductVersion + Environment.NewLine +
                "By JeffMan" + Environment.NewLine + Environment.NewLine +
                "Fugue icon set: (C) 2012 Yusuke Kamiyamane";

            MessageBox.Show(str, "About");
        }
    }
}
