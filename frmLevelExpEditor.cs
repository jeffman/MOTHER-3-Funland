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
    public partial class frmLevelExpEditor : M3Form
    {
        bool loading = false;
        bool loading2 = false;

        // Level stuff
        Label[] lblLevel = new Label[10];
        TextBox[] txtLevel = new TextBox[10];

        // Text cache
        string[] pcharnames = new string[TextPCharNames.Entries];

        public frmLevelExpEditor()
        {
            InitializeComponent();

            // Load the char names
            for (int i = 0; i < pcharnames.Length; i++)
                pcharnames[i] = TextPCharNames.GetName(i);

            // Draw the level stuff
            for (int i = 0; i < 10; i++)
            {
                var l = new Label();

                l.AutoSize = true;
                l.Left = 12;
                l.Top = cboLevelRange.Top + ((i + 1) * 27) + 2;

                this.Controls.Add(l);
                lblLevel[i] = l;

                var t = new TextBox();

                t.Left = cboLevelRange.Left;
                t.Top = l.Top - 2;
                t.Width = 96;

                this.Controls.Add(t);
                txtLevel[i] = t;
            }

            // Load the data
            LevelExpData.Init();
            Helpers.CheckFont(cboChar);

            loading = true;

            for (int i = 0; i < 9; i++)
                cboLevelRange.Items.Add("Levels " + ((i * 10) + 1).ToString() +
                    " to " + ((i + 1) * 10) .ToString());
            cboLevelRange.Items.Add("Levels 91 to 99");
            cboLevelRange.SelectedIndex = 0;

            for (int i = 0; i < 16; i++)
                cboChar.Items.Add("[" + i.ToString("X2") + "] " + pcharnames[i]);

            loading = false;

            cboChar.SelectedIndex = 0;
        }

        private void cboChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            int cindex = cboChar.SelectedIndex;
            int lindex = cboLevelRange.SelectedIndex;

            if (lindex == 9)
            {
                lblLevel[9].Visible = false;
                txtLevel[9].Visible = false;
            }
            else
            {
                lblLevel[9].Visible = true;
                txtLevel[9].Visible = true;
            }

            for (int i = 0; i < 10; i++)
            {
                int tindex = ((lindex * 10) + i);
                lblLevel[i].Text = "Level " + ((lindex * 10) + i + 1).ToString();
                if (tindex < 99)
                    txtLevel[i].Text = LevelExpData.LevelExpEntries[cindex]
                        .Data[(lindex * 10) + i].ToString();
            }

            if (!loading2)
                txtName.Text = pcharnames[cindex];
        }

        private void cboLevelRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            loading2 = true;
            cboChar_SelectedIndexChanged(null, null);
            loading2 = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int cindex = cboChar.SelectedIndex;
            int lindex = cboLevelRange.SelectedIndex;

            var ed = LevelExpData.LevelExpEntries[cindex];

            loading = true;

            TextPCharNames.SetName(cindex, txtName.Text);
            string newName = TextPCharNames.GetName(cindex);
            pcharnames[cindex] = newName;
            cboChar.Items[cindex] = "";
            cboChar.Items[cindex] = "[" + cindex.ToString("X2") + "] " + newName;

            loading = false;

            for (int i = 0; i < 10; i++)
            {
                if ((lindex == 9) && (i == 9))
                    break;

                try
                {
                    ed.Data[(lindex * 10) + i] = uint.Parse(txtLevel[i].Text);
                }
                catch
                {
                    txtLevel[i].SelectAll();
                    return;
                }
            }

            ed.Save();

            cboChar_SelectedIndexChanged(null, null);
        }

        public override void SelectIndex(int[] index)
        {
            cboChar.SelectedIndex = index[0];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboChar.SelectedIndex };
        }
    }
}
