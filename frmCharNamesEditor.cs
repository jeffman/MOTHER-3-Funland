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
	public partial class frmCharNamesEditor : M3Form
	{
		bool loading = false;

		// Text cache
		string[] charnames = new string[TextCharNames.Entries];

		public frmCharNamesEditor()
		{
			InitializeComponent();

			Helpers.CheckFont(cboChar);
			Helpers.CheckFont(txtChar);
			if (M3Rom.Version == RomVersion.Japanese) cboChar.JapaneseSearch = true;

			// Load the char names
			loading = true;
			for (int i = 0; i < charnames.Length; i++)
			{
				charnames[i] = TextCharNames.GetName(i);
				cboChar.Items.Add("[" + i.ToString("X3") + "] " + charnames[i]);
			}
			loading = false;
			cboChar.SelectedIndex = 0;
		}

		private void cboChar_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loading) return;

			int index = cboChar.SelectedIndex;
			txtChar.Text = charnames[index];
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			loading = true;

			int index = cboChar.SelectedIndex;
			TextCharNames.SetName(index, txtChar.Text);
			charnames[index] = TextCharNames.GetName(index);
			cboChar.Items[index] = "";
			cboChar.Items[index] = "[" + index.ToString("X3") + "] " + charnames[index];

			loading = true;

			M3Rom.IsModified = true;

			cboChar_SelectedIndexChanged(null, null);
		}
	}
}
