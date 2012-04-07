using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MOTHER3;
using Extensions;

namespace MOTHER3Funland
{
	public partial class ArrangementEditor : UserControl
	{
		#region Variables

		private bool loading = false;

		private ArrEntry[] Arrangement = null;
		private byte[] Tileset = null;
		private int TileCount = -1;

		private MPalette Palette
		{
			get
			{
				return palSelector.Palettes;
			}
		}

		public int CurrentPalette
		{
			get
			{
				return palSelector.PalIndex;
			}
			set
			{
				palSelector.PalIndex = value;
			}
		}

		public int PrimaryColorIndex
		{
			get
			{
				return palSelector.PrimaryIndex;
			}
			set
			{
				palSelector.PrimaryIndex = value;
			}
		}

		public int SecondaryColorIndex
		{
			get
			{
				return palSelector.SecondaryIndex;
			}
			set
			{
				palSelector.SecondaryIndex = value;
			}
		}

		private Bitmap bmpTileset = null;
		private Bitmap bmpTile = null;
		private Bitmap bmpArr = null;

		public int ZoomTileset
		{
			get
			{
				return zoomTileset;
			}
			set
			{
				zoomTileset = value;
				RefreshTileset();
			}
		}
		private int zoomTileset = 4;

		public int ZoomTile
		{
			get
			{
				return zoomTile;
			}
			set
			{
				zoomTile = value;
				RefreshTile();
			}
		}
		private int zoomTile = 8;

		public int ZoomArr
		{
			get
			{
				return zoomArr;
			}
			set
			{
				zoomArr = value;
				RefreshArr();
			}
		}
		private int zoomArr = 2;

		public bool GridArr
		{
			get
			{
				return gridArr;
			}
			set
			{
				gridArr = value;
				RefreshArr();
			}
		}
		private bool gridArr = true;

		public bool GridTileset
		{
			get
			{
				return gridTileset;
			}
			set
			{
				gridTileset = value;
				RefreshTileset();
			}
		}
		private bool gridTileset = true;

		public bool GridTile
		{
			get
			{
				return gridTile;
			}
			set
			{
				gridTile = value;
				RefreshTile();
				RefreshTileset();
			}
		}
		private bool gridTile = true;

		private int arrWidth = 0;
		private int arrHeight = 0;

		private int currentTile = 0;

		public Pen GridPen
		{
			get
			{
				return gridPen;
			}
			set
			{
				GridPen = value;

				if (gridTile) RefreshTile();
				if (gridTileset) RefreshTileset();
				if (gridArr) RefreshArr();
			}
		}
		private Pen gridPen = Pens.Red;

		public Color HighlightColor
		{
			get
			{
				return highlightColor;
			}
			set
			{
				highlightColor = value;
				RefreshTileset();
			}
		}
		private Color highlightColor = Color.FromArgb(160, 192, 144, 0);

		public int CurrentTile
		{
			get
			{
				return currentTile;
			}
			set
			{
				currentTile = value;
				RenderTile();
				RefreshTile();
				RefreshTileset();
			}
		}

		public int SplitMainPosition
		{
			get
			{
				return splitMain.SplitterDistance;
			}
			set
			{
				splitMain.SplitterDistance = value;
			}
		}

		public int SplitLeftPosition
		{
			get
			{
				return splitLeft.SplitterDistance;
			}
			set
			{
				splitLeft.SplitterDistance = value;
			}
		}

		public int EditLimit = -1;

		private ToolStripMenuItem[] mnuZoom = new ToolStripMenuItem[5];
		private Control mnuSourceControl = null;

		public event EventHandler TileModified;

		protected virtual void OnTileModified(EventArgs e)
		{
			if (TileModified != null)
			{
				TileModified(this, e);
			}
		}

		#endregion

		public ArrangementEditor()
		{
			InitializeComponent();
			
			// Add some mouse handlers for the arrangement
			pArr.MouseDown += new MouseEventHandler(pArr_MouseClick);
			pArr.MouseMove += new MouseEventHandler(pArr_MouseClick);

			// Add some mouse handlers for the tile
			pTile.MouseDown += new MouseEventHandler(pTile_MouseClick);
			pTile.MouseMove += new MouseEventHandler(pTile_MouseClick);

			// Create the zoom menus
			for (int i = 0; i < 5; i++)
			{
				int amount = (int)Math.Pow(2, i);
				var mnu = new ToolStripMenuItem(amount + "00%");
				mnu.Tag = i;
				mnu.Click += (sender, e) =>
				{
					var t = (ToolStripDropDownItem)sender;
					int index = (int)(t.Tag);
					int a = (int)Math.Pow(2, index);

					var p = mnuSourceControl;

					if (p == pArr)
						ZoomArr = a;

					else if (p == pTileset)
						ZoomTileset = a;

					else if (p == btnTileMenu)
						ZoomTile = a;
				};

				mnuControlZoom.DropDownItems.Add(mnu);
				mnuZoom[i] = mnu;
			}
		}

