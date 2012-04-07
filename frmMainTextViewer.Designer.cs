namespace MOTHER3Funland
{
    partial class frmMainTextViewer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.lstLines = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboRoom = new MOTHER3Funland.ComboSearch();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room";
            // 
            // txtLine
            // 
            this.txtLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLine.Location = new System.Drawing.Point(0, 0);
            this.txtLine.Multiline = true;
            this.txtLine.Name = "txtLine";
            this.txtLine.ReadOnly = true;
            this.txtLine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLine.Size = new System.Drawing.Size(460, 132);
            this.txtLine.TabIndex = 7;
            // 
            // lstLines
            // 
            this.lstLines.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLines.FormattingEnabled = true;
            this.lstLines.Location = new System.Drawing.Point(0, 0);
            this.lstLines.Name = "lstLines";
            this.lstLines.Size = new System.Drawing.Size(460, 250);
            this.lstLines.TabIndex = 8;
            this.lstLines.SelectedIndexChanged += new System.EventHandler(this.lstLines_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(12, 39);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstLines);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLine);
            this.splitContainer1.Size = new System.Drawing.Size(460, 386);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 9;
            // 
            // cboRoom
            // 
            this.cboRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRoom.Location = new System.Drawing.Point(50, 12);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.SelectedIndex = -1;
            this.cboRoom.Size = new System.Drawing.Size(422, 21);
            this.cboRoom.TabIndex = 10;
            this.cboRoom.SelectedIndexChanged += new System.EventHandler(this.cboRoom_SelectedIndexChanged);
            // 
            // frmMainTextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 437);
            this.Controls.Add(this.cboRoom);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(500, 475);
            this.Name = "frmMainTextViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main text viewer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.ListBox lstLines;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ComboSearch cboRoom;
    }
}