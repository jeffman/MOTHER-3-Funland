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
	public partial class frmBattleBgLayerEditor : M3Form
	{
		bool loading = false;
		bool expanded = false;

		public frmBattleBgLayerEditor()
		{
			InitializeComponent();

			// Load the layer entries
			loading = true;
			for (int i = 0; i < GfxBattleBg.Entries; i++)
			{
				cboEntry.Items.Add(i.ToString("X2"));
			}
			loading = false;
			cboEntry.SelectedIndex = 0;
		}

		private void mnuGraphicsSave_Click(object sender, EventArgs e)
		{
			Helpers.GraphicsSave(sender, dlgSaveImage);
		}

		private void mnuGraphicsCopy_Click(object sender, EventArgs e)
		{
			Helpers.GraphicsCopy(sender);
		}

		private void cboEntry_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loading) return;

			int index = cboEntry.SelectedIndex;
			var bg = GfxBattleBg.Bgs[index];

			//pLayer.Image = GfxBattleBg.GetLayer(index);

			txtGfxEntry.Text = bg.GfxEntry.ToString();
			txtArrEntry.Text = bg.ArrEntry.ToString();
			txtPalDir.Text = bg.PalDir.ToString();
			txtPalStart.Text = bg.PalStart.ToString();
			txtPalEnd.Text = bg.PalEnd.ToString();
			txtPalDelay.Text = bg.PalDelay.ToString();

			txtDriftH.Text = bg.DriftH.ToString();
			txtDriftV.Text = bg.DriftV.ToString();
			txtAmplH.Text = bg.AmplH.ToString();
			txtAmplV.Text = bg.AmplV.ToString();
			txtFreqH.Text = bg.FreqH.ToString();
			txtFreqV.Text = bg.FreqV.ToString();
			txtWavenumH.Text = bg.WavenumH.ToString();
			txtWavenumV.Text = bg.WavenumV.ToString();

			// Arrangement stuff
			arrEditor.Clear();

			int[] gfxEntry = GfxBattleBgTable.GetEntry(bg.GfxEntry);
			arrEditor.SetTileset(M3Rom.Rom, gfxEntry[0], gfxEntry[1] >> 5);
			arrEditor.SetArrangement(GfxBattleBgTable.GetArr(bg.ArrEntry), 32, 32);
			arrEditor.SetPalette(bg.Palette);

			arrEditor.RenderArr();
			arrEditor.RenderTileset();
			arrEditor.CurrentTile = 0;
			arrEditor.RefreshArr();
		}

		public override void SelectIndex(int[] index)
		{
			// 0: Layer index
			// 1: Expanded
			// 2: Palette index
			// 3: Tile index
			// 4: splitMain position
			// 5: splitLeft position
			// 6: Arrangement grid
			// 7: Arrangement zoom
			// 8: Tileset grid
			// 9: Tileset zoom
			// 10: Tile grid
			// 11: Tile zoom

			cboEntry.SelectedIndex = index[0];

			if (index.Length == 1) return;

			if (index[1] == 1)
				lblAnim_Click(null, null);

			arrEditor.CurrentPalette = index[2];
			arrEditor.CurrentTile = index[3];
			arrEditor.SplitMainPosition = index[4];
			arrEditor.SplitLeftPosition = index[5];
			arrEditor.GridArr = index[6] != 0;
			arrEditor.ZoomArr = index[7];
			arrEditor.GridTileset = index[8] != 0;
			arrEditor.ZoomTileset = index[9];
			arrEditor.GridTile = index[10] != 0;
			arrEditor.ZoomTile = index[11];
		}

		public override int[] GetIndex()
		{
			return new int[] {
				cboEntry.SelectedIndex,
				(expanded ? 1 : 0),
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

		private void btnApply_Click(object sender, EventArgs e)
		{
			int index = cboEntry.SelectedIndex;
			var bg = GfxBattleBg.Bgs[index];

			// Gfx entry
			/*try
			{
				bg.GfxEntry = ushort.Parse(txtGfxEntry.Text);
			}
			catch
			{
				txtGfxEntry.SelectAll();
				return;
			}

			// Arr entry
			try
			{
				bg.ArrEntry = ushort.Parse(txtArrEntry.Text);
			}
			catch
			{
				txtArrEntry.SelectAll();
				return;
			}*/
			
			// Pal dir
			try
			{
				bg.PalDir = ushort.Parse(txtPalDir.Text);
			}
			catch
			{
				txtPalDir.SelectAll();
				return;
			}
			
			// Pal start
			try
			{
				bg.PalStart = ushort.Parse(txtPalStart.Text);
			}
			catch
			{
				txtPalStart.SelectAll();
				return;
			}
			
			// Pal end
			try
			{
				bg.PalEnd = ushort.Parse(txtPalEnd.Text);
			}
			catch
			{
				txtPalEnd.SelectAll();
				return;
			}
			
			// Pal delay
			try
			{
				bg.PalDelay = ushort.Parse(txtPalDelay.Text);
			}
			catch
			{
				txtPalDelay.SelectAll();
				return;
			}
			
			// Drift H
			try
			{
				bg.DriftH = short.Parse(txtDriftH.Text);
			}
			catch
			{
				txtDriftH.SelectAll();
				return;
			}
			
			// Drift V
			try
			{
				bg.DriftV = short.Parse(txtDriftV.Text);
			}
			catch
			{
				txtDriftV.SelectAll();
				return;
			}

			// Ampl H
			try
			{
				bg.AmplH = short.Parse(txtAmplH.Text);
			}
			catch
			{
				txtAmplH.SelectAll();
				return;
			}
			
			// Ampl V
			try
			{
				bg.AmplV = short.Parse(txtAmplV.Text);
			}
			catch
			{
				txtAmplV.SelectAll();
				return;
			}

			// Freq H
			try
			{
				bg.FreqH = short.Parse(txtFreqH.Text);
			}
			catch
			{
				txtFreqH.SelectAll();
				return;
			}

			// Freq V
			try
			{
				bg.FreqV = short.Parse(txtFreqV.Text);
			}
			catch
			{
				txtFreqV.SelectAll();
				return;
			}

			// Wavenum H
			try
			{
				bg.WavenumH = short.Parse(txtWavenumH.Text);
			}
			catch
			{
				txtWavenumH.SelectAll();
				return;
			}

			// Wavenum V
			try
			{
				bg.WavenumV = short.Parse(txtWavenumV.Text);
			}
			catch
			{
				txtWavenumV.SelectAll();
				return;
			}

			if (index > 0)
			{
				// Arrangement
				GfxBattleBgTable.SetArr(bg.ArrEntry, arrEditor.GetArrangement());

				// Graphics
				int gfxPointer = GfxBattleBgTable.GetEntry(bg.GfxEntry)[0];
				arrEditor.GetTileset(M3Rom.Rom, gfxPointer);

				// Palette
				bg.Palette = arrEditor.GetPalette();
			}

			bg.Save();

			int currentpal = arrEditor.CurrentPalette;
			int currenttile = arrEditor.CurrentTile;
			int primarycol = arrEditor.PrimaryColorIndex;
			int secondarycol = arrEditor.SecondaryColorIndex;

			cboEntry_SelectedIndexChanged(null, null);

			arrEditor.CurrentPalette = currentpal;
			arrEditor.PrimaryColorIndex = primarycol;
			arrEditor.SecondaryColorIndex = secondarycol;
			arrEditor.CurrentTile = currenttile;
		}

		private void lblAnim_Click(object sender, EventArgs e)
		{
			if (expanded)
			{
				// Let's collapse it
				lblAnim.Text = "[ + ] Animation parameters";
				grpAnim.Height = 18;
			}
			else
			{
				// Let's expand it
				lblAnim.Text = "[ - ] Animation parameters";
				grpAnim.Height = 180;
			}

			arrEditor.Top = grpAnim.Top + grpAnim.Height + 6;
			arrEditor.Height = btnApply.Top - arrEditor.Top - 6;

			expanded = !expanded;
		}
	}
}
