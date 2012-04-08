using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Extensions;
using MOTHER3;

namespace MOTHER3Funland
{
    public partial class frmSpriteEditor : M3Form
    {
        bool loading = false;
        int zoom = 1;

        // Text cache
        string[] spritenames = null;

        // Since we're hiding the null entries, this helps keep track of the sprite indexing in the combo box
        int[] indexmap = null;
        List<int> indexmaplist = new List<int>();

        public frmSpriteEditor()
        {
            InitializeComponent();

            Helpers.CheckFont(cboChar);

            // Load the sprite names
            spritenames = Properties.Resources.spritenames.SplitN();

            // Load the 4 banks
            loading = true;
            for (int i = 0; i < 4; i++)
                cboBank.Items.Add(i.ToString());
            loading = false;

            cboBank.SelectedIndex = 0;
        }

        private void cboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            int index = cboBank.SelectedIndex;
            var si = SpriteInfo.InfoEntries[index];
            cboChar.Items.Clear();

            loading = true;

            // Load the sprites for that bank
            indexmaplist.Clear();
            for (int i = 0; i < si.Length; i++)
            {
                // Only add it to the list if it's not null
                if (SpriteInfo.InfoEntries[index][i] != null)
                {
                    cboChar.Items.Add("[" + i.ToString("X3") + "] " + spritenames[i]);
                    indexmaplist.Add(i);
                }
            }

            // Convert our index map to an array, as it's faster than a list for lookup
            indexmap = indexmaplist.ToArray();

            loading = false;

            cboChar.SelectedIndex = 0;
        }

        private void cboChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            int index = indexmap[cboChar.SelectedIndex];
            var ie = SpriteInfo.InfoEntries[cboBank.SelectedIndex][index];
            cboSprite.Items.Clear();

            if (ie == null) return;

            // Load the sprite numbers
            loading = true;
            for (int i = 0; i < ie.SpriteCount; i++)
                cboSprite.Items.Add(i.ToString());
            loading = false;

            cboSprite.SelectedIndex = 0;

