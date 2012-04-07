using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Extensions;
using MOTHER3;

namespace MOTHER3Funland
{
    unsafe public partial class frmBattleBgEntryEditor : M3Form
    {
        bool loading = false;
        bool loading2 = false;
        bool changed = false;
        // Layer controls
        PictureBox[] pLayer = new PictureBox[2];
        LinkLabel[] lblLayer = new LinkLabel[2];
        ComboBox[] cboLayer = new ComboBox[2];
        Label[] lblAlpha = new Label[2];
        TextBox[] txtAlpha = new TextBox[2];

        // Stuff for the animation
        int t = 0;
        GfxBattleBg.MasterEntry ms = null;
        int[] bgLayers = new int[2];
        int[] bgAlphas = new int[2];

        Bitmap canvas = new Bitmap(256, 256, PixelFormat.Format8bppIndexed);

        Bitmap[] srcBitmap = new Bitmap[2];
        BitmapData[] srcBd = new BitmapData[2];
        MPalette[] srcPal = new MPalette[2];

        Bitmap[] bufBitmap = new Bitmap[2];
        BitmapData[] bufBd = new BitmapData[2];
        byte*[] buf = new byte*[2];

        Bitmap[] dstBitmap = new Bitmap[2];
        BitmapData[] dstBd = new BitmapData[2];

        ImageAttributes[] alphaAttr = new ImageAttributes[2];
        ColorMatrix[] alphaMatrix = new ColorMatrix[2];

        Multimedia.Timer tm = new Multimedia.Timer();

        public frmBattleBgEntryEditor()
        {
            InitializeComponent();

            pAnimation.Image = canvas;
            pAnimation.Visible = false;

            // Draw the layer stuff
            for (int i = 0; i < 2; i++)
            {
                var p = new PictureBox();
                p.SizeMode = PictureBoxSizeMode.Normal;
                p.Width = p.Height = 128;
                p.Left = 15;
                p.Top = 39 + (134 * i);
                p.Visible = true;
                p.Paint += (s, e) =>
                {
                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    e.Graphics.Clear(this.BackColor);
                    e.Graphics.DrawImage((s as PictureBox).Image, new Rectangle(0, 0, 128, 128),
                        0, 0, 256, 256, GraphicsUnit.Pixel);
                };

                this.Controls.Add(p);
                pLayer[i] = p;

                var ll = new LinkLabel();
                ll.AutoSize = true;
                ll.Text = "Layer " + (i + 1).ToString();
                ll.Left = 149;
                ll.Top = 42 + (134 * i);
                ll.Visible = true;
                ll.Tag = i;
                ll.LinkClicked += (s, e) =>
                {
                    int index = (int)((LinkLabel)s).Tag;
                    ModuleArbiter.ShowSelect(typeof(frmBattleBgLayerEditor), cboLayer[index].SelectedIndex);
                };

                this.Controls.Add(ll);
                lblLayer[i] = ll;

                var c = new ComboBox();
                c.DropDownStyle = ComboBoxStyle.DropDownList;
                c.Width = 128;
                c.Height = 21;
                c.Left = 200;
                c.Top = p.Top;
                c.Visible = true;
                c.Tag = i;
                for (int j = 0; j < GfxBattleBg.Entries; j++)
                    c.Items.Add(j.ToString("X3"));
                c.SelectedIndexChanged += (s, e) =>
                {
                    if (loading2) return;
                    var cb = s as ComboBox;
                    int index = (int)cb.Tag;
                    pLayer[index].Image = GfxBattleBg.GetLayer(cb.SelectedIndex);
                };
                
                this.Controls.Add(c);
                cboLayer[i] = c;

                var l = new Label();
                l.AutoSize = true;
                l.Text = "Alpha";
                l.Left = ll.Left;
                l.Top = ll.Top + 28;
                l.Visible = true;

                this.Controls.Add(l);
                lblAlpha[i] = l;

                var t = new TextBox();
                t.Width = 64;
                t.Height = 20;
                t.Left = c.Left;
                t.Top = l.Top - 3;
                t.Visible = true;

                this.Controls.Add(t);
                txtAlpha[i] = t;
            }
            
            // Load the entry list
            loading = true;
            for (int i = 0; i < GfxBattleBg.MasterEntries; i++)
                cboEntry.Items.Add(i.ToString("X2"));
            loading = false;
            cboEntry.SelectedIndex = 0;

            // Setup the animation timer
            tm.Mode = Multimedia.TimerMode.Periodic;
            tm.Period = 16;
            tm.Resolution = 1;
            tm.Tick += (s, ee) =>
            {
                if (this.InvokeRequired)
                    this.BeginInvoke(new MethodInvoker(UpdateFrame));
                else
                    UpdateFrame();

                t++;
            };
        }

        private void UpdateFrame()
        {
            pAnimation.Refresh();
        }

        private void cboEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            int index = cboEntry.SelectedIndex;
            var ms = GfxBattleBg.Masters[index];

            for (int i = 0; i < 2; i++)
            {
                cboLayer[i].SelectedIndex = ms.Layer[i];
                txtAlpha[i].Text = ms.Alpha[i].ToString();
            }

            changed = true;
        }

        public override void SelectIndex(int[] index)
        {
            cboEntry.SelectedIndex = index[0];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboEntry.SelectedIndex };
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int index = cboEntry.SelectedIndex;
            var ms = GfxBattleBg.Masters[index];

            for (int i = 0; i < 2; i++)
            {
                ms.Layer[i] = (ushort)cboLayer[i].SelectedIndex;

                try
                {
                    ms.Alpha[i] = ushort.Parse(txtAlpha[i].Text);
                }
                catch
                {
                    txtAlpha[i].Focus();
                    txtAlpha[i].SelectAll();
                    return;
                }
            }

            ms.Save();
            cboEntry_SelectedIndexChanged(null, null);
        }

        private void btnAnimStart_Click(object sender, EventArgs e)
        {
            btnAnimStop.Enabled = true;
            btnAnimStart.Enabled = false;
            btnAnimNext.Enabled = false;

            int index = cboEntry.SelectedIndex;
            ms = GfxBattleBg.Masters[index];

            for (int i = 0; i < 2; i++)
            {
                try
                {
                    bgAlphas[i] = int.Parse(txtAlpha[i].Text);
                }
                catch
                {
                    txtAlpha[i].SelectAll();
                    return;
                }

                bgLayers[i] = cboLayer[i].SelectedIndex;
                srcBitmap[i] = GfxBattleBg.GetBg(index, i);
                if (changed) srcPal[i] = (MPalette)GfxBattleBg.Bgs[bgLayers[i]].Palette.Clone();
                srcBd[i] = srcBitmap[i].LockBits(ImageLockMode.ReadWrite);

                bufBitmap[i] = new Bitmap(256, 256, PixelFormat.Format8bppIndexed);
                bufBd[i] = bufBitmap[i].LockBits(ImageLockMode.ReadWrite);
                buf[i] = (byte*)bufBd[i].Scan0;

                dstBitmap[i] = new Bitmap(256, 256, PixelFormat.Format8bppIndexed);

                // Apply the alphas
                alphaAttr[i] = new ImageAttributes();

                float a = bgAlphas[i];
                alphaMatrix[i] = new ColorMatrix();
                alphaMatrix[i].Matrix33 = a / 16.0f;

                alphaAttr[i].SetColorMatrix(alphaMatrix[i], ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            }

            if (changed)
            {
                changed = false;
                t = 0;
            }

            pAnimation.Visible = true;
            tm.Start();
        }

        private void btnAnimStop_Click(object sender, EventArgs e)
        {
            tm.Stop();

            btnAnimStart.Enabled = true;
            btnAnimStop.Enabled = false;
            btnAnimNext.Enabled = !changed;
        }

        private void frmBattleBgEntryEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnAnimStart.Enabled == false) btnAnimStop_Click(null, null);
        }

        private void pAnimation_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                if (bgLayers[i] == 0) continue;

                var bg = GfxBattleBg.Bgs[bgLayers[i]];

                if ((bg.PalDelay != 0) && (t > 0) && ((t % bg.PalDelay) == 0))
                    GfxBattleBg.RotatePal(srcPal[i], bg);
                dstBitmap[i].CopyPalette(srcPal[i], false);

                byte* src = (byte*)srcBd[i].Scan0;

                double dt = (double)t;
                double DH = -(double)bg.DriftH;
                double DV = -(double)bg.DriftV;
                double AH = (double)bg.AmplH;
                double AV = (double)bg.AmplV;
                double WH = (double)bg.WavenumH;
                double WV = (double)bg.WavenumV;
                double FH = (double)bg.FreqH;
                double FV = (double)bg.FreqV;

                dstBd[i] = dstBitmap[i].LockBits(ImageLockMode.WriteOnly);

                byte* dst = (byte*)dstBd[i].Scan0;

                int height = 256;
                int width = 256;

                // Horizontal translation
                for (int y = 0; y < height; y++)
                {
                    double dy = (double)y;

                    byte offset_x = (byte)((DH * dt / 256.0d) +
                        AH * Math.Sin(2.0d * Math.PI * WH * (
                        (FH * dt / 65536.0d) + (dy / 256.0d))));

                    int new_y = y;
                    int tmp = y * width;

                    for (int x = 0; x < width; x++)
                    {
                        int tmpnew = new_y * width + offset_x;
                        buf[i][tmp] = src[tmpnew];

                        offset_x++;
                        tmp++;
                    }
                }

                // Vertical compression
                for (int y = 0; y < height; y++)
                {
                    double dy = (double)y;

                    byte offset_y = (byte)((DV * dt / 256.0d) +
                        AV * Math.Sin(2.0d * Math.PI * WV * (
                        (FV * dt / 65536.0d) + (dy / 256.0d))));

                    int tmp = y * width;
                    int tmpnew = ((offset_y + y) & 0xFF) * width;

                    for (int x = 0; x < width; x++)
                    {
                        dst[tmp++] = buf[i][tmpnew++];
                    }
                }

                dstBitmap[i].UnlockBits(dstBd[i]);
                Bitmap b = dstBitmap[i].ToRaster();

                e.Graphics.DrawImage(b, new Rectangle(0, 0, 256, 256), 0, 0, 256, 256, GraphicsUnit.Pixel, alphaAttr[i]);
            }
        }

        private void btnAnimNext_Click(object sender, EventArgs e)
        {
            t++;
            UpdateFrame();
        }
    }
}
