namespace MOTHER3Funland
{
    partial class frmBattleBgEntryEditor
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
            this.cboEntry = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAnimStop = new System.Windows.Forms.Button();
            this.btnAnimStart = new System.Windows.Forms.Button();
            this.pAnimation = new System.Windows.Forms.PictureBox();
            this.btnAnimNext = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEntry
            // 
            this.cboEntry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntry.FormattingEnabled = true;
            this.cboEntry.Location = new System.Drawing.Point(49, 12);
            this.cboEntry.Name = "cboEntry";
            this.cboEntry.Size = new System.Drawing.Size(128, 21);
            this.cboEntry.TabIndex = 0;
            this.cboEntry.SelectedIndexChanged += new System.EventHandler(this.cboEntry_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entry";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(457, 336);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAnimNext);
            this.groupBox1.Controls.Add(this.btnAnimStop);
            this.groupBox1.Controls.Add(this.btnAnimStart);
            this.groupBox1.Controls.Add(this.pAnimation);
            this.groupBox1.Location = new System.Drawing.Point(337, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 312);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animation";
            // 
            // btnAnimStop
            // 
            this.btnAnimStop.Enabled = false;
            this.btnAnimStop.Location = new System.Drawing.Point(87, 281);
            this.btnAnimStop.Name = "btnAnimStop";
            this.btnAnimStop.Size = new System.Drawing.Size(75, 23);
            this.btnAnimStop.TabIndex = 2;
            this.btnAnimStop.Text = "Stop";
            this.btnAnimStop.UseVisualStyleBackColor = true;
            this.btnAnimStop.Click += new System.EventHandler(this.btnAnimStop_Click);
            // 
            // btnAnimStart
            // 
            this.btnAnimStart.Location = new System.Drawing.Point(6, 281);
            this.btnAnimStart.Name = "btnAnimStart";
            this.btnAnimStart.Size = new System.Drawing.Size(75, 23);
            this.btnAnimStart.TabIndex = 1;
            this.btnAnimStart.Text = "Start";
            this.btnAnimStart.UseVisualStyleBackColor = true;
            this.btnAnimStart.Click += new System.EventHandler(this.btnAnimStart_Click);
            // 
            // pAnimation
            // 
            this.pAnimation.Location = new System.Drawing.Point(6, 19);
            this.pAnimation.Name = "pAnimation";
            this.pAnimation.Size = new System.Drawing.Size(256, 256);
            this.pAnimation.TabIndex = 0;
            this.pAnimation.TabStop = false;
            this.pAnimation.Paint += new System.Windows.Forms.PaintEventHandler(this.pAnimation_Paint);
            // 
            // btnAnimNext
            // 
            this.btnAnimNext.Enabled = false;
            this.btnAnimNext.Location = new System.Drawing.Point(168, 281);
            this.btnAnimNext.Name = "btnAnimNext";
            this.btnAnimNext.Size = new System.Drawing.Size(75, 23);
            this.btnAnimNext.TabIndex = 3;
            this.btnAnimNext.Text = "Next";
            this.btnAnimNext.UseVisualStyleBackColor = true;
            this.btnAnimNext.Click += new System.EventHandler(this.btnAnimNext_Click);
            // 
            // frmBattleBgEntryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 371);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEntry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBattleBgEntryEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Battle BG entry editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBattleBgEntryEditor_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pAnimation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pAnimation;
        private System.Windows.Forms.Button btnAnimStop;
        private System.Windows.Forms.Button btnAnimStart;
        private System.Windows.Forms.Button btnAnimNext;
    }
}