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
	public partial class frmDontCareNamesEditor : M3Form
	{
		bool loading = false;

		TextBox[] txtName = new TextBox[7];
		
		// Text cache
		string[] charnames = new string[10];

		public frmDontCareNamesEditor()
		{
			InitializeComponent();

			Helpers.CheckFont(cboChar);

			// Draw the text boxes
			for (int i = 0; i < 7; i++)
			{
				var t = new TextBox();

				t.Width = 160;
				t.Height = 20;
				t.Top = cboChar.Top + ((i + 1) * 27);
				t.Left = cboChar.Left;

				this.Controls.Add(t);
				txtName[i] = t;

				Helpers.CheckFont(t);
			}

			// Get the default names
			loading = true;
			for (int i = 0; i < 10; i++)
			{
				charnames[i] = TextDontCareNames.GetName(i * 7);
				cboChar.Items.Add("[" + i.ToString("X2") + "] " + charnames[i]);
			}
			loading = false;
			cboChar.SelectedIndex = 0;
		}

		private void cboChar_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loading) return;

			int index = cboChar.SelectedIndex;

			for (int i = 0; i < 7; i++)
			{
				txtName[i].Text = TextDontCareNames.GetName((index * 7) + i);
			}
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			int index = cboChar.SelectedIndex;

			loading = true;

			for (int i = 0; i < 7; i++)
			{
				TextDontCareNames.SetName((index * 7) + i, txtName[i].Text);
			}

			charnames[index] = TextDontCareNames.GetName(index * 7);
			cboChar.Items[index] = "";
			cboChar.Items[index] = "[" + index.ToString("X2") + "] " + charnames[index];

			loading = false;

			M3Rom.IsModified = true;

			cboChar_SelectedIndexChanged(null, null);
		}
	}
}
