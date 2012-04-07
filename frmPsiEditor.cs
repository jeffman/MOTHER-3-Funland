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
	public partial class frmPsiEditor : M3Form
	{
		bool loading = true;

		// Animation stuff
		Label[] lblAnimation = new Label[2];
		ComboBox[] cboAnimation = new ComboBox[2];

		// Text cache
		string[] psinames = new string[TextPsiNames.Entries];

		public frmPsiEditor()
		{
			InitializeComponent();

			// Draw the animation stuff
			string[] psianims = Properties.Resources.psianimations.SplitN();
			for (int i = 0; i < 2; i++)
			{
				var l = new Label();
				l.AutoSize = true;
				l.Text = "Animation " + (i + 1).ToString();
				l.Left = 12;
				l.Top = txtAmountHigh.Top + 29 + (i * 27);
				l.Visible = true;

				this.Controls.Add(l);
				lblAnimation[i] = l;

				var c = new ComboBox();
				c.Left = 100;
				c.Top = l.Top - 3;
				c.Width = 216;
				c.DropDownStyle = ComboBoxStyle.DropDownList;
				c.Visible = true;

				for (int j = 0; j < psianims.Length; j++)
				{
					c.Items.Add("[" + j.ToString("X2") + "] " + psianims[j]);
				}

				this.Controls.Add(c);
				cboAnimation[i] = c;
			}

			// Load the PSI names
			for (int i = 0; i < psinames.Length; i++)
				psinames[i] = TextPsiNames.GetName(i);

			// Load the PSI types
			cboType.Items.Add("[00] Offense");
			cboType.Items.Add("[01] Recover");
			cboType.Items.Add("[02] Assist");

			// Load the PSI targets
			string[] targets = Properties.Resources.psitargets.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			for (int i = 0; i < targets.Length; i++)
				cboTarget.Items.Add("[" + i.ToString("X2") + "] " + targets[i]);

			// Load the data
			PsiData.Init();
			Helpers.CheckFont(cboPsi);
			Helpers.CheckFont(txtPsiName);
			loading = true;
			for (int i = 0; i < PsiData.Entries; i++)
				cboPsi.Items.Add("[" + i.ToString("X2") + "] " + psinames[i]);
			loading = false;
			cboPsi.SelectedIndex = 0;
		}

		private void cboPsi_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loading) return;

			int index =cboPsi.SelectedIndex;

			var pd = PsiData.PsiEntries[index];

			// Type
			if (pd.Type < cboType.Items.Count)
				cboType.SelectedIndex = pd.Type;
			else
				cboType.SelectedIndex = -1;

			// Target
			if (pd.Target < cboTarget.Items.Count)
				cboTarget.SelectedIndex = pd.Target;
			else
				cboTarget.SelectedIndex = -1;

			// PP
			txtPp.Text = pd.Pp.ToString();

			// Recovery (low)
			txtAmountLow.Text = pd.AmountLow.ToString();

			// Recovery (high)
			txtAmountHigh.Text = pd.AmountHigh.ToString();

			// Animations
			for (int i = 0; i < 2; i++)
				cboAnimation[i].SelectedIndex = pd.Animation[i];

			// Name
			txtPsiName.Text = psinames[index];
		}

		private void HighlightControl(Control c)
		{
			if (c is TextBox)
			{
				(c as TextBox).Focus();
				(c as TextBox).SelectAll();
			}
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			int index = cboPsi.SelectedIndex;

			var pd = PsiData.PsiEntries[index];

			pd.Type = (byte)cboType.SelectedIndex;
			pd.Target = (byte)cboTarget.SelectedIndex;

			loading = true;
			TextPsiNames.SetName(index, txtPsiName.Text);
			psinames[index] = TextPsiNames.GetName(index);
			cboPsi.Items[index] = "";
			cboPsi.Items[index] = "[" + index.ToString("X2") + "] " + psinames[index];
			loading = false;

			// PP
			try
			{
				pd.Pp = ushort.Parse(txtPp.Text);
			}
			catch
			{
				HighlightControl(txtPp);
				return;
			}

			// Amount (low)
			try
			{
				pd.AmountLow = ushort.Parse(txtAmountLow.Text);
			}
			catch
			{
				HighlightControl(txtAmountLow);
				return;
			}

			// Amount (high)
			try
			{
				pd.AmountHigh = ushort.Parse(txtAmountHigh.Text);
			}
			catch
			{
				HighlightControl(txtAmountHigh);
				return;
			}

			// Animations
			for (int i = 0; i < 2; i++)
				pd.Animation[i] = (byte)cboAnimation[i].SelectedIndex;

			pd.Save();
			cboPsi_SelectedIndexChanged(null, null);
		}

		public override void SelectIndex(int[] index)
		{
			cboPsi.SelectedIndex = index[0];
		}

		public override int[] GetIndex()
		{
			return new int[] { cboPsi.SelectedIndex };
		}
	}
}