            // Load the palette number
            if ((index < 0x100) || (index > 0x26B))
            {
                cboPalNum.Enabled = true;
                cboPalNum.SelectedIndex = SpritePalettes.GetPalNum(index);
            }
            else
            {
                cboPalNum.Enabled = false;
                cboPalNum.SelectedIndex = -1;
            }
        }

        private void cboSprite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Get the sprite indices
            int bank = cboBank.SelectedIndex;
            int chr = indexmap[cboChar.SelectedIndex];
            int sprite = cboSprite.SelectedIndex;

            // Clear the subsprite box
            cboOam.Items.Clear();

            // Populate the subsprite box
            var si = SpriteInfo.InfoEntries[bank][chr].Sprites[sprite];
            for (int i = 0; i < si.SpriteCount; i++)
                cboOam.Items.Add(i.ToString());
            if (cboOam.Items.Count > 0) cboOam.SelectedIndex = 0;

            RefreshSprite();
        }

        private void tbZoom_Scroll(object sender, EventArgs e)
        {
            RefreshSprite();
        }

        public override void SelectIndex(int[] index)
        {
            cboBank.SelectedIndex = index[0];
            cboChar.SelectedIndex = index[1];
            cboSprite.SelectedIndex = index[2];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboBank.SelectedIndex, cboChar.SelectedIndex, cboSprite.SelectedIndex };
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string search = txtSearch.Text;
                int startindex = cboChar.SelectedIndex;
                bool wrapped = false;

                for (int i = startindex + 1; ; i++)
                {
                    if (i == cboChar.Items.Count)
                    {
                        i = 0;
                        wrapped = true;
                    }

                    if (wrapped && (i == startindex)) break;

                    if (((string)cboChar.Items[i]).ToLower().Contains(search.ToLower()))
                    {
                        cboChar.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                // Get the sprite indices
                int bank = cboBank.SelectedIndex;
                int chr = indexmap[cboChar.SelectedIndex];
                int sprite = cboSprite.SelectedIndex;

                // Get the bitmap
                Bitmap bmp = SpriteData.GetSprite(bank, chr, sprite, cboPalNum.SelectedIndex, false);

                // Get the palette
                var palette = SpritePalettes.GetPalette(sprite);

                // Create the target bitmap
                Bitmap target = new Bitmap(Math.Max(128, bmp.Width), 32 + bmp.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(target);

                // Draw the palette
                for (int i = 0; i < 16; i++)
                {
                    int x = (i & 7) << 4;
                    int y = ((i & 8) << 1);

                    g.FillRectangle(new SolidBrush(palette.Entries[0][i]), new Rectangle(x, y, 16, 16));
                }

                // Draw the sprite
                g.DrawImage(bmp, new Point(0, 32));

                // Save
                target.Save(dlgSave.FileName);
                g.Dispose();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Get the sprite indices
            int bank = cboBank.SelectedIndex;
            int chr = indexmap[cboChar.SelectedIndex];
            int sprite = cboSprite.SelectedIndex;
            int oam = cboOam.SelectedIndex;

            var si = SpriteInfo.InfoEntries[bank][chr].Sprites[sprite].Sprites[oam];

            if (cboPalNum.Enabled)
                SpritePalettes.SetPalNum(chr, cboPalNum.SelectedIndex);

            // X
            try
            {
                si.CoordX = (short)(sbyte.Parse(txtOamX.Text));
            }
            catch
            {
                txtOamX.SelectAll();
                return;
            }

            // Y
            try
            {
                si.CoordY = sbyte.Parse(txtOamY.Text);
            }
            catch
            {
                txtOamY.SelectAll();
                return;
            }

            // Flip
            si.FlipH = chkFlipH.Checked;
            si.FlipV = chkFlipV.Checked;

            SpriteInfo.InfoEntries[bank][chr].Save(sprite, oam);

            RefreshSprite();
        }

        private void cboPalNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSprite();
        }

        private void RefreshSprite()
        {
            // Get the sprite indices
            int bank = cboBank.SelectedIndex;
            int chr = indexmap[cboChar.SelectedIndex];
            int sprite = cboSprite.SelectedIndex;
            int oam = cboOam.SelectedIndex;

            // Try getting the sprite
            Bitmap bmp = SpriteData.GetSprite(bank, chr, sprite, cboPalNum.SelectedIndex, true);
            pSprite.Image = null;
            pOam.Image = null;
            if (bmp != null)
            {
                // Stretch the sprite according to our zoom
                zoom = (int)Math.Pow(2, tbZoom.Value);
                Bitmap bmpZoom = new Bitmap(bmp.Width * zoom, bmp.Height * zoom, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmpZoom);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.DrawImage(bmp, new Rectangle(0, 0, bmpZoom.Width, bmpZoom.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);

                // Show the sprite
                pSprite.Width = bmpZoom.Width;
                pSprite.Height = bmpZoom.Height;
                pSprite.Image = bmpZoom;
            }

            // Sprite arrangement
            if (oam < 0)
            {
                txtOamX.Text = "";
                txtOamY.Text = "";
                chkFlipH.Checked = false;
                chkFlipV.Checked = false;

                txtOamX.Enabled = false;
                txtOamY.Enabled = false;
                chkFlipH.Enabled = false;
                chkFlipV.Enabled = false;

                btnApply.Enabled = false;

                pOam.Image = null;
            }
            else
            {
                var si = SpriteInfo.InfoEntries[bank][chr].Sprites[sprite].Sprites[oam];

                txtOamX.Text = si.CoordX.ToString();
                txtOamY.Text = si.CoordY.ToString();
                chkFlipH.Checked = si.FlipH;
                chkFlipV.Checked = si.FlipV;

                txtOamX.Enabled = true;
                txtOamY.Enabled = true;
                chkFlipH.Enabled = true;
                chkFlipV.Enabled = true;

                btnApply.Enabled = true;

                pOam.Image = SpriteData.GetOam(bank, chr, sprite, oam, cboPalNum.SelectedIndex, true);
            }
        }

        private void cboOam_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSprite();
        }
    }
}