		public void Clear()
		{
			palSelector.Palettes = null;
			Arrangement = null;
			Tileset = null;
			bmpTile = null;
			bmpTileset = null;
			bmpArr = null;
		}

		public void SetArrangement(ArrEntry[] arr, int w, int h)
		{
			if (arr == null)
			{
				Arrangement = null;
				return;
			}

			if ((w * h) > arr.Length)
				throw new Exception("Canvas is larger than arrangement!");

			if ((Arrangement == null) || (Arrangement.Length != arr.Length))
			{
				Arrangement = new ArrEntry[arr.Length];
			}

			for (int i = 0; i < arr.Length; i++)
				Arrangement[i] = (ArrEntry)arr[i].Clone();

			arrWidth = w;
			arrHeight = h;
		}

		public void SetTileset(byte[] data, int gfxOffset = 0, int tileCount = -1, int editlimit = -1)
		{
			if (tileCount == 0)
			{
				Tileset = null;
				TileCount = -1;
			}
			else
			{
				if (tileCount == -1)
					tileCount = data.Length >> 5;

				if ((Tileset == null) || (Tileset.Length != (tileCount << 5)))
					Tileset = new byte[tileCount << 5];

				Array.Copy(data, gfxOffset, Tileset, 0, tileCount << 5);

				TileCount = tileCount;
			}

			EditLimit = editlimit;
		}

		public void SetPalette(MPalette pal)
		{
			palSelector.Palettes = pal;
		}

		public ArrEntry[] GetArrangement()
		{
			var ret = new ArrEntry[Arrangement.Length];
			for (int i = 0; i < ret.Length; i++)
				ret[i] = (ArrEntry)Arrangement[i].Clone();
			return ret;
		}

		public byte[] GetTileset()
		{
			var ret = new byte[Tileset.Length];
			Array.Copy(Tileset, 0, ret, 0, ret.Length);
			return ret;
		}

		public void GetTileset(byte[] dest, int destOffset)
		{
			Array.Copy(Tileset, 0, dest, destOffset, Tileset.Length);
		}

		public MPalette GetPalette()
		{
            return (MPalette)palSelector.Palettes.Clone();
		}

		public void RenderTile()
		{
			if ((Tileset == null) || (Palette == null))
			{
				bmpTile = null;
			}
			else
			{
				if (bmpTile == null) bmpTile = new Bitmap(8, 8, PixelFormat.Format8bppIndexed);

				lock (bmpTile)
				{
					bmpTile.CopyPalette(Palette, false);
					BitmapData bd = bmpTile.LockBits(ImageLockMode.WriteOnly);
					byte[,] pixels = Tileset.Read4BppTile(currentTile << 5);
					GfxProvider.RenderToBitmap(bd, pixels, 0, 0, chkFlipH.Checked, chkFlipV.Checked, palSelector.PalIndex, false);
					bmpTile.UnlockBits(bd);
				}
			}
		}

		public void RenderTileset()
		{
			if (Tileset == null)
			{
				bmpTileset = null;
			}
			else
			{
				int tilecount = Tileset.Length >> 5;
				int w = 32;
				int h = (tilecount >> 2) << 3;
				if ((h == 0) || ((tilecount & 3) != 0)) h += 8;

				if ((bmpTileset == null) || (bmpTileset.Width != w))
				{
					bmpTileset = new Bitmap(w, h, PixelFormat.Format8bppIndexed);
				}

				lock (bmpTileset)
				{
					bmpTileset.CopyPalette(Palette, false);
					BitmapData bd = bmpTileset.LockBits(ImageLockMode.WriteOnly);

					for (int i = 0; i < tilecount; i++)
					{
						byte[,] pixels = Tileset.Read4BppTile(i << 5);
						GfxProvider.RenderToBitmap(bd, pixels, (i & 3) << 3, (i >> 2) << 3, false, false, palSelector.PalIndex, false);
					}

					bmpTileset.UnlockBits(bd);
				}
			}
		}

