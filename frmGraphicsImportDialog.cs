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
	public partial class frmGraphicsImportDialog : Form
	{
		public bool UseCurrentTileset
		{
			get
			{
				return chkTileset.Checked;
			}
		}

		public bool UseFlips
		{
			get
			{
				return chkFlips.Checked;
			}
		}

		public bool UseCurrentPalette
		{
			get
			{
				return chkPal.Checked;
			}
		}

		public bool UseTransparency
		{
			get
			{
				return chkTransparent.Checked;
			}
		}

		public Color TransparentColor
		{
			get
			{
				return lblTransparent.BackColor;
			}
		}
		public frmGraphicsImportDialog()
		{
			InitializeComponent();
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
	}
}
