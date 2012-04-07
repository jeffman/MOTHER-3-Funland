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
    public partial class frmMainTextViewer : M3Form
    {
        public static Bitmap formIcon = Properties.Resources.sparrow;

        bool loading = false;
        bool loading2 = false;

        // Text cache
        string[] mapnames = new string[TextMapNames.Entries];

        public frmMainTextViewer()
        {
            InitializeComponent();
        
            Helpers.CheckFont(cboRoom);
            Helpers.CheckFont(lstLines);
            Helpers.CheckFont(txtLine);
            cboRoom.JapaneseSearch = M3Rom.Version == RomVersion.Japanese;

            // Load the map names
            loading = true;
            for (int i = 0; i < mapnames.Length; i++)
            {
                mapnames[i] = TextMapNames.GetName(i);
                cboRoom.Items.Add("[" + i.ToString("X3") + "] " +
                    mapnames[i].Replace(Environment.NewLine, " "));
            }
            loading = false;
            cboRoom.SelectedIndex = 0;
        }

        private void cboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            lstLines.Items.Clear();
            txtLine.Text = "";

            int room = cboRoom.SelectedIndex;
            int lines = TextMain.GetNumLines(room);

            loading2 = true;
            for (int i = 0; i < lines; i++)
            {
                string str = "[" + i.ToString("X3") + "] " + TextMain.GetLine(room, i).Replace(Environment.NewLine, "");
                if (str.Length > 500)
                    lstLines.Items.Add(str.Substring(0, 500) + " [...]");
                else
                    lstLines.Items.Add(str);
            }
            loading2 = false;
            if (lines > 0)
                lstLines.SelectedIndex = 0;
        }

        private void lstLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading2) return;

            txtLine.Text = TextMain.GetLine(cboRoom.SelectedIndex, lstLines.SelectedIndex);
        }

        public override void SelectIndex(int[] index)
        {
            cboRoom.SelectedIndex = index[0];
            lstLines.SelectedIndex = index[1];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboRoom.SelectedIndex, lstLines.SelectedIndex };
        }
    }
}
