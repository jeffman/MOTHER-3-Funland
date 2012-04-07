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
    public partial class frmLevelPsiEditor : M3Form
    {
        bool loading = false;
        bool loading2 = false;

        // Text cache
        string[] psinames = new string[TextPsiNames.Entries];

        public frmLevelPsiEditor()
        {
            InitializeComponent();

            Helpers.CheckFont(cboEntry);
            Helpers.CheckFont(cboPsi);

            // Load the PSI names
            for (int i = 0; i < psinames.Length; i++)
            {
                psinames[i] = TextPsiNames.GetName(i);
                cboPsi.Items.Add("[" + i.ToString("X2") + "] " + psinames[i]);
            }

            // Load the data
            LevelPsiData.Init();
            loading = true;
            cboChar.Items.Add("Lucas");
            cboChar.Items.Add("Kumatora");
            loading = false;
            cboChar.SelectedIndex = 0;
        }

        private void cboChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            int index = cboChar.SelectedIndex;
            var pd = LevelPsiData.LevelPsiEntries[index];

            loading2 = true;
            cboEntry.Items.Clear();
            for (int i = 0; i < pd.Length; i++)
                cboEntry.Items.Add("[" + i.ToString("X2") + "] " + psinames[pd[i].First]);
            loading2 = false;
            cboEntry.SelectedIndex = 0;
        }

        private void lblPsi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ll = sender as LinkLabel;
            ModuleArbiter.ShowSelect(typeof(frmPsiEditor), cboPsi.SelectedIndex);
        }

        private void cboEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            int cindex = cboChar.SelectedIndex;
            int pindex = cboEntry.SelectedIndex;
            var pd = LevelPsiData.LevelPsiEntries[cindex][pindex];

            cboPsi.SelectedIndex = pd.First;
            txtLevel.Text = pd.Second.ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int cindex = cboChar.SelectedIndex;
            int pindex = cboEntry.SelectedIndex;
            var pd = LevelPsiData.LevelPsiEntries[cindex][pindex];

            pd.First = (ushort)cboPsi.SelectedIndex;

            // Level
            try
            {
                pd.Second = ushort.Parse(txtLevel.Text);
            }
            catch
            {
                txtLevel.Focus();
                txtLevel.SelectAll();
            }

            pd.Save();
            cboEntry_SelectedIndexChanged(null, null);
        }

        public override void SelectIndex(int[] index)
        {
            cboChar.SelectedIndex = index[0];
            cboEntry.SelectedIndex = index[1];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboChar.SelectedIndex, cboEntry.SelectedIndex };
        }
    }
}
