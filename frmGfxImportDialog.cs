using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MOTHER3Funland
{
    public partial class frmGfxImportDialog : Form
    {
        public frmGfxImportDialog()
        {
            InitializeComponent();

            var g = M3Settings.MainSettings.GfxImportSettings;
            chkTileset.Checked = g.UseTileset;
            chkFlips.Checked = g.UseFlips;
            chkPal.Checked = g.UsePalette;
            chkTransparent.Checked = g.UseTransparency;
            lblTransparent.BackColor = dlgTransparent.Color = g.TransparentColor;

            this.Location = g.GfxFormParams.WindowLoc;
        }

        private void chkTileset_CheckedChanged(object sender, EventArgs e)
        {
            chkFlips.Enabled = !chkTileset.Checked;
        }

        private void lblTransparent_Click(object sender, EventArgs e)
        {
            if (dlgTransparent.ShowDialog() == DialogResult.OK)
            {
                lblTransparent.BackColor = dlgTransparent.Color;
            }
        }

        private void chkPal_CheckedChanged(object sender, EventArgs e)
        {
            lblTransparent.Enabled =
                chkTransparent.Enabled =
                !chkPal.Checked;
        }

        private void frmGfxImportDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                GfxImportSettings g = new GfxImportSettings(
                    new FormParams(this.Location, new Size(), FormWindowState.Normal, null),
                    chkTileset.Checked,
                    chkFlips.Checked,
                    chkPal.Checked,
                    chkTransparent.Checked,
                    lblTransparent.BackColor);

                M3Settings.MainSettings.GfxImportSettings = g;
            }
        }
    }
}
