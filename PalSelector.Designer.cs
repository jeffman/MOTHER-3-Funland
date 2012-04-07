namespace MOTHER3Funland
{
	partial class PalSelector
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
			this.grpMain = new System.Windows.Forms.GroupBox();
			this.lblPalPrimary = new System.Windows.Forms.Label();
			this.lblPalSecondary = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cboPalIndex = new System.Windows.Forms.ComboBox();
			this.dlgColor = new System.Windows.Forms.ColorDialog();
			this.grpMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpMain
			// 
			this.grpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpMain.Controls.Add(this.lblPalPrimary);
			this.grpMain.Controls.Add(this.lblPalSecondary);
			this.grpMain.Controls.Add(this.label1);
			this.grpMain.Controls.Add(this.cboPalIndex);
			this.grpMain.Location = new System.Drawing.Point(1, -5);
			this.grpMain.Name = "grpMain";
			this.grpMain.Size = new System.Drawing.Size(263, 97);
			this.grpMain.TabIndex = 0;
			this.grpMain.TabStop = false;
			// 
			// lblPalPrimary
			// 
			this.lblPalPrimary.BackColor = System.Drawing.Color.White;
			this.lblPalPrimary.Location = new System.Drawing.Point(6, 40);
			this.lblPalPrimary.Name = "lblPalPrimary";
			this.lblPalPrimary.Size = new System.Drawing.Size(32, 32);
			this.lblPalPrimary.TabIndex = 2;
			// 
			// lblPalSecondary
			// 
			this.lblPalSecondary.BackColor = System.Drawing.Color.White;
			this.lblPalSecondary.Location = new System.Drawing.Point(23, 57);
			this.lblPalSecondary.Name = "lblPalSecondary";
			this.lblPalSecondary.Size = new System.Drawing.Size(32, 32);
			this.lblPalSecondary.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Palette";
			// 
			// cboPalIndex
			// 
			this.cboPalIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPalIndex.FormattingEnabled = true;
			this.cboPalIndex.Location = new System.Drawing.Point(52, 12);
			this.cboPalIndex.Name = "cboPalIndex";
			this.cboPalIndex.Size = new System.Drawing.Size(121, 21);
			this.cboPalIndex.TabIndex = 0;
			this.cboPalIndex.SelectedIndexChanged += new System.EventHandler(this.cboPalIndex_SelectedIndexChanged);
			// 
			// dlgColor
			// 
			this.dlgColor.FullOpen = true;
			// 
			// PalSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grpMain);
			this.MaximumSize = new System.Drawing.Size(265, 92);
			this.MinimumSize = new System.Drawing.Size(265, 92);
			this.Name = "PalSelector";
			this.Size = new System.Drawing.Size(265, 92);
			this.grpMain.ResumeLayout(false);
			this.grpMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpMain;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboPalIndex;
		private System.Windows.Forms.Label lblPalPrimary;
		private System.Windows.Forms.Label lblPalSecondary;
		private System.Windows.Forms.ColorDialog dlgColor;
	}
}
