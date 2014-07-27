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
    public partial class frmLogoEditor : M3Form
    {
        bool loading = false;

        public frmLogoEditor()
        {
            InitializeComponent();

            // Set the tileset and palette
            arrEditor.Clear();

            var pal = GfxLogoTitle.GetLogoPalettes();
            var tileset = GfxLogoTitle.GetLogoTileset();

            arrEditor.SetPalette(pal);
            arrEditor.SetTileset(tileset);

            loading = true;
            cboLogoNum.Items.Clear();
            cboLogoNum.Items.Add("[00] Nintendo");
            cboLogoNum.Items.Add("[01] Shigesato Itoi");
            cboLogoNum.Items.Add("[02] Brownie Brown");
            cboLogoNum.Items.Add("[03] HAL");
            loading = false;

            cboLogoNum.SelectedIndex = 0;
        }

        private void cboLogoNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            var arr = GfxLogoTitle.GetLogoArr(cboLogoNum.SelectedIndex);
            arrEditor.SetArrangement(arr, 32, 32);

            arrEditor.RenderArr();
            arrEditor.RenderTileset();
            arrEditor.CurrentTile = 0;
            arrEditor.RefreshArr();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int index = cboLogoNum.SelectedIndex;

            // Arrangement
            GfxLogoTitle.SetLogoArr(index, arrEditor.GetArrangement());

            // Tileset
            GfxLogoTitle.SetLogoTileset(arrEditor.GetTileset());

            // Palette
            var pals = arrEditor.GetPalette();
            GfxLogoTitle.SetLogoPalettes(pals);

            M3Rom.IsModified = true;

            int currentpal = arrEditor.CurrentPalette;
            int currenttile = arrEditor.CurrentTile;
            int primarycol = arrEditor.PrimaryColorIndex;
            int secondarycol = arrEditor.SecondaryColorIndex;

            cboLogoNum_SelectedIndexChanged(null, null);

            arrEditor.CurrentPalette = currentpal;
            arrEditor.PrimaryColorIndex = primarycol;
            arrEditor.SecondaryColorIndex = secondarycol;
            arrEditor.CurrentTile = currenttile;
        }
    }
}
