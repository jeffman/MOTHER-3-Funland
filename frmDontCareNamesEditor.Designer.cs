namespace MOTHER3Funland
{
	partial class frmDontCareNamesEditor
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
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboChar
            // 
            this.cboChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChar.FormattingEnabled = true;
            this.cboChar.Location = new System.Drawing.Point(12, 12);
            this.cboChar.Name = "cboChar";
            this.cboChar.Size = new System.Drawing.Size(160, 21);
            this.cboChar.TabIndex = 0;
            this.cboChar.SelectedIndexChanged += new System.EventHandler(this.cboChar_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(120, 237);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 48;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmDontCareNamesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 272);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cboChar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDontCareNamesEditor";
            this.Text = "Don\'t Care names editor";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cboChar;
		private System.Windows.Forms.Button btnApply;
	}
}