namespace MOTHER3Funland
{
	partial class frmCompression
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
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDecomp = new System.Windows.Forms.Button();
			this.dlgSave = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(89, 12);
			this.txtAddress.MaxLength = 7;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(100, 20);
			this.txtAddress.TabIndex = 0;
			this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Address (hex)";
			// 
			// btnDecomp
			// 
			this.btnDecomp.Location = new System.Drawing.Point(89, 38);
			this.btnDecomp.Name = "btnDecomp";
			this.btnDecomp.Size = new System.Drawing.Size(75, 23);
			this.btnDecomp.TabIndex = 2;
			this.btnDecomp.Text = "Decomp";
			this.btnDecomp.UseVisualStyleBackColor = true;
			this.btnDecomp.Click += new System.EventHandler(this.btnDecomp_Click);
			// 
			// dlgSave
			// 
			this.dlgSave.Filter = "GBA files|*.gba|Bin files|*.bin|All files|*.*";
			// 
			// frmCompression
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(206, 71);
			this.Controls.Add(this.btnDecomp);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtAddress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmCompression";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Compression";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDecomp;
		private System.Windows.Forms.SaveFileDialog dlgSave;
	}
}