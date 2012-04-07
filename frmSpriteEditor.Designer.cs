namespace MOTHER3Funland
{
	partial class frmSpriteEditor
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
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.cboChar = new System.Windows.Forms.ComboBox();
            this.cboSprite = new System.Windows.Forms.ComboBox();
            this.pSprite = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbZoom = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.panelSprite = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.btnApply = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPalNum = new System.Windows.Forms.ComboBox();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pOam = new System.Windows.Forms.PictureBox();
            this.chkFlipV = new System.Windows.Forms.CheckBox();
            this.chkFlipH = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOamY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOamX = new System.Windows.Forms.TextBox();
            this.cboOam = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).BeginInit();
            this.panelSprite.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pOam)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBank
            // 
            this.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Location = new System.Drawing.Point(84, 19);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(121, 21);
            this.cboBank.TabIndex = 0;
            this.cboBank.SelectedIndexChanged += new System.EventHandler(this.cboBank_SelectedIndexChanged);
            // 
            // cboChar
            // 
            this.cboChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChar.FormattingEnabled = true;
            this.cboChar.Location = new System.Drawing.Point(84, 46);
            this.cboChar.Name = "cboChar";
            this.cboChar.Size = new System.Drawing.Size(256, 21);
            this.cboChar.TabIndex = 1;
            this.cboChar.SelectedIndexChanged += new System.EventHandler(this.cboChar_SelectedIndexChanged);
            // 
            // cboSprite
            // 
            this.cboSprite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSprite.FormattingEnabled = true;
            this.cboSprite.Location = new System.Drawing.Point(84, 73);
            this.cboSprite.Name = "cboSprite";
            this.cboSprite.Size = new System.Drawing.Size(121, 21);
            this.cboSprite.TabIndex = 2;
            this.cboSprite.SelectedIndexChanged += new System.EventHandler(this.cboSprite_SelectedIndexChanged);
            // 
            // pSprite
            // 
            this.pSprite.Location = new System.Drawing.Point(3, 3);
            this.pSprite.Name = "pSprite";
            this.pSprite.Size = new System.Drawing.Size(100, 50);
            this.pSprite.TabIndex = 3;
            this.pSprite.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Character";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sprite";
            // 
            // tbZoom
            // 
            this.tbZoom.AutoSize = false;
            this.tbZoom.Location = new System.Drawing.Point(84, 100);
            this.tbZoom.Maximum = 4;
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Size = new System.Drawing.Size(121, 26);
            this.tbZoom.TabIndex = 7;
            this.tbZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbZoom.Scroll += new System.EventHandler(this.tbZoom_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Zoom";
            // 
            // panelSprite
            // 
            this.panelSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSprite.AutoScroll = true;
            this.panelSprite.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSprite.Controls.Add(this.pSprite);
            this.panelSprite.Location = new System.Drawing.Point(12, 153);
            this.panelSprite.Name = "panelSprite";
            this.panelSprite.Size = new System.Drawing.Size(614, 330);
            this.panelSprite.TabIndex = 9;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(230, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(110, 20);
            this.txtSearch.TabIndex = 10;
            this.ttMain.SetToolTip(this.txtSearch, "Search (type a keyword and press Enter)");
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(93, 489);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(12, 489);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "Import...";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "PNG files|*.png|Bitmap files|*.bmp";
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "PNG files|*.png|Bitmap files|*.bmp";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(478, 489);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Palette";
            // 
            // cboPalNum
            // 
            this.cboPalNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPalNum.FormattingEnabled = true;
            this.cboPalNum.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cboPalNum.Location = new System.Drawing.Point(276, 73);
            this.cboPalNum.Name = "cboPalNum";
            this.cboPalNum.Size = new System.Drawing.Size(64, 21);
            this.cboPalNum.TabIndex = 15;
            this.cboPalNum.SelectedIndexChanged += new System.EventHandler(this.cboPalNum_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboChar);
            this.groupBox1.Controls.Add(this.cboPalNum);
            this.groupBox1.Controls.Add(this.cboSprite);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbZoom);
            this.groupBox1.Controls.Add(this.cboBank);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 135);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selector";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.chkFlipV);
            this.groupBox2.Controls.Add(this.chkFlipH);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtOamY);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtOamX);
            this.groupBox2.Controls.Add(this.cboOam);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(379, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 135);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sprite arrangement";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pOam);
            this.panel1.Location = new System.Drawing.Point(131, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(104, 104);
            this.panel1.TabIndex = 25;
            // 
            // pOam
            // 
            this.pOam.Location = new System.Drawing.Point(3, 3);
            this.pOam.Name = "pOam";
            this.pOam.Size = new System.Drawing.Size(64, 64);
            this.pOam.TabIndex = 0;
            this.pOam.TabStop = false;
            // 
            // chkFlipV
            // 
            this.chkFlipV.AutoSize = true;
            this.chkFlipV.Location = new System.Drawing.Point(92, 102);
            this.chkFlipV.Name = "chkFlipV";
            this.chkFlipV.Size = new System.Drawing.Size(33, 17);
            this.chkFlipV.TabIndex = 24;
            this.chkFlipV.Text = "V";
            this.chkFlipV.UseVisualStyleBackColor = true;
            // 
            // chkFlipH
            // 
            this.chkFlipH.AutoSize = true;
            this.chkFlipH.Location = new System.Drawing.Point(52, 102);
            this.chkFlipH.Name = "chkFlipH";
            this.chkFlipH.Size = new System.Drawing.Size(34, 17);
            this.chkFlipH.TabIndex = 23;
            this.chkFlipH.Text = "H";
            this.chkFlipH.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Flip";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Y";
            // 
            // txtOamY
            // 
            this.txtOamY.Location = new System.Drawing.Point(52, 73);
            this.txtOamY.MaxLength = 4;
            this.txtOamY.Name = "txtOamY";
            this.txtOamY.Size = new System.Drawing.Size(64, 20);
            this.txtOamY.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "X";
            // 
            // txtOamX
            // 
            this.txtOamX.Location = new System.Drawing.Point(52, 47);
            this.txtOamX.MaxLength = 4;
            this.txtOamX.Name = "txtOamX";
            this.txtOamX.Size = new System.Drawing.Size(64, 20);
            this.txtOamX.TabIndex = 18;
            // 
            // cboOam
            // 
            this.cboOam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOam.FormattingEnabled = true;
            this.cboOam.Location = new System.Drawing.Point(52, 19);
            this.cboOam.Name = "cboOam";
            this.cboOam.Size = new System.Drawing.Size(64, 21);
            this.cboOam.TabIndex = 17;
            this.cboOam.SelectedIndexChanged += new System.EventHandler(this.cboOam_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Chunk";
            // 
            // frmSpriteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 524);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.panelSprite);
            this.MinimumSize = new System.Drawing.Size(654, 562);
            this.Name = "frmSpriteEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sprite editor";
            ((System.ComponentModel.ISupportInitialize)(this.pSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).EndInit();
            this.panelSprite.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pOam)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cboBank;
		private System.Windows.Forms.ComboBox cboChar;
		private System.Windows.Forms.ComboBox cboSprite;
		private System.Windows.Forms.PictureBox pSprite;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar tbZoom;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panelSprite;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.SaveFileDialog dlgSave;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboPalNum;
		private System.Windows.Forms.ToolTip ttMain;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cboOam;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtOamY;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtOamX;
		private System.Windows.Forms.CheckBox chkFlipV;
		private System.Windows.Forms.CheckBox chkFlipH;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pOam;
	}
}