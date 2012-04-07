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
	public partial class frmTownMapEditor : M3Form
	{
		bool loading = false;

		// Text cache
		string[] mapnames = null;

		public frmTownMapEditor()
		{
			InitializeComponent();

			// Get the map names
			mapnames = Properties.Resources.townmapnames.SplitN();
			loading = true;
			for (int i = 0; i < mapnames.Length; i++)
				cboMap.Items.Add("[" + i.ToString("X2") + "] " + mapnames[i]);
			loading = false;
			cboMap.SelectedIndex = 0;
		}

		public override void SelectIndex(int[] index)
		{
			cboMap.SelectedIndex = index[0];

			if (index.Length == 1) return;

			arrEditor.CurrentPalette = index[1];
			arrEditor.CurrentTile = index[2];
			arrEditor.SplitMainPosition = index[3];
			arrEditor.SplitLeftPosition = index[4];
			arrEditor.GridArr = index[5] != 0;
			arrEditor.ZoomArr = index[6];
			arrEditor.GridTileset = index[7] != 0;
			arrEditor.ZoomTileset = index[8];
			arrEditor.GridTile = index[9] != 0;
			arrEditor.ZoomTile = index[10];
		}

		public override int[] GetIndex()
		{
			return new int[] {
				cboMap.SelectedIndex,
				arrEditor.CurrentPalette,
				arrEditor.CurrentTile,
				arrEditor.SplitMainPosition,
				arrEditor.SplitLeftPosition,
				arrEditor.GridArr ? 1 : 0,
				arrEditor.ZoomArr,
				arrEditor.GridTileset ? 1 : 0,
				arrEditor.ZoomTileset,
				arrEditor.GridTile ? 1 : 0,
				arrEditor.ZoomTile
			};
		}

		private void cboMap_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loading) return;

			int index = cboMap.SelectedIndex;
			
			// Arrangement
			arrEditor.Clear();

			int[] gfxEntry = GfxTownMaps.GetEntry(index * 3);
			var palette = GfxTownMaps.GetPalette((index * 3) + 1);
			var arr = GfxTownMaps.GetArr((index * 3) + 2);

			byte[] tileset = new byte[0x8000];
			Array.Copy(M3Rom.Rom, gfxEntry[0], tileset, 0, gfxEntry[1]);
			arrEditor.SetTileset(tileset, 0, -1, gfxEntry[1] >> 5);

			arrEditor.SetArrangement(arr, 64, 64);
			arrEditor.SetPalette(palette);

			arrEditor.RenderArr();
			arrEditor.RenderTileset();
			arrEditor.CurrentTile = 0;
			arrEditor.RefreshArr();
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			int index = cboMap.SelectedIndex;

			// Arrangement
			GfxTownMaps.SetArr((index * 3) + 2, arrEditor.GetArrangement());

			// Graphics
			byte[] tileset = arrEditor.GetTileset();
			int[] gfxEntry = GfxTownMaps.GetEntry(index * 3);
			Array.Copy(tileset, 0, M3Rom.Rom, gfxEntry[0], gfxEntry[1]);

			// Palette
			int[] palEntry = GfxTownMaps.GetEntry((index * 3) + 1);
			var palette = arrEditor.GetPalette();
			M3Rom.Rom.WritePal(palEntry[0], palette);

			M3Rom.IsModified = true;

			int currentpal = arrEditor.CurrentPalette;
			int currenttile = arrEditor.CurrentTile;
			int primarycol = arrEditor.PrimaryColorIndex;
			int secondarycol = arrEditor.SecondaryColorIndex;

			cboMap_SelectedIndexChanged(null, null);

			arrEditor.CurrentPalette = currentpal;
			arrEditor.PrimaryColorIndex = primarycol;
			arrEditor.SecondaryColorIndex = secondarycol;
			arrEditor.CurrentTile = currenttile;
		}
	}
}
