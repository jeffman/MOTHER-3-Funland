namespace MOTHER3Funland
{
    partial class frmLevelPsiEditor
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
            this.cboChar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEntry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPsi = new System.Windows.Forms.ComboBox();
            this.lblPsi = new System.Windows.Forms.LinkLabel();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboChar
            // 
            this.cboChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChar.FormattingEnabled = true;
            this.cboChar.Location = new System.Drawing.Point(72, 12);
            this.cboChar.Name = "cboChar";
            this.cboChar.Size = new System.Drawing.Size(160, 21);
            this.cboChar.TabIndex = 0;
            this.cboChar.SelectedIndexChanged += new System.EventHandler(this.cboChar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Character";
            // 
            // cboEntry
            // 
            this.cboEntry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntry.FormattingEnabled = true;
            this.cboEntry.Location = new System.Drawing.Point(72, 39);
            this.cboEntry.Name = "cboEntry";
            this.cboEntry.Size = new System.Drawing.Size(200, 21);
            this.cboEntry.TabIndex = 2;
            this.cboEntry.SelectedIndexChanged += new System.EventHandler(this.cboEntry_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entry";
            // 
            // cboPsi
            // 
            this.cboPsi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPsi.FormattingEnabled = true;
            this.cboPsi.Location = new System.Drawing.Point(72, 66);
            this.cboPsi.Name = "cboPsi";
            this.cboPsi.Size = new System.Drawing.Size(200, 21);
            this.cboPsi.TabIndex = 4;
            // 
            // lblPsi
            // 
            this.lblPsi.AutoSize = true;
            this.lblPsi.Location = new System.Drawing.Point(12, 69);
            this.lblPsi.Name = "lblPsi";
            this.lblPsi.Size = new System.Drawing.Size(24, 13);
            this.lblPsi.TabIndex = 5;
            this.lblPsi.TabStop = true;
            this.lblPsi.Text = "PSI";
            this.lblPsi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPsi_LinkClicked);
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(72, 93);
            this.txtLevel.MaxLength = 5;
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(100, 20);
            this.txtLevel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Level";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(124, 123);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmLevelPsiEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 158);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.lblPsi);
            this.Controls.Add(this.cboPsi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboEntry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboChar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLevelPsiEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Level-up PSI editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboChar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEntry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPsi;
        private System.Windows.Forms.LinkLabel lblPsi;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApply;
    }
}