namespace MOTHER3Funland
{
    partial class frmEnemyEditor
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
            this.label18 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSpeedBack = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.txtIqBack = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIq = new System.Windows.Forms.TextBox();
            this.txtDefBack = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDef = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOffBack = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOff = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.tabWeaknesses = new System.Windows.Forms.TabPage();
            this.tabBattle = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.cboTextDeath = new System.Windows.Forms.ComboBox();
            this.cboTextEncounter = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboMusicWin = new System.Windows.Forms.ComboBox();
            this.cboMusicBattle = new System.Windows.Forms.ComboBox();
            this.cboMusicSwirl = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMusicWin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMusicBattle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMusicSwirl = new System.Windows.Forms.TextBox();
            this.tabGraphics = new System.Windows.Forms.TabPage();
            this.pSprite = new System.Windows.Forms.PictureBox();
            this.mnuGraphics = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuGraphicsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGraphicsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSprite = new System.Windows.Forms.LinkLabel();
            this.cboBg = new System.Windows.Forms.ComboBox();
            this.lblBg = new System.Windows.Forms.LinkLabel();
            this.cboShowLayer = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.pBack = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.pFront = new System.Windows.Forms.PictureBox();
            this.pBg = new System.Windows.Forms.PictureBox();
            this.ttipMain = new System.Windows.Forms.ToolTip(this.components);
            this.btnApply = new System.Windows.Forms.Button();
            this.dlgSaveImage = new System.Windows.Forms.SaveFileDialog();
            this.cboEnemy = new MOTHER3Funland.ComboSearch();
            this.tabMain.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabBattle.SuspendLayout();
            this.tabGraphics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSprite)).BeginInit();
            this.mnuGraphics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enemy";
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabBasic);
            this.tabMain.Controls.Add(this.tabWeaknesses);
            this.tabMain.Controls.Add(this.tabBattle);
            this.tabMain.Controls.Add(this.tabGraphics);
            this.tabMain.Location = new System.Drawing.Point(12, 39);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(681, 533);
            this.tabMain.TabIndex = 3;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.label18);
            this.tabBasic.Controls.Add(this.txtDescription);
            this.tabBasic.Controls.Add(this.lblShortName);
            this.tabBasic.Controls.Add(this.txtShortName);
            this.tabBasic.Controls.Add(this.label17);
            this.tabBasic.Controls.Add(this.txtName);
            this.tabBasic.Controls.Add(this.txtSpeedBack);
            this.tabBasic.Controls.Add(this.label16);
            this.tabBasic.Controls.Add(this.txtSpeed);
            this.tabBasic.Controls.Add(this.txtIqBack);
            this.tabBasic.Controls.Add(this.label15);
            this.tabBasic.Controls.Add(this.txtIq);
            this.tabBasic.Controls.Add(this.txtDefBack);
            this.tabBasic.Controls.Add(this.label14);
            this.tabBasic.Controls.Add(this.txtDef);
            this.tabBasic.Controls.Add(this.label13);
            this.tabBasic.Controls.Add(this.label12);
            this.tabBasic.Controls.Add(this.txtOffBack);
            this.tabBasic.Controls.Add(this.label11);
            this.tabBasic.Controls.Add(this.txtOff);
            this.tabBasic.Controls.Add(this.label6);
            this.tabBasic.Controls.Add(this.txtDp);
            this.tabBasic.Controls.Add(this.label5);
            this.tabBasic.Controls.Add(this.txtExp);
            this.tabBasic.Controls.Add(this.label4);
            this.tabBasic.Controls.Add(this.txtPp);
            this.tabBasic.Controls.Add(this.label3);
            this.tabBasic.Controls.Add(this.txtHp);
            this.tabBasic.Controls.Add(this.label2);
            this.tabBasic.Controls.Add(this.txtLevel);
            this.tabBasic.Location = new System.Drawing.Point(4, 22);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(673, 507);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(209, 165);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 30;
            this.label18.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(277, 162);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(169, 88);
            this.txtDescription.TabIndex = 29;
            // 
            // lblShortName
            // 
            this.lblShortName.AutoSize = true;
            this.lblShortName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblShortName.Location = new System.Drawing.Point(6, 35);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(61, 13);
            this.lblShortName.TabIndex = 27;
            this.lblShortName.Text = "Short name";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(74, 32);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.ReadOnly = true;
            this.txtShortName.Size = new System.Drawing.Size(160, 20);
            this.txtShortName.TabIndex = 26;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(6, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(74, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 20);
            this.txtName.TabIndex = 24;
            // 
            // txtSpeedBack
            // 
            this.txtSpeedBack.Location = new System.Drawing.Point(347, 136);
            this.txtSpeedBack.MaxLength = 3;
            this.txtSpeedBack.Name = "txtSpeedBack";
            this.txtSpeedBack.Size = new System.Drawing.Size(64, 20);
            this.txtSpeedBack.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(209, 139);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Speed";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(277, 136);
            this.txtSpeed.MaxLength = 3;
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(64, 20);
            this.txtSpeed.TabIndex = 21;
            // 
            // txtIqBack
            // 
            this.txtIqBack.Location = new System.Drawing.Point(347, 110);
            this.txtIqBack.MaxLength = 3;
            this.txtIqBack.Name = "txtIqBack";
            this.txtIqBack.Size = new System.Drawing.Size(64, 20);
            this.txtIqBack.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(209, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "IQ";
            // 
            // txtIq
            // 
            this.txtIq.Location = new System.Drawing.Point(277, 110);
            this.txtIq.MaxLength = 3;
            this.txtIq.Name = "txtIq";
            this.txtIq.Size = new System.Drawing.Size(64, 20);
            this.txtIq.TabIndex = 18;
            // 
            // txtDefBack
            // 
            this.txtDefBack.Location = new System.Drawing.Point(347, 84);
            this.txtDefBack.MaxLength = 3;
            this.txtDefBack.Name = "txtDefBack";
            this.txtDefBack.Size = new System.Drawing.Size(64, 20);
            this.txtDefBack.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(209, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Defense";
            // 
            // txtDef
            // 
            this.txtDef.Location = new System.Drawing.Point(277, 84);
            this.txtDef.MaxLength = 3;
            this.txtDef.Name = "txtDef";
            this.txtDef.Size = new System.Drawing.Size(64, 20);
            this.txtDef.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(344, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Back-attack";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(274, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Normal";
            // 
            // txtOffBack
            // 
            this.txtOffBack.Location = new System.Drawing.Point(347, 58);
            this.txtOffBack.MaxLength = 3;
            this.txtOffBack.Name = "txtOffBack";
            this.txtOffBack.Size = new System.Drawing.Size(64, 20);
            this.txtOffBack.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(209, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Offense";
            // 
            // txtOff
            // 
            this.txtOff.Location = new System.Drawing.Point(277, 58);
            this.txtOff.MaxLength = 3;
            this.txtOff.Name = "txtOff";
            this.txtOff.Size = new System.Drawing.Size(64, 20);
            this.txtOff.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "DP";
            // 
            // txtDp
            // 
            this.txtDp.Location = new System.Drawing.Point(74, 162);
            this.txtDp.Name = "txtDp";
            this.txtDp.Size = new System.Drawing.Size(96, 20);
            this.txtDp.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Experience";
            // 
            // txtExp
            // 
            this.txtExp.Location = new System.Drawing.Point(74, 136);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(96, 20);
            this.txtExp.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PP";
            // 
            // txtPp
            // 
            this.txtPp.Location = new System.Drawing.Point(74, 110);
            this.txtPp.Name = "txtPp";
            this.txtPp.Size = new System.Drawing.Size(96, 20);
            this.txtPp.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "HP";
            // 
            // txtHp
            // 
            this.txtHp.Location = new System.Drawing.Point(74, 84);
            this.txtHp.Name = "txtHp";
            this.txtHp.Size = new System.Drawing.Size(96, 20);
            this.txtHp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Level";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(74, 58);
            this.txtLevel.MaxLength = 5;
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(64, 20);
            this.txtLevel.TabIndex = 0;
            // 
            // tabWeaknesses
            // 
            this.tabWeaknesses.Location = new System.Drawing.Point(4, 22);
            this.tabWeaknesses.Name = "tabWeaknesses";
            this.tabWeaknesses.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeaknesses.Size = new System.Drawing.Size(673, 507);
            this.tabWeaknesses.TabIndex = 1;
            this.tabWeaknesses.Text = "Weaknesses";
            this.tabWeaknesses.UseVisualStyleBackColor = true;
            // 
            // tabBattle
            // 
            this.tabBattle.Controls.Add(this.label20);
            this.tabBattle.Controls.Add(this.cboTextDeath);
            this.tabBattle.Controls.Add(this.cboTextEncounter);
            this.tabBattle.Controls.Add(this.label19);
            this.tabBattle.Controls.Add(this.cboMusicWin);
            this.tabBattle.Controls.Add(this.cboMusicBattle);
            this.tabBattle.Controls.Add(this.cboMusicSwirl);
            this.tabBattle.Controls.Add(this.label10);
            this.tabBattle.Controls.Add(this.txtMusicWin);
            this.tabBattle.Controls.Add(this.label9);
            this.tabBattle.Controls.Add(this.txtMusicBattle);
            this.tabBattle.Controls.Add(this.label8);
            this.tabBattle.Controls.Add(this.txtMusicSwirl);
            this.tabBattle.Location = new System.Drawing.Point(4, 22);
            this.tabBattle.Name = "tabBattle";
            this.tabBattle.Padding = new System.Windows.Forms.Padding(3);
            this.tabBattle.Size = new System.Drawing.Size(673, 507);
            this.tabBattle.TabIndex = 2;
            this.tabBattle.Text = "Battle details";
            this.tabBattle.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(6, 116);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 16;
            this.label20.Text = "Death text";
            // 
            // cboTextDeath
            // 
            this.cboTextDeath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextDeath.FormattingEnabled = true;
            this.cboTextDeath.Location = new System.Drawing.Point(90, 113);
            this.cboTextDeath.Name = "cboTextDeath";
            this.cboTextDeath.Size = new System.Drawing.Size(390, 21);
            this.cboTextDeath.TabIndex = 15;
            // 
            // cboTextEncounter
            // 
            this.cboTextEncounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextEncounter.FormattingEnabled = true;
            this.cboTextEncounter.Location = new System.Drawing.Point(90, 86);
            this.cboTextEncounter.Name = "cboTextEncounter";
            this.cboTextEncounter.Size = new System.Drawing.Size(390, 21);
            this.cboTextEncounter.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(6, 89);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "Encounter text";
            // 
            // cboMusicWin
            // 
            this.cboMusicWin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMusicWin.FormattingEnabled = true;
            this.cboMusicWin.Location = new System.Drawing.Point(160, 59);
            this.cboMusicWin.Name = "cboMusicWin";
            this.cboMusicWin.Size = new System.Drawing.Size(320, 21);
            this.cboMusicWin.TabIndex = 12;
            this.cboMusicWin.SelectedIndexChanged += new System.EventHandler(this.cboMusicWin_SelectedIndexChanged);
            // 
            // cboMusicBattle
            // 
            this.cboMusicBattle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMusicBattle.FormattingEnabled = true;
            this.cboMusicBattle.Location = new System.Drawing.Point(160, 33);
            this.cboMusicBattle.Name = "cboMusicBattle";
            this.cboMusicBattle.Size = new System.Drawing.Size(320, 21);
            this.cboMusicBattle.TabIndex = 11;
            this.cboMusicBattle.SelectedIndexChanged += new System.EventHandler(this.cboMusicBattle_SelectedIndexChanged);
            // 
            // cboMusicSwirl
            // 
            this.cboMusicSwirl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMusicSwirl.FormattingEnabled = true;
            this.cboMusicSwirl.Location = new System.Drawing.Point(160, 7);
            this.cboMusicSwirl.Name = "cboMusicSwirl";
            this.cboMusicSwirl.Size = new System.Drawing.Size(320, 21);
            this.cboMusicSwirl.TabIndex = 10;
            this.cboMusicSwirl.SelectedIndexChanged += new System.EventHandler(this.cboMusicSwirl_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Win music";
            // 
            // txtMusicWin
            // 
            this.txtMusicWin.Location = new System.Drawing.Point(90, 60);
            this.txtMusicWin.MaxLength = 5;
            this.txtMusicWin.Name = "txtMusicWin";
            this.txtMusicWin.Size = new System.Drawing.Size(64, 20);
            this.txtMusicWin.TabIndex = 8;
            this.txtMusicWin.TextChanged += new System.EventHandler(this.txtMusicWin_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Battle music";
            // 
            // txtMusicBattle
            // 
            this.txtMusicBattle.Location = new System.Drawing.Point(90, 34);
            this.txtMusicBattle.MaxLength = 5;
            this.txtMusicBattle.Name = "txtMusicBattle";
            this.txtMusicBattle.Size = new System.Drawing.Size(64, 20);
            this.txtMusicBattle.TabIndex = 6;
            this.txtMusicBattle.TextChanged += new System.EventHandler(this.txtMusicBattle_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Swirl music";
            // 
            // txtMusicSwirl
            // 
            this.txtMusicSwirl.Location = new System.Drawing.Point(90, 8);
            this.txtMusicSwirl.MaxLength = 5;
            this.txtMusicSwirl.Name = "txtMusicSwirl";
            this.txtMusicSwirl.Size = new System.Drawing.Size(64, 20);
            this.txtMusicSwirl.TabIndex = 4;
            this.txtMusicSwirl.TextChanged += new System.EventHandler(this.txtMusicSwirl_TextChanged);
            // 
            // tabGraphics
            // 
            this.tabGraphics.Controls.Add(this.pSprite);
            this.tabGraphics.Controls.Add(this.lblSprite);
            this.tabGraphics.Controls.Add(this.cboBg);
            this.tabGraphics.Controls.Add(this.lblBg);
            this.tabGraphics.Controls.Add(this.cboShowLayer);
            this.tabGraphics.Controls.Add(this.label23);
            this.tabGraphics.Controls.Add(this.label22);
            this.tabGraphics.Controls.Add(this.pBack);
            this.tabGraphics.Controls.Add(this.label21);
            this.tabGraphics.Controls.Add(this.pFront);
            this.tabGraphics.Controls.Add(this.pBg);
            this.tabGraphics.Location = new System.Drawing.Point(4, 22);
            this.tabGraphics.Name = "tabGraphics";
            this.tabGraphics.Padding = new System.Windows.Forms.Padding(3);
            this.tabGraphics.Size = new System.Drawing.Size(673, 507);
            this.tabGraphics.TabIndex = 3;
            this.tabGraphics.Text = "Graphics";
            this.tabGraphics.UseVisualStyleBackColor = true;
            // 
            // pSprite
            // 
            this.pSprite.ContextMenuStrip = this.mnuGraphics;
            this.pSprite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pSprite.Location = new System.Drawing.Point(414, 25);
            this.pSprite.Name = "pSprite";
            this.pSprite.Size = new System.Drawing.Size(64, 64);
            this.pSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pSprite.TabIndex = 19;
            this.pSprite.TabStop = false;
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
            this.mnuGraphicsCopy.Size = new System.Drawing.Size(143, 22);
            this.mnuGraphicsCopy.Text = "Copy";
            this.mnuGraphicsCopy.Click += new System.EventHandler(this.mnuGraphicsCopy_Click);
            // 
            // mnuGraphicsSave
            // 
            this.mnuGraphicsSave.Image = global::MOTHER3Funland.Properties.Resources.disk;
            this.mnuGraphicsSave.Name = "mnuGraphicsSave";
            this.mnuGraphicsSave.Size = new System.Drawing.Size(143, 22);
            this.mnuGraphicsSave.Text = "Save image...";
            this.mnuGraphicsSave.Click += new System.EventHandler(this.mnuGraphicsSave_Click);
            // 
            // lblSprite
            // 
            this.lblSprite.AutoSize = true;
            this.lblSprite.Location = new System.Drawing.Point(414, 9);
            this.lblSprite.Name = "lblSprite";
            this.lblSprite.Size = new System.Drawing.Size(71, 13);
            this.lblSprite.TabIndex = 18;
            this.lblSprite.TabStop = true;
            this.lblSprite.Text = "Outside sprite";
            this.lblSprite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSprite_LinkClicked);
            // 
            // cboBg
            // 
            this.cboBg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBg.FormattingEnabled = true;
            this.cboBg.Location = new System.Drawing.Point(82, 6);
            this.cboBg.Name = "cboBg";
            this.cboBg.Size = new System.Drawing.Size(64, 21);
            this.cboBg.TabIndex = 17;
            this.cboBg.SelectedIndexChanged += new System.EventHandler(this.cboBg_SelectedIndexChanged);
            // 
            // lblBg
            // 
            this.lblBg.AutoSize = true;
            this.lblBg.Location = new System.Drawing.Point(11, 9);
            this.lblBg.Name = "lblBg";
            this.lblBg.Size = new System.Drawing.Size(65, 13);
            this.lblBg.TabIndex = 16;
            this.lblBg.TabStop = true;
            this.lblBg.Text = "Background";
            this.lblBg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBg_LinkClicked);
            // 
            // cboShowLayer
            // 
            this.cboShowLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShowLayer.FormattingEnabled = true;
            this.cboShowLayer.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cboShowLayer.Location = new System.Drawing.Point(82, 33);
            this.cboShowLayer.Name = "cboShowLayer";
            this.cboShowLayer.Size = new System.Drawing.Size(64, 21);
            this.cboShowLayer.TabIndex = 15;
            this.cboShowLayer.SelectedIndexChanged += new System.EventHandler(this.cboShowLayer_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(11, 36);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 13);
            this.label23.TabIndex = 14;
            this.label23.Text = "Show layer";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(326, 268);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Back";
            // 
            // pBack
            // 
            this.pBack.ContextMenuStrip = this.mnuGraphics;
            this.pBack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBack.Location = new System.Drawing.Point(364, 268);
            this.pBack.Name = "pBack";
            this.pBack.Size = new System.Drawing.Size(256, 192);
            this.pBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pBack.TabIndex = 13;
            this.pBack.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(19, 268);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "Front";
            // 
            // pFront
            // 
            this.pFront.ContextMenuStrip = this.mnuGraphics;
            this.pFront.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pFront.Location = new System.Drawing.Point(56, 268);
            this.pFront.Name = "pFront";
            this.pFront.Size = new System.Drawing.Size(256, 192);
            this.pFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pFront.TabIndex = 11;
            this.pFront.TabStop = false;
            // 
            // pBg
            // 
            this.pBg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBg.Location = new System.Drawing.Point(152, 6);
            this.pBg.Name = "pBg";
            this.pBg.Size = new System.Drawing.Size(256, 256);
            this.pBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pBg.TabIndex = 9;
            this.pBg.TabStop = false;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(545, 578);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // dlgSaveImage
            // 
            this.dlgSaveImage.Filter = "PNG files|*.png|Bitmap files|*.bmp|All files|*.*";
            // 
            // cboEnemy
            // 
            this.cboEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEnemy.Location = new System.Drawing.Point(56, 12);
            this.cboEnemy.Name = "cboEnemy";
            this.cboEnemy.SelectedIndex = -1;
            this.cboEnemy.Size = new System.Drawing.Size(637, 21);
            this.cboEnemy.TabIndex = 5;
            this.cboEnemy.SelectedIndexChanged += new System.EventHandler(this.cboEnemy_SelectedIndexChanged);
            // 
            // frmEnemyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 613);
            this.Controls.Add(this.cboEnemy);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 540);
            this.Name = "frmEnemyEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Enemy editor";
            this.tabMain.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.tabBattle.ResumeLayout(false);
            this.tabBattle.PerformLayout();
            this.tabGraphics.ResumeLayout(false);
            this.tabGraphics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSprite)).EndInit();
            this.mnuGraphics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.TabPage tabWeaknesses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExp;
        private System.Windows.Forms.TabPage tabBattle;
        private System.Windows.Forms.ToolTip ttipMain;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMusicWin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMusicBattle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMusicSwirl;
        private System.Windows.Forms.ComboBox cboMusicWin;
        private System.Windows.Forms.ComboBox cboMusicBattle;
        private System.Windows.Forms.ComboBox cboMusicSwirl;
        private System.Windows.Forms.TextBox txtSpeedBack;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.TextBox txtIqBack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIq;
        private System.Windows.Forms.TextBox txtDefBack;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDef;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOffBack;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOff;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblShortName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboTextDeath;
        private System.Windows.Forms.ComboBox cboTextEncounter;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabGraphics;
        private System.Windows.Forms.ContextMenuStrip mnuGraphics;
        private System.Windows.Forms.ToolStripMenuItem mnuGraphicsSave;
        private System.Windows.Forms.SaveFileDialog dlgSaveImage;
        private System.Windows.Forms.ToolStripMenuItem mnuGraphicsCopy;
        private System.Windows.Forms.ComboBox cboShowLayer;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pBack;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.PictureBox pFront;
        private System.Windows.Forms.PictureBox pBg;
        private System.Windows.Forms.ComboBox cboBg;
        private System.Windows.Forms.LinkLabel lblBg;
        private System.Windows.Forms.PictureBox pSprite;
        private System.Windows.Forms.LinkLabel lblSprite;
        private ComboSearch cboEnemy;
    }
}