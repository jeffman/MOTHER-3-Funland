namespace MOTHER3Funland
{
	partial class frmItemEditor
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabBasic = new System.Windows.Forms.TabPage();
			this.cboItemType = new System.Windows.Forms.ComboBox();
			this.chkKeyItem = new System.Windows.Forms.CheckBox();
			this.lblItemType = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtHp2 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtHp1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSpeed = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtIq = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDef = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtOff = new System.Windows.Forms.TextBox();
			this.lblPp = new System.Windows.Forms.Label();
			this.txtPp = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSell = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.tabAilments = new System.Windows.Forms.TabPage();
			this.tabPsi = new System.Windows.Forms.TabPage();
			this.tabGraphics = new System.Windows.Forms.TabPage();
			this.flowGraphicsMain = new System.Windows.Forms.FlowLayoutPanel();
			this.flowItemIcon = new System.Windows.Forms.FlowLayoutPanel();
			this.label21 = new System.Windows.Forms.Label();
			this.pIcon = new System.Windows.Forms.PictureBox();
			this.mnuGraphics = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuGraphicsCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuGraphicsSave = new System.Windows.Forms.ToolStripMenuItem();
			this.btnApply = new System.Windows.Forms.Button();
			this.dlgSaveImage = new System.Windows.Forms.SaveFileDialog();
			this.cboItem = new MOTHER3Funland.ComboSearch();
			this.tabMain.SuspendLayout();
			this.tabBasic.SuspendLayout();
			this.tabGraphics.SuspendLayout();
			this.flowGraphicsMain.SuspendLayout();
			this.flowItemIcon.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pIcon)).BeginInit();
			this.mnuGraphics.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(11, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Item";
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabBasic);
			this.tabMain.Controls.Add(this.tabAilments);
			this.tabMain.Controls.Add(this.tabPsi);
			this.tabMain.Controls.Add(this.tabGraphics);
			this.tabMain.Location = new System.Drawing.Point(14, 39);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(418, 392);
			this.tabMain.TabIndex = 46;
			// 
			// tabBasic
			// 
			this.tabBasic.Controls.Add(this.cboItemType);
			this.tabBasic.Controls.Add(this.chkKeyItem);
			this.tabBasic.Controls.Add(this.lblItemType);
			this.tabBasic.Controls.Add(this.txtDescription);
			this.tabBasic.Controls.Add(this.label9);
			this.tabBasic.Controls.Add(this.label7);
			this.tabBasic.Controls.Add(this.txtHp2);
			this.tabBasic.Controls.Add(this.label8);
			this.tabBasic.Controls.Add(this.txtHp1);
			this.tabBasic.Controls.Add(this.label5);
			this.tabBasic.Controls.Add(this.txtSpeed);
			this.tabBasic.Controls.Add(this.label6);
			this.tabBasic.Controls.Add(this.txtIq);
			this.tabBasic.Controls.Add(this.label4);
			this.tabBasic.Controls.Add(this.txtDef);
			this.tabBasic.Controls.Add(this.label11);
			this.tabBasic.Controls.Add(this.txtOff);
			this.tabBasic.Controls.Add(this.lblPp);
			this.tabBasic.Controls.Add(this.txtPp);
			this.tabBasic.Controls.Add(this.label2);
			this.tabBasic.Controls.Add(this.txtSell);
			this.tabBasic.Controls.Add(this.label17);
			this.tabBasic.Controls.Add(this.txtName);
			this.tabBasic.Location = new System.Drawing.Point(4, 22);
			this.tabBasic.Name = "tabBasic";
			this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
			this.tabBasic.Size = new System.Drawing.Size(410, 366);
			this.tabBasic.TabIndex = 0;
			this.tabBasic.Text = "Basic";
			this.tabBasic.UseVisualStyleBackColor = true;
			// 
			// cboItemType
			// 
			this.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboItemType.FormattingEnabled = true;
			this.cboItemType.Location = new System.Drawing.Point(273, 31);
			this.cboItemType.Name = "cboItemType";
			this.cboItemType.Size = new System.Drawing.Size(121, 21);
			this.cboItemType.TabIndex = 68;
			// 
			// chkKeyItem
			// 
			this.chkKeyItem.AutoSize = true;
			this.chkKeyItem.Location = new System.Drawing.Point(280, 8);
			this.chkKeyItem.Name = "chkKeyItem";
			this.chkKeyItem.Size = new System.Drawing.Size(66, 17);
			this.chkKeyItem.TabIndex = 67;
			this.chkKeyItem.Text = "Key item";
			this.chkKeyItem.UseVisualStyleBackColor = true;
			// 
			// lblItemType
			// 
			this.lblItemType.AutoSize = true;
			this.lblItemType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblItemType.Location = new System.Drawing.Point(198, 35);
			this.lblItemType.Name = "lblItemType";
			this.lblItemType.Size = new System.Drawing.Size(31, 13);
			this.lblItemType.TabIndex = 66;
			this.lblItemType.Text = "Type";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(114, 263);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.Size = new System.Drawing.Size(265, 72);
			this.txtDescription.TabIndex = 65;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label9.Location = new System.Drawing.Point(7, 266);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(60, 13);
			this.label9.TabIndex = 64;
			this.label9.Text = "Description";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label7.Location = new System.Drawing.Point(8, 191);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 13);
			this.label7.TabIndex = 63;
			this.label7.Text = "Lower HP";
			// 
			// txtHp2
			// 
			this.txtHp2.Location = new System.Drawing.Point(114, 214);
			this.txtHp2.MaxLength = 5;
			this.txtHp2.Name = "txtHp2";
			this.txtHp2.Size = new System.Drawing.Size(64, 20);
			this.txtHp2.TabIndex = 62;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label8.Location = new System.Drawing.Point(8, 217);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 13);
			this.label8.TabIndex = 61;
			this.label8.Text = "Upper HP";
			// 
			// txtHp1
			// 
			this.txtHp1.Location = new System.Drawing.Point(114, 188);
			this.txtHp1.MaxLength = 5;
			this.txtHp1.Name = "txtHp1";
			this.txtHp1.Size = new System.Drawing.Size(64, 20);
			this.txtHp1.TabIndex = 60;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(8, 165);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(81, 13);
			this.label5.TabIndex = 59;
			this.label5.Text = "Speed increase";
			// 
			// txtSpeed
			// 
			this.txtSpeed.Location = new System.Drawing.Point(114, 162);
			this.txtSpeed.MaxLength = 3;
			this.txtSpeed.Name = "txtSpeed";
			this.txtSpeed.Size = new System.Drawing.Size(64, 20);
			this.txtSpeed.TabIndex = 58;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label6.Location = new System.Drawing.Point(8, 139);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 13);
			this.label6.TabIndex = 57;
			this.label6.Text = "IQ increase";
			// 
			// txtIq
			// 
			this.txtIq.Location = new System.Drawing.Point(114, 136);
			this.txtIq.MaxLength = 3;
			this.txtIq.Name = "txtIq";
			this.txtIq.Size = new System.Drawing.Size(64, 20);
			this.txtIq.TabIndex = 56;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(8, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 13);
			this.label4.TabIndex = 55;
			this.label4.Text = "Defense increase";
			// 
			// txtDef
			// 
			this.txtDef.Location = new System.Drawing.Point(114, 110);
			this.txtDef.MaxLength = 3;
			this.txtDef.Name = "txtDef";
			this.txtDef.Size = new System.Drawing.Size(64, 20);
			this.txtDef.TabIndex = 54;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label11.Location = new System.Drawing.Point(8, 87);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(87, 13);
			this.label11.TabIndex = 53;
			this.label11.Text = "Offense increase";
			// 
			// txtOff
			// 
			this.txtOff.Location = new System.Drawing.Point(114, 84);
			this.txtOff.MaxLength = 3;
			this.txtOff.Name = "txtOff";
			this.txtOff.Size = new System.Drawing.Size(64, 20);
			this.txtOff.TabIndex = 52;
			// 
			// lblPp
			// 
			this.lblPp.AutoSize = true;
			this.lblPp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblPp.Location = new System.Drawing.Point(7, 61);
			this.lblPp.Name = "lblPp";
			this.lblPp.Size = new System.Drawing.Size(64, 13);
			this.lblPp.TabIndex = 51;
			this.lblPp.Text = "PP increase";
			// 
			// txtPp
			// 
			this.txtPp.Location = new System.Drawing.Point(114, 58);
			this.txtPp.MaxLength = 5;
			this.txtPp.Name = "txtPp";
			this.txtPp.Size = new System.Drawing.Size(64, 20);
			this.txtPp.TabIndex = 50;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(7, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 49;
			this.label2.Text = "Sell price";
			// 
			// txtSell
			// 
			this.txtSell.Location = new System.Drawing.Point(114, 32);
			this.txtSell.MaxLength = 5;
			this.txtSell.Name = "txtSell";
			this.txtSell.Size = new System.Drawing.Size(64, 20);
			this.txtSell.TabIndex = 48;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label17.Location = new System.Drawing.Point(7, 9);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(35, 13);
			this.label17.TabIndex = 47;
			this.label17.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(114, 6);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(160, 20);
			this.txtName.TabIndex = 46;
			// 
			// tabAilments
			// 
			this.tabAilments.Location = new System.Drawing.Point(4, 22);
			this.tabAilments.Name = "tabAilments";
			this.tabAilments.Padding = new System.Windows.Forms.Padding(3);
			this.tabAilments.Size = new System.Drawing.Size(410, 366);
			this.tabAilments.TabIndex = 1;
			this.tabAilments.Text = "Protection (ailments)";
			this.tabAilments.UseVisualStyleBackColor = true;
			// 
			// tabPsi
			// 
			this.tabPsi.Location = new System.Drawing.Point(4, 22);
			this.tabPsi.Name = "tabPsi";
			this.tabPsi.Padding = new System.Windows.Forms.Padding(3);
			this.tabPsi.Size = new System.Drawing.Size(410, 366);
			this.tabPsi.TabIndex = 2;
			this.tabPsi.Text = "Protection (PSI)";
			this.tabPsi.UseVisualStyleBackColor = true;
			// 
			// tabGraphics
			// 
			this.tabGraphics.Controls.Add(this.flowGraphicsMain);
			this.tabGraphics.Location = new System.Drawing.Point(4, 22);
			this.tabGraphics.Name = "tabGraphics";
			this.tabGraphics.Padding = new System.Windows.Forms.Padding(3);
			this.tabGraphics.Size = new System.Drawing.Size(410, 366);
			this.tabGraphics.TabIndex = 3;
			this.tabGraphics.Text = "Graphics";
			this.tabGraphics.UseVisualStyleBackColor = true;
			// 
			// flowGraphicsMain
			// 
			this.flowGraphicsMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flowGraphicsMain.Controls.Add(this.flowItemIcon);
			this.flowGraphicsMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowGraphicsMain.Location = new System.Drawing.Point(6, 6);
			this.flowGraphicsMain.Name = "flowGraphicsMain";
			this.flowGraphicsMain.Size = new System.Drawing.Size(398, 354);
			this.flowGraphicsMain.TabIndex = 0;
			// 
			// flowItemIcon
			// 
			this.flowItemIcon.AutoSize = true;
			this.flowItemIcon.Controls.Add(this.label21);
			this.flowItemIcon.Controls.Add(this.pIcon);
			this.flowItemIcon.Location = new System.Drawing.Point(3, 3);
			this.flowItemIcon.Name = "flowItemIcon";
			this.flowItemIcon.Size = new System.Drawing.Size(146, 56);
			this.flowItemIcon.TabIndex = 0;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label21.Location = new System.Drawing.Point(3, 0);
			this.label21.Name = "label21";
			this.label21.Padding = new System.Windows.Forms.Padding(0, 2, 6, 0);
			this.label21.Size = new System.Drawing.Size(34, 15);
			this.label21.TabIndex = 1;
			this.label21.Text = "Icon";
			// 
			// pIcon
			// 
			this.pIcon.ContextMenuStrip = this.mnuGraphics;
			this.pIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.pIcon.Location = new System.Drawing.Point(43, 3);
			this.pIcon.Name = "pIcon";
			this.pIcon.Size = new System.Drawing.Size(100, 50);
			this.pIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pIcon.TabIndex = 2;
			this.pIcon.TabStop = false;
			// 
			// mnuGraphics
			// 
			this.mnuGraphics.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGraphicsCopy,
            this.mnuGraphicsSave});
			this.mnuGraphics.Name = "mnuGraphics";
			this.mnuGraphics.Size = new System.Drawing.Size(153, 70);
			// 
			// mnuGraphicsCopy
			// 
			this.mnuGraphicsCopy.Image = global::MOTHER3Funland.Properties.Resources.blue_document_copy;
			this.mnuGraphicsCopy.Name = "mnuGraphicsCopy";
			this.mnuGraphicsCopy.Size = new System.Drawing.Size(152, 22);
			this.mnuGraphicsCopy.Text = "Copy";
			this.mnuGraphicsCopy.Click += new System.EventHandler(this.mnuGraphicsCopy_Click);
			// 
			// mnuGraphicsSave
			// 
			this.mnuGraphicsSave.Image = global::MOTHER3Funland.Properties.Resources.disk;
			this.mnuGraphicsSave.Name = "mnuGraphicsSave";
			this.mnuGraphicsSave.Size = new System.Drawing.Size(152, 22);
			this.mnuGraphicsSave.Text = "Save image...";
			this.mnuGraphicsSave.Click += new System.EventHandler(this.mnuGraphicsSave_Click);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnApply.Location = new System.Drawing.Point(284, 437);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(148, 23);
			this.btnApply.TabIndex = 47;
			this.btnApply.Text = "Apply changes";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// dlgSaveImage
			// 
			this.dlgSaveImage.Filter = "PNG files|*.png|Bitmap files|*.bmp|All files|*.*";
			// 
			// cboItem
			// 
			this.cboItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboItem.Location = new System.Drawing.Point(44, 12);
			this.cboItem.Name = "cboItem";
			this.cboItem.SelectedIndex = -1;
			this.cboItem.Size = new System.Drawing.Size(388, 21);
			this.cboItem.TabIndex = 48;
			this.cboItem.SelectedIndexChanged += new System.EventHandler(this.cboItem_SelectedIndexChanged);
			// 
			// frmItemEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 472);
			this.Controls.Add(this.cboItem);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(450, 500);
			this.Name = "frmItemEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Item editor";
			this.tabMain.ResumeLayout(false);
			this.tabBasic.ResumeLayout(false);
			this.tabBasic.PerformLayout();
			this.tabGraphics.ResumeLayout(false);
			this.flowGraphicsMain.ResumeLayout(false);
			this.flowGraphicsMain.PerformLayout();
			this.flowItemIcon.ResumeLayout(false);
			this.flowItemIcon.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pIcon)).EndInit();
			this.mnuGraphics.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabBasic;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtHp2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtHp1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtSpeed;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtIq;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDef;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtOff;
		private System.Windows.Forms.Label lblPp;
		private System.Windows.Forms.TextBox txtPp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSell;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TabPage tabAilments;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.TabPage tabPsi;
		private System.Windows.Forms.CheckBox chkKeyItem;
		private System.Windows.Forms.Label lblItemType;
		private System.Windows.Forms.ComboBox cboItemType;
		private System.Windows.Forms.TabPage tabGraphics;
		private System.Windows.Forms.FlowLayoutPanel flowGraphicsMain;
		private System.Windows.Forms.FlowLayoutPanel flowItemIcon;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.PictureBox pIcon;
		private System.Windows.Forms.ContextMenuStrip mnuGraphics;
		private System.Windows.Forms.ToolStripMenuItem mnuGraphicsSave;
		private System.Windows.Forms.SaveFileDialog dlgSaveImage;
		private System.Windows.Forms.ToolStripMenuItem mnuGraphicsCopy;
		private ComboSearch cboItem;
	}
}