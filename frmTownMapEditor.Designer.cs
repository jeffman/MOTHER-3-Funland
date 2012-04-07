namespace MOTHER3Funland
{
    partial class frmTownMapEditor
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
            this.cboMap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.arrEditor = new MOTHER3Funland.ArrangementEditor();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboMap
            // 
            this.cboMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMap.FormattingEnabled = true;
            this.cboMap.Location = new System.Drawing.Point(72, 12);
            this.cboMap.Name = "cboMap";
            this.cboMap.Size = new System.Drawing.Size(256, 21);
            this.cboMap.TabIndex = 0;
            this.cboMap.SelectedIndexChanged += new System.EventHandler(this.cboMap_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Town map";
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
            this.arrEditor.Size = new System.Drawing.Size(647, 592);
            this.arrEditor.SplitLeftPosition = 473;
            this.arrEditor.SplitMainPosition = 483;
            this.arrEditor.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(511, 637);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 14;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmTownMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 672);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.arrEditor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMap);
            this.Name = "frmTownMapEditor";
            this.Text = "Town map editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMap;
        private System.Windows.Forms.Label label1;
        private ArrangementEditor arrEditor;
        private System.Windows.Forms.Button btnApply;
    }
}