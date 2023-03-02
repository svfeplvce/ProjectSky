using Siticone.Desktop.UI.WinForms;
using Sky.Core;

namespace Sky.SubForms
{
    partial class PokeEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PokeEditor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.returnButton = new System.Windows.Forms.Button();
            this.tabPages = new Siticone.Desktop.UI.WinForms.SiticoneTabControl();
            this.baseStatsPage = new System.Windows.Forms.TabPage();
            this.panel2 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.label27 = new System.Windows.Forms.Label();
            this.hatchBox = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.labelfriend = new System.Windows.Forms.Label();
            this.friendshipBox = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.catchRateBox = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.xpBox = new Sky.Core.FlatComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.ratioLabel = new System.Windows.Forms.Label();
            this.genderRatioBox = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.genderBox = new Sky.Core.FlatComboBox();
            this.percentLabel = new System.Windows.Forms.Label();
            this.heldLabel = new System.Windows.Forms.Label();
            this.heldItemRateBox = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.heldItemBox = new Sky.Core.FlatComboBox();
            this.eggBox2 = new Sky.Core.FlatComboBox();
            this.eggBox1 = new Sky.Core.FlatComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.abilityBox3 = new Sky.Core.FlatComboBox();
            this.abilityBox2 = new Sky.Core.FlatComboBox();
            this.abilityBox1 = new Sky.Core.FlatComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.typeBox2 = new Sky.Core.FlatComboBox();
            this.typeBox1 = new Sky.Core.FlatComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.presentCheck = new Siticone.Desktop.UI.WinForms.SiticoneCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.evSPA = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.evHP = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.evATK = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.evDEF = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.evSPD = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.evSPE = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.panel3 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.baseSPE = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.baseSPD = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.baseSPA = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.baseDEF = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.baseATK = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.baseHP = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pokemonName = new System.Windows.Forms.Label();
            this.movesetPage = new System.Windows.Forms.TabPage();
            this.tmBox = new System.Windows.Forms.CheckedListBox();
            this.movesetGrid = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.evolutionPage = new System.Windows.Forms.TabPage();
            this.evoGrid = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.BSTtooltip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tabPages.SuspendLayout();
            this.baseStatsPage.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hatchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendshipBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catchRateBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderRatioBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heldItemRateBox)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evSPA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evATK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evDEF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPE)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseSPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSPA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDEF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseATK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseHP)).BeginInit();
            this.movesetPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movesetGrid)).BeginInit();
            this.evolutionPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.returnButton);
            this.panel1.Controls.Add(this.tabPages);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 610);
            this.panel1.TabIndex = 1;
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.returnButton.FlatAppearance.BorderSize = 0;
            this.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Font = new System.Drawing.Font("dripicons-v2", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.returnButton.ForeColor = System.Drawing.SystemColors.Control;
            this.returnButton.Location = new System.Drawing.Point(0, 0);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(39, 32);
            this.returnButton.TabIndex = 1;
            this.returnButton.Text = "l";
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // tabPages
            // 
            this.tabPages.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabPages.Controls.Add(this.baseStatsPage);
            this.tabPages.Controls.Add(this.movesetPage);
            this.tabPages.Controls.Add(this.evolutionPage);
            this.tabPages.ItemSize = new System.Drawing.Size(120, 40);
            this.tabPages.Location = new System.Drawing.Point(3, 0);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(997, 610);
            this.tabPages.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabPages.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPages.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPages.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabPages.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPages.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabPages.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPages.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPages.TabButtonIdleState.ForeColor = System.Drawing.Color.White;
            this.tabPages.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPages.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabPages.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPages.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPages.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabPages.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPages.TabButtonSize = new System.Drawing.Size(120, 40);
            this.tabPages.TabIndex = 2;
            this.tabPages.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPages.TabMenuOrientation = Siticone.Desktop.UI.WinForms.TabMenuOrientation.VerticalRight;
            // 
            // baseStatsPage
            // 
            this.baseStatsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.baseStatsPage.Controls.Add(this.panel2);
            this.baseStatsPage.Controls.Add(this.panel4);
            this.baseStatsPage.Controls.Add(this.panel3);
            this.baseStatsPage.Controls.Add(this.pokemonName);
            this.baseStatsPage.ForeColor = System.Drawing.SystemColors.Control;
            this.baseStatsPage.Location = new System.Drawing.Point(4, 4);
            this.baseStatsPage.Name = "baseStatsPage";
            this.baseStatsPage.Padding = new System.Windows.Forms.Padding(3);
            this.baseStatsPage.Size = new System.Drawing.Size(869, 602);
            this.baseStatsPage.TabIndex = 0;
            this.baseStatsPage.Text = "Base Stats";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel2.BorderRadius = 10;
            this.panel2.BorderThickness = 1;
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.hatchBox);
            this.panel2.Controls.Add(this.labelfriend);
            this.panel2.Controls.Add(this.friendshipBox);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.catchRateBox);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.xpBox);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.ratioLabel);
            this.panel2.Controls.Add(this.genderRatioBox);
            this.panel2.Controls.Add(this.genderBox);
            this.panel2.Controls.Add(this.percentLabel);
            this.panel2.Controls.Add(this.heldLabel);
            this.panel2.Controls.Add(this.heldItemRateBox);
            this.panel2.Controls.Add(this.heldItemBox);
            this.panel2.Controls.Add(this.eggBox2);
            this.panel2.Controls.Add(this.eggBox1);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.abilityBox3);
            this.panel2.Controls.Add(this.abilityBox2);
            this.panel2.Controls.Add(this.abilityBox1);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.typeBox2);
            this.panel2.Controls.Add(this.typeBox1);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.presentCheck);
            this.panel2.Controls.Add(this.label3);
            this.panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel2.Location = new System.Drawing.Point(435, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 491);
            this.panel2.TabIndex = 2;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(333, 418);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(76, 15);
            this.label27.TabIndex = 28;
            this.label27.Text = "Hatch Cycles";
            // 
            // hatchBox
            // 
            this.hatchBox.BackColor = System.Drawing.Color.Transparent;
            this.hatchBox.BorderThickness = 0;
            this.hatchBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hatchBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hatchBox.ForeColor = System.Drawing.SystemColors.Control;
            this.hatchBox.Location = new System.Drawing.Point(227, 415);
            this.hatchBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hatchBox.Name = "hatchBox";
            this.hatchBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.hatchBox.Size = new System.Drawing.Size(100, 23);
            this.hatchBox.TabIndex = 27;
            this.hatchBox.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.hatchBox.ValueChanged += new System.EventHandler(this.miscStats_ValueChanged);
            // 
            // labelfriend
            // 
            this.labelfriend.AutoSize = true;
            this.labelfriend.Location = new System.Drawing.Point(33, 364);
            this.labelfriend.Name = "labelfriend";
            this.labelfriend.Size = new System.Drawing.Size(62, 15);
            this.labelfriend.TabIndex = 26;
            this.labelfriend.Text = "Friendship";
            // 
            // friendshipBox
            // 
            this.friendshipBox.BackColor = System.Drawing.Color.Transparent;
            this.friendshipBox.BorderThickness = 0;
            this.friendshipBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.friendshipBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.friendshipBox.ForeColor = System.Drawing.SystemColors.Control;
            this.friendshipBox.Location = new System.Drawing.Point(101, 360);
            this.friendshipBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.friendshipBox.Name = "friendshipBox";
            this.friendshipBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.friendshipBox.Size = new System.Drawing.Size(100, 23);
            this.friendshipBox.TabIndex = 25;
            this.friendshipBox.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.friendshipBox.ValueChanged += new System.EventHandler(this.miscStats_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(333, 364);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(64, 15);
            this.label26.TabIndex = 24;
            this.label26.Text = "Catch Rate";
            // 
            // catchRateBox
            // 
            this.catchRateBox.BackColor = System.Drawing.Color.Transparent;
            this.catchRateBox.BorderThickness = 0;
            this.catchRateBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.catchRateBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.catchRateBox.ForeColor = System.Drawing.SystemColors.Control;
            this.catchRateBox.Location = new System.Drawing.Point(227, 361);
            this.catchRateBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.catchRateBox.Name = "catchRateBox";
            this.catchRateBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.catchRateBox.Size = new System.Drawing.Size(100, 23);
            this.catchRateBox.TabIndex = 23;
            this.catchRateBox.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.catchRateBox.ValueChanged += new System.EventHandler(this.miscStats_ValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(333, 178);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 15);
            this.label25.TabIndex = 22;
            this.label25.Text = "XP Group";
            // 
            // xpBox
            // 
            this.xpBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.xpBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.xpBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpBox.ForeColor = System.Drawing.SystemColors.Control;
            this.xpBox.FormattingEnabled = true;
            this.xpBox.Items.AddRange(new object[] {
            "Medium Fast",
            "Erratic",
            "Fluctuating",
            "Medium Slow",
            "Fast",
            "Slow"});
            this.xpBox.Location = new System.Drawing.Point(227, 174);
            this.xpBox.Name = "xpBox";
            this.xpBox.Size = new System.Drawing.Size(100, 23);
            this.xpBox.TabIndex = 21;
            this.xpBox.SelectedIndexChanged += new System.EventHandler(this.xp_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(14, 306);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(81, 15);
            this.label24.TabIndex = 20;
            this.label24.Text = "Gender Group";
            // 
            // ratioLabel
            // 
            this.ratioLabel.AutoSize = true;
            this.ratioLabel.Location = new System.Drawing.Point(333, 306);
            this.ratioLabel.Name = "ratioLabel";
            this.ratioLabel.Size = new System.Drawing.Size(75, 15);
            this.ratioLabel.TabIndex = 19;
            this.ratioLabel.Text = "Gender Ratio";
            // 
            // genderRatioBox
            // 
            this.genderRatioBox.BackColor = System.Drawing.Color.Transparent;
            this.genderRatioBox.BorderThickness = 0;
            this.genderRatioBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.genderRatioBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.genderRatioBox.ForeColor = System.Drawing.SystemColors.Control;
            this.genderRatioBox.Location = new System.Drawing.Point(227, 303);
            this.genderRatioBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.genderRatioBox.Name = "genderRatioBox";
            this.genderRatioBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.genderRatioBox.Size = new System.Drawing.Size(100, 23);
            this.genderRatioBox.TabIndex = 18;
            this.genderRatioBox.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.genderRatioBox.ValueChanged += new System.EventHandler(this.genderRatio_ValueChanged);
            // 
            // genderBox
            // 
            this.genderBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.genderBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.genderBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genderBox.ForeColor = System.Drawing.SystemColors.Control;
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Items.AddRange(new object[] {
            "Male/Female",
            "Male Only",
            "Female Only",
            "Genderless"});
            this.genderBox.Location = new System.Drawing.Point(101, 303);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(100, 23);
            this.genderBox.TabIndex = 17;
            this.genderBox.SelectedIndexChanged += new System.EventHandler(this.gender_SelectedIndexChanged);
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Location = new System.Drawing.Point(333, 244);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(72, 15);
            this.percentLabel.TabIndex = 16;
            this.percentLabel.Text = "Held Item %";
            // 
            // heldLabel
            // 
            this.heldLabel.AutoSize = true;
            this.heldLabel.Location = new System.Drawing.Point(36, 245);
            this.heldLabel.Name = "heldLabel";
            this.heldLabel.Size = new System.Drawing.Size(59, 15);
            this.heldLabel.TabIndex = 15;
            this.heldLabel.Text = "Held Item";
            // 
            // heldItemRateBox
            // 
            this.heldItemRateBox.BackColor = System.Drawing.Color.Transparent;
            this.heldItemRateBox.BorderThickness = 0;
            this.heldItemRateBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.heldItemRateBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.heldItemRateBox.ForeColor = System.Drawing.SystemColors.Control;
            this.heldItemRateBox.Location = new System.Drawing.Point(227, 241);
            this.heldItemRateBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.heldItemRateBox.Name = "heldItemRateBox";
            this.heldItemRateBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.heldItemRateBox.Size = new System.Drawing.Size(100, 23);
            this.heldItemRateBox.TabIndex = 13;
            this.heldItemRateBox.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.heldItemRateBox.ValueChanged += new System.EventHandler(this.heldItemRatio_ValueChanged);
            // 
            // heldItemBox
            // 
            this.heldItemBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.heldItemBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.heldItemBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heldItemBox.ForeColor = System.Drawing.SystemColors.Control;
            this.heldItemBox.FormattingEnabled = true;
            this.heldItemBox.Items.AddRange(new object[] {
            "None",
            "Master Ball",
            "Ultra Ball",
            "Great Ball",
            "Poké Ball",
            "Safari Ball",
            "Net Ball",
            "Dive Ball",
            "Nest Ball",
            "Repeat Ball",
            "Timer Ball",
            "Luxury Ball",
            "Premier Ball",
            "Dusk Ball",
            "Heal Ball",
            "Quick Ball",
            "Cherish Ball",
            "Potion",
            "Antidote",
            "Burn Heal",
            "Ice Heal",
            "Awakening",
            "Paralyze Heal",
            "Full Restore",
            "Max Potion",
            "Hyper Potion",
            "Super Potion",
            "Full Heal",
            "Revive",
            "Max Revive",
            "Fresh Water",
            "Soda Pop",
            "Lemonade",
            "Moomoo Milk",
            "Energy Powder",
            "Energy Root",
            "Heal Powder",
            "Revival Herb",
            "Ether",
            "Max Ether",
            "Elixir",
            "Max Elixir",
            "Lava Cookie",
            "Berry Juice",
            "Sacred Ash",
            "HP Up",
            "Protein",
            "Iron",
            "Carbos",
            "Calcium",
            "Rare Candy",
            "PP Up",
            "Zinc",
            "PP Max",
            "Old Gateau",
            "Guard Spec.",
            "Dire Hit",
            "X Attack",
            "X Defense",
            "X Speed",
            "X Accuracy",
            "X Sp. Atk",
            "X Sp. Def",
            "Poké Doll",
            "Fluffy Tail",
            "Blue Flute",
            "Yellow Flute",
            "Red Flute",
            "Black Flute",
            "White Flute",
            "Shoal Salt",
            "Shoal Shell",
            "Red Shard",
            "Blue Shard",
            "Yellow Shard",
            "Green Shard",
            "Super Repel",
            "Max Repel",
            "Escape Rope",
            "Repel",
            "Sun Stone",
            "Moon Stone",
            "Fire Stone",
            "Thunder Stone",
            "Water Stone",
            "Leaf Stone",
            "Tiny Mushroom",
            "Big Mushroom",
            "Pearl",
            "Big Pearl",
            "Stardust",
            "Star Piece",
            "Nugget",
            "Heart Scale",
            "Honey",
            "Growth Mulch",
            "Damp Mulch",
            "Stable Mulch",
            "Gooey Mulch",
            "Root Fossil",
            "Claw Fossil",
            "Helix Fossil",
            "Dome Fossil",
            "Old Amber",
            "Armor Fossil",
            "Skull Fossil",
            "Rare Bone",
            "Shiny Stone",
            "Dusk Stone",
            "Dawn Stone",
            "Oval Stone",
            "Odd Keystone",
            "Griseous Orb",
            "Tea",
            "???",
            "Autograph",
            "Douse Drive",
            "Shock Drive",
            "Burn Drive",
            "Chill Drive",
            "???",
            "Pokémon Box Link",
            "Medicine Pocket",
            "TM Case",
            "Candy Jar",
            "Power-Up Pocket",
            "Clothing Trunk",
            "Catching Pocket",
            "Battle Pocket",
            "???",
            "???",
            "???",
            "???",
            "???",
            "Sweet Heart",
            "Adamant Orb",
            "Lustrous Orb",
            "Greet Mail",
            "Favored Mail",
            "RSVP Mail",
            "Thanks Mail",
            "Inquiry Mail",
            "Like Mail",
            "Reply Mail",
            "Bridge Mail S",
            "Bridge Mail D",
            "Bridge Mail T",
            "Bridge Mail V",
            "Bridge Mail M",
            "Cheri Berry",
            "Chesto Berry",
            "Pecha Berry",
            "Rawst Berry",
            "Aspear Berry",
            "Leppa Berry",
            "Oran Berry",
            "Persim Berry",
            "Lum Berry",
            "Sitrus Berry",
            "Figy Berry",
            "Wiki Berry",
            "Mago Berry",
            "Aguav Berry",
            "Iapapa Berry",
            "Razz Berry",
            "Bluk Berry",
            "Nanab Berry",
            "Wepear Berry",
            "Pinap Berry",
            "Pomeg Berry",
            "Kelpsy Berry",
            "Qualot Berry",
            "Hondew Berry",
            "Grepa Berry",
            "Tamato Berry",
            "Cornn Berry",
            "Magost Berry",
            "Rabuta Berry",
            "Nomel Berry",
            "Spelon Berry",
            "Pamtre Berry",
            "Watmel Berry",
            "Durin Berry",
            "Belue Berry",
            "Occa Berry",
            "Passho Berry",
            "Wacan Berry",
            "Rindo Berry",
            "Yache Berry",
            "Chople Berry",
            "Kebia Berry",
            "Shuca Berry",
            "Coba Berry",
            "Payapa Berry",
            "Tanga Berry",
            "Charti Berry",
            "Kasib Berry",
            "Haban Berry",
            "Colbur Berry",
            "Babiri Berry",
            "Chilan Berry",
            "Liechi Berry",
            "Ganlon Berry",
            "Salac Berry",
            "Petaya Berry",
            "Apicot Berry",
            "Lansat Berry",
            "Starf Berry",
            "Enigma Berry",
            "Micle Berry",
            "Custap Berry",
            "Jaboca Berry",
            "Rowap Berry",
            "Bright Powder",
            "White Herb",
            "Macho Brace",
            "Exp. Share",
            "Quick Claw",
            "Soothe Bell",
            "Mental Herb",
            "Choice Band",
            "King’s Rock",
            "Silver Powder",
            "Amulet Coin",
            "Cleanse Tag",
            "Soul Dew",
            "Deep Sea Tooth",
            "Deep Sea Scale",
            "Smoke Ball",
            "Everstone",
            "Focus Band",
            "Lucky Egg",
            "Scope Lens",
            "Metal Coat",
            "Leftovers",
            "Dragon Scale",
            "Light Ball",
            "Soft Sand",
            "Hard Stone",
            "Miracle Seed",
            "Black Glasses",
            "Black Belt",
            "Magnet",
            "Mystic Water",
            "Sharp Beak",
            "Poison Barb",
            "Never-Melt Ice",
            "Spell Tag",
            "Twisted Spoon",
            "Charcoal",
            "Dragon Fang",
            "Silk Scarf",
            "Upgrade",
            "Shell Bell",
            "Sea Incense",
            "Lax Incense",
            "Lucky Punch",
            "Metal Powder",
            "Thick Club",
            "Leek",
            "Red Scarf",
            "Blue Scarf",
            "Pink Scarf",
            "Green Scarf",
            "Yellow Scarf",
            "Wide Lens",
            "Muscle Band",
            "Wise Glasses",
            "Expert Belt",
            "Light Clay",
            "Life Orb",
            "Power Herb",
            "Toxic Orb",
            "Flame Orb",
            "Quick Powder",
            "Focus Sash",
            "Zoom Lens",
            "Metronome",
            "Iron Ball",
            "Lagging Tail",
            "Destiny Knot",
            "Black Sludge",
            "Icy Rock",
            "Smooth Rock",
            "Heat Rock",
            "Damp Rock",
            "Grip Claw",
            "Choice Scarf",
            "Sticky Barb",
            "Power Bracer",
            "Power Belt",
            "Power Lens",
            "Power Band",
            "Power Anklet",
            "Power Weight",
            "Shed Shell",
            "Big Root",
            "Choice Specs",
            "Flame Plate",
            "Splash Plate",
            "Zap Plate",
            "Meadow Plate",
            "Icicle Plate",
            "Fist Plate",
            "Toxic Plate",
            "Earth Plate",
            "Sky Plate",
            "Mind Plate",
            "Insect Plate",
            "Stone Plate",
            "Spooky Plate",
            "Draco Plate",
            "Dread Plate",
            "Iron Plate",
            "Odd Incense",
            "Rock Incense",
            "Full Incense",
            "Wave Incense",
            "Rose Incense",
            "Luck Incense",
            "Pure Incense",
            "Protector",
            "Electirizer",
            "Magmarizer",
            "Dubious Disc",
            "Reaper Cloth",
            "Razor Claw",
            "Razor Fang",
            "TM001",
            "TM002",
            "TM003",
            "TM004",
            "TM005",
            "TM006",
            "TM007",
            "TM008",
            "TM009",
            "TM010",
            "TM011",
            "TM012",
            "TM013",
            "TM014",
            "TM015",
            "TM016",
            "TM017",
            "TM018",
            "TM019",
            "TM020",
            "TM021",
            "TM022",
            "TM023",
            "TM024",
            "TM025",
            "TM026",
            "TM027",
            "TM028",
            "TM029",
            "TM030",
            "TM031",
            "TM032",
            "TM033",
            "TM034",
            "TM035",
            "TM036",
            "TM037",
            "TM038",
            "TM039",
            "TM040",
            "TM041",
            "TM042",
            "TM043",
            "TM044",
            "TM045",
            "TM046",
            "TM047",
            "TM048",
            "TM049",
            "TM050",
            "TM051",
            "TM052",
            "TM053",
            "TM054",
            "TM055",
            "TM056",
            "TM057",
            "TM058",
            "TM059",
            "TM060",
            "TM061",
            "TM062",
            "TM063",
            "TM064",
            "TM065",
            "TM066",
            "TM067",
            "TM068",
            "TM069",
            "TM070",
            "TM071",
            "TM072",
            "TM073",
            "TM074",
            "TM075",
            "TM076",
            "TM077",
            "TM078",
            "TM079",
            "TM080",
            "TM081",
            "TM082",
            "TM083",
            "TM084",
            "TM085",
            "TM086",
            "TM087",
            "TM088",
            "TM089",
            "TM090",
            "TM091",
            "TM092",
            "HM01",
            "HM02",
            "HM03",
            "HM04",
            "HM05",
            "HM06",
            "???",
            "???",
            "Explorer Kit",
            "Loot Sack",
            "Rule Book",
            "Poké Radar",
            "Point Card",
            "Guidebook",
            "Sticker Case",
            "Fashion Case",
            "Sticker Bag",
            "Pal Pad",
            "Works Key",
            "Old Charm",
            "Galactic Key",
            "Red Chain",
            "Town Map",
            "Vs. Seeker",
            "Coin Case",
            "Old Rod",
            "Good Rod",
            "Super Rod",
            "Sprayduck",
            "Poffin Case",
            "Bike",
            "Suite Key",
            "Oak’s Letter",
            "Lunar Feather",
            "Member Card",
            "Azure Flute",
            "S.S. Ticket",
            "Contest Pass",
            "Magma Stone",
            "Parcel",
            "Coupon 1",
            "Coupon 2",
            "Coupon 3",
            "Storage Key",
            "Secret Medicine",
            "Vs. Recorder",
            "Gracidea",
            "Secret Key",
            "Apricorn Box",
            "Unown Report",
            "Berry Pots",
            "Dowsing Machine",
            "Blue Card",
            "Slowpoke Tail",
            "Clear Bell",
            "Card Key",
            "Basement Key",
            "Squirt Bottle",
            "Red Scale",
            "Lost Item",
            "Pass",
            "Machine Part",
            "Silver Feather",
            "Rainbow Feather",
            "Mystery Egg",
            "Red Apricorn",
            "Blue Apricorn",
            "Yellow Apricorn",
            "Green Apricorn",
            "Pink Apricorn",
            "White Apricorn",
            "Black Apricorn",
            "Fast Ball",
            "Level Ball",
            "Lure Ball",
            "Heavy Ball",
            "Love Ball",
            "Friend Ball",
            "Moon Ball",
            "Sport Ball",
            "Park Ball",
            "Photo Album",
            "GB Sounds",
            "Tidal Bell",
            "Rage Candy Bar",
            "Data Card 01",
            "Data Card 02",
            "Data Card 03",
            "Data Card 04",
            "Data Card 05",
            "Data Card 06",
            "Data Card 07",
            "Data Card 08",
            "Data Card 09",
            "Data Card 10",
            "Data Card 11",
            "Data Card 12",
            "Data Card 13",
            "Data Card 14",
            "Data Card 15",
            "Data Card 16",
            "Data Card 17",
            "Data Card 18",
            "Data Card 19",
            "Data Card 20",
            "Data Card 21",
            "Data Card 22",
            "Data Card 23",
            "Data Card 24",
            "Data Card 25",
            "Data Card 26",
            "Data Card 27",
            "Jade Orb",
            "Lock Capsule",
            "Red Orb",
            "Blue Orb",
            "Enigma Stone",
            "Prism Scale",
            "Eviolite",
            "Float Stone",
            "Rocky Helmet",
            "Air Balloon",
            "Red Card",
            "Ring Target",
            "Binding Band",
            "Absorb Bulb",
            "Cell Battery",
            "Eject Button",
            "Fire Gem",
            "Water Gem",
            "Electric Gem",
            "Grass Gem",
            "Ice Gem",
            "Fighting Gem",
            "Poison Gem",
            "Ground Gem",
            "Flying Gem",
            "Psychic Gem",
            "Bug Gem",
            "Rock Gem",
            "Ghost Gem",
            "Dragon Gem",
            "Dark Gem",
            "Steel Gem",
            "Normal Gem",
            "Health Feather",
            "Muscle Feather",
            "Resist Feather",
            "Genius Feather",
            "Clever Feather",
            "Swift Feather",
            "Pretty Feather",
            "Cover Fossil",
            "Plume Fossil",
            "Liberty Pass",
            "Pass Orb",
            "Dream Ball",
            "Poké Toy",
            "Prop Case",
            "Dragon Skull",
            "Balm Mushroom",
            "Big Nugget",
            "Pearl String",
            "Comet Shard",
            "Relic Copper",
            "Relic Silver",
            "Relic Gold",
            "Relic Vase",
            "Relic Band",
            "Relic Statue",
            "Relic Crown",
            "Casteliacone",
            "Dire Hit 2",
            "X Speed 2",
            "X Sp. Atk 2",
            "X Sp. Def 2",
            "X Defense 2",
            "X Attack 2",
            "X Accuracy 2",
            "X Speed 3",
            "X Sp. Atk 3",
            "X Sp. Def 3",
            "X Defense 3",
            "X Attack 3",
            "X Accuracy 3",
            "X Speed 6",
            "X Sp. Atk 6",
            "X Sp. Def 6",
            "X Defense 6",
            "X Attack 6",
            "X Accuracy 6",
            "Ability Urge",
            "Item Drop",
            "Item Urge",
            "Reset Urge",
            "Dire Hit 3",
            "Light Stone",
            "Dark Stone",
            "TM093",
            "TM094",
            "TM095",
            "Xtransceiver",
            "???",
            "Gram 1",
            "Gram 2",
            "Gram 3",
            "Xtransceiver",
            "Medal Box",
            "DNA Splicers",
            "DNA Splicers",
            "Permit",
            "Oval Charm",
            "Shiny Charm",
            "Plasma Card",
            "Grubby Hanky",
            "Colress Machine",
            "Dropped Item",
            "Dropped Item",
            "Reveal Glass",
            "Weakness Policy",
            "Assault Vest",
            "Holo Caster",
            "Prof’s Letter",
            "Roller Skates",
            "Pixie Plate",
            "Ability Capsule",
            "Whipped Dream",
            "Sachet",
            "Luminous Moss",
            "Snowball",
            "Safety Goggles",
            "Poké Flute",
            "Rich Mulch",
            "Surprise Mulch",
            "Boost Mulch",
            "Amaze Mulch",
            "Gengarite",
            "Gardevoirite",
            "Ampharosite",
            "Venusaurite",
            "Charizardite X",
            "Blastoisinite",
            "Mewtwonite X",
            "Mewtwonite Y",
            "Blazikenite",
            "Medichamite",
            "Houndoominite",
            "Aggronite",
            "Banettite",
            "Tyranitarite",
            "Scizorite",
            "Pinsirite",
            "Aerodactylite",
            "Lucarionite",
            "Abomasite",
            "Kangaskhanite",
            "Gyaradosite",
            "Absolite",
            "Charizardite Y",
            "Alakazite",
            "Heracronite",
            "Mawilite",
            "Manectite",
            "Garchompite",
            "Latiasite",
            "Latiosite",
            "Roseli Berry",
            "Kee Berry",
            "Maranga Berry",
            "Sprinklotad",
            "TM096",
            "TM097",
            "TM098",
            "TM099",
            "TM100",
            "Power Plant Pass",
            "Mega Ring",
            "Intriguing Stone",
            "Common Stone",
            "Discount Coupon",
            "Elevator Key",
            "TMV Pass",
            "Honor of Kalos",
            "Adventure Guide",
            "Strange Souvenir",
            "Lens Case",
            "Makeup Bag",
            "Travel Trunk",
            "Lumiose Galette",
            "Shalour Sable",
            "Jaw Fossil",
            "Sail Fossil",
            "Looker Ticket",
            "Bike",
            "Holo Caster",
            "Fairy Gem",
            "Mega Charm",
            "Mega Glove",
            "Mach Bike",
            "Acro Bike",
            "Wailmer Pail",
            "Devon Parts",
            "Soot Sack",
            "Basement Key",
            "Pokéblock Kit",
            "Letter",
            "Eon Ticket",
            "Scanner",
            "Go-Goggles",
            "Meteorite",
            "Key to Room 1",
            "Key to Room 2",
            "Key to Room 4",
            "Key to Room 6",
            "Storage Key",
            "Devon Scope",
            "S.S. Ticket",
            "HM07",
            "Devon Scuba Gear",
            "Contest Costume",
            "Contest Costume",
            "Magma Suit",
            "Aqua Suit",
            "Pair of Tickets",
            "Mega Bracelet",
            "Mega Pendant",
            "Mega Glasses",
            "Mega Anchor",
            "Mega Stickpin",
            "Mega Tiara",
            "Mega Anklet",
            "Meteorite",
            "Swampertite",
            "Sceptilite",
            "Sablenite",
            "Altarianite",
            "Galladite",
            "Audinite",
            "Metagrossite",
            "Sharpedonite",
            "Slowbronite",
            "Steelixite",
            "Pidgeotite",
            "Glalitite",
            "Diancite",
            "Prison Bottle",
            "Mega Cuff",
            "Cameruptite",
            "Lopunnite",
            "Salamencite",
            "Beedrillite",
            "Meteorite",
            "Meteorite",
            "Key Stone",
            "Meteorite Shard",
            "Eon Flute",
            "Normalium Z",
            "Firium Z",
            "Waterium Z",
            "Electrium Z",
            "Grassium Z",
            "Icium Z",
            "Fightinium Z",
            "Poisonium Z",
            "Groundium Z",
            "Flyinium Z",
            "Psychium Z",
            "Buginium Z",
            "Rockium Z",
            "Ghostium Z",
            "Dragonium Z",
            "Darkinium Z",
            "Steelium Z",
            "Fairium Z",
            "Pikanium Z",
            "Bottle Cap",
            "Gold Bottle Cap",
            "Z-Ring",
            "Decidium Z",
            "Incinium Z",
            "Primarium Z",
            "Tapunium Z",
            "Marshadium Z",
            "Aloraichium Z",
            "Snorlium Z",
            "Eevium Z",
            "Mewnium Z",
            "Normalium Z",
            "Firium Z",
            "Waterium Z",
            "Electrium Z",
            "Grassium Z",
            "Icium Z",
            "Fightinium Z",
            "Poisonium Z",
            "Groundium Z",
            "Flyinium Z",
            "Psychium Z",
            "Buginium Z",
            "Rockium Z",
            "Ghostium Z",
            "Dragonium Z",
            "Darkinium Z",
            "Steelium Z",
            "Fairium Z",
            "Pikanium Z",
            "Decidium Z",
            "Incinium Z",
            "Primarium Z",
            "Tapunium Z",
            "Marshadium Z",
            "Aloraichium Z",
            "Snorlium Z",
            "Eevium Z",
            "Mewnium Z",
            "Pikashunium Z",
            "Pikashunium Z",
            "???",
            "???",
            "???",
            "???",
            "Forage Bag",
            "Fishing Rod",
            "Professor’s Mask",
            "Festival Ticket",
            "Sparkling Stone",
            "Adrenaline Orb",
            "Zygarde Cube",
            "???",
            "Ice Stone",
            "Ride Pager",
            "Beast Ball",
            "Big Malasada",
            "Red Nectar",
            "Yellow Nectar",
            "Pink Nectar",
            "Purple Nectar",
            "Sun Flute",
            "Moon Flute",
            "???",
            "Enigmatic Card",
            "Silver Razz Berry",
            "Golden Razz Berry",
            "Silver Nanab Berry",
            "Golden Nanab Berry",
            "Silver Pinap Berry",
            "Golden Pinap Berry",
            "???",
            "???",
            "???",
            "???",
            "???",
            "Secret Key",
            "S.S. Ticket",
            "Silph Scope",
            "Parcel",
            "Card Key",
            "Gold Teeth",
            "Lift Key",
            "Terrain Extender",
            "Protective Pads",
            "Electric Seed",
            "Psychic Seed",
            "Misty Seed",
            "Grassy Seed",
            "Stretchy Spring",
            "Chalky Stone",
            "Marble",
            "Lone Earring",
            "Beach Glass",
            "Gold Leaf",
            "Silver Leaf",
            "Polished Mud Ball",
            "Tropical Shell",
            "Leaf Letter",
            "Leaf Letter",
            "Small Bouquet",
            "???",
            "???",
            "???",
            "Lure",
            "Super Lure",
            "Max Lure",
            "Pewter Crunchies",
            "Fighting Memory",
            "Flying Memory",
            "Poison Memory",
            "Ground Memory",
            "Rock Memory",
            "Bug Memory",
            "Ghost Memory",
            "Steel Memory",
            "Fire Memory",
            "Water Memory",
            "Grass Memory",
            "Electric Memory",
            "Psychic Memory",
            "Ice Memory",
            "Dragon Memory",
            "Dark Memory",
            "Fairy Memory",
            "Solganium Z",
            "Lunalium Z",
            "Ultranecrozium Z",
            "Mimikium Z",
            "Lycanium Z",
            "Kommonium Z",
            "Solganium Z",
            "Lunalium Z",
            "Ultranecrozium Z",
            "Mimikium Z",
            "Lycanium Z",
            "Kommonium Z",
            "Z-Power Ring",
            "Pink Petal",
            "Orange Petal",
            "Blue Petal",
            "Red Petal",
            "Green Petal",
            "Yellow Petal",
            "Purple Petal",
            "Rainbow Flower",
            "Surge Badge",
            "N-Solarizer",
            "N-Lunarizer",
            "N-Solarizer",
            "N-Lunarizer",
            "Ilima’s Normalium Z",
            "Left Poké Ball",
            "Roto Hatch",
            "Roto Bargain",
            "Roto Prize Money",
            "Roto Exp. Points",
            "Roto Friendship",
            "Roto Encounter",
            "Roto Stealth",
            "Roto HP Restore",
            "Roto PP Restore",
            "Roto Boost",
            "Roto Catch",
            "Health Candy",
            "Mighty Candy",
            "Tough Candy",
            "Smart Candy",
            "Courage Candy",
            "Quick Candy",
            "Health Candy L",
            "Mighty Candy L",
            "Tough Candy L",
            "Smart Candy L",
            "Courage Candy L",
            "Quick Candy L",
            "Health Candy XL",
            "Mighty Candy XL",
            "Tough Candy XL",
            "Smart Candy XL",
            "Courage Candy XL",
            "Quick Candy XL",
            "Bulbasaur Candy",
            "Charmander Candy",
            "Squirtle Candy",
            "Caterpie Candy",
            "Weedle Candy",
            "Pidgey Candy",
            "Rattata Candy",
            "Spearow Candy",
            "Ekans Candy",
            "Pikachu Candy",
            "Sandshrew Candy",
            "Nidoran♀ Candy",
            "Nidoran♂ Candy",
            "Clefairy Candy",
            "Vulpix Candy",
            "Jigglypuff Candy",
            "Zubat Candy",
            "Oddish Candy",
            "Paras Candy",
            "Venonat Candy",
            "Diglett Candy",
            "Meowth Candy",
            "Psyduck Candy",
            "Mankey Candy",
            "Growlithe Candy",
            "Poliwag Candy",
            "Abra Candy",
            "Machop Candy",
            "Bellsprout Candy",
            "Tentacool Candy",
            "Geodude Candy",
            "Ponyta Candy",
            "Slowpoke Candy",
            "Magnemite Candy",
            "Farfetch’d Candy",
            "Doduo Candy",
            "Seel Candy",
            "Grimer Candy",
            "Shellder Candy",
            "Gastly Candy",
            "Onix Candy",
            "Drowzee Candy",
            "Krabby Candy",
            "Voltorb Candy",
            "Exeggcute Candy",
            "Cubone Candy",
            "Hitmonlee Candy",
            "Hitmonchan Candy",
            "Lickitung Candy",
            "Koffing Candy",
            "Rhyhorn Candy",
            "Chansey Candy",
            "Tangela Candy",
            "Kangaskhan Candy",
            "Horsea Candy",
            "Goldeen Candy",
            "Staryu Candy",
            "Mr. Mime Candy",
            "Scyther Candy",
            "Jynx Candy",
            "Electabuzz Candy",
            "Pinsir Candy",
            "Tauros Candy",
            "Magikarp Candy",
            "Lapras Candy",
            "Ditto Candy",
            "Eevee Candy",
            "Porygon Candy",
            "Omanyte Candy",
            "Kabuto Candy",
            "Aerodactyl Candy",
            "Snorlax Candy",
            "Articuno Candy",
            "Zapdos Candy",
            "Moltres Candy",
            "Dratini Candy",
            "Mewtwo Candy",
            "Mew Candy",
            "Meltan Candy",
            "Magmar Candy",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "Endorsement",
            "Pokémon Box Link",
            "Wishing Star",
            "Dynamax Band",
            "???",
            "???",
            "Fishing Rod",
            "Rotom Bike",
            "???",
            "???",
            "Sausages",
            "Bob’s Food Tin",
            "Bach’s Food Tin",
            "Tin of Beans",
            "Bread",
            "Pasta",
            "Mixed Mushrooms",
            "Smoke-Poke Tail",
            "Large Leek",
            "Fancy Apple",
            "Brittle Bones",
            "Pack of Potatoes",
            "Pungent Root",
            "Salad Mix",
            "Fried Food",
            "Boiled Egg",
            "Camping Gear",
            "???",
            "???",
            "Rusted Sword",
            "Rusted Shield",
            "Fossilized Bird",
            "Fossilized Fish",
            "Fossilized Drake",
            "Fossilized Dino",
            "Strawberry Sweet",
            "Love Sweet",
            "Berry Sweet",
            "Clover Sweet",
            "Flower Sweet",
            "Star Sweet",
            "Ribbon Sweet",
            "Sweet Apple",
            "Tart Apple",
            "Throat Spray",
            "Eject Pack",
            "Heavy-Duty Boots",
            "Blunder Policy",
            "Room Service",
            "Utility Umbrella",
            "Exp. Candy XS",
            "Exp. Candy S",
            "Exp. Candy M",
            "Exp. Candy L",
            "Exp. Candy XL",
            "Dynamax Candy",
            "TR00",
            "TR01",
            "TR02",
            "TR03",
            "TR04",
            "TR05",
            "TR06",
            "TR07",
            "TR08",
            "TR09",
            "TR10",
            "TR11",
            "TR12",
            "TR13",
            "TR14",
            "TR15",
            "TR16",
            "TR17",
            "TR18",
            "TR19",
            "TR20",
            "TR21",
            "TR22",
            "TR23",
            "TR24",
            "TR25",
            "TR26",
            "TR27",
            "TR28",
            "TR29",
            "TR30",
            "TR31",
            "TR32",
            "TR33",
            "TR34",
            "TR35",
            "TR36",
            "TR37",
            "TR38",
            "TR39",
            "TR40",
            "TR41",
            "TR42",
            "TR43",
            "TR44",
            "TR45",
            "TR46",
            "TR47",
            "TR48",
            "TR49",
            "TR50",
            "TR51",
            "TR52",
            "TR53",
            "TR54",
            "TR55",
            "TR56",
            "TR57",
            "TR58",
            "TR59",
            "TR60",
            "TR61",
            "TR62",
            "TR63",
            "TR64",
            "TR65",
            "TR66",
            "TR67",
            "TR68",
            "TR69",
            "TR70",
            "TR71",
            "TR72",
            "TR73",
            "TR74",
            "TR75",
            "TR76",
            "TR77",
            "TR78",
            "TR79",
            "TR80",
            "TR81",
            "TR82",
            "TR83",
            "TR84",
            "TR85",
            "TR86",
            "TR87",
            "TR88",
            "TR89",
            "TR90",
            "TR91",
            "TR92",
            "TR93",
            "TR94",
            "TR95",
            "TR96",
            "TR97",
            "TR98",
            "TR99",
            "TM00",
            "Lonely Mint",
            "Adamant Mint",
            "Naughty Mint",
            "Brave Mint",
            "Bold Mint",
            "Impish Mint",
            "Lax Mint",
            "Relaxed Mint",
            "Modest Mint",
            "Mild Mint",
            "Rash Mint",
            "Quiet Mint",
            "Calm Mint",
            "Gentle Mint",
            "Careful Mint",
            "Sassy Mint",
            "Timid Mint",
            "Hasty Mint",
            "Jolly Mint",
            "Naive Mint",
            "Serious Mint",
            "Wishing Piece",
            "Cracked Pot",
            "Chipped Pot",
            "Hi-tech Earbuds",
            "Fruit Bunch",
            "Moomoo Cheese",
            "Spice Mix",
            "Fresh Cream",
            "Packaged Curry",
            "Coconut Milk",
            "Instant Noodles",
            "Precooked Burger",
            "Gigantamix",
            "Wishing Chip",
            "Rotom Bike",
            "Catching Charm",
            "???",
            "Old Letter",
            "Band Autograph",
            "Sonia’s Book",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "Rotom Catalog",
            "★And458",
            "★And15",
            "★And337",
            "★And603",
            "★And390",
            "★Sgr6879",
            "★Sgr6859",
            "★Sgr6913",
            "★Sgr7348",
            "★Sgr7121",
            "★Sgr6746",
            "★Sgr7194",
            "★Sgr7337",
            "★Sgr7343",
            "★Sgr6812",
            "★Sgr7116",
            "★Sgr7264",
            "★Sgr7597",
            "★Del7882",
            "★Del7906",
            "★Del7852",
            "★Psc596",
            "★Psc361",
            "★Psc510",
            "★Psc437",
            "★Psc8773",
            "★Lep1865",
            "★Lep1829",
            "★Boo5340",
            "★Boo5506",
            "★Boo5435",
            "★Boo5602",
            "★Boo5733",
            "★Boo5235",
            "★Boo5351",
            "★Hya3748",
            "★Hya3903",
            "★Hya3418",
            "★Hya3482",
            "★Hya3845",
            "★Eri1084",
            "★Eri472",
            "★Eri1666",
            "★Eri897",
            "★Eri1231",
            "★Eri874",
            "★Eri1298",
            "★Eri1325",
            "★Eri984",
            "★Eri1464",
            "★Eri1393",
            "★Eri850",
            "★Tau1409",
            "★Tau1457",
            "★Tau1165",
            "★Tau1791",
            "★Tau1910",
            "★Tau1346",
            "★Tau1373",
            "★Tau1412",
            "★CMa2491",
            "★CMa2693",
            "★CMa2294",
            "★CMa2827",
            "★CMa2282",
            "★CMa2618",
            "★CMa2657",
            "★CMa2646",
            "★UMa4905",
            "★UMa4301",
            "★UMa5191",
            "★UMa5054",
            "★UMa4295",
            "★UMa4660",
            "★UMa4554",
            "★UMa4069",
            "★UMa3569",
            "★UMa3323",
            "★UMa4033",
            "★UMa4377",
            "★UMa4375",
            "★UMa4518",
            "★UMa3594",
            "★Vir5056",
            "★Vir4825",
            "★Vir4932",
            "★Vir4540",
            "★Vir4689",
            "★Vir5338",
            "★Vir4910",
            "★Vir5315",
            "★Vir5359",
            "★Vir5409",
            "★Vir5107",
            "★Ari617",
            "★Ari553",
            "★Ari546",
            "★Ari951",
            "★Ori1713",
            "★Ori2061",
            "★Ori1790",
            "★Ori1903",
            "★Ori1948",
            "★Ori2004",
            "★Ori1852",
            "★Ori1879",
            "★Ori1899",
            "★Ori1543",
            "★Cas21",
            "★Cas168",
            "★Cas403",
            "★Cas153",
            "★Cas542",
            "★Cas219",
            "★Cas265",
            "★Cnc3572",
            "★Cnc3208",
            "★Cnc3461",
            "★Cnc3449",
            "★Cnc3429",
            "★Cnc3627",
            "★Cnc3268",
            "★Cnc3249",
            "★Com4968",
            "★Crv4757",
            "★Crv4623",
            "★Crv4662",
            "★Crv4786",
            "★Aur1708",
            "★Aur2088",
            "★Aur1605",
            "★Aur2095",
            "★Aur1577",
            "★Aur1641",
            "★Aur1612",
            "★Pav7790",
            "★Cet911",
            "★Cet681",
            "★Cet188",
            "★Cet539",
            "★Cet804",
            "★Cep8974",
            "★Cep8162",
            "★Cep8238",
            "★Cep8417",
            "★Cen5267",
            "★Cen5288",
            "★Cen551",
            "★Cen5459",
            "★Cen5460",
            "★CMi2943",
            "★CMi2845",
            "★Equ8131",
            "★Vul7405",
            "★UMi424",
            "★UMi5563",
            "★UMi5735",
            "★UMi6789",
            "★Crt4287",
            "★Lyr7001",
            "★Lyr7178",
            "★Lyr7106",
            "★Lyr7298",
            "★Ara6585",
            "★Sco6134",
            "★Sco6527",
            "★Sco6553",
            "★Sco5953",
            "★Sco5984",
            "★Sco6508",
            "★Sco6084",
            "★Sco5944",
            "★Sco6630",
            "★Sco6027",
            "★Sco6247",
            "★Sco6252",
            "★Sco5928",
            "★Sco6241",
            "★Sco6165",
            "★Tri544",
            "★Leo3982",
            "★Leo4534",
            "★Leo4357",
            "★Leo4057",
            "★Leo4359",
            "★Leo4031",
            "★Leo3852",
            "★Leo3905",
            "★Leo3773",
            "★Gru8425",
            "★Gru8636",
            "★Gru8353",
            "★Lib5685",
            "★Lib5531",
            "★Lib5787",
            "★Lib5603",
            "★Pup3165",
            "★Pup3185",
            "★Pup3045",
            "★Cyg7924",
            "★Cyg7417",
            "★Cyg7796",
            "★Cyg8301",
            "★Cyg7949",
            "★Cyg7528",
            "★Oct7228",
            "★Col1956",
            "★Col2040",
            "★Col2177",
            "★Gem2990",
            "★Gem2891",
            "★Gem2421",
            "★Gem2473",
            "★Gem2216",
            "★Gem2777",
            "★Gem2650",
            "★Gem2286",
            "★Gem2484",
            "★Gem2930",
            "★Peg8775",
            "★Peg8781",
            "★Peg39",
            "★Peg8308",
            "★Peg8650",
            "★Peg8634",
            "★Peg8684",
            "★Peg8450",
            "★Peg8880",
            "★Peg8905",
            "★Oph6556",
            "★Oph6378",
            "★Oph6603",
            "★Oph6149",
            "★Oph6056",
            "★Oph6075",
            "★Ser5854",
            "★Ser7141",
            "★Ser5879",
            "★Her6406",
            "★Her6148",
            "★Her6410",
            "★Her6526",
            "★Her6117",
            "★Her6008",
            "★Per936",
            "★Per1017",
            "★Per1131",
            "★Per1228",
            "★Per834",
            "★Per941",
            "★Phe99",
            "★Phe338",
            "★Vel3634",
            "★Vel3485",
            "★Vel3734",
            "★Aqr8232",
            "★Aqr8414",
            "★Aqr8709",
            "★Aqr8518",
            "★Aqr7950",
            "★Aqr8499",
            "★Aqr8610",
            "★Aqr8264",
            "★Cru4853",
            "★Cru4730",
            "★Cru4763",
            "★Cru4700",
            "★Cru4656",
            "★PsA8728",
            "★TrA6217",
            "★Cap7776",
            "★Cap7754",
            "★Cap8278",
            "★Cap8322",
            "★Cap7773",
            "★Sge7479",
            "★Car2326",
            "★Car3685",
            "★Car3307",
            "★Car3699",
            "★Dra5744",
            "★Dra5291",
            "★Dra6705",
            "★Dra6536",
            "★Dra7310",
            "★Dra6688",
            "★Dra4434",
            "★Dra6370",
            "★Dra7462",
            "★Dra6396",
            "★Dra6132",
            "★Dra6636",
            "★CVn4915",
            "★CVn4785",
            "★CVn4846",
            "★Aql7595",
            "★Aql7557",
            "★Aql7525",
            "★Aql7602",
            "★Aql7235",
            "Max Honey",
            "Max Mushrooms",
            "Galarica Twig",
            "Galarica Cuff",
            "Style Card",
            "Armor Pass",
            "Rotom Bike",
            "Rotom Bike",
            "Exp. Charm",
            "Armorite Ore",
            "Mark Charm",
            "Reins of Unity",
            "Reins of Unity",
            "Galarica Wreath",
            "Legendary Clue 1",
            "Legendary Clue 2",
            "Legendary Clue 3",
            "Legendary Clue?",
            "Crown Pass",
            "Wooden Crown",
            "Radiant Petal",
            "White Mane Hair",
            "Black Mane Hair",
            "Iceroot Carrot",
            "Shaderoot Carrot",
            "Dynite Ore",
            "Carrot Seeds",
            "Ability Patch",
            "Reins of Unity",
            "Time Balm",
            "Space Balm",
            "Mysterious Balm",
            "Linking Cord",
            "Hometown Muffin",
            "Apricorn",
            "Jubilife Muffin",
            "Aux Powerguard",
            "Dire Hit",
            "Choice Dumpling",
            "Twice-Spiced Radish",
            "Swap Snack",
            "Caster Fern",
            "Seed of Mastery",
            "Poké Ball",
            "???",
            "Eternal Ice",
            "Uxie’s Claw",
            "Azelf’s Fang",
            "Mesprit’s Plume",
            "Tumblestone",
            "Celestica Flute",
            "Remedy",
            "Fine Remedy",
            "Dazzling Honey",
            "Hearty Grains",
            "Plump Beans",
            "Springy Mushroom",
            "Crunchy Salt",
            "Wood",
            "King’s Leaf",
            "Marsh Balm",
            "Poké Ball",
            "Great Ball",
            "Ultra Ball",
            "Feather Ball",
            "Pokéshi Doll",
            "???",
            "Smoke Bomb",
            "Scatter Bang",
            "Sticky Glob",
            "Star Piece",
            "Mushroom Cake",
            "Bugwort",
            "Honey Cake",
            "Grain Cake",
            "Bean Cake",
            "Salt Cake",
            "Potion",
            "Super Potion",
            "Hyper Potion",
            "Max Potion",
            "Full Restore",
            "Remedy",
            "Fine Remedy",
            "Superb Remedy",
            "Old Gateau",
            "Jubilife Muffin",
            "Full Heal",
            "Revive",
            "Max Revive",
            "Max Ether",
            "Max Elixir",
            "Stealth Spray",
            "???",
            "Aux Power",
            "Aux Guard",
            "Dire Hit",
            "Aux Evasion",
            "Aux Powerguard",
            "Forest Balm",
            "Iron Chunk",
            "???",
            "Black Tumblestone",
            "Sky Tumblestone",
            "???",
            "Ball of Mud",
            "???",
            "Pop Pod",
            "Sootfoot Root",
            "Spoiled Apricorn",
            "Snowball",
            "Sticky Glob",
            "Black Augurite",
            "Peat Block",
            "Stealth Spray",
            "Medicinal Leek",
            "Vivichoke",
            "Pep-Up Plant",
            "???",
            "???",
            "Tempting Charm B",
            "Tempting Charm P",
            "Swordcap",
            "Iron Barktongue",
            "Doppel Bonnets",
            "Direshroom",
            "Sand Radish",
            "Tempting Charm T",
            "Tempting Charm Y",
            "Candy Truffle",
            "Cake-Lure Base",
            "Poké Ball",
            "Great Ball",
            "Ultra Ball",
            "Feather Ball",
            "???",
            "???",
            "Scatter Bang",
            "Smoke Bomb",
            "???",
            "???",
            "Pokéshi Doll",
            "Volcano Balm",
            "Mountain Balm",
            "Snow Balm",
            "Honey Cake",
            "Grain Cake",
            "Bean Cake",
            "Mushroom Cake",
            "Salt Cake",
            "Swap Snack",
            "Choice Dumpling",
            "Twice-Spiced Radish",
            "Survival Charm R",
            "Survival Charm B",
            "Survival Charm P",
            "Survival Charm T",
            "Survival Charm Y",
            "Torn Journal",
            "Warding Charm R",
            "Warding Charm B",
            "Warding Charm P",
            "Warding Charm T",
            "Warding Charm Y",
            "Wall Fragment",
            "Basculegion Food",
            "Old Journal",
            "Wing Ball",
            "Jet Ball",
            "Heavy Ball",
            "Leaden Ball",
            "Gigaton Ball",
            "Wing Ball",
            "Jet Ball",
            "Heavy Ball",
            "Hopo Berry",
            "Superb Remedy",
            "Aux Power",
            "Aux Guard",
            "Aux Evasion",
            "Grit Dust",
            "Grit Gravel",
            "Grit Pebble",
            "Grit Rock",
            "Secret Medicine",
            "Tempting Charm R",
            "Lost Satchel",
            "Lost Satchel",
            "Lost Satchel",
            "Lost Satchel",
            "Lost Satchel",
            "???",
            "Origin Ball",
            "???",
            "???",
            "???",
            "???",
            "Origin Ore",
            "Adamant Crystal",
            "Lustrous Globe",
            "Griseous Core",
            "Blank Plate",
            "???",
            "Crafting Kit",
            "Leaden Ball",
            "Gigaton Ball",
            "Strange Ball",
            "Pokédex",
            "Old Verse 1",
            "Old Verse 2",
            "Old Verse 3",
            "Old Verse 4",
            "???",
            "Old Verse 5",
            "Old Verse 6",
            "Old Verse 7",
            "Old Verse 8",
            "Old Verse 9",
            "Old Verse 10",
            "Old Verse 11",
            "Old Verse 12",
            "Old Verse 13",
            "Old Verse 14",
            "Old Verse 15",
            "Old Verse 16",
            "Old Verse 17",
            "Old Verse 18",
            "Old Verse 19",
            "Old Verse 20",
            "Mysterious Shard S",
            "Mysterious Shard L",
            "Digger Drill",
            "Kanto Slate",
            "Johto Slate",
            "Soul Slate",
            "Rainbow Slate",
            "Squall Slate",
            "Oceanic Slate",
            "Tectonic Slate",
            "Stratospheric Slate",
            "Genome Slate",
            "Discovery Slate",
            "Distortion Slate",
            "DS Sounds",
            "",
            "",
            "",
            "",
            "",
            "Legend Plate",
            "Rotom Phone",
            "Sandwich",
            "Koraidon’s Poké Ball",
            "Miraidon’s Poké Ball",
            "Tera Orb",
            "Scarlet Book",
            "Violet Book",
            "Kofu’s Wallet",
            "",
            "",
            "",
            "",
            "",
            "Tiny Bamboo Shoot",
            "Big Bamboo Shoot",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "Scroll of Darkness",
            "Scroll of Waters",
            "",
            "",
            "Malicious Armor",
            "Normal Tera Shard",
            "Fire Tera Shard",
            "Water Tera Shard",
            "Electric Tera Shard",
            "Grass Tera Shard",
            "Ice Tera Shard",
            "Fighting Tera Shard",
            "Poison Tera Shard",
            "Ground Tera Shard",
            "Flying Tera Shard",
            "Psychic Tera Shard",
            "Bug Tera Shard",
            "Rock Tera Shard",
            "Ghost Tera Shard",
            "Dragon Tera Shard",
            "Dark Tera Shard",
            "Steel Tera Shard",
            "Fairy Tera Shard",
            "Booster Energy",
            "Ability Shield",
            "Clear Amulet",
            "Mirror Herb",
            "Punching Glove",
            "Covert Cloak",
            "Loaded Dice",
            "",
            "Baguette",
            "Mayonnaise",
            "Ketchup",
            "Mustard",
            "Butter",
            "Peanut Butter",
            "Chili Sauce",
            "Salt",
            "Pepper",
            "Yogurt",
            "Whipped Cream",
            "Cream Cheese",
            "Jam",
            "Marmalade",
            "Olive Oil",
            "Vinegar",
            "Sweet Herba Mystica",
            "Salty Herba Mystica",
            "Sour Herba Mystica",
            "Bitter Herba Mystica",
            "Spicy Herba Mystica",
            "Lettuce",
            "Tomato",
            "Cherry Tomatoes",
            "Cucumber",
            "Pickle",
            "Onion",
            "Red Onion",
            "Green Bell Pepper",
            "Red Bell Pepper",
            "Yellow Bell Pepper",
            "Avocado",
            "Bacon",
            "Ham",
            "Prosciutto",
            "Chorizo",
            "Herbed Sausage",
            "Hamburger",
            "Klawf Stick",
            "Smoked Fillet",
            "Fried Fillet",
            "Egg",
            "Potato Tortilla",
            "Tofu",
            "Rice",
            "Noodles",
            "Potato Salad",
            "Cheese",
            "Banana",
            "Strawberry",
            "Apple",
            "Kiwi",
            "Pineapple",
            "Jalapeño",
            "Horseradish",
            "Curry Powder",
            "Wasabi",
            "Watercress",
            "Basil",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "Venonat Fang",
            "Diglett Dirt",
            "Meowth Fur",
            "Psyduck Down",
            "Mankey Fur",
            "Growlithe Fur",
            "Slowpoke Claw",
            "Magnemite Screw",
            "Grimer Toxin",
            "Shellder Pearl",
            "Gastly Gas",
            "Drowzee Fur",
            "Voltorb Sparks",
            "Scyther Claw",
            "Tauros Hair",
            "Magikarp Scales",
            "Ditto Goo",
            "Eevee Fur",
            "Dratini Scales",
            "Pichu Fur",
            "Igglybuff Fluff",
            "Mareep Wool",
            "Hoppip Leaf",
            "Sunkern Leaf",
            "Murkrow Bauble",
            "Misdreavus Tears",
            "Girafarig Fur",
            "Pineco Husk",
            "Dunsparce Scales",
            "Qwilfish Spines",
            "Heracross Claw",
            "Sneasel Claw",
            "Teddiursa Claw",
            "Delibird Parcel",
            "Houndour Fang",
            "Phanpy Nail",
            "Stantler Hair",
            "Larvitar Claw",
            "Wingull Feather",
            "Ralts Dust",
            "Surskit Syrup",
            "Shroomish Spores",
            "Slakoth Fur",
            "Makuhita Sweat",
            "Azurill Fur",
            "Sableye Gem",
            "Meditite Sweat",
            "Gulpin Mucus",
            "Numel Lava",
            "Torkoal Coal",
            "Spoink Pearl",
            "Cacnea Needle",
            "Swablu Fluff",
            "Zangoose Claw",
            "Seviper Fang",
            "Barboach Slime",
            "Shuppet Scrap",
            "Tropius Leaf",
            "Snorunt Fur",
            "Luvdisc Scales",
            "Bagon Scales",
            "Starly Feather",
            "Kricketot Shell",
            "Shinx Fang",
            "Combee Honey",
            "Pachirisu Fur",
            "Buizel Fur",
            "Shellos Mucus",
            "Drifloon Gas",
            "Stunky Fur",
            "Bronzor Fragment",
            "Bonsly Tears",
            "Happiny Dust",
            "Spiritomb Fragment",
            "Gible Scales",
            "Riolu Fur",
            "Hippopotas Sand",
            "Croagunk Poison",
            "Finneon Scales",
            "Snover Berries",
            "Rotom Sparks",
            "Petilil Leaf",
            "Basculin Fang",
            "Sandile Claw",
            "Zorua Fur",
            "Gothita Eyelash",
            "Deerling Hair",
            "Foongus Spores",
            "Alomomola Mucus",
            "Tynamo Slime",
            "Axew Scales",
            "Cubchoo Fur",
            "Cryogonal Ice",
            "Pawniard Blade",
            "Rufflet Feather",
            "Deino Scales",
            "Larvesta Fuzz",
            "Fletchling Feather",
            "Scatterbug Powder",
            "Litleo Tuft",
            "Flabébé Pollen",
            "Skiddo Leaf",
            "Skrelp Kelp",
            "Clauncher Claw",
            "Hawlucha Down",
            "Dedenne Fur",
            "Goomy Goo",
            "Klefki Key",
            "Bergmite Ice",
            "Noibat Fur",
            "Yungoos Fur",
            "Crabrawler Shell",
            "Oricorio Feather",
            "Rockruff Rock",
            "Mareanie Spike",
            "Mudbray Mud",
            "Fomantis Leaf",
            "Salandit Gas",
            "Bounsweet Sweat",
            "Oranguru Fur",
            "Passimian Fur",
            "Sandygast Sand",
            "Komala Claw",
            "Mimikyu Scrap",
            "Bruxish Tooth",
            "Chewtle Claw",
            "Skwovet Fur",
            "Arrokuda Scales",
            "Rookidee Feather",
            "Toxel Sparks",
            "Falinks Sweat",
            "Cufant Tarnish",
            "Rolycoly Coal",
            "Silicobra Sand",
            "Indeedee Fur",
            "Pincurchin Spines",
            "Snom Thread",
            "Impidimp Hair",
            "Applin Juice",
            "Sinistea Chip",
            "Hatenna Dust",
            "Stonjourner Stone",
            "Eiscue Down",
            "Dreepy Powder",
            "",
            "",
            "",
            "Lechonk Hair",
            "Tarountula Thread",
            "Nymble Claw",
            "Rellor Mud",
            "Greavard Wax",
            "Flittle Down",
            "Wiglett Sand",
            "Dondozo Whisker",
            "Veluza Fillet",
            "Finizen Mucus",
            "Smoliv Oil",
            "Capsakid Seed",
            "Tadbulb Mucus",
            "Varoom Fume",
            "Orthworm Tarnish",
            "Tandemaus Fur",
            "Cetoddle Grease",
            "Frigibax Scales",
            "Tatsugiri Scales",
            "Cyclizar Scales",
            "Pawmi Fur",
            "",
            "",
            "Wattrel Feather",
            "Bombirdier Feather",
            "Squawkabilly Feather",
            "Flamigo Down",
            "Klawf Claw",
            "Nacli Salt",
            "Glimmet Crystal",
            "Shroodle Ink",
            "Fidough Fur",
            "Maschiff Fang",
            "Bramblin Twig",
            "Gimmighoul Coin",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "Tinkatink Hair",
            "Charcadet Soot",
            "Toedscool Flaps",
            "Wooper Slime",
            "TM100",
            "TM101",
            "TM102",
            "TM103",
            "TM104",
            "TM105",
            "TM106",
            "TM107",
            "TM108",
            "TM109",
            "TM110",
            "TM111",
            "TM112",
            "TM113",
            "TM114",
            "TM115",
            "TM116",
            "TM117",
            "TM118",
            "TM119",
            "TM120",
            "TM121",
            "TM122",
            "TM123",
            "TM124",
            "TM125",
            "TM126",
            "TM127",
            "TM128",
            "TM129",
            "TM130",
            "TM131",
            "TM132",
            "TM133",
            "TM134",
            "TM135",
            "TM136",
            "TM137",
            "TM138",
            "TM139",
            "TM140",
            "TM141",
            "TM142",
            "TM143",
            "TM144",
            "TM145",
            "TM146",
            "TM147",
            "TM148",
            "TM149",
            "TM150",
            "TM151",
            "TM152",
            "TM153",
            "TM154",
            "TM155",
            "TM156",
            "TM157",
            "TM158",
            "TM159",
            "TM160",
            "TM161",
            "TM162",
            "TM163",
            "TM164",
            "TM165",
            "TM166",
            "TM167",
            "TM168",
            "TM169",
            "TM170",
            "TM171",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "Picnic Set",
            "",
            "Academy Bottle",
            "Academy Bottle",
            "Polka-Dot Bottle",
            "Striped Bottle",
            "Diamond Bottle",
            "Academy Cup",
            "Academy Cup",
            "Striped Cup",
            "Polka-Dot Cup",
            "Flower Pattern Cup",
            "Academy Tablecloth",
            "Academy Tablecloth",
            "Whimsical Tablecloth",
            "Leafy Tablecloth",
            "Spooky Tablecloth",
            "",
            "Academy Ball",
            "Academy Ball",
            "Marill Ball",
            "Yarn Ball",
            "Cyber Ball",
            "Gold Pick",
            "Silver Pick",
            "Red-Flag Pick",
            "Blue-Flag Pick",
            "Pika-Pika Pick",
            "Winking Pika Pick",
            "Vee-Vee Pick",
            "Smiling Vee Pick",
            "Blue Poké Ball Pick",
            "",
            "Auspicious Armor",
            "Leader’s Crest",
            "",
            "",
            "Pink Bottle",
            "Blue Bottle",
            "Yellow Bottle",
            "Steel Bottle (R)",
            "Steel Bottle (Y)",
            "Steel Bottle (B)",
            "Silver Bottle",
            "Barred Cup",
            "Diamond Pattern Cup",
            "Fire Pattern Cup",
            "Pink Cup",
            "Blue Cup",
            "Yellow Cup",
            "Pikachu Cup",
            "Eevee Cup",
            "Slowpoke Cup",
            "Silver Cup",
            "Exercise Ball",
            "Plaid Tablecloth (Y)",
            "Plaid Tablecloth (B)",
            "Plaid Tablecloth (R)",
            "B&W Grass Tablecloth",
            "Battle Tablecloth",
            "Monstrous Tablecloth",
            "Striped Tablecloth",
            "Diamond Tablecloth",
            "Polka-Dot Tablecloth",
            "Lilac Tablecloth",
            "Mint Tablecloth",
            "Peach Tablecloth",
            "Yellow Tablecloth",
            "Blue Tablecloth",
            "Pink Tablecloth",
            "Gold Bottle",
            "Bronze Bottle",
            "Gold Cup",
            "Bronze Cup",
            "Green Poké Ball Pick",
            "Red Poké Ball Pick",
            "Party Sparkler Pick",
            "Heroic Sword Pick",
            "Magical Star Pick",
            "Magical Heart Pick",
            "Parasol Pick",
            "Blue-Sky Flower Pick",
            "Sunset Flower Pick",
            "Sunrise Flower Pick",
            "Blue Dish",
            "Green Dish",
            "Orange Dish",
            "Red Dish",
            "White Dish",
            "Yellow Dish"});
            this.heldItemBox.Location = new System.Drawing.Point(101, 241);
            this.heldItemBox.Name = "heldItemBox";
            this.heldItemBox.Size = new System.Drawing.Size(100, 23);
            this.heldItemBox.TabIndex = 14;
            this.heldItemBox.SelectedIndexChanged += new System.EventHandler(this.heldItem_SelectedIndexChanged);
            // 
            // eggBox2
            // 
            this.eggBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.eggBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.eggBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eggBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.eggBox2.FormattingEnabled = true;
            this.eggBox2.Items.AddRange(new object[] {
            "None",
            "Monster",
            "Water-1",
            "Bug",
            "Flying",
            "Field",
            "Fairy",
            "Grass",
            "Humanlike",
            "Water-3",
            "Mineral",
            "Amorphous",
            "Water-2",
            "Ditto",
            "Dragon",
            "Undiscovered"});
            this.eggBox2.Location = new System.Drawing.Point(227, 145);
            this.eggBox2.Name = "eggBox2";
            this.eggBox2.Size = new System.Drawing.Size(100, 23);
            this.eggBox2.TabIndex = 13;
            this.eggBox2.SelectedIndexChanged += new System.EventHandler(this.egg_SelectedIndexChanged);
            // 
            // eggBox1
            // 
            this.eggBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.eggBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.eggBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eggBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.eggBox1.FormattingEnabled = true;
            this.eggBox1.Items.AddRange(new object[] {
            "None",
            "Monster",
            "Water-1",
            "Bug",
            "Flying",
            "Field",
            "Fairy",
            "Grass",
            "Humanlike",
            "Water-3",
            "Mineral",
            "Amorphous",
            "Water-2",
            "Ditto",
            "Dragon",
            "Undiscovered"});
            this.eggBox1.Location = new System.Drawing.Point(227, 116);
            this.eggBox1.Name = "eggBox1";
            this.eggBox1.Size = new System.Drawing.Size(100, 23);
            this.eggBox1.TabIndex = 12;
            this.eggBox1.SelectedIndexChanged += new System.EventHandler(this.egg_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(333, 119);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 15);
            this.label20.TabIndex = 11;
            this.label20.Text = "Egg Groups";
            // 
            // abilityBox3
            // 
            this.abilityBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.abilityBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.abilityBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abilityBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.abilityBox3.FormattingEnabled = true;
            this.abilityBox3.Items.AddRange(new object[] {
            "—",
            "Stench",
            "Drizzle",
            "Speed Boost",
            "Battle Armor",
            "Sturdy",
            "Damp",
            "Limber",
            "Sand Veil",
            "Static",
            "Volt Absorb",
            "Water Absorb",
            "Oblivious",
            "Cloud Nine",
            "Compound Eyes",
            "Insomnia",
            "Color Change",
            "Immunity",
            "Flash Fire",
            "Shield Dust",
            "Own Tempo",
            "Suction Cups",
            "Intimidate",
            "Shadow Tag",
            "Rough Skin",
            "Wonder Guard",
            "Levitate",
            "Effect Spore",
            "Synchronize",
            "Clear Body",
            "Natural Cure",
            "Lightning Rod",
            "Serene Grace",
            "Swift Swim",
            "Chlorophyll",
            "Illuminate",
            "Trace",
            "Huge Power",
            "Poison Point",
            "Inner Focus",
            "Magma Armor",
            "Water Veil",
            "Magnet Pull",
            "Soundproof",
            "Rain Dish",
            "Sand Stream",
            "Pressure",
            "Thick Fat",
            "Early Bird",
            "Flame Body",
            "Run Away",
            "Keen Eye",
            "Hyper Cutter",
            "Pickup",
            "Truant",
            "Hustle",
            "Cute Charm",
            "Plus",
            "Minus",
            "Forecast",
            "Sticky Hold",
            "Shed Skin",
            "Guts",
            "Marvel Scale",
            "Liquid Ooze",
            "Overgrow",
            "Blaze",
            "Torrent",
            "Swarm",
            "Rock Head",
            "Drought",
            "Arena Trap",
            "Vital Spirit",
            "White Smoke",
            "Pure Power",
            "Shell Armor",
            "Air Lock",
            "Tangled Feet",
            "Motor Drive",
            "Rivalry",
            "Steadfast",
            "Snow Cloak",
            "Gluttony",
            "Anger Point",
            "Unburden",
            "Heatproof",
            "Simple",
            "Dry Skin",
            "Download",
            "Iron Fist",
            "Poison Heal",
            "Adaptability",
            "Skill Link",
            "Hydration",
            "Solar Power",
            "Quick Feet",
            "Normalize",
            "Sniper",
            "Magic Guard",
            "No Guard",
            "Stall",
            "Technician",
            "Leaf Guard",
            "Klutz",
            "Mold Breaker",
            "Super Luck",
            "Aftermath",
            "Anticipation",
            "Forewarn",
            "Unaware",
            "Tinted Lens",
            "Filter",
            "Slow Start",
            "Scrappy",
            "Storm Drain",
            "Ice Body",
            "Solid Rock",
            "Snow Warning",
            "Honey Gather",
            "Frisk",
            "Reckless",
            "Multitype",
            "Flower Gift",
            "Bad Dreams",
            "Pickpocket",
            "Sheer Force",
            "Contrary",
            "Unnerve",
            "Defiant",
            "Defeatist",
            "Cursed Body",
            "Healer",
            "Friend Guard",
            "Weak Armor",
            "Heavy Metal",
            "Light Metal",
            "Multiscale",
            "Toxic Boost",
            "Flare Boost",
            "Harvest",
            "Telepathy",
            "Moody",
            "Overcoat",
            "Poison Touch",
            "Regenerator",
            "Big Pecks",
            "Sand Rush",
            "Wonder Skin",
            "Analytic",
            "Illusion",
            "Imposter",
            "Infiltrator",
            "Mummy",
            "Moxie",
            "Justified",
            "Rattled",
            "Magic Bounce",
            "Sap Sipper",
            "Prankster",
            "Sand Force",
            "Iron Barbs",
            "Zen Mode",
            "Victory Star",
            "Turboblaze",
            "Teravolt",
            "Aroma Veil",
            "Flower Veil",
            "Cheek Pouch",
            "Protean",
            "Fur Coat",
            "Magician",
            "Bulletproof",
            "Competitive",
            "Strong Jaw",
            "Refrigerate",
            "Sweet Veil",
            "Stance Change",
            "Gale Wings",
            "Mega Launcher",
            "Grass Pelt",
            "Symbiosis",
            "Tough Claws",
            "Pixilate",
            "Gooey",
            "Aerilate",
            "Parental Bond",
            "Dark Aura",
            "Fairy Aura",
            "Aura Break",
            "Primordial Sea",
            "Desolate Land",
            "Delta Stream",
            "Stamina",
            "Wimp Out",
            "Emergency Exit",
            "Water Compaction",
            "Merciless",
            "Shields Down",
            "Stakeout",
            "Water Bubble",
            "Steelworker",
            "Berserk",
            "Slush Rush",
            "Long Reach",
            "Liquid Voice",
            "Triage",
            "Galvanize",
            "Surge Surfer",
            "Schooling",
            "Disguise",
            "Battle Bond",
            "Power Construct",
            "Corrosion",
            "Comatose",
            "Queenly Majesty",
            "Innards Out",
            "Dancer",
            "Battery",
            "Fluffy",
            "Dazzling",
            "Soul-Heart",
            "Tangling Hair",
            "Receiver",
            "Power of Alchemy",
            "Beast Boost",
            "RKS System",
            "Electric Surge",
            "Psychic Surge",
            "Misty Surge",
            "Grassy Surge",
            "Full Metal Body",
            "Shadow Shield",
            "Prism Armor",
            "Neuroforce",
            "Intrepid Sword",
            "Dauntless Shield",
            "Libero",
            "Ball Fetch",
            "Cotton Down",
            "Propeller Tail",
            "Mirror Armor",
            "Gulp Missile",
            "Stalwart",
            "Steam Engine",
            "Punk Rock",
            "Sand Spit",
            "Ice Scales",
            "Ripen",
            "Ice Face",
            "Power Spot",
            "Mimicry",
            "Screen Cleaner",
            "Steely Spirit",
            "Perish Body",
            "Wandering Spirit",
            "Gorilla Tactics",
            "Neutralizing Gas",
            "Pastel Veil",
            "Hunger Switch",
            "Quick Draw",
            "Unseen Fist",
            "Curious Medicine",
            "Transistor",
            "Dragon’s Maw",
            "Chilling Neigh",
            "Grim Neigh",
            "As One",
            "As One",
            "Lingering Aroma",
            "Seed Sower",
            "Thermal Exchange",
            "Anger Shell",
            "Purifying Salt",
            "Well-Baked Body",
            "Wind Rider",
            "Guard Dog",
            "Rocky Payload",
            "Wind Power",
            "Zero to Hero",
            "Commander",
            "Electromorphosis",
            "Protosynthesis",
            "Quark Drive",
            "Good as Gold",
            "Vessel of Ruin",
            "Sword of Ruin",
            "Tablets of Ruin",
            "Beads of Ruin",
            "Orichalcum Pulse",
            "Hadron Engine",
            "Opportunist",
            "Cud Chew",
            "Sharpness",
            "Supreme Overlord",
            "Costar",
            "Toxic Debris",
            "Armor Tail",
            "Earth Eater",
            "Mycelium Might"});
            this.abilityBox3.Location = new System.Drawing.Point(101, 174);
            this.abilityBox3.Name = "abilityBox3";
            this.abilityBox3.Size = new System.Drawing.Size(100, 23);
            this.abilityBox3.TabIndex = 10;
            this.abilityBox3.SelectedIndexChanged += new System.EventHandler(this.ability_SelectedIndexChanged);
            // 
            // abilityBox2
            // 
            this.abilityBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.abilityBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.abilityBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abilityBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.abilityBox2.FormattingEnabled = true;
            this.abilityBox2.Items.AddRange(new object[] {
            "—",
            "Stench",
            "Drizzle",
            "Speed Boost",
            "Battle Armor",
            "Sturdy",
            "Damp",
            "Limber",
            "Sand Veil",
            "Static",
            "Volt Absorb",
            "Water Absorb",
            "Oblivious",
            "Cloud Nine",
            "Compound Eyes",
            "Insomnia",
            "Color Change",
            "Immunity",
            "Flash Fire",
            "Shield Dust",
            "Own Tempo",
            "Suction Cups",
            "Intimidate",
            "Shadow Tag",
            "Rough Skin",
            "Wonder Guard",
            "Levitate",
            "Effect Spore",
            "Synchronize",
            "Clear Body",
            "Natural Cure",
            "Lightning Rod",
            "Serene Grace",
            "Swift Swim",
            "Chlorophyll",
            "Illuminate",
            "Trace",
            "Huge Power",
            "Poison Point",
            "Inner Focus",
            "Magma Armor",
            "Water Veil",
            "Magnet Pull",
            "Soundproof",
            "Rain Dish",
            "Sand Stream",
            "Pressure",
            "Thick Fat",
            "Early Bird",
            "Flame Body",
            "Run Away",
            "Keen Eye",
            "Hyper Cutter",
            "Pickup",
            "Truant",
            "Hustle",
            "Cute Charm",
            "Plus",
            "Minus",
            "Forecast",
            "Sticky Hold",
            "Shed Skin",
            "Guts",
            "Marvel Scale",
            "Liquid Ooze",
            "Overgrow",
            "Blaze",
            "Torrent",
            "Swarm",
            "Rock Head",
            "Drought",
            "Arena Trap",
            "Vital Spirit",
            "White Smoke",
            "Pure Power",
            "Shell Armor",
            "Air Lock",
            "Tangled Feet",
            "Motor Drive",
            "Rivalry",
            "Steadfast",
            "Snow Cloak",
            "Gluttony",
            "Anger Point",
            "Unburden",
            "Heatproof",
            "Simple",
            "Dry Skin",
            "Download",
            "Iron Fist",
            "Poison Heal",
            "Adaptability",
            "Skill Link",
            "Hydration",
            "Solar Power",
            "Quick Feet",
            "Normalize",
            "Sniper",
            "Magic Guard",
            "No Guard",
            "Stall",
            "Technician",
            "Leaf Guard",
            "Klutz",
            "Mold Breaker",
            "Super Luck",
            "Aftermath",
            "Anticipation",
            "Forewarn",
            "Unaware",
            "Tinted Lens",
            "Filter",
            "Slow Start",
            "Scrappy",
            "Storm Drain",
            "Ice Body",
            "Solid Rock",
            "Snow Warning",
            "Honey Gather",
            "Frisk",
            "Reckless",
            "Multitype",
            "Flower Gift",
            "Bad Dreams",
            "Pickpocket",
            "Sheer Force",
            "Contrary",
            "Unnerve",
            "Defiant",
            "Defeatist",
            "Cursed Body",
            "Healer",
            "Friend Guard",
            "Weak Armor",
            "Heavy Metal",
            "Light Metal",
            "Multiscale",
            "Toxic Boost",
            "Flare Boost",
            "Harvest",
            "Telepathy",
            "Moody",
            "Overcoat",
            "Poison Touch",
            "Regenerator",
            "Big Pecks",
            "Sand Rush",
            "Wonder Skin",
            "Analytic",
            "Illusion",
            "Imposter",
            "Infiltrator",
            "Mummy",
            "Moxie",
            "Justified",
            "Rattled",
            "Magic Bounce",
            "Sap Sipper",
            "Prankster",
            "Sand Force",
            "Iron Barbs",
            "Zen Mode",
            "Victory Star",
            "Turboblaze",
            "Teravolt",
            "Aroma Veil",
            "Flower Veil",
            "Cheek Pouch",
            "Protean",
            "Fur Coat",
            "Magician",
            "Bulletproof",
            "Competitive",
            "Strong Jaw",
            "Refrigerate",
            "Sweet Veil",
            "Stance Change",
            "Gale Wings",
            "Mega Launcher",
            "Grass Pelt",
            "Symbiosis",
            "Tough Claws",
            "Pixilate",
            "Gooey",
            "Aerilate",
            "Parental Bond",
            "Dark Aura",
            "Fairy Aura",
            "Aura Break",
            "Primordial Sea",
            "Desolate Land",
            "Delta Stream",
            "Stamina",
            "Wimp Out",
            "Emergency Exit",
            "Water Compaction",
            "Merciless",
            "Shields Down",
            "Stakeout",
            "Water Bubble",
            "Steelworker",
            "Berserk",
            "Slush Rush",
            "Long Reach",
            "Liquid Voice",
            "Triage",
            "Galvanize",
            "Surge Surfer",
            "Schooling",
            "Disguise",
            "Battle Bond",
            "Power Construct",
            "Corrosion",
            "Comatose",
            "Queenly Majesty",
            "Innards Out",
            "Dancer",
            "Battery",
            "Fluffy",
            "Dazzling",
            "Soul-Heart",
            "Tangling Hair",
            "Receiver",
            "Power of Alchemy",
            "Beast Boost",
            "RKS System",
            "Electric Surge",
            "Psychic Surge",
            "Misty Surge",
            "Grassy Surge",
            "Full Metal Body",
            "Shadow Shield",
            "Prism Armor",
            "Neuroforce",
            "Intrepid Sword",
            "Dauntless Shield",
            "Libero",
            "Ball Fetch",
            "Cotton Down",
            "Propeller Tail",
            "Mirror Armor",
            "Gulp Missile",
            "Stalwart",
            "Steam Engine",
            "Punk Rock",
            "Sand Spit",
            "Ice Scales",
            "Ripen",
            "Ice Face",
            "Power Spot",
            "Mimicry",
            "Screen Cleaner",
            "Steely Spirit",
            "Perish Body",
            "Wandering Spirit",
            "Gorilla Tactics",
            "Neutralizing Gas",
            "Pastel Veil",
            "Hunger Switch",
            "Quick Draw",
            "Unseen Fist",
            "Curious Medicine",
            "Transistor",
            "Dragon’s Maw",
            "Chilling Neigh",
            "Grim Neigh",
            "As One",
            "As One",
            "Lingering Aroma",
            "Seed Sower",
            "Thermal Exchange",
            "Anger Shell",
            "Purifying Salt",
            "Well-Baked Body",
            "Wind Rider",
            "Guard Dog",
            "Rocky Payload",
            "Wind Power",
            "Zero to Hero",
            "Commander",
            "Electromorphosis",
            "Protosynthesis",
            "Quark Drive",
            "Good as Gold",
            "Vessel of Ruin",
            "Sword of Ruin",
            "Tablets of Ruin",
            "Beads of Ruin",
            "Orichalcum Pulse",
            "Hadron Engine",
            "Opportunist",
            "Cud Chew",
            "Sharpness",
            "Supreme Overlord",
            "Costar",
            "Toxic Debris",
            "Armor Tail",
            "Earth Eater",
            "Mycelium Might"});
            this.abilityBox2.Location = new System.Drawing.Point(101, 145);
            this.abilityBox2.Name = "abilityBox2";
            this.abilityBox2.Size = new System.Drawing.Size(100, 23);
            this.abilityBox2.TabIndex = 9;
            this.abilityBox2.SelectedIndexChanged += new System.EventHandler(this.ability_SelectedIndexChanged);
            // 
            // abilityBox1
            // 
            this.abilityBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.abilityBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.abilityBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abilityBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.abilityBox1.FormattingEnabled = true;
            this.abilityBox1.Items.AddRange(new object[] {
            "—",
            "Stench",
            "Drizzle",
            "Speed Boost",
            "Battle Armor",
            "Sturdy",
            "Damp",
            "Limber",
            "Sand Veil",
            "Static",
            "Volt Absorb",
            "Water Absorb",
            "Oblivious",
            "Cloud Nine",
            "Compound Eyes",
            "Insomnia",
            "Color Change",
            "Immunity",
            "Flash Fire",
            "Shield Dust",
            "Own Tempo",
            "Suction Cups",
            "Intimidate",
            "Shadow Tag",
            "Rough Skin",
            "Wonder Guard",
            "Levitate",
            "Effect Spore",
            "Synchronize",
            "Clear Body",
            "Natural Cure",
            "Lightning Rod",
            "Serene Grace",
            "Swift Swim",
            "Chlorophyll",
            "Illuminate",
            "Trace",
            "Huge Power",
            "Poison Point",
            "Inner Focus",
            "Magma Armor",
            "Water Veil",
            "Magnet Pull",
            "Soundproof",
            "Rain Dish",
            "Sand Stream",
            "Pressure",
            "Thick Fat",
            "Early Bird",
            "Flame Body",
            "Run Away",
            "Keen Eye",
            "Hyper Cutter",
            "Pickup",
            "Truant",
            "Hustle",
            "Cute Charm",
            "Plus",
            "Minus",
            "Forecast",
            "Sticky Hold",
            "Shed Skin",
            "Guts",
            "Marvel Scale",
            "Liquid Ooze",
            "Overgrow",
            "Blaze",
            "Torrent",
            "Swarm",
            "Rock Head",
            "Drought",
            "Arena Trap",
            "Vital Spirit",
            "White Smoke",
            "Pure Power",
            "Shell Armor",
            "Air Lock",
            "Tangled Feet",
            "Motor Drive",
            "Rivalry",
            "Steadfast",
            "Snow Cloak",
            "Gluttony",
            "Anger Point",
            "Unburden",
            "Heatproof",
            "Simple",
            "Dry Skin",
            "Download",
            "Iron Fist",
            "Poison Heal",
            "Adaptability",
            "Skill Link",
            "Hydration",
            "Solar Power",
            "Quick Feet",
            "Normalize",
            "Sniper",
            "Magic Guard",
            "No Guard",
            "Stall",
            "Technician",
            "Leaf Guard",
            "Klutz",
            "Mold Breaker",
            "Super Luck",
            "Aftermath",
            "Anticipation",
            "Forewarn",
            "Unaware",
            "Tinted Lens",
            "Filter",
            "Slow Start",
            "Scrappy",
            "Storm Drain",
            "Ice Body",
            "Solid Rock",
            "Snow Warning",
            "Honey Gather",
            "Frisk",
            "Reckless",
            "Multitype",
            "Flower Gift",
            "Bad Dreams",
            "Pickpocket",
            "Sheer Force",
            "Contrary",
            "Unnerve",
            "Defiant",
            "Defeatist",
            "Cursed Body",
            "Healer",
            "Friend Guard",
            "Weak Armor",
            "Heavy Metal",
            "Light Metal",
            "Multiscale",
            "Toxic Boost",
            "Flare Boost",
            "Harvest",
            "Telepathy",
            "Moody",
            "Overcoat",
            "Poison Touch",
            "Regenerator",
            "Big Pecks",
            "Sand Rush",
            "Wonder Skin",
            "Analytic",
            "Illusion",
            "Imposter",
            "Infiltrator",
            "Mummy",
            "Moxie",
            "Justified",
            "Rattled",
            "Magic Bounce",
            "Sap Sipper",
            "Prankster",
            "Sand Force",
            "Iron Barbs",
            "Zen Mode",
            "Victory Star",
            "Turboblaze",
            "Teravolt",
            "Aroma Veil",
            "Flower Veil",
            "Cheek Pouch",
            "Protean",
            "Fur Coat",
            "Magician",
            "Bulletproof",
            "Competitive",
            "Strong Jaw",
            "Refrigerate",
            "Sweet Veil",
            "Stance Change",
            "Gale Wings",
            "Mega Launcher",
            "Grass Pelt",
            "Symbiosis",
            "Tough Claws",
            "Pixilate",
            "Gooey",
            "Aerilate",
            "Parental Bond",
            "Dark Aura",
            "Fairy Aura",
            "Aura Break",
            "Primordial Sea",
            "Desolate Land",
            "Delta Stream",
            "Stamina",
            "Wimp Out",
            "Emergency Exit",
            "Water Compaction",
            "Merciless",
            "Shields Down",
            "Stakeout",
            "Water Bubble",
            "Steelworker",
            "Berserk",
            "Slush Rush",
            "Long Reach",
            "Liquid Voice",
            "Triage",
            "Galvanize",
            "Surge Surfer",
            "Schooling",
            "Disguise",
            "Battle Bond",
            "Power Construct",
            "Corrosion",
            "Comatose",
            "Queenly Majesty",
            "Innards Out",
            "Dancer",
            "Battery",
            "Fluffy",
            "Dazzling",
            "Soul-Heart",
            "Tangling Hair",
            "Receiver",
            "Power of Alchemy",
            "Beast Boost",
            "RKS System",
            "Electric Surge",
            "Psychic Surge",
            "Misty Surge",
            "Grassy Surge",
            "Full Metal Body",
            "Shadow Shield",
            "Prism Armor",
            "Neuroforce",
            "Intrepid Sword",
            "Dauntless Shield",
            "Libero",
            "Ball Fetch",
            "Cotton Down",
            "Propeller Tail",
            "Mirror Armor",
            "Gulp Missile",
            "Stalwart",
            "Steam Engine",
            "Punk Rock",
            "Sand Spit",
            "Ice Scales",
            "Ripen",
            "Ice Face",
            "Power Spot",
            "Mimicry",
            "Screen Cleaner",
            "Steely Spirit",
            "Perish Body",
            "Wandering Spirit",
            "Gorilla Tactics",
            "Neutralizing Gas",
            "Pastel Veil",
            "Hunger Switch",
            "Quick Draw",
            "Unseen Fist",
            "Curious Medicine",
            "Transistor",
            "Dragon’s Maw",
            "Chilling Neigh",
            "Grim Neigh",
            "As One",
            "As One",
            "Lingering Aroma",
            "Seed Sower",
            "Thermal Exchange",
            "Anger Shell",
            "Purifying Salt",
            "Well-Baked Body",
            "Wind Rider",
            "Guard Dog",
            "Rocky Payload",
            "Wind Power",
            "Zero to Hero",
            "Commander",
            "Electromorphosis",
            "Protosynthesis",
            "Quark Drive",
            "Good as Gold",
            "Vessel of Ruin",
            "Sword of Ruin",
            "Tablets of Ruin",
            "Beads of Ruin",
            "Orichalcum Pulse",
            "Hadron Engine",
            "Opportunist",
            "Cud Chew",
            "Sharpness",
            "Supreme Overlord",
            "Costar",
            "Toxic Debris",
            "Armor Tail",
            "Earth Eater",
            "Mycelium Might"});
            this.abilityBox1.Location = new System.Drawing.Point(101, 116);
            this.abilityBox1.Name = "abilityBox1";
            this.abilityBox1.Size = new System.Drawing.Size(100, 23);
            this.abilityBox1.TabIndex = 8;
            this.abilityBox1.SelectedIndexChanged += new System.EventHandler(this.ability_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(46, 119);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 15);
            this.label19.TabIndex = 7;
            this.label19.Text = "Abilities";
            // 
            // typeBox2
            // 
            this.typeBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.typeBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.typeBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.typeBox2.FormattingEnabled = true;
            this.typeBox2.Items.AddRange(new object[] {
            "Normal",
            "Fighting",
            "Flying",
            "Poison",
            "Ground",
            "Rock",
            "Bug",
            "Ghost",
            "Steel",
            "Fire",
            "Water",
            "Grass",
            "Electric",
            "Psychic",
            "Ice",
            "Dragon",
            "Dark",
            "Fairy"});
            this.typeBox2.Location = new System.Drawing.Point(227, 59);
            this.typeBox2.Name = "typeBox2";
            this.typeBox2.Size = new System.Drawing.Size(100, 23);
            this.typeBox2.TabIndex = 6;
            this.typeBox2.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // typeBox1
            // 
            this.typeBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.typeBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.typeBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.typeBox1.FormattingEnabled = true;
            this.typeBox1.Items.AddRange(new object[] {
            "Normal",
            "Fighting",
            "Flying",
            "Poison",
            "Ground",
            "Rock",
            "Bug",
            "Ghost",
            "Steel",
            "Fire",
            "Water",
            "Grass",
            "Electric",
            "Psychic",
            "Ice",
            "Dragon",
            "Dark",
            "Fairy"});
            this.typeBox1.Location = new System.Drawing.Point(101, 59);
            this.typeBox1.Name = "typeBox1";
            this.typeBox1.Size = new System.Drawing.Size(100, 23);
            this.typeBox1.TabIndex = 5;
            this.typeBox1.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(59, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 15);
            this.label18.TabIndex = 4;
            this.label18.Text = "Types";
            // 
            // presentCheck
            // 
            this.presentCheck.AutoSize = true;
            this.presentCheck.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.presentCheck.CheckedState.BorderRadius = 0;
            this.presentCheck.CheckedState.BorderThickness = 0;
            this.presentCheck.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.presentCheck.ForeColor = System.Drawing.SystemColors.Control;
            this.presentCheck.Location = new System.Drawing.Point(0, 472);
            this.presentCheck.Name = "presentCheck";
            this.presentCheck.Size = new System.Drawing.Size(81, 19);
            this.presentCheck.TabIndex = 3;
            this.presentCheck.Text = "Is present?";
            this.presentCheck.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.presentCheck.UncheckedState.BorderRadius = 0;
            this.presentCheck.UncheckedState.BorderThickness = 0;
            this.presentCheck.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.presentCheck.CheckedChanged += new System.EventHandler(this.presentCheck_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Revamped", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(153, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "MISC STATS";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel4.BorderRadius = 10;
            this.panel4.BorderThickness = 1;
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.evSPA);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.evHP);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.evATK);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.evDEF);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.evSPD);
            this.panel4.Controls.Add(this.evSPE);
            this.panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel4.Location = new System.Drawing.Point(6, 348);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(423, 246);
            this.panel4.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(271, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "SPE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Revamped", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(158, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "EV YIELDS";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(271, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = "SPD";
            // 
            // evSPA
            // 
            this.evSPA.BackColor = System.Drawing.Color.Transparent;
            this.evSPA.BorderThickness = 0;
            this.evSPA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.evSPA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.evSPA.ForeColor = System.Drawing.SystemColors.Control;
            this.evSPA.Location = new System.Drawing.Point(213, 54);
            this.evSPA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evSPA.Name = "evSPA";
            this.evSPA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.evSPA.Size = new System.Drawing.Size(52, 26);
            this.evSPA.TabIndex = 16;
            this.evSPA.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.evSPA.ValueChanged += new System.EventHandler(this.ev_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(271, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 15);
            this.label14.TabIndex = 22;
            this.label14.Text = "SPA";
            // 
            // evHP
            // 
            this.evHP.BackColor = System.Drawing.Color.Transparent;
            this.evHP.BorderThickness = 0;
            this.evHP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.evHP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.evHP.ForeColor = System.Drawing.SystemColors.Control;
            this.evHP.Location = new System.Drawing.Point(151, 54);
            this.evHP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evHP.Name = "evHP";
            this.evHP.Size = new System.Drawing.Size(52, 26);
            this.evHP.TabIndex = 13;
            this.evHP.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.evHP.ValueChanged += new System.EventHandler(this.ev_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(115, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 17);
            this.label15.TabIndex = 21;
            this.label15.Text = "DEF";
            // 
            // evATK
            // 
            this.evATK.BackColor = System.Drawing.Color.Transparent;
            this.evATK.BorderThickness = 0;
            this.evATK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.evATK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.evATK.ForeColor = System.Drawing.SystemColors.Control;
            this.evATK.Location = new System.Drawing.Point(151, 112);
            this.evATK.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evATK.Name = "evATK";
            this.evATK.Size = new System.Drawing.Size(52, 26);
            this.evATK.TabIndex = 14;
            this.evATK.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.evATK.ValueChanged += new System.EventHandler(this.ev_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(115, 117);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 17);
            this.label16.TabIndex = 20;
            this.label16.Text = "ATK";
            // 
            // evDEF
            // 
            this.evDEF.BackColor = System.Drawing.Color.Transparent;
            this.evDEF.BorderThickness = 0;
            this.evDEF.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.evDEF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.evDEF.ForeColor = System.Drawing.SystemColors.Control;
            this.evDEF.Location = new System.Drawing.Point(151, 170);
            this.evDEF.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evDEF.Name = "evDEF";
            this.evDEF.Size = new System.Drawing.Size(52, 26);
            this.evDEF.TabIndex = 15;
            this.evDEF.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.evDEF.ValueChanged += new System.EventHandler(this.ev_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(121, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 17);
            this.label17.TabIndex = 19;
            this.label17.Text = "HP";
            // 
            // evSPD
            // 
            this.evSPD.BackColor = System.Drawing.Color.Transparent;
            this.evSPD.BorderThickness = 0;
            this.evSPD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.evSPD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.evSPD.ForeColor = System.Drawing.SystemColors.Control;
            this.evSPD.Location = new System.Drawing.Point(213, 112);
            this.evSPD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evSPD.Name = "evSPD";
            this.evSPD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.evSPD.Size = new System.Drawing.Size(52, 26);
            this.evSPD.TabIndex = 17;
            this.evSPD.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.evSPD.ValueChanged += new System.EventHandler(this.ev_ValueChanged);
            // 
            // evSPE
            // 
            this.evSPE.BackColor = System.Drawing.Color.Transparent;
            this.evSPE.BorderThickness = 0;
            this.evSPE.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.evSPE.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.evSPE.ForeColor = System.Drawing.SystemColors.Control;
            this.evSPE.Location = new System.Drawing.Point(213, 170);
            this.evSPE.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evSPE.Name = "evSPE";
            this.evSPE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.evSPE.Size = new System.Drawing.Size(52, 26);
            this.evSPE.TabIndex = 18;
            this.evSPE.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.evSPE.ValueChanged += new System.EventHandler(this.ev_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel3.BorderRadius = 10;
            this.panel3.BorderThickness = 1;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.baseSPE);
            this.panel3.Controls.Add(this.baseSPD);
            this.panel3.Controls.Add(this.baseSPA);
            this.panel3.Controls.Add(this.baseDEF);
            this.panel3.Controls.Add(this.baseATK);
            this.panel3.Controls.Add(this.baseHP);
            this.panel3.Controls.Add(this.label1);
            this.panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel3.Location = new System.Drawing.Point(6, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(423, 239);
            this.panel3.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(271, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "SPE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(271, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "SPD";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "SPA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(115, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "DEF";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(115, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "ATK";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(121, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "HP";
            // 
            // baseSPE
            // 
            this.baseSPE.BackColor = System.Drawing.Color.Transparent;
            this.baseSPE.BorderThickness = 0;
            this.baseSPE.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.baseSPE.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.baseSPE.ForeColor = System.Drawing.SystemColors.Control;
            this.baseSPE.Location = new System.Drawing.Point(213, 172);
            this.baseSPE.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.baseSPE.Name = "baseSPE";
            this.baseSPE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.baseSPE.Size = new System.Drawing.Size(52, 26);
            this.baseSPE.TabIndex = 6;
            this.baseSPE.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.baseSPE.ValueChanged += new System.EventHandler(this.baseStat_ValueChanged);
            // 
            // baseSPD
            // 
            this.baseSPD.BackColor = System.Drawing.Color.Transparent;
            this.baseSPD.BorderThickness = 0;
            this.baseSPD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.baseSPD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.baseSPD.ForeColor = System.Drawing.SystemColors.Control;
            this.baseSPD.Location = new System.Drawing.Point(213, 114);
            this.baseSPD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.baseSPD.Name = "baseSPD";
            this.baseSPD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.baseSPD.Size = new System.Drawing.Size(52, 26);
            this.baseSPD.TabIndex = 5;
            this.baseSPD.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.baseSPD.ValueChanged += new System.EventHandler(this.baseStat_ValueChanged);
            // 
            // baseSPA
            // 
            this.baseSPA.BackColor = System.Drawing.Color.Transparent;
            this.baseSPA.BorderThickness = 0;
            this.baseSPA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.baseSPA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.baseSPA.ForeColor = System.Drawing.SystemColors.Control;
            this.baseSPA.Location = new System.Drawing.Point(213, 56);
            this.baseSPA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.baseSPA.Name = "baseSPA";
            this.baseSPA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.baseSPA.Size = new System.Drawing.Size(52, 26);
            this.baseSPA.TabIndex = 4;
            this.baseSPA.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.baseSPA.ValueChanged += new System.EventHandler(this.baseStat_ValueChanged);
            // 
            // baseDEF
            // 
            this.baseDEF.BackColor = System.Drawing.Color.Transparent;
            this.baseDEF.BorderThickness = 0;
            this.baseDEF.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.baseDEF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.baseDEF.ForeColor = System.Drawing.SystemColors.Control;
            this.baseDEF.Location = new System.Drawing.Point(151, 172);
            this.baseDEF.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.baseDEF.Name = "baseDEF";
            this.baseDEF.Size = new System.Drawing.Size(52, 26);
            this.baseDEF.TabIndex = 3;
            this.baseDEF.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.baseDEF.ValueChanged += new System.EventHandler(this.baseStat_ValueChanged);
            // 
            // baseATK
            // 
            this.baseATK.BackColor = System.Drawing.Color.Transparent;
            this.baseATK.BorderThickness = 0;
            this.baseATK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.baseATK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.baseATK.ForeColor = System.Drawing.SystemColors.Control;
            this.baseATK.Location = new System.Drawing.Point(151, 114);
            this.baseATK.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.baseATK.Name = "baseATK";
            this.baseATK.Size = new System.Drawing.Size(52, 26);
            this.baseATK.TabIndex = 2;
            this.baseATK.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.baseATK.ValueChanged += new System.EventHandler(this.baseStat_ValueChanged);
            // 
            // baseHP
            // 
            this.baseHP.BackColor = System.Drawing.Color.Transparent;
            this.baseHP.BorderThickness = 0;
            this.baseHP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.baseHP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.baseHP.ForeColor = System.Drawing.SystemColors.Control;
            this.baseHP.Location = new System.Drawing.Point(151, 56);
            this.baseHP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.baseHP.Name = "baseHP";
            this.baseHP.Size = new System.Drawing.Size(52, 26);
            this.baseHP.TabIndex = 1;
            this.baseHP.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.baseHP.ValueChanged += new System.EventHandler(this.baseStat_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Revamped", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(151, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "BASE STATS";
            // 
            // pokemonName
            // 
            this.pokemonName.AutoSize = true;
            this.pokemonName.Font = new System.Drawing.Font("Akira Expanded", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pokemonName.ForeColor = System.Drawing.SystemColors.Control;
            this.pokemonName.Location = new System.Drawing.Point(351, 29);
            this.pokemonName.Name = "pokemonName";
            this.pokemonName.Size = new System.Drawing.Size(178, 45);
            this.pokemonName.TabIndex = 0;
            this.pokemonName.Text = "TEXT";
            this.pokemonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // movesetPage
            // 
            this.movesetPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.movesetPage.Controls.Add(this.tmBox);
            this.movesetPage.Controls.Add(this.movesetGrid);
            this.movesetPage.Controls.Add(this.label4);
            this.movesetPage.Location = new System.Drawing.Point(4, 4);
            this.movesetPage.Name = "movesetPage";
            this.movesetPage.Padding = new System.Windows.Forms.Padding(3);
            this.movesetPage.Size = new System.Drawing.Size(869, 602);
            this.movesetPage.TabIndex = 1;
            this.movesetPage.Text = "Movesets";
            // 
            // tmBox
            // 
            this.tmBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tmBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tmBox.ForeColor = System.Drawing.SystemColors.Control;
            this.tmBox.FormattingEnabled = true;
            this.tmBox.Items.AddRange(new object[] {
            "Take Down",
            "Charm",
            "Fake Tears",
            "Agility",
            "Mud Slap",
            "Scary Face",
            "Protect",
            "Fire Fang",
            "Thunder Fang",
            "Ice Fang",
            "Water Pulse",
            "Low Kick",
            "Acid Spray",
            "Acrobatics",
            "Struggle Bug",
            "Psybeam",
            "Confuse Ray",
            "Thief",
            "Disarming Voice",
            "Trailblaze",
            "Pounce",
            "Chilling Water",
            "Charge Beam",
            "Fire Spin",
            "Facade",
            "Poison Tail",
            "Aerial Ace",
            "Bulldoze",
            "Hex",
            "Snarl",
            "Metal Claw",
            "Swift",
            "Magical Leaf",
            "Icy Wind",
            "Mud Shot",
            "Rock Tomb",
            "Draining Kiss",
            "Flame Charge",
            "Low Sweep",
            "Air Cutter",
            "Stored Power",
            "Night Shade",
            "Fling",
            "Dragon Tail",
            "Venoshock",
            "Avalanche",
            "Endure",
            "Volt Switch",
            "Sunny Day",
            "Rain Dance",
            "Sandstorm",
            "Snowscape",
            "Smart Strike",
            "Psyshock",
            "Dig",
            "Bullet Seed",
            "False Swipe",
            "Brick Break",
            "Zen Headbutt",
            "U-Turn",
            "Shadow Claw",
            "Foul Play",
            "Psychic Fangs",
            "Bulk Up",
            "Air Slash",
            "Body Slam",
            "Fire Punch",
            "Thunder Punch",
            "Ice Punch",
            "Sleep Talk",
            "Seed Bomb",
            "Electro Ball",
            "Drain Punch",
            "Reflect",
            "Light Screen",
            "Rock Blast",
            "Waterfall",
            "Dragon Claw",
            "Dazzling Gleam",
            "Metronome",
            "Grass Knot",
            "Thunder Wave",
            "Poison Jab",
            "Stomping Tantrum",
            "Rest",
            "Rock Slide",
            "Taunt",
            "Swords Dance",
            "Body Press",
            "Spikes",
            "Toxic Spikes",
            "Imprison",
            "Flash Cannon",
            "Dark Pulse",
            "Leech Life",
            "Eerie Impulse",
            "Fly",
            "Skill Swap",
            "Iron Head",
            "Dragon Dance",
            "Power Gem",
            "Gunk Shot",
            "Substitute",
            "Iron Defense",
            "X-Scissor",
            "Drill Run",
            "Will-O-Wisp",
            "Crunch",
            "Trick",
            "Liquidation",
            "Giga Drain",
            "Aura Sphere",
            "Tailwind",
            "Shadow Ball",
            "Dragon Pulse",
            "Stealth Rock",
            "Hyper Voice",
            "Heat Wave",
            "Energy Ball",
            "Psychic",
            "Heavy Slam",
            "Encore",
            "Surf",
            "Ice Spinner",
            "Flamethrower",
            "Thunderbolt",
            "Play Rough",
            "Amnesia",
            "Calm Mind",
            "Helping Hand",
            "Pollen Puff",
            "Baton Pass",
            "Earth Power",
            "Reversal",
            "Ice Beam",
            "Electric Terrain",
            "Grassy Terrain",
            "Psychic Terrain",
            "Misty Terrain",
            "Nasty Plot",
            "Fire Blast",
            "Hydro Pump",
            "Blizzard",
            "Fire Pledge",
            "Water Pledge",
            "Grass Pledge",
            "Wild Charge",
            "Sludge Bomb",
            "Earthquake",
            "Stone Edge",
            "Phantom Force",
            "Giga Impact",
            "Blast Burn",
            "Hydro Cannon",
            "Frenzy Plant",
            "Outrage",
            "Overheat",
            "Focus Blast",
            "Leaf Storm",
            "Hurricane",
            "Trick Room",
            "Bug Buzz",
            "Hyper Beam",
            "Brave Bird",
            "Flare Blitz",
            "Thunder",
            "Close Combat",
            "Solar Beam",
            "Draco Meteor",
            "Steel Beam",
            "Tera Blast"});
            this.tmBox.Location = new System.Drawing.Point(626, 108);
            this.tmBox.Name = "tmBox";
            this.tmBox.Size = new System.Drawing.Size(237, 486);
            this.tmBox.TabIndex = 2;
            this.tmBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tmBox_ItemCheck);
            // 
            // movesetGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.movesetGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.movesetGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.movesetGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.movesetGrid.ColumnHeadersHeight = 17;
            this.movesetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.movesetGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.movesetGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.movesetGrid.Location = new System.Drawing.Point(6, 103);
            this.movesetGrid.Name = "movesetGrid";
            this.movesetGrid.RowHeadersVisible = false;
            this.movesetGrid.RowTemplate.Height = 25;
            this.movesetGrid.Size = new System.Drawing.Size(614, 491);
            this.movesetGrid.TabIndex = 1;
            this.movesetGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.movesetGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.movesetGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.movesetGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.movesetGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.movesetGrid.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.movesetGrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.movesetGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.movesetGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.movesetGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.movesetGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.movesetGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.movesetGrid.ThemeStyle.HeaderStyle.Height = 17;
            this.movesetGrid.ThemeStyle.ReadOnly = false;
            this.movesetGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.movesetGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.movesetGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.movesetGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.movesetGrid.ThemeStyle.RowsStyle.Height = 25;
            this.movesetGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.movesetGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.movesetGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.movesetGrid_CellValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Akira Expanded", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(351, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 45);
            this.label4.TabIndex = 0;
            this.label4.Text = "TEXT";
            // 
            // evolutionPage
            // 
            this.evolutionPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.evolutionPage.Controls.Add(this.evoGrid);
            this.evolutionPage.Controls.Add(this.label5);
            this.evolutionPage.Location = new System.Drawing.Point(4, 4);
            this.evolutionPage.Name = "evolutionPage";
            this.evolutionPage.Size = new System.Drawing.Size(869, 602);
            this.evolutionPage.TabIndex = 2;
            this.evolutionPage.Text = "Evolutions";
            // 
            // evoGrid
            // 
            this.evoGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.evoGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.evoGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.evoGrid.ColumnHeadersHeight = 17;
            this.evoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.evoGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.evoGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.evoGrid.Location = new System.Drawing.Point(6, 103);
            this.evoGrid.Name = "evoGrid";
            this.evoGrid.RowHeadersVisible = false;
            this.evoGrid.RowTemplate.Height = 25;
            this.evoGrid.Size = new System.Drawing.Size(860, 491);
            this.evoGrid.TabIndex = 1;
            this.evoGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.evoGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.evoGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.evoGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.evoGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.evoGrid.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.evoGrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.evoGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.evoGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.evoGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.evoGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.evoGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.evoGrid.ThemeStyle.HeaderStyle.Height = 17;
            this.evoGrid.ThemeStyle.ReadOnly = false;
            this.evoGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.evoGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.evoGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.evoGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.evoGrid.ThemeStyle.RowsStyle.Height = 25;
            this.evoGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.evoGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.evoGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.evoGrid_CellEndEdit);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Akira Expanded", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(351, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 45);
            this.label5.TabIndex = 0;
            this.label5.Text = "TEXT";
            // 
            // PokeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PokeEditor";
            this.Text = "PROJECT SKY";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PokeEditor_FormClosing);
            this.panel1.ResumeLayout(false);
            this.tabPages.ResumeLayout(false);
            this.baseStatsPage.ResumeLayout(false);
            this.baseStatsPage.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hatchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendshipBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catchRateBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderRatioBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heldItemRateBox)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evSPA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evATK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evDEF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPE)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseSPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSPA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDEF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseATK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseHP)).EndInit();
            this.movesetPage.ResumeLayout(false);
            this.movesetPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movesetGrid)).EndInit();
            this.evolutionPage.ResumeLayout(false);
            this.evolutionPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evoGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Button returnButton;
        private Siticone.Desktop.UI.WinForms.SiticoneTabControl tabPages;
        private TabPage baseStatsPage;
        private TabPage movesetPage;
        private TabPage evolutionPage;
        private Label pokemonName;
        private SiticonePanel panel4;
        private SiticonePanel panel3;
        private SiticonePanel panel2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label12;
        private Label label13;
        private SiticoneNumericUpDown evSPA;
        private Label label14;
        private SiticoneNumericUpDown evHP;
        private Label label15;
        private SiticoneNumericUpDown evATK;
        private Label label16;
        private SiticoneNumericUpDown evDEF;
        private Label label17;
        private SiticoneNumericUpDown evSPD;
        private SiticoneNumericUpDown evSPE;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private SiticoneNumericUpDown baseSPE;
        private SiticoneNumericUpDown baseSPD;
        private SiticoneNumericUpDown baseSPA;
        private SiticoneNumericUpDown baseDEF;
        private SiticoneNumericUpDown baseATK;
        private SiticoneNumericUpDown baseHP;
        private ToolTip BSTtooltip;
        private SiticoneCheckBox presentCheck;
        private FlatComboBox typeBox2;
        private FlatComboBox typeBox1;
        private Label label18;
        private Label label25;
        private FlatComboBox xpBox;
        private Label label24;
        private Label ratioLabel;
        private SiticoneNumericUpDown genderRatioBox;
        private FlatComboBox genderBox;
        private Label percentLabel;
        private Label heldLabel;
        private SiticoneNumericUpDown heldItemRateBox;
        private FlatComboBox heldItemBox;
        private FlatComboBox eggBox2;
        private FlatComboBox eggBox1;
        private Label label20;
        private FlatComboBox abilityBox3;
        private FlatComboBox abilityBox2;
        private FlatComboBox abilityBox1;
        private Label label19;
        private Label labelfriend;
        private SiticoneNumericUpDown friendshipBox;
        private Label label26;
        private SiticoneNumericUpDown catchRateBox;
        private Label label27;
        private SiticoneNumericUpDown hatchBox;
        private CheckedListBox tmBox;
        private SiticoneDataGridView movesetGrid;
        private SiticoneDataGridView evoGrid;
    }
}