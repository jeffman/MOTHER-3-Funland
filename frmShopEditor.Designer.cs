namespace MOTHER3Funland
{
	partial class frmShopEditor
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
			this.cboShop = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.btnApply = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cboShop
			// 
			this.cboShop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboShop.FormattingEnabled = true;
			this.cboShop.Location = new System.Drawing.Point(62, 12);
			this.cboShop.Name = "cboShop";
			this.cboShop.Size = new System.Drawing.Size(270, 21);
			this.cboShop.TabIndex = 0;
			this.cboShop.SelectedIndexChanged += new System.EventHandler(this.cboShop_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Shop";
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Location = new System.Drawing.Point(12, 39);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(320, 342);
			this.tabMain.TabIndex = 2;
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnApply.Location = new System.Drawing.Point(184, 387);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(148, 23);
			this.btnApply.TabIndex = 5;
			this.btnApply.Text = "Apply changes";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// frmShopEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 422);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboShop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(350, 450);
			this.Name = "frmShopEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Shop editor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cboShop;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.Button btnApply;
	}
}