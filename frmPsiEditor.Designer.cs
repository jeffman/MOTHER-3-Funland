namespace MOTHER3Funland
{
    partial class frmPsiEditor
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
            this.cboPsi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTarget = new System.Windows.Forms.ComboBox();
            this.txtPp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmountLow = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmountHigh = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtPsiName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboPsi
            // 
            this.cboPsi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPsi.FormattingEnabled = true;
            this.cboPsi.Location = new System.Drawing.Point(72, 12);
            this.cboPsi.Name = "cboPsi";
            this.cboPsi.Size = new System.Drawing.Size(200, 21);
            this.cboPsi.TabIndex = 0;
            this.cboPsi.SelectedIndexChanged += new System.EventHandler(this.cboPsi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PSI";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(72, 65);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(120, 21);
            this.cboType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Target";
            // 
            // cboTarget
            // 
            this.cboTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarget.FormattingEnabled = true;
            this.cboTarget.Location = new System.Drawing.Point(72, 92);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Size = new System.Drawing.Size(200, 21);
            this.cboTarget.TabIndex = 4;
            // 
            // txtPp
            // 
            this.txtPp.Location = new System.Drawing.Point(100, 119);
            this.txtPp.MaxLength = 5;
            this.txtPp.Name = "txtPp";
            this.txtPp.Size = new System.Drawing.Size(80, 20);
            this.txtPp.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "PP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Amount (low)";
            // 
            // txtAmountLow
            // 
            this.txtAmountLow.Location = new System.Drawing.Point(100, 145);
            this.txtAmountLow.MaxLength = 5;
            this.txtAmountLow.Name = "txtAmountLow";
            this.txtAmountLow.Size = new System.Drawing.Size(80, 20);
            this.txtAmountLow.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Amount (high)";
            // 
            // txtAmountHigh
            // 
            this.txtAmountHigh.Location = new System.Drawing.Point(100, 171);
            this.txtAmountHigh.MaxLength = 5;
            this.txtAmountHigh.Name = "txtAmountHigh";
            this.txtAmountHigh.Size = new System.Drawing.Size(80, 20);
            this.txtAmountHigh.TabIndex = 10;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(205, 327);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtPsiName
            // 
            this.txtPsiName.Location = new System.Drawing.Point(72, 39);
            this.txtPsiName.Name = "txtPsiName";
            this.txtPsiName.Size = new System.Drawing.Size(200, 20);
            this.txtPsiName.TabIndex = 13;
            // 
            // frmPsiEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 362);
            this.Controls.Add(this.txtPsiName);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAmountHigh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAmountLow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPsi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPsiEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PSI editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPsi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTarget;
        private System.Windows.Forms.TextBox txtPp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAmountLow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmountHigh;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtPsiName;
    }
}