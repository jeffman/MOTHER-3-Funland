namespace MOTHER3Funland
{
    partial class ArrangementEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitLeft = new System.Windows.Forms.SplitContainer();
            this.pArr = new System.Windows.Forms.PictureBox();
            this.contextControls = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuControlGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuControlZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTileMenu = new System.Windows.Forms.Button();
            this.chkFlipV = new System.Windows.Forms.CheckBox();
            this.chkFlipH = new System.Windows.Forms.CheckBox();
            this.palSelector = new MOTHER3Funland.PalSelector();
            this.pTile = new System.Windows.Forms.PictureBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pTileset = new System.Windows.Forms.PictureBox();
            this.dlgImport = new System.Windows.Forms.OpenFileDialog();
            this.dlgExport = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).BeginInit();
            this.splitLeft.Panel1.SuspendLayout();
            this.splitLeft.Panel2.SuspendLayout();
            this.splitLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pArr)).BeginInit();
            this.contextControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTileset)).BeginInit();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitMain.Location = new System.Drawing.Point(3, 3);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitLeft);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.AutoScroll = true;
            this.splitMain.Panel2.Controls.Add(this.btnImport);
            this.splitMain.Panel2.Controls.Add(this.btnExport);
            this.splitMain.Panel2.Controls.Add(this.pTileset);
            this.splitMain.Size = new System.Drawing.Size(696, 602);
            this.splitMain.SplitterDistance = 535;
            this.splitMain.TabIndex = 2;
            // 
            // splitLeft
            // 
            this.splitLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitLeft.Location = new System.Drawing.Point(0, 0);
            this.splitLeft.Name = "splitLeft";
            this.splitLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLeft.Panel1
            // 
            this.splitLeft.Panel1.AutoScroll = true;
            this.splitLeft.Panel1.Controls.Add(this.pArr);
            // 
            // splitLeft.Panel2
            // 
            this.splitLeft.Panel2.AutoScroll = true;
            this.splitLeft.Panel2.Controls.Add(this.btnTileMenu);
            this.splitLeft.Panel2.Controls.Add(this.chkFlipV);
            this.splitLeft.Panel2.Controls.Add(this.chkFlipH);
            this.splitLeft.Panel2.Controls.Add(this.palSelector);
            this.splitLeft.Panel2.Controls.Add(this.pTile);
            this.splitLeft.Size = new System.Drawing.Size(535, 602);
            this.splitLeft.SplitterDistance = 489;
            this.splitLeft.TabIndex = 1;
            // 
            // pArr
            // 
            this.pArr.ContextMenuStrip = this.contextControls;
            this.pArr.Location = new System.Drawing.Point(0, 3);
            this.pArr.Name = "pArr";
            this.pArr.Size = new System.Drawing.Size(512, 512);
            this.pArr.TabIndex = 0;
            this.pArr.TabStop = false;
            this.pArr.Paint += new System.Windows.Forms.PaintEventHandler(this.pArr_Paint);
            this.pArr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pArr_MouseClick);
            this.pArr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pArr_MouseDown);
            // 
            // contextControls
            // 
            this.contextControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuControlGrid,
            this.mnuControlZoom});
            this.contextControls.Name = "contextControls";
            this.contextControls.Size = new System.Drawing.Size(107, 48);
            this.contextControls.Opening += new System.ComponentModel.CancelEventHandler(this.contextControls_Opening);
            // 
            // mnuControlGrid
            // 
            this.mnuControlGrid.CheckOnClick = true;
            this.mnuControlGrid.Name = "mnuControlGrid";
            this.mnuControlGrid.Size = new System.Drawing.Size(106, 22);
            this.mnuControlGrid.Text = "Grid";
            this.mnuControlGrid.Click += new System.EventHandler(this.mnuControlGrid_Click);
            // 
            // mnuControlZoom
            // 
            this.mnuControlZoom.Name = "mnuControlZoom";
            this.mnuControlZoom.Size = new System.Drawing.Size(106, 22);
            this.mnuControlZoom.Text = "Zoom";
            // 
            // btnTileMenu
            // 
            this.btnTileMenu.Location = new System.Drawing.Point(274, 49);
            this.btnTileMenu.Name = "btnTileMenu";
            this.btnTileMenu.Size = new System.Drawing.Size(64, 23);
            this.btnTileMenu.TabIndex = 4;
            this.btnTileMenu.Text = "(Menu...)";
            this.btnTileMenu.UseVisualStyleBackColor = true;
            this.btnTileMenu.Click += new System.EventHandler(this.btnTileMenu_Click);
            // 
            // chkFlipV
            // 
            this.chkFlipV.AutoSize = true;
            this.chkFlipV.Location = new System.Drawing.Point(274, 26);
            this.chkFlipV.Name = "chkFlipV";
            this.chkFlipV.Size = new System.Drawing.Size(52, 17);
            this.chkFlipV.TabIndex = 3;
            this.chkFlipV.Text = "Flip V";
            this.chkFlipV.UseVisualStyleBackColor = true;
            this.chkFlipV.CheckedChanged += new System.EventHandler(this.chkFlipV_CheckedChanged);
            // 
            // chkFlipH
            // 
            this.chkFlipH.AutoSize = true;
            this.chkFlipH.Location = new System.Drawing.Point(274, 3);
            this.chkFlipH.Name = "chkFlipH";
            this.chkFlipH.Size = new System.Drawing.Size(53, 17);
            this.chkFlipH.TabIndex = 2;
            this.chkFlipH.Text = "Flip H";
            this.chkFlipH.UseVisualStyleBackColor = true;
            this.chkFlipH.CheckedChanged += new System.EventHandler(this.chkFlipH_CheckedChanged);
            // 
            // palSelector
            // 
            this.palSelector.Location = new System.Drawing.Point(3, 3);
            this.palSelector.MaximumSize = new System.Drawing.Size(265, 92);
            this.palSelector.MinimumSize = new System.Drawing.Size(265, 92);
            this.palSelector.Name = "palSelector";
            this.palSelector.Palettes = null;
            this.palSelector.PalIndex = 0;
            this.palSelector.PrimaryIndex = 0;
            this.palSelector.SecondaryIndex = 0;
            this.palSelector.Size = new System.Drawing.Size(265, 92);
            this.palSelector.TabIndex = 0;
            this.palSelector.PalChanged += new System.EventHandler(this.palSelector_PalChanged);
            this.palSelector.PalModified += new System.EventHandler(this.palSelector_PalModified);
            // 
            // pTile
            // 
            this.pTile.Location = new System.Drawing.Point(344, 3);
            this.pTile.Name = "pTile";
            this.pTile.Size = new System.Drawing.Size(64, 64);
            this.pTile.TabIndex = 1;
            this.pTile.TabStop = false;
            this.pTile.Paint += new System.Windows.Forms.PaintEventHandler(this.pTile_Paint);
            this.pTile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pTile_MouseClick);
            this.pTile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pTile_MouseUp);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(3, 32);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import...";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(3, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pTileset
            // 
            this.pTileset.ContextMenuStrip = this.contextControls;
            this.pTileset.Location = new System.Drawing.Point(3, 61);
            this.pTileset.Name = "pTileset";
            this.pTileset.Size = new System.Drawing.Size(128, 50);
            this.pTileset.TabIndex = 0;
            this.pTileset.TabStop = false;
            this.pTileset.Paint += new System.Windows.Forms.PaintEventHandler(this.pTileset_Paint);
            this.pTileset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pTileset_MouseClick);
            this.pTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pTileset_MouseDown);
            // 
            // dlgImport
            // 
            this.dlgImport.Filter = "Image files|*.png;*.bmp";
            // 
            // dlgExport
            // 
            this.dlgExport.Filter = "PNG files|*.png|Bitmap files|*.bmp";
            // 
            // ArrangementEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Name = "ArrangementEditor";
            this.Size = new System.Drawing.Size(699, 608);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitLeft.Panel1.ResumeLayout(false);
            this.splitLeft.Panel2.ResumeLayout(false);
            this.splitLeft.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).EndInit();
            this.splitLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pArr)).EndInit();
            this.contextControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTileset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.SplitContainer splitLeft;
        private System.Windows.Forms.PictureBox pArr;
        private PalSelector palSelector;
        private System.Windows.Forms.PictureBox pTile;
        private System.Windows.Forms.PictureBox pTileset;
        private System.Windows.Forms.ContextMenuStrip contextControls;
        private System.Windows.Forms.ToolStripMenuItem mnuControlGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuControlZoom;
        private System.Windows.Forms.CheckBox chkFlipV;
        private System.Windows.Forms.CheckBox chkFlipH;
        private System.Windows.Forms.Button btnTileMenu;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.OpenFileDialog dlgImport;
        private System.Windows.Forms.SaveFileDialog dlgExport;




    }
}
