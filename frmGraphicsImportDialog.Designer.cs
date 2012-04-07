namespace MOTHER3Funland
{
	partial class frmGraphicsImportDialog
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
			this.chkFlips = new System.Windows.Forms.CheckBox();
			this.chkTileset = new System.Windows.Forms.CheckBox();
			this.chkPal = new System.Windows.Forms.CheckBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.chkTransparent = new System.Windows.Forms.CheckBox();
			this.lblTransparent = new System.Windows.Forms.Label();
			this.dlgTransparent = new System.Windows.Forms.ColorDialog();
			this.SuspendLayout();
			// 
			// chkFlips
			// 
			this.chkFlips.AutoSize = true;
			this.chkFlips.Checked = true;
			this.chkFlips.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFlips.Location = new System.Drawing.Point(45, 35);
			this.chkFlips.Name = "chkFlips";
			this.chkFlips.Size = new System.Drawing.Size(93, 17);
			this.chkFlips.TabIndex = 0;
			this.chkFlips.Text = "Check for flips";
			this.chkFlips.UseVisualStyleBackColor = true;
			// 
			// chkTileset
			// 
			this.chkTileset.AutoSize = true;
			this.chkTileset.Location = new System.Drawing.Point(12, 12);
			this.chkTileset.Name = "chkTileset";
			this.chkTileset.Size = new System.Drawing.Size(111, 17);
			this.chkTileset.TabIndex = 1;
			this.chkTileset.Text = "Use current tileset";
			this.chkTileset.UseVisualStyleBackColor = true;
			this.chkTileset.CheckedChanged += new System.EventHandler(this.chkTileset_CheckedChanged);
			// 
			// chkPal
			// 
			this.chkPal.AutoSize = true;
			this.chkPal.Location = new System.Drawing.Point(12, 58);
			this.chkPal.Name = "chkPal";
			this.chkPal.Size = new System.Drawing.Size(116, 17);
			this.chkPal.TabIndex = 2;
			this.chkPal.Text = "Use current palette";
			this.chkPal.UseVisualStyleBackColor = true;
			this.chkPal.CheckedChanged += new System.EventHandler(this.chkPal_CheckedChanged);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(124, 120);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(205, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// chkTransparent
			// 
			this.chkTransparent.AutoSize = true;
			this.chkTransparent.Location = new System.Drawing.Point(45, 81);
			this.chkTransparent.Name = "chkTransparent";
			this.chkTransparent.Size = new System.Drawing.Size(112, 17);
			this.chkTransparent.TabIndex = 5;
			this.chkTransparent.Text = "Transparent color:";
			this.chkTransparent.UseVisualStyleBackColor = true;
			// 
			// lblTransparent
			// 
			this.lblTransparent.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
			this.lblTransparent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTransparent.Location = new System.Drawing.Point(163, 78);
			this.lblTransparent.Name = "lblTransparent";
			this.lblTransparent.Size = new System.Drawing.Size(24, 24);
			this.lblTransparent.TabIndex = 6;
			this.lblTransparent.Click += new System.EventHandler(this.lblTransparent_Click);
			// 
			// frmGraphicsImportDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 155);
			this.Controls.Add(this.lblTransparent);
			this.Controls.Add(this.chkTransparent);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.chkPal);
			this.Controls.Add(this.chkTileset);
			this.Controls.Add(this.chkFlips);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmGraphicsImportDialog";
			this.ShowInTaskbar = false;
			this.Text = "Import graphics";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkFlips;
		private System.Windows.Forms.CheckBox chkTileset;
		private System.Windows.Forms.CheckBox chkPal;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox chkTransparent;
		private System.Windows.Forms.Label lblTransparent;
		private System.Windows.Forms.ColorDialog dlgTransparent;
	}
}