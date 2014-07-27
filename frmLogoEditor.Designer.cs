namespace MOTHER3Funland
{
    partial class frmLogoEditor
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
            this.cboLogoNum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.arrEditor = new MOTHER3Funland.ArrangementEditor();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboLogoNum
            // 
            this.cboLogoNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLogoNum.FormattingEnabled = true;
            this.cboLogoNum.Location = new System.Drawing.Point(49, 12);
            this.cboLogoNum.Name = "cboLogoNum";
            this.cboLogoNum.Size = new System.Drawing.Size(154, 21);
            this.cboLogoNum.TabIndex = 0;
            this.cboLogoNum.SelectedIndexChanged += new System.EventHandler(this.cboLogoNum_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Logo:";
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
            this.arrEditor.Location = new System.Drawing.Point(12, 39);
            this.arrEditor.Name = "arrEditor";
            this.arrEditor.PrimaryColorIndex = 0;
            this.arrEditor.SecondaryColorIndex = 0;
            this.arrEditor.Size = new System.Drawing.Size(887, 526);
            this.arrEditor.SplitLeftPosition = 407;
            this.arrEditor.SplitMainPosition = 723;
            this.arrEditor.TabIndex = 2;
            this.arrEditor.ZoomArr = 2;
            this.arrEditor.ZoomTile = 8;
            this.arrEditor.ZoomTileset = 4;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(751, 571);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 15;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmLogoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 606);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.arrEditor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLogoNum);
            this.Name = "frmLogoEditor";
            this.Text = "Logo editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLogoNum;
        private System.Windows.Forms.Label label1;
        private ArrangementEditor arrEditor;
        private System.Windows.Forms.Button btnApply;
    }
}