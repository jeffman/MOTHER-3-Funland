namespace MOTHER3Funland
{
    partial class frmLevelExpEditor
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
            this.cboLevelRange = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboChar
            // 
            this.cboChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChar.FormattingEnabled = true;
            this.cboChar.Location = new System.Drawing.Point(81, 12);
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
            // cboLevelRange
            // 
            this.cboLevelRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevelRange.FormattingEnabled = true;
            this.cboLevelRange.Location = new System.Drawing.Point(81, 65);
            this.cboLevelRange.Name = "cboLevelRange";
            this.cboLevelRange.Size = new System.Drawing.Size(160, 21);
            this.cboLevelRange.TabIndex = 2;
            this.cboLevelRange.SelectedIndexChanged += new System.EventHandler(this.cboLevelRange_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Level range";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(114, 440);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(81, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 6;
            // 
            // frmLevelExpEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 475);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLevelRange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboChar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 450);
            this.Name = "frmLevelExpEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Level-up experience editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboChar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLevelRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtName;
    }
}