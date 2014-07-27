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
    public partial class frmMapViewer : M3Form
    {
        // Layer stuff
        CheckBox[] chkLayer = new CheckBox[3];

        bool loading = false;

        // Text cache
        string[] mapnames = new string[TextMapNames.Entries - 1];

        public frmMapViewer()
        {
            InitializeComponent();

            // Draw the layer stuff
            for (int i = 0; i < 3; i++)
            {
                var cb = new CheckBox();

                cb.AutoSize = true;
                cb.Text = "Layer " + (i + 1).ToString();
                cb.Checked = true;
                cb.Left = 53 + (i * 120);
                cb.Top = 39;
                cb.Visible = true;

                cb.CheckedChanged += new EventHandler(cboRoom_SelectedIndexChanged);

                this.Controls.Add(cb);
                chkLayer[i] = cb;
            }

            MapData.Init();

            // Load the map names
            loading = true;
            Helpers.CheckFont(cboRoom);
            cboRoom.JapaneseSearch = M3Rom.Version == RomVersion.Japanese;
            for (int i = 0; i < mapnames.Length - 1; i++)
            {
                mapnames[i] = TextMapNames.GetName(i + 1);
                cboRoom.Items.Add("[" + i.ToString("X3") + "] " +
                    mapnames[i].Replace(Environment.NewLine, " "));
            }
            loading = false;
            cboRoom.SelectedIndex = 0;
        }

        private void cboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            int flags = 0;
            for (int i = 0; i < 3; i++)
                flags |= (chkLayer[i].Checked ? (1 << i) : 0);

            pMap.Image = MapData.GetMap(cboRoom.SelectedIndex, flags, false);
            pMap.Refresh();
        }

        private void mnuMapCopy_Click(object sender, EventArgs e)
        {
            Helpers.GraphicsCopy(sender);
        }

        private void mnuMapSave_Click(object sender, EventArgs e)
        {
            Helpers.GraphicsSave(sender, dlgSaveImage);
        }

        public override void SelectIndex(int[] index)
        {
            cboRoom.SelectedIndex = index[0];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboRoom.SelectedIndex };
        }
    }
}