		public void RenderArr()
		{
			if ((Arrangement == null) || (Tileset == null))
			{
				bmpArr = null;
			}
			else
			{
				bmpArr = new Bitmap(arrWidth << 3, arrHeight << 3, PixelFormat.Format8bppIndexed);
				bmpArr.CopyPalette(Palette, false);
				lock (bmpArr)
				{
					BitmapData bd = bmpArr.LockBits(ImageLockMode.WriteOnly);
					GfxProvider.RenderArrangement(bd, Arrangement, arrWidth, arrHeight, Tileset, 0, false, false);
					bmpArr.UnlockBits(bd);
				}
			}
		}

		public void RefreshTile()
		{
			if (bmpTile == null) return;
			pTile.Width = 8 * zoomTile + (gridTile ? 1 : 0);
			pTile.Height = pTile.Width;
			pTile.Refresh();
		}

		public void RefreshTileset()
		{
			if (bmpTileset == null) return;
			pTileset.Width = bmpTileset.Width * zoomTileset + (gridTileset ? 1 : 0);
			pTileset.Height = bmpTileset.Height * zoomTileset + (gridTileset ? 1 : 0);
			pTileset.Refresh();
		}

		public void RefreshArr()
		{
			if (bmpArr == null) return;
			pArr.Width = bmpArr.Width * zoomArr + (gridArr ? 1 : 0);
			pArr.Height = bmpArr.Height * zoomArr + (gridArr ? 1 : 0);
			pArr.Refresh();
		}

		private void pTile_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.Half;

			if (bmpTile == null)
			{
				g.Clear(pTile.BackColor);
				return;
			}

			g.DrawImage(bmpTile, new Rectangle(0, 0, bmpTile.Width * zoomTile, bmpTile.Height * zoomTile),
				0, 0, 8, 8, GraphicsUnit.Pixel);

			// Draw the gridlines
			if (gridTile && (zoomTile > 1))
			{
				for (int i = 0; i <= 8; i++)
				{
					g.DrawLine(GridPen, 0, i * zoomTile + 1, pTile.Width, i * zoomTile + 1);
					g.DrawLine(GridPen, i * zoomTile + 1, 0, i * zoomTile + 1, pTile.Height);
				}
			}
		}

		private void pTileset_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.Half;

			if (bmpTileset == null)
			{
				g.Clear(pTileset.BackColor);
				return;
			}

			// Draw the tileset
			g.DrawImage(bmpTileset, new Rectangle(0, 0, bmpTileset.Width * zoomTileset, bmpTileset.Height * zoomTileset),
				0, 0, bmpTileset.Width, bmpTileset.Height, GraphicsUnit.Pixel);

			int tx = (currentTile & 3) * 8 * zoomTileset;
			int ty = (currentTile >> 2) * 8 * zoomTileset;

			// Cross out the protected tiles
			if (EditLimit >= 0)
			{
				for (int i = EditLimit; i < TileCount; i++)
				{
					int itx = (i & 3) * 8 * zoomTileset;
					int ity = (i >> 2) * 8 * zoomTileset;
					g.DrawLine(gridPen, itx, ity, itx + (8 * zoomTileset), ity + (8 * zoomTileset));
					g.DrawLine(gridPen, itx + (8 * zoomTileset), ity, itx, ity + (8 * zoomTileset));
				}
			}

			// Highlight the current tile
			g.FillRectangle(new SolidBrush(HighlightColor), new Rectangle(
				tx, ty, 8 * zoomTileset, 8 * zoomTileset));
			g.DrawRectangle(new Pen(gridPen.Color, gridPen.Width * 3.0f), new Rectangle(
				tx, ty, 8 * zoomTileset + 2, 8 * zoomTileset + 2));

