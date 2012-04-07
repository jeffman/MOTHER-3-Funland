namespace MOTHER3Funland
{
	partial class frmBattleBgLayerEditor
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
			this.cboEntry = new System.Windows.Forms.ComboBox();
			this.mnuGraphics = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuGraphicsCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuGraphicsSave = new System.Windows.Forms.ToolStripMenuItem();
			this.dlgSaveImage = new System.Windows.Forms.SaveFileDialog();
			this.btnApply = new System.Windows.Forms.Button();
			this.ttMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblAnim = new System.Windows.Forms.Label();
			this.grpAnim = new System.Windows.Forms.GroupBox();
			this.txtGfxEntry = new System.Windows.Forms.TextBox();
			this.txtArrEntry = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPalDir = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtPalStart = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtPalEnd = new System.Windows.Forms.TextBox();
			this.txtWavenumV = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtPalDelay = new System.Windows.Forms.TextBox();
			this.txtWavenumH = new System.Windows.Forms.TextBox();
			this.txtDriftH = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtFreqV = new System.Windows.Forms.TextBox();
			this.txtDriftV = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtFreqH = new System.Windows.Forms.TextBox();
			this.txtAmplH = new System.Windows.Forms.TextBox();
			this.txtAmplV = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.arrEditor = new MOTHER3Funland.ArrangementEditor();
			this.mnuGraphics.SuspendLayout();
			this.grpAnim.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Layer";
			// 
			// cboEntry
			// 
			this.cboEntry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEntry.FormattingEnabled = true;
			this.cboEntry.Location = new System.Drawing.Point(53, 12);
			this.cboEntry.Name = "cboEntry";
			this.cboEntry.Size = new System.Drawing.Size(128, 21);
			this.cboEntry.TabIndex = 2;
			this.cboEntry.SelectedIndexChanged += new System.EventHandler(this.cboEntry_SelectedIndexChanged);
			// 
			// mnuGraphics
			// 
			this.mnuGraphics.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGraphicsCopy,
            this.mnuGraphicsSave});
			this.mnuGraphics.Name = "mnuGraphics";
			this.mnuGraphics.Size = new System.Drawing.Size(144, 48);
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
			// dlgSaveImage
			// 
			this.dlgSaveImage.Filter = "PNG files|*.png|Bitmap files|*.bmp|All files|*.*";
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnApply.Location = new System.Drawing.Point(778, 441);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(148, 23);
			this.btnApply.TabIndex = 13;
			this.btnApply.Text = "Apply changes";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// lblAnim
			// 
			this.lblAnim.AutoSize = true;
			this.lblAnim.ForeColor = System.Drawing.Color.Blue;
			this.lblAnim.Location = new System.Drawing.Point(6, 0);
			this.lblAnim.Name = "lblAnim";
			this.lblAnim.Size = new System.Drawing.Size(129, 13);
			this.lblAnim.TabIndex = 42;
			this.lblAnim.Text = "[ + ] Animation parameters";
			this.ttMain.SetToolTip(this.lblAnim, "Click to collapse/expand");
			this.lblAnim.Click += new System.EventHandler(this.lblAnim_Click);
			// 
			// grpAnim
			// 
			this.grpAnim.Controls.Add(this.lblAnim);
			this.grpAnim.Controls.Add(this.txtGfxEntry);
			this.grpAnim.Controls.Add(this.txtArrEntry);
			this.grpAnim.Controls.Add(this.label3);
			this.grpAnim.Controls.Add(this.txtPalDir);
			this.grpAnim.Controls.Add(this.label2);
			this.grpAnim.Controls.Add(this.label4);
			this.grpAnim.Controls.Add(this.label8);
			this.grpAnim.Controls.Add(this.txtPalStart);
			this.grpAnim.Controls.Add(this.label12);
			this.grpAnim.Controls.Add(this.label5);
			this.grpAnim.Controls.Add(this.label15);
			this.grpAnim.Controls.Add(this.txtPalEnd);
			this.grpAnim.Controls.Add(this.txtWavenumV);
			this.grpAnim.Controls.Add(this.label6);
			this.grpAnim.Controls.Add(this.label13);
			this.grpAnim.Controls.Add(this.txtPalDelay);
			this.grpAnim.Controls.Add(this.txtWavenumH);
			this.grpAnim.Controls.Add(this.txtDriftH);
			this.grpAnim.Controls.Add(this.label14);
			this.grpAnim.Controls.Add(this.label7);
			this.grpAnim.Controls.Add(this.txtFreqV);
			this.grpAnim.Controls.Add(this.txtDriftV);
			this.grpAnim.Controls.Add(this.label11);
			this.grpAnim.Controls.Add(this.label10);
			this.grpAnim.Controls.Add(this.txtFreqH);
			this.grpAnim.Controls.Add(this.txtAmplH);
			this.grpAnim.Controls.Add(this.txtAmplV);
			this.grpAnim.Controls.Add(this.label9);
			this.grpAnim.Location = new System.Drawing.Point(12, 39);
			this.grpAnim.Name = "grpAnim";
			this.grpAnim.Size = new System.Drawing.Size(569, 18);
			this.grpAnim.TabIndex = 14;
			this.grpAnim.TabStop = false;
			// 
			// txtGfxEntry
			// 
			this.txtGfxEntry.Location = new System.Drawing.Point(105, 21);
			this.txtGfxEntry.MaxLength = 5;
			this.txtGfxEntry.Name = "txtGfxEntry";
			this.txtGfxEntry.ReadOnly = true;
			this.txtGfxEntry.Size = new System.Drawing.Size(64, 20);
			this.txtGfxEntry.TabIndex = 14;
			// 
			// txtArrEntry
			// 
			this.txtArrEntry.Location = new System.Drawing.Point(105, 47);
			this.txtArrEntry.MaxLength = 5;
			this.txtArrEntry.Name = "txtArrEntry";
			this.txtArrEntry.ReadOnly = true;
			this.txtArrEntry.Size = new System.Drawing.Size(64, 20);
			this.txtArrEntry.TabIndex = 16;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Arrangement entry";
			// 
			// txtPalDir
			// 
			this.txtPalDir.Location = new System.Drawing.Point(105, 73);
			this.txtPalDir.MaxLength = 3;
			this.txtPalDir.Name = "txtPalDir";
			this.txtPalDir.Size = new System.Drawing.Size(64, 20);
			this.txtPalDir.TabIndex = 18;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Graphics entry";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "Palette direction";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(175, 102);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 13);
			this.label8.TabIndex = 33;
			this.label8.Text = "Vertical amplitude";
			// 
			// txtPalStart
			// 
			this.txtPalStart.Location = new System.Drawing.Point(105, 99);
			this.txtPalStart.MaxLength = 5;
			this.txtPalStart.Name = "txtPalStart";
			this.txtPalStart.Size = new System.Drawing.Size(64, 20);
			this.txtPalStart.TabIndex = 20;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(369, 102);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(106, 13);
			this.label12.TabIndex = 41;
			this.label12.Text = "Vertical wavenumber";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 102);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 21;
			this.label5.Text = "Palette start";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(369, 24);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(104, 13);
			this.label15.TabIndex = 35;
			this.label15.Text = "Horizontal frequency";
			// 
			// txtPalEnd
			// 
			this.txtPalEnd.Location = new System.Drawing.Point(105, 125);
			this.txtPalEnd.MaxLength = 5;
			this.txtPalEnd.Name = "txtPalEnd";
			this.txtPalEnd.Size = new System.Drawing.Size(64, 20);
			this.txtPalEnd.TabIndex = 22;
			// 
			// txtWavenumV
			// 
			this.txtWavenumV.Location = new System.Drawing.Point(493, 99);
			this.txtWavenumV.MaxLength = 6;
			this.txtWavenumV.Name = "txtWavenumV";
			this.txtWavenumV.Size = new System.Drawing.Size(64, 20);
			this.txtWavenumV.TabIndex = 40;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "Palette end";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(369, 76);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(118, 13);
			this.label13.TabIndex = 39;
			this.label13.Text = "Horizontal wavenumber";
			// 
			// txtPalDelay
			// 
			this.txtPalDelay.Location = new System.Drawing.Point(105, 151);
			this.txtPalDelay.MaxLength = 5;
			this.txtPalDelay.Name = "txtPalDelay";
			this.txtPalDelay.Size = new System.Drawing.Size(64, 20);
			this.txtPalDelay.TabIndex = 24;
			// 
			// txtWavenumH
			// 
			this.txtWavenumH.Location = new System.Drawing.Point(493, 73);
			this.txtWavenumH.MaxLength = 6;
			this.txtWavenumH.Name = "txtWavenumH";
			this.txtWavenumH.Size = new System.Drawing.Size(64, 20);
			this.txtWavenumH.TabIndex = 38;
			// 
			// txtDriftH
			// 
			this.txtDriftH.Location = new System.Drawing.Point(299, 21);
			this.txtDriftH.MaxLength = 6;
			this.txtDriftH.Name = "txtDriftH";
			this.txtDriftH.Size = new System.Drawing.Size(64, 20);
			this.txtDriftH.TabIndex = 26;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(369, 50);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(92, 13);
			this.label14.TabIndex = 37;
			this.label14.Text = "Vertical frequency";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 154);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(68, 13);
			this.label7.TabIndex = 25;
			this.label7.Text = "Palette delay";
			// 
			// txtFreqV
			// 
			this.txtFreqV.Location = new System.Drawing.Point(493, 47);
			this.txtFreqV.MaxLength = 6;
			this.txtFreqV.Name = "txtFreqV";
			this.txtFreqV.Size = new System.Drawing.Size(64, 20);
			this.txtFreqV.TabIndex = 36;
			// 
			// txtDriftV
			// 
			this.txtDriftV.Location = new System.Drawing.Point(299, 47);
			this.txtDriftV.MaxLength = 6;
			this.txtDriftV.Name = "txtDriftV";
			this.txtDriftV.Size = new System.Drawing.Size(64, 20);
			this.txtDriftV.TabIndex = 28;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(175, 24);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(74, 13);
			this.label11.TabIndex = 27;
			this.label11.Text = "Horizontal drift";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(175, 50);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(62, 13);
			this.label10.TabIndex = 29;
			this.label10.Text = "Vertical drift";
			// 
			// txtFreqH
			// 
			this.txtFreqH.Location = new System.Drawing.Point(493, 21);
			this.txtFreqH.MaxLength = 6;
			this.txtFreqH.Name = "txtFreqH";
			this.txtFreqH.Size = new System.Drawing.Size(64, 20);
			this.txtFreqH.TabIndex = 34;
			// 
			// txtAmplH
			// 
			this.txtAmplH.Location = new System.Drawing.Point(299, 73);
			this.txtAmplH.MaxLength = 6;
			this.txtAmplH.Name = "txtAmplH";
			this.txtAmplH.Size = new System.Drawing.Size(64, 20);
			this.txtAmplH.TabIndex = 30;
			// 
			// txtAmplV
			// 
			this.txtAmplV.Location = new System.Drawing.Point(299, 99);
			this.txtAmplV.MaxLength = 6;
			this.txtAmplV.Name = "txtAmplV";
			this.txtAmplV.Size = new System.Drawing.Size(64, 20);
			this.txtAmplV.TabIndex = 32;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(175, 76);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(102, 13);
			this.label9.TabIndex = 31;
			this.label9.Text = "Horizontal amplitude";
			// 
			// arrEditor
			// 
			this.arrEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.arrEditor.CurrentPalette = 0;
			this.arrEditor.CurrentTile = 0;
			this.arrEditor.GridArr = true;
			this.arrEditor.GridTile = true;
			this.arrEditor.GridTileset = true;
			this.arrEditor.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
			this.arrEditor.Location = new System.Drawing.Point(12, 63);
			this.arrEditor.Name = "arrEditor";
			this.arrEditor.PrimaryColorIndex = 0;
			this.arrEditor.SecondaryColorIndex = 0;
			this.arrEditor.Size = new System.Drawing.Size(914, 372);
			this.arrEditor.SplitLeftPosition = 253;
			this.arrEditor.SplitMainPosition = 750;
			this.arrEditor.TabIndex = 15;
			this.arrEditor.ZoomArr = 2;
			this.arrEditor.ZoomTile = 8;
			this.arrEditor.ZoomTileset = 4;
			// 
			// frmBattleBgLayerEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(938, 476);
			this.Controls.Add(this.arrEditor);
			this.Controls.Add(this.grpAnim);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboEntry);
			this.MinimumSize = new System.Drawing.Size(615, 514);
			this.Name = "frmBattleBgLayerEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Battle BG layer editor";
			this.mnuGraphics.ResumeLayout(false);
			this.grpAnim.ResumeLayout(false);
			this.grpAnim.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboEntry;
		private System.Windows.Forms.SaveFileDialog dlgSaveImage;
		private System.Windows.Forms.ContextMenuStrip mnuGraphics;
		private System.Windows.Forms.ToolStripMenuItem mnuGraphicsCopy;
		private System.Windows.Forms.ToolStripMenuItem mnuGraphicsSave;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.ToolTip ttMain;
		private System.Windows.Forms.GroupBox grpAnim;
		private System.Windows.Forms.Label lblAnim;
		private System.Windows.Forms.TextBox txtGfxEntry;
		private System.Windows.Forms.TextBox txtArrEntry;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPalDir;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPalStart;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtPalEnd;
		private System.Windows.Forms.TextBox txtWavenumV;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtPalDelay;
		private System.Windows.Forms.TextBox txtWavenumH;
		private System.Windows.Forms.TextBox txtDriftH;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtFreqV;
		private System.Windows.Forms.TextBox txtDriftV;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtFreqH;
		private System.Windows.Forms.TextBox txtAmplH;
		private System.Windows.Forms.TextBox txtAmplV;
		private System.Windows.Forms.Label label9;
		private ArrangementEditor arrEditor;
	}
}