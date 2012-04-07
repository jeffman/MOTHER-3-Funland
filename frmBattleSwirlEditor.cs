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
	public partial class frmBattleSwirlEditor : M3Form
	{
		bool loading = false;

		public frmBattleSwirlEditor()
		{
			InitializeComponent();

			// Init the swirl data
			GfxBattleSwirls.Init();

			// Populate the palette and swirl boxes
			loading = true;
			for (int i = 0; i < GfxBattleSwirls.SequenceEntries; i++)
			{
				cboSwirl.Items.Add(i.ToString());
				cboPalette.Items.Add(i.ToString());
			}
			cboPalette.SelectedIndex = 0;
			loading = false;
			cboSwirl.SelectedIndex = 0;
		}

		public override void SelectIndex(int[] index)
		{
			// 0: Swirl
			// 1: Frame
			// 2: Palette
			// 3: Tile index
			// 4: splitMain position
			// 5: splitLeft position

			cboSwirl.SelectedIndex = index[0];

			if (index.Length == 1) return;

			cboFrame.SelectedIndex = index[1];
			cboPalette.SelectedIndex = index[2];
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
				cboSwirl.SelectedIndex,
				cboFrame.SelectedIndex,
				cboPalette.SelectedIndex,
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

		private void cboSwirl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loading) return;

			int index = cboSwirl.SelectedIndex;
			var s = GfxBattleSwirls.Sequences[index];

			// Populate the frame list
			loading = true;
			cboFrame.Items.Clear();
			for (int i = 0; i < s.ArrLen; i++)
				cboFrame.Items.Add(i.ToString());
			loading = false;
			cboFrame.SelectedIndex = 0;

			txtGfxEntry.Text = s.GfxEntry.ToString();
			txtArrStart.Text = s.ArrStart.ToString();
			txtArrLen.Text = s.ArrLen.ToString();
		}

		private void cboFrame_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loading) return;

			int index = cboSwirl.SelectedIndex;
			int frame = cboFrame.SelectedIndex;
			int pal = cboPalette.SelectedIndex;
			var s = GfxBattleSwirls.Sequences[index];

			txtFrameDuration.Text = s.Lengths[frame].ToString();

			// Arrangement stuff
			arrEditor.Clear();

			int[] gfxEntry = GfxBattleSwirls.GetEntry(s.GfxEntry);

			byte[] tileset = new byte[0x800];
			Array.Copy(M3Rom.Rom, gfxEntry[0], tileset, 0, gfxEntry[1]);
			arrEditor.SetTileset(tileset, 0, -1, gfxEntry[1] >> 5);
			arrEditor.SetArrangement(GfxBattleSwirls.GetArr(s.ArrStart + frame), 30, 20);
			arrEditor.SetPalette(GfxBattleSwirls.Palettes[pal]);

			arrEditor.RenderArr();
			arrEditor.RenderTileset();
			arrEditor.CurrentTile = 0;
			arrEditor.RefreshArr();
		}

		private void cboPalette_SelectedIndexChanged(object sender, EventArgs e)
		{
			cboFrame_SelectedIndexChanged(null, null);
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			int index = cboSwirl.SelectedIndex;
			int frame = cboFrame.SelectedIndex;
			int pal = cboPalette.SelectedIndex;
			var s = GfxBattleSwirls.Sequences[index];

			// Graphics entry
			try
			{
				s.GfxEntry = byte.Parse(txtGfxEntry.Text);
			}
			catch
			{
				txtGfxEntry.SelectAll();
				return;
			}

			// Arrangement start
			try
			{
				s.ArrStart = byte.Parse(txtArrStart.Text);
			}
			catch
			{
				txtArrStart.SelectAll();
				return;
			}

			// Arrangement length
			try
			{
				s.ArrLen = byte.Parse(txtArrLen.Text);
			}
			catch
			{
				txtArrLen.SelectAll();
				return;
			}

			// Frame duration
			try
			{
				s.Lengths[frame] = byte.Parse(txtFrameDuration.Text);
			}
			catch
			{
				txtFrameDuration.SelectAll();
				return;
			}

			if (index > 0)
			{
				// Arrangement
				GfxBattleSwirls.SetArr(s.ArrStart + frame, arrEditor.GetArrangement());

				// Graphics
				byte[] tileset = arrEditor.GetTileset();
				int[] gfxEntry = GfxBattleSwirls.GetEntry(s.GfxEntry);
				Array.Copy(tileset, 0, M3Rom.Rom, gfxEntry[0], gfxEntry[1]);

				// Palette
				var palette = arrEditor.GetPalette();
				M3Rom.Rom.WritePal(GfxBattleSwirls.GetEntry(0)[0] + (pal << 5), palette);
				GfxBattleSwirls.Palettes[pal] = palette;
			}

			s.Save();

			int currentpal = arrEditor.CurrentPalette;
			int currenttile = arrEditor.CurrentTile;
			int primarycol = arrEditor.PrimaryColorIndex;
			int secondarycol = arrEditor.SecondaryColorIndex;

			cboFrame_SelectedIndexChanged(null, null);

			arrEditor.CurrentPalette = currentpal;
			arrEditor.PrimaryColorIndex = primarycol;
			arrEditor.SecondaryColorIndex = secondarycol;
			arrEditor.CurrentTile = currenttile;
		}
	}
}