			// Draw the gridlines
			if (gridTileset)
			{
				for (int i = 0; i <= 4; i++)
				{
					g.DrawLine(GridPen, i * 8 * zoomTileset + 1, 0, i * 8 * zoomTileset + 1, pTileset.Height);
				}

				for (int i = 0; i <= bmpTileset.Height; i += 8)
				{
					g.DrawLine(GridPen, 0, i * zoomTileset + 1, pTileset.Width, i * zoomTileset + 1);
				}
			}
		}

		private void pArr_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.Half;

			if (bmpArr == null)
			{
				g.Clear(pArr.BackColor);
				return;
			}

			g.DrawImage(bmpArr, new Rectangle(0, 0, bmpArr.Width * zoomArr, bmpArr.Height * zoomArr),
				0, 0, bmpArr.Width, bmpArr.Height, GraphicsUnit.Pixel);

			// Draw the gridlines
			if (gridArr)
			{
				for (int x = 0; x <= arrWidth; x++)
				{
					g.DrawLine(GridPen, x * 8 * zoomArr + 1, 0, x * 8 * zoomArr + 1, pArr.Height);
				}

				for (int y = 0; y <= arrHeight; y++)
				{
					g.DrawLine(GridPen, 0, y * 8 * zoomArr + 1, pArr.Width, y * 8 * zoomArr + 1);
				}
			}
		}

		private void mnuControlGrid_Click(object sender, EventArgs e)
		{
			if (loading) return;

			var t = (ToolStripMenuItem)sender;
			var s = (ContextMenuStrip)t.GetCurrentParent();
			var p = s.SourceControl;

			if (p == pArr)
			{
				GridArr = mnuControlGrid.Checked;
				RefreshArr();
			}

			else if (p == pTileset)
			{
				GridTileset = mnuControlGrid.Checked;
				RefreshTileset();
			}

			else if (p == btnTileMenu)
			{
				GridTile = mnuControlGrid.Checked;
				RefreshTile();
			}
		}

		private void pArr_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				loading = true;
				mnuControlGrid.Checked = gridArr;
				loading = false;
			}
		}

		private void pTileset_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				loading = true;
				mnuControlGrid.Checked = gridTileset;
				loading = false;
			}
		}

		private void contextControls_Opening(object sender, CancelEventArgs e)
		{
			var s = (ContextMenuStrip)sender;
			mnuSourceControl = s.SourceControl;
		}

		private void pTileset_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				// Translate the X and Y into the tile number
				int x = e.X;
				int y = e.Y;

				x /= zoomTileset;
				y /= zoomTileset;

				x >>= 3;
				y >>= 3;

				int tilenum = x + (y << 2);

				if (tilenum >= TileCount) return;

				// Refresh the tile number
				CurrentTile = tilenum;
			}
		}

		private void palSelector_PalChanged(object sender, EventArgs e)
		{
			if (loading) return;
			if (bmpTileset == null) return;
			if (bmpTile == null) return;

			RenderTileset();
			RefreshTileset();

			RenderTile();
			RefreshTile();
		}

		private void palSelector_PalModified(object sender, EventArgs e)
		{
			palSelector_PalChanged(sender, e);
			RenderArr();
			RefreshArr();
		}

		private void chkFlipH_CheckedChanged(object sender, EventArgs e)
		{
			if (loading) return;

			RenderTile();
			RefreshTile();
		}

		private void chkFlipV_CheckedChanged(object sender, EventArgs e)
		{
			if (loading) return;

			RenderTile();
			RefreshTile();
		}

		private void pArr_MouseClick(object sender, MouseEventArgs e)
		{
			if (bmpArr == null) return;

			if (e.Button == MouseButtons.Left)
			{
				// Get the X and Y
				int x = e.X;
				int y = e.Y;

				x /= zoomArr;
				y /= zoomArr;

				x >>= 3;
				y >>= 3;

				if (x >= arrWidth) return;
				if (y >= arrHeight) return;

				if ((Control.ModifierKeys & Keys.Shift) == 0)
				{
					// Draw tile
					DrawTile(x, y);
				}
				else
				{
					// Get tile
					ArrEntry a = Arrangement[x + (y * arrWidth)];

					loading = true;
					chkFlipH.Checked = a.FlipH;
					chkFlipV.Checked = a.FlipV;

					int pnum = a.Palette;
					if (pnum >= Palette.Count) pnum = 0;
					palSelector.PalIndex = pnum;
					loading = false;

					RenderTileset();
					RefreshTileset();
					CurrentTile = a.TileNumber;
				}
			}
		}

		private void DrawTile(int x, int y)
		{
			// Get tile
			ArrEntry a = Arrangement[x + (y * arrWidth)];

			a.FlipH = chkFlipH.Checked;
			a.FlipV = chkFlipV.Checked;
			a.Palette = (byte)palSelector.PalIndex;
			a.TileNumber = (ushort)currentTile;

			RenderArr();
			RefreshArr();
		}

		private void pTile_MouseClick(object sender, MouseEventArgs e)
		{
			if (bmpTile == null) return;
			if (Tileset == null) return;

			if ((e.Button == MouseButtons.Left) || (e.Button == MouseButtons.Right))
			{
				int x = e.X;
				int y = e.Y;

				x /= zoomTile;
				y /= zoomTile;

				if (chkFlipH.Checked) x = 7 - x;
				if (chkFlipV.Checked) y = 7 - y;

				int tileoffset = (currentTile << 5) + (y << 2) + (x >> 1);
				byte ch = Tileset[tileoffset];

				if ((Control.ModifierKeys & Keys.Shift) == 0)
				{
					// Exit if this tile is protected
					if ((EditLimit >= 0) && (currentTile >= EditLimit))
						return;

					// Draw pixel
					ch &= (byte)(0xF << (((x & 1) ^ 1) << 2));

					int c = (e.Button == MouseButtons.Left) ? palSelector.PrimaryIndex : palSelector.SecondaryIndex;
					c &= 0xF;
					ch |= (byte)(c << ((x & 1) << 2));

					Tileset[tileoffset] = ch;

					RenderTile();
					RefreshTile();
				}
				else
				{
					// Get pixel
					ch &= (byte)(0xF << ((x & 1) << 2));
					ch >>= ((x & 1) << 2);

					if (e.Button == MouseButtons.Left)
						palSelector.PrimaryIndex = ch;

					else
						palSelector.SecondaryIndex = ch;
				}
			}
		}

		private void pTile_MouseUp(object sender, MouseEventArgs e)
		{
			if (bmpTile == null) return;
			if (Tileset == null) return;

			OnTileModified(new EventArgs());

			RenderTileset();
			RefreshTileset();

			RenderArr();
			RefreshArr();
		}

		private void btnTileMenu_Click(object sender, EventArgs e)
		{
			loading = true;
			mnuControlGrid.Checked = gridTile;
			loading = false;

			contextControls.Show(btnTileMenu, btnTileMenu.PointToClient(Control.MousePosition));
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			if (dlgExport.ShowDialog() == DialogResult.OK)
			{
				bmpArr.Save(dlgExport.FileName);
			}
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			if (dlgImport.ShowDialog() == DialogResult.OK)
			{
				Bitmap bmp = new Bitmap(dlgImport.FileName);
				if ((bmp.Width != (arrWidth << 3)) || (bmp.Height != (arrHeight << 3)))
				{
					MessageBox.Show("The image is the wrong size. It's " + bmp.Width + "x" + bmp.Height +
						", but it should be " + (arrWidth << 3) + "x" + (arrHeight << 3) + ".",
						"Wrong size");
					return;
				}

				// Prompt for options
				var f = new frmGfxImportDialog();
				DialogResult res = f.ShowDialog();
				if (res != DialogResult.OK) return;

				GfxImportSettings g = M3Settings.MainSettings.GfxImportSettings;

				try
				{
					object[] o = GfxProvider.SetArrangement(bmp, Tileset, 0, (EditLimit == -1) ?
						 TileCount : EditLimit,
						 g.UseTileset,
						 g.UseFlips,
						 g.UsePalette ? Palette.Entries[CurrentPalette] : null,
						 g.UsePalette ? CurrentPalette : 0,
						 g.TransparentColor,
						 g.UseTransparency
						 );

					// Success!
					Arrangement = (ArrEntry[])o[0];
					Palette.Entries[CurrentPalette] = (Color[])o[1];

					int colorsDropped = (int)o[2];
					if (colorsDropped > 0)
						MessageBox.Show("There were too many colors in the image, so only the 15 most common ones were preserved." +
							Environment.NewLine + colorsDropped + " color(s) were dropped.", "Too many colors");

					SetPalette(Palette);

					RenderTileset();
					RenderTile();
					RenderArr();

					RefreshTileset();
					RefreshTile();
					RefreshArr();
				}
				catch (TileCountException ee)
				{
					MessageBox.Show("This image needs " +
						ee.Tilecount + " tiles, but we only have room for " + ee.Tilelimit +
						" tiles.", "Too many tiles");
				}
				catch (TileMismatchException ee)
				{
					MessageBox.Show("This image contains tiles not in the current tileset." +
					Environment.NewLine + "The problematic tile is at (" + (ee.TileX << 3) + ", " +
					(ee.TileY << 3) + ").",
						"No tile match");
				}

				f.Dispose();
				bmp.Dispose();
			}
		}
	}
}
