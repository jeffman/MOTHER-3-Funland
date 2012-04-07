namespace MOTHER3Funland
{
	partial class frmCharNamesEditor
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
			this.btnApply = new System.Windows.Forms.Button();
			this.cboChar = new MOTHER3Funland.ComboSearch();
			this.label1 = new System.Windows.Forms.Label();
			this.txtChar = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnApply.Location = new System.Drawing.Point(230, 66);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(148, 23);
			this.btnApply.TabIndex = 49;
			this.btnApply.Text = "Apply changes";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// cboChar
			// 
			this.cboChar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboChar.DataSource = null;
			this.cboChar.Location = new System.Drawing.Point(71, 12);
			this.cboChar.Name = "cboChar";
			this.cboChar.SelectedIndex = -1;
			this.cboChar.Size = new System.Drawing.Size(307, 21);
			this.cboChar.TabIndex = 50;
			this.cboChar.SelectedIndexChanged += new System.EventHandler(this.cboChar_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 51;
			this.label1.Text = "Character";
			// 
			// txtChar
			// 
			this.txtChar.Location = new System.Drawing.Point(71, 39);
			this.txtChar.Name = "txtChar";
			this.txtChar.Size = new System.Drawing.Size(198, 20);
			this.txtChar.TabIndex = 52;
			// 
			// frmCharNamesEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 101);
			this.Controls.Add(this.txtChar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboChar);
			this.Controls.Add(this.btnApply);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmCharNamesEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Character names editor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnApply;
		private ComboSearch cboChar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtChar;
	}
}