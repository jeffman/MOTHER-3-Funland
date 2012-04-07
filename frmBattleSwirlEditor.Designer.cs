namespace MOTHER3Funland
{
    partial class frmBattleSwirlEditor
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
            this.cboSwirl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFrame = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArrLen = new System.Windows.Forms.TextBox();
            this.txtArrStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGfxEntry = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPalette = new System.Windows.Forms.ComboBox();
            this.arrEditor = new MOTHER3Funland.ArrangementEditor();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtFrameDuration = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboSwirl
            // 
            this.cboSwirl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSwirl.FormattingEnabled = true;
            this.cboSwirl.Location = new System.Drawing.Point(54, 12);
            this.cboSwirl.Name = "cboSwirl";
            this.cboSwirl.Size = new System.Drawing.Size(121, 21);
            this.cboSwirl.TabIndex = 0;
            this.cboSwirl.SelectedIndexChanged += new System.EventHandler(this.cboSwirl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Swirl";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Frame";
            // 
            // cboFrame
            // 
            this.cboFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrame.FormattingEnabled = true;
            this.cboFrame.Location = new System.Drawing.Point(54, 39);
            this.cboFrame.Name = "cboFrame";
            this.cboFrame.Size = new System.Drawing.Size(121, 21);
            this.cboFrame.TabIndex = 2;
            this.cboFrame.SelectedIndexChanged += new System.EventHandler(this.cboFrame_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Frame count";
            // 
            // txtArrLen
            // 
            this.txtArrLen.Location = new System.Drawing.Point(450, 40);
            this.txtArrLen.MaxLength = 3;
            this.txtArrLen.Name = "txtArrLen";
            this.txtArrLen.Size = new System.Drawing.Size(64, 20);
            this.txtArrLen.TabIndex = 5;
            // 
            // txtArrStart
            // 
            this.txtArrStart.Location = new System.Drawing.Point(450, 12);
            this.txtArrStart.MaxLength = 3;
            this.txtArrStart.Name = "txtArrStart";
            this.txtArrStart.Size = new System.Drawing.Size(64, 20);
            this.txtArrStart.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Frame start";
            // 
            // txtGfxEntry
            // 
            this.txtGfxEntry.Location = new System.Drawing.Point(280, 13);
            this.txtGfxEntry.MaxLength = 3;
            this.txtGfxEntry.Name = "txtGfxEntry";
            this.txtGfxEntry.Size = new System.Drawing.Size(64, 20);
            this.txtGfxEntry.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Graphics";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Palette";
            // 
            // cboPalette
            // 
            this.cboPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPalette.FormattingEnabled = true;
            this.cboPalette.Location = new System.Drawing.Point(280, 39);
            this.cboPalette.Name = "cboPalette";
            this.cboPalette.Size = new System.Drawing.Size(64, 21);
            this.cboPalette.TabIndex = 12;
            this.cboPalette.SelectedIndexChanged += new System.EventHandler(this.cboPalette_SelectedIndexChanged);
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
            this.arrEditor.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(192)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.arrEditor.Location = new System.Drawing.Point(12, 66);
            this.arrEditor.Name = "arrEditor";
            this.arrEditor.PrimaryColorIndex = 0;
            this.arrEditor.SecondaryColorIndex = 0;
            this.arrEditor.Size = new System.Drawing.Size(808, 579);
            this.arrEditor.SplitLeftPosition = 460;
            this.arrEditor.SplitMainPosition = 644;
            this.arrEditor.TabIndex = 13;
            this.arrEditor.ZoomArr = 2;
            this.arrEditor.ZoomTile = 8;
            this.arrEditor.ZoomTileset = 4;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(672, 651);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 14;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtFrameDuration
            // 
            this.txtFrameDuration.Location = new System.Drawing.Point(619, 12);
            this.txtFrameDuration.MaxLength = 3;
            this.txtFrameDuration.Name = "txtFrameDuration";
            this.txtFrameDuration.Size = new System.Drawing.Size(64, 20);
            this.txtFrameDuration.TabIndex = 16;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(535, 15);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(77, 13);
            this.Label7.TabIndex = 15;
            this.Label7.Text = "Frame duration";
            // 
            // frmBattleSwirlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 686);
            this.Controls.Add(this.txtFrameDuration);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.arrEditor);
            this.Controls.Add(this.cboPalette);
            this.Controls.Add(this.txtGfxEntry);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtArrStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtArrLen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFrame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSwirl);
            this.Name = "frmBattleSwirlEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Battle swirl editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSwirl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArrLen;
        private System.Windows.Forms.TextBox txtArrStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGfxEntry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPalette;
        private ArrangementEditor arrEditor;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtFrameDuration;
        private System.Windows.Forms.Label Label7;
    }
}