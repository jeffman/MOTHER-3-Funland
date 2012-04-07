namespace MOTHER3Funland
{
    partial class frmMapViewer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.pMap = new System.Windows.Forms.PictureBox();
            this.mnuMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMapCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMapSave = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSaveImage = new System.Windows.Forms.SaveFileDialog();
            this.cboRoom = new MOTHER3Funland.ComboSearch();
            this.pnlMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMap)).BeginInit();
            this.mnuMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room";
            // 
            // pnlMap
            // 
            this.pnlMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMap.AutoScroll = true;
            this.pnlMap.Controls.Add(this.pMap);
            this.pnlMap.Location = new System.Drawing.Point(0, 62);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(484, 400);
            this.pnlMap.TabIndex = 4;
            // 
            // pMap
            // 
            this.pMap.ContextMenuStrip = this.mnuMap;
            this.pMap.Location = new System.Drawing.Point(0, 0);
            this.pMap.Name = "pMap";
            this.pMap.Size = new System.Drawing.Size(100, 50);
            this.pMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pMap.TabIndex = 0;
            this.pMap.TabStop = false;
            // 
            // mnuMap
            // 
            this.mnuMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMapCopy,
            this.mnuMapSave});
            this.mnuMap.Name = "mnuMap";
            this.mnuMap.Size = new System.Drawing.Size(144, 48);
            // 
            // mnuMapCopy
            // 
            this.mnuMapCopy.Image = global::MOTHER3Funland.Properties.Resources.blue_document_copy;
            this.mnuMapCopy.Name = "mnuMapCopy";
            this.mnuMapCopy.Size = new System.Drawing.Size(152, 22);
            this.mnuMapCopy.Text = "Copy";
            this.mnuMapCopy.Click += new System.EventHandler(this.mnuMapCopy_Click);
            // 
            // mnuMapSave
            // 
            this.mnuMapSave.Image = global::MOTHER3Funland.Properties.Resources.disk;
            this.mnuMapSave.Name = "mnuMapSave";
            this.mnuMapSave.Size = new System.Drawing.Size(152, 22);
            this.mnuMapSave.Text = "Save image...";
            this.mnuMapSave.Click += new System.EventHandler(this.mnuMapSave_Click);
            // 
            // dlgSaveImage
            // 
            this.dlgSaveImage.Filter = "PNG files|*.png|Bitmap files|*.bmp|All files|*.*";
            // 
            // cboRoom
            // 
            this.cboRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRoom.Location = new System.Drawing.Point(53, 12);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.SelectedIndex = -1;
            this.cboRoom.Size = new System.Drawing.Size(419, 21);
            this.cboRoom.TabIndex = 5;
            this.cboRoom.SelectedIndexChanged += new System.EventHandler(this.cboRoom_SelectedIndexChanged);
            // 
            // frmMapViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.cboRoom);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmMapViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Map viewer";
            this.pnlMap.ResumeLayout(false);
            this.pnlMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMap)).EndInit();
            this.mnuMap.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.PictureBox pMap;
        private System.Windows.Forms.ContextMenuStrip mnuMap;
        private System.Windows.Forms.ToolStripMenuItem mnuMapCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuMapSave;
        private System.Windows.Forms.SaveFileDialog dlgSaveImage;
        private ComboSearch cboRoom;
    }
}