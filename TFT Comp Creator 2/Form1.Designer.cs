using static TFT_Comp_Creator_2.VisualForms;

namespace TFT_Comp_Creator_2
{
    partial class Form1
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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MenuTab = new System.Windows.Forms.TabControl();
            this.main = new System.Windows.Forms.TabPage();
            this.linkBox = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TLink = new System.Windows.Forms.Button();
            this.compBox = new System.Windows.Forms.TextBox();
            this.error = new System.Windows.Forms.Label();
            this.min_comp_size = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.incEx = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Trait_default_to_exclude = new System.Windows.Forms.Button();
            this.Trait_default_to_include = new System.Windows.Forms.Button();
            this.Trait_include_to_default = new System.Windows.Forms.Button();
            this.Trait_exclude_to_default = new System.Windows.Forms.Button();
            this.exclude_trait = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.default_trait = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.include_trait = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.champion_default_to_include = new System.Windows.Forms.Button();
            this.champion_include_to_default = new System.Windows.Forms.Button();
            this.champion_default_to_exclude = new System.Windows.Forms.Button();
            this.champion_exclude_to_default = new System.Windows.Forms.Button();
            this.exclude_champion = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.default_champion = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.include_champion = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.filtersTab = new System.Windows.Forms.TabPage();
            this.traitFocusValue = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.traitFocusNames = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.minTraits = new System.Windows.Forms.NumericUpDown();
            this.limit_champions_cost_5 = new System.Windows.Forms.CheckBox();
            this.no_error = new System.Windows.Forms.CheckBox();
            this.disable_champions_cost_5_more = new System.Windows.Forms.CheckBox();
            this.disable_champions_cost_5 = new System.Windows.Forms.CheckBox();
            this.disable_champions_cost_4 = new System.Windows.Forms.CheckBox();
            this.disable_champions_cost_3 = new System.Windows.Forms.CheckBox();
            this.disable_champions_cost_2 = new System.Windows.Forms.CheckBox();
            this.disable_champions_cost_1 = new System.Windows.Forms.CheckBox();
            this.quickActions = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.FineTune = new System.Windows.Forms.Button();
            this.BadCompsBox = new System.Windows.Forms.RichTextBox();
            this.GoodCompsBox = new System.Windows.Forms.RichTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ratio2_5 = new System.Windows.Forms.RadioButton();
            this.ratio2_4 = new System.Windows.Forms.RadioButton();
            this.ratio1_4 = new System.Windows.Forms.RadioButton();
            this.ratio1_3 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.RichTextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.MenuTab.SuspendLayout();
            this.main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.min_comp_size)).BeginInit();
            this.incEx.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.filtersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minTraits)).BeginInit();
            this.quickActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuTab
            // 
            this.MenuTab.Controls.Add(this.main);
            this.MenuTab.Controls.Add(this.incEx);
            this.MenuTab.Controls.Add(this.filtersTab);
            this.MenuTab.Controls.Add(this.quickActions);
            this.MenuTab.Location = new System.Drawing.Point(12, 12);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.SelectedIndex = 0;
            this.MenuTab.Size = new System.Drawing.Size(776, 248);
            this.MenuTab.TabIndex = 0;
            // 
            // main
            // 
            this.main.Controls.Add(this.linkBox);
            this.main.Controls.Add(this.label9);
            this.main.Controls.Add(this.label1);
            this.main.Controls.Add(this.TLink);
            this.main.Controls.Add(this.compBox);
            this.main.Controls.Add(this.error);
            this.main.Controls.Add(this.min_comp_size);
            this.main.Controls.Add(this.label5);
            this.main.Location = new System.Drawing.Point(4, 22);
            this.main.Name = "main";
            this.main.Padding = new System.Windows.Forms.Padding(3);
            this.main.Size = new System.Drawing.Size(768, 222);
            this.main.TabIndex = 0;
            this.main.Text = "Main";
            this.main.UseVisualStyleBackColor = true;
            // 
            // linkBox
            // 
            this.linkBox.AutoSize = true;
            this.linkBox.Location = new System.Drawing.Point(167, 179);
            this.linkBox.Name = "linkBox";
            this.linkBox.Size = new System.Drawing.Size(10, 13);
            this.linkBox.TabIndex = 32;
            this.linkBox.TabStop = true;
            this.linkBox.Text = "-";
            this.linkBox.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBox_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(134, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Link";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Paste Comp here";
            // 
            // TLink
            // 
            this.TLink.Location = new System.Drawing.Point(321, 144);
            this.TLink.Name = "TLink";
            this.TLink.Size = new System.Drawing.Size(90, 23);
            this.TLink.TabIndex = 29;
            this.TLink.Text = "Conver to link";
            this.TLink.UseVisualStyleBackColor = true;
            this.TLink.Click += new System.EventHandler(this.TLink_Click);
            // 
            // compBox
            // 
            this.compBox.Location = new System.Drawing.Point(134, 146);
            this.compBox.Name = "compBox";
            this.compBox.Size = new System.Drawing.Size(181, 20);
            this.compBox.TabIndex = 28;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(305, 2);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(0, 13);
            this.error.TabIndex = 21;
            // 
            // min_comp_size
            // 
            this.min_comp_size.Location = new System.Drawing.Point(134, 20);
            this.min_comp_size.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.min_comp_size.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.min_comp_size.Name = "min_comp_size";
            this.min_comp_size.Size = new System.Drawing.Size(120, 20);
            this.min_comp_size.TabIndex = 20;
            this.min_comp_size.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Comp size";
            // 
            // incEx
            // 
            this.incEx.Controls.Add(this.tabControl2);
            this.incEx.Location = new System.Drawing.Point(4, 22);
            this.incEx.Name = "incEx";
            this.incEx.Padding = new System.Windows.Forms.Padding(3);
            this.incEx.Size = new System.Drawing.Size(768, 222);
            this.incEx.TabIndex = 1;
            this.incEx.Text = "Include / Exclude";
            this.incEx.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(3, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(761, 212);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.Trait_default_to_exclude);
            this.tabPage4.Controls.Add(this.Trait_default_to_include);
            this.tabPage4.Controls.Add(this.Trait_include_to_default);
            this.tabPage4.Controls.Add(this.Trait_exclude_to_default);
            this.tabPage4.Controls.Add(this.exclude_trait);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.default_trait);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.include_trait);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(753, 186);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Traits";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Trait_default_to_exclude
            // 
            this.Trait_default_to_exclude.ForeColor = System.Drawing.Color.Red;
            this.Trait_default_to_exclude.Location = new System.Drawing.Point(215, 20);
            this.Trait_default_to_exclude.Name = "Trait_default_to_exclude";
            this.Trait_default_to_exclude.Size = new System.Drawing.Size(75, 23);
            this.Trait_default_to_exclude.TabIndex = 8;
            this.Trait_default_to_exclude.Text = "< ==";
            this.Trait_default_to_exclude.UseVisualStyleBackColor = true;
            this.Trait_default_to_exclude.Click += new System.EventHandler(this.Trait_default_to_exclude_Click);
            // 
            // Trait_default_to_include
            // 
            this.Trait_default_to_include.ForeColor = System.Drawing.Color.Red;
            this.Trait_default_to_include.Location = new System.Drawing.Point(476, 20);
            this.Trait_default_to_include.Name = "Trait_default_to_include";
            this.Trait_default_to_include.Size = new System.Drawing.Size(75, 23);
            this.Trait_default_to_include.TabIndex = 7;
            this.Trait_default_to_include.Text = "== >";
            this.Trait_default_to_include.UseVisualStyleBackColor = true;
            this.Trait_default_to_include.Click += new System.EventHandler(this.Trait_default_to_include_Click);
            // 
            // Trait_include_to_default
            // 
            this.Trait_include_to_default.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Trait_include_to_default.Location = new System.Drawing.Point(496, 49);
            this.Trait_include_to_default.Name = "Trait_include_to_default";
            this.Trait_include_to_default.Size = new System.Drawing.Size(75, 23);
            this.Trait_include_to_default.TabIndex = 6;
            this.Trait_include_to_default.Text = "< ==";
            this.Trait_include_to_default.UseVisualStyleBackColor = true;
            this.Trait_include_to_default.Click += new System.EventHandler(this.Trait_include_to_default_Click);
            // 
            // Trait_exclude_to_default
            // 
            this.Trait_exclude_to_default.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Trait_exclude_to_default.Location = new System.Drawing.Point(190, 49);
            this.Trait_exclude_to_default.Name = "Trait_exclude_to_default";
            this.Trait_exclude_to_default.Size = new System.Drawing.Size(75, 23);
            this.Trait_exclude_to_default.TabIndex = 3;
            this.Trait_exclude_to_default.Text = "== >";
            this.Trait_exclude_to_default.UseVisualStyleBackColor = true;
            this.Trait_exclude_to_default.Click += new System.EventHandler(this.Trait_exclude_to_default_Click);
            // 
            // exclude_trait
            // 
            this.exclude_trait.FormattingEnabled = true;
            this.exclude_trait.Location = new System.Drawing.Point(10, 20);
            this.exclude_trait.Name = "exclude_trait";
            this.exclude_trait.Size = new System.Drawing.Size(174, 160);
            this.exclude_trait.TabIndex = 0;
            this.exclude_trait.DoubleClick += new System.EventHandler(this.Trait_exclude_to_default_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(355, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Default";
            // 
            // default_trait
            // 
            this.default_trait.FormattingEnabled = true;
            this.default_trait.Location = new System.Drawing.Point(296, 20);
            this.default_trait.Name = "default_trait";
            this.default_trait.Size = new System.Drawing.Size(174, 160);
            this.default_trait.Sorted = true;
            this.default_trait.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(638, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Include";
            // 
            // include_trait
            // 
            this.include_trait.FormattingEnabled = true;
            this.include_trait.Location = new System.Drawing.Point(577, 20);
            this.include_trait.Name = "include_trait";
            this.include_trait.Size = new System.Drawing.Size(174, 160);
            this.include_trait.TabIndex = 2;
            this.include_trait.DoubleClick += new System.EventHandler(this.Trait_include_to_default_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Exclude";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.champion_default_to_include);
            this.tabPage5.Controls.Add(this.champion_include_to_default);
            this.tabPage5.Controls.Add(this.champion_default_to_exclude);
            this.tabPage5.Controls.Add(this.champion_exclude_to_default);
            this.tabPage5.Controls.Add(this.exclude_champion);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.default_champion);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.include_champion);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(753, 186);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Champions";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // champion_default_to_include
            // 
            this.champion_default_to_include.ForeColor = System.Drawing.Color.Red;
            this.champion_default_to_include.Location = new System.Drawing.Point(476, 20);
            this.champion_default_to_include.Name = "champion_default_to_include";
            this.champion_default_to_include.Size = new System.Drawing.Size(75, 23);
            this.champion_default_to_include.TabIndex = 15;
            this.champion_default_to_include.Text = "== >";
            this.champion_default_to_include.UseVisualStyleBackColor = true;
            this.champion_default_to_include.Click += new System.EventHandler(this.Champion_default_to_include_Click);
            // 
            // champion_include_to_default
            // 
            this.champion_include_to_default.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.champion_include_to_default.Location = new System.Drawing.Point(496, 49);
            this.champion_include_to_default.Name = "champion_include_to_default";
            this.champion_include_to_default.Size = new System.Drawing.Size(75, 23);
            this.champion_include_to_default.TabIndex = 14;
            this.champion_include_to_default.Text = "< ==";
            this.champion_include_to_default.UseVisualStyleBackColor = true;
            this.champion_include_to_default.Click += new System.EventHandler(this.Champion_include_to_default_Click);
            // 
            // champion_default_to_exclude
            // 
            this.champion_default_to_exclude.ForeColor = System.Drawing.Color.Red;
            this.champion_default_to_exclude.Location = new System.Drawing.Point(215, 20);
            this.champion_default_to_exclude.Name = "champion_default_to_exclude";
            this.champion_default_to_exclude.Size = new System.Drawing.Size(75, 23);
            this.champion_default_to_exclude.TabIndex = 13;
            this.champion_default_to_exclude.Text = "< ==";
            this.champion_default_to_exclude.UseVisualStyleBackColor = true;
            this.champion_default_to_exclude.Click += new System.EventHandler(this.Champion_default_to_exclude_Click);
            // 
            // champion_exclude_to_default
            // 
            this.champion_exclude_to_default.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.champion_exclude_to_default.Location = new System.Drawing.Point(190, 49);
            this.champion_exclude_to_default.Name = "champion_exclude_to_default";
            this.champion_exclude_to_default.Size = new System.Drawing.Size(75, 23);
            this.champion_exclude_to_default.TabIndex = 12;
            this.champion_exclude_to_default.Text = "== >";
            this.champion_exclude_to_default.UseVisualStyleBackColor = true;
            this.champion_exclude_to_default.Click += new System.EventHandler(this.Champion_exclude_to_default_Click);
            // 
            // exclude_champion
            // 
            this.exclude_champion.FormattingEnabled = true;
            this.exclude_champion.Location = new System.Drawing.Point(10, 20);
            this.exclude_champion.Name = "exclude_champion";
            this.exclude_champion.Size = new System.Drawing.Size(174, 160);
            this.exclude_champion.TabIndex = 6;
            this.exclude_champion.DoubleClick += new System.EventHandler(this.Champion_exclude_to_default_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(355, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Default";
            // 
            // default_champion
            // 
            this.default_champion.FormattingEnabled = true;
            this.default_champion.Location = new System.Drawing.Point(296, 20);
            this.default_champion.Name = "default_champion";
            this.default_champion.Size = new System.Drawing.Size(174, 160);
            this.default_champion.Sorted = true;
            this.default_champion.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(638, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Include";
            // 
            // include_champion
            // 
            this.include_champion.FormattingEnabled = true;
            this.include_champion.Location = new System.Drawing.Point(577, 20);
            this.include_champion.Name = "include_champion";
            this.include_champion.Size = new System.Drawing.Size(174, 160);
            this.include_champion.TabIndex = 8;
            this.include_champion.DoubleClick += new System.EventHandler(this.Champion_include_to_default_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(61, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Exclude";
            // 
            // filtersTab
            // 
            this.filtersTab.Controls.Add(this.traitFocusValue);
            this.filtersTab.Controls.Add(this.label18);
            this.filtersTab.Controls.Add(this.traitFocusNames);
            this.filtersTab.Controls.Add(this.label10);
            this.filtersTab.Controls.Add(this.minTraits);
            this.filtersTab.Controls.Add(this.limit_champions_cost_5);
            this.filtersTab.Controls.Add(this.no_error);
            this.filtersTab.Controls.Add(this.disable_champions_cost_5_more);
            this.filtersTab.Controls.Add(this.disable_champions_cost_5);
            this.filtersTab.Controls.Add(this.disable_champions_cost_4);
            this.filtersTab.Controls.Add(this.disable_champions_cost_3);
            this.filtersTab.Controls.Add(this.disable_champions_cost_2);
            this.filtersTab.Controls.Add(this.disable_champions_cost_1);
            this.filtersTab.Location = new System.Drawing.Point(4, 22);
            this.filtersTab.Name = "filtersTab";
            this.filtersTab.Size = new System.Drawing.Size(768, 222);
            this.filtersTab.TabIndex = 2;
            this.filtersTab.Text = "Filters";
            this.filtersTab.UseVisualStyleBackColor = true;
            // 
            // traitFocusValue
            // 
            this.traitFocusValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traitFocusValue.FormattingEnabled = true;
            this.traitFocusValue.Items.AddRange(new object[] {
            "NONE"});
            this.traitFocusValue.Location = new System.Drawing.Point(417, 43);
            this.traitFocusValue.Name = "traitFocusValue";
            this.traitFocusValue.Size = new System.Drawing.Size(121, 21);
            this.traitFocusValue.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(233, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Focus on";
            // 
            // traitFocusNames
            // 
            this.traitFocusNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traitFocusNames.FormattingEnabled = true;
            this.traitFocusNames.Items.AddRange(new object[] {
            "NONE"});
            this.traitFocusNames.Location = new System.Drawing.Point(290, 43);
            this.traitFocusNames.Name = "traitFocusNames";
            this.traitFocusNames.Size = new System.Drawing.Size(121, 21);
            this.traitFocusNames.TabIndex = 31;
            this.traitFocusNames.SelectedIndexChanged += new System.EventHandler(this.traitFocusNames_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(204, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Min active traits";
            // 
            // minTraits
            // 
            this.minTraits.Location = new System.Drawing.Point(291, 17);
            this.minTraits.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.minTraits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minTraits.Name = "minTraits";
            this.minTraits.Size = new System.Drawing.Size(120, 20);
            this.minTraits.TabIndex = 29;
            this.minTraits.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // limit_champions_cost_5
            // 
            this.limit_champions_cost_5.AutoSize = true;
            this.limit_champions_cost_5.Location = new System.Drawing.Point(170, 110);
            this.limit_champions_cost_5.Name = "limit_champions_cost_5";
            this.limit_champions_cost_5.Size = new System.Drawing.Size(154, 17);
            this.limit_champions_cost_5.TabIndex = 28;
            this.limit_champions_cost_5.Text = "Limit cost 5 champions to 1";
            this.limit_champions_cost_5.UseVisualStyleBackColor = true;
            // 
            // no_error
            // 
            this.no_error.AutoSize = true;
            this.no_error.Checked = true;
            this.no_error.CheckState = System.Windows.Forms.CheckState.Checked;
            this.no_error.Location = new System.Drawing.Point(14, 178);
            this.no_error.Name = "no_error";
            this.no_error.Size = new System.Drawing.Size(149, 17);
            this.no_error.TabIndex = 27;
            this.no_error.Text = "Disallow unbalanced traits";
            this.no_error.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_5_more
            // 
            this.disable_champions_cost_5_more.AutoSize = true;
            this.disable_champions_cost_5_more.Location = new System.Drawing.Point(14, 133);
            this.disable_champions_cost_5_more.Name = "disable_champions_cost_5_more";
            this.disable_champions_cost_5_more.Size = new System.Drawing.Size(153, 17);
            this.disable_champions_cost_5_more.TabIndex = 26;
            this.disable_champions_cost_5_more.Text = "Disable cost >5 champions";
            this.disable_champions_cost_5_more.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_5
            // 
            this.disable_champions_cost_5.AutoSize = true;
            this.disable_champions_cost_5.Location = new System.Drawing.Point(14, 110);
            this.disable_champions_cost_5.Name = "disable_champions_cost_5";
            this.disable_champions_cost_5.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_5.TabIndex = 25;
            this.disable_champions_cost_5.Text = "Disable cost 5 champions";
            this.disable_champions_cost_5.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_4
            // 
            this.disable_champions_cost_4.AutoSize = true;
            this.disable_champions_cost_4.Location = new System.Drawing.Point(14, 87);
            this.disable_champions_cost_4.Name = "disable_champions_cost_4";
            this.disable_champions_cost_4.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_4.TabIndex = 24;
            this.disable_champions_cost_4.Text = "Disable cost 4 champions";
            this.disable_champions_cost_4.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_3
            // 
            this.disable_champions_cost_3.AutoSize = true;
            this.disable_champions_cost_3.Location = new System.Drawing.Point(14, 64);
            this.disable_champions_cost_3.Name = "disable_champions_cost_3";
            this.disable_champions_cost_3.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_3.TabIndex = 23;
            this.disable_champions_cost_3.Text = "Disable cost 3 champions";
            this.disable_champions_cost_3.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_2
            // 
            this.disable_champions_cost_2.AutoSize = true;
            this.disable_champions_cost_2.Location = new System.Drawing.Point(14, 41);
            this.disable_champions_cost_2.Name = "disable_champions_cost_2";
            this.disable_champions_cost_2.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_2.TabIndex = 22;
            this.disable_champions_cost_2.Text = "Disable cost 2 champions";
            this.disable_champions_cost_2.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_1
            // 
            this.disable_champions_cost_1.AutoSize = true;
            this.disable_champions_cost_1.Location = new System.Drawing.Point(14, 18);
            this.disable_champions_cost_1.Name = "disable_champions_cost_1";
            this.disable_champions_cost_1.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_1.TabIndex = 21;
            this.disable_champions_cost_1.Text = "Disable cost 1 champions";
            this.disable_champions_cost_1.UseVisualStyleBackColor = true;
            // 
            // quickActions
            // 
            this.quickActions.Controls.Add(this.label17);
            this.quickActions.Controls.Add(this.label16);
            this.quickActions.Controls.Add(this.FineTune);
            this.quickActions.Controls.Add(this.BadCompsBox);
            this.quickActions.Controls.Add(this.GoodCompsBox);
            this.quickActions.Controls.Add(this.radioButton1);
            this.quickActions.Controls.Add(this.ratio2_5);
            this.quickActions.Controls.Add(this.ratio2_4);
            this.quickActions.Controls.Add(this.ratio1_4);
            this.quickActions.Controls.Add(this.ratio1_3);
            this.quickActions.Controls.Add(this.label11);
            this.quickActions.Location = new System.Drawing.Point(4, 22);
            this.quickActions.Name = "quickActions";
            this.quickActions.Padding = new System.Windows.Forms.Padding(3);
            this.quickActions.Size = new System.Drawing.Size(768, 222);
            this.quickActions.TabIndex = 3;
            this.quickActions.Text = "Quick Actions";
            this.quickActions.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(476, 140);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Bad comps";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(91, 137);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Good comps";
            // 
            // FineTune
            // 
            this.FineTune.Location = new System.Drawing.Point(285, 175);
            this.FineTune.Name = "FineTune";
            this.FineTune.Size = new System.Drawing.Size(75, 23);
            this.FineTune.TabIndex = 8;
            this.FineTune.Text = "FineTune";
            this.FineTune.UseVisualStyleBackColor = true;
            this.FineTune.Click += new System.EventHandler(this.FineTune_Click);
            // 
            // BadCompsBox
            // 
            this.BadCompsBox.Location = new System.Drawing.Point(366, 156);
            this.BadCompsBox.Name = "BadCompsBox";
            this.BadCompsBox.Size = new System.Drawing.Size(273, 60);
            this.BadCompsBox.TabIndex = 7;
            this.BadCompsBox.Text = resources.GetString("BadCompsBox.Text");
            // 
            // GoodCompsBox
            // 
            this.GoodCompsBox.Location = new System.Drawing.Point(6, 156);
            this.GoodCompsBox.Name = "GoodCompsBox";
            this.GoodCompsBox.Size = new System.Drawing.Size(273, 60);
            this.GoodCompsBox.TabIndex = 6;
            this.GoodCompsBox.Text = resources.GetString("GoodCompsBox.Text");
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(214, 35);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "2 - 5";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // ratio2_5
            // 
            this.ratio2_5.AutoSize = true;
            this.ratio2_5.Location = new System.Drawing.Point(162, 35);
            this.ratio2_5.Name = "ratio2_5";
            this.ratio2_5.Size = new System.Drawing.Size(46, 17);
            this.ratio2_5.TabIndex = 4;
            this.ratio2_5.TabStop = true;
            this.ratio2_5.Text = "2 - 5";
            this.ratio2_5.UseVisualStyleBackColor = true;
            // 
            // ratio2_4
            // 
            this.ratio2_4.AutoSize = true;
            this.ratio2_4.Location = new System.Drawing.Point(110, 35);
            this.ratio2_4.Name = "ratio2_4";
            this.ratio2_4.Size = new System.Drawing.Size(46, 17);
            this.ratio2_4.TabIndex = 3;
            this.ratio2_4.TabStop = true;
            this.ratio2_4.Text = "2 - 4";
            this.ratio2_4.UseVisualStyleBackColor = true;
            // 
            // ratio1_4
            // 
            this.ratio1_4.AutoSize = true;
            this.ratio1_4.Location = new System.Drawing.Point(58, 35);
            this.ratio1_4.Name = "ratio1_4";
            this.ratio1_4.Size = new System.Drawing.Size(46, 17);
            this.ratio1_4.TabIndex = 2;
            this.ratio1_4.TabStop = true;
            this.ratio1_4.Text = "1 - 4";
            this.ratio1_4.UseVisualStyleBackColor = true;
            // 
            // ratio1_3
            // 
            this.ratio1_3.AutoSize = true;
            this.ratio1_3.Location = new System.Drawing.Point(6, 35);
            this.ratio1_3.Name = "ratio1_3";
            this.ratio1_3.Size = new System.Drawing.Size(46, 17);
            this.ratio1_3.TabIndex = 1;
            this.ratio1_3.TabStop = true;
            this.ratio1_3.Text = "1 - 3";
            this.ratio1_3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(88, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Champion Levels";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(271, 263);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Best score: 0";
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 289);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(552, 149);
            this.output.TabIndex = 1;
            this.output.Text = "";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(570, 289);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(570, 318);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(570, 367);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.output);
            this.Controls.Add(this.MenuTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TFT Comp Creator";
            this.MenuTab.ResumeLayout(false);
            this.main.ResumeLayout(false);
            this.main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.min_comp_size)).EndInit();
            this.incEx.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.filtersTab.ResumeLayout(false);
            this.filtersTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minTraits)).EndInit();
            this.quickActions.ResumeLayout(false);
            this.quickActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MenuTab;
        private System.Windows.Forms.TabPage main;
        private System.Windows.Forms.TabPage incEx;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TabPage filtersTab;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.NumericUpDown min_comp_size;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button Trait_default_to_exclude;
        private System.Windows.Forms.Button Trait_default_to_include;
        private System.Windows.Forms.Button Trait_include_to_default;
        private System.Windows.Forms.Button Trait_exclude_to_default;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button champion_default_to_include;
        private System.Windows.Forms.Button champion_include_to_default;
        private System.Windows.Forms.Button champion_default_to_exclude;
        private System.Windows.Forms.Button champion_exclude_to_default;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.CheckBox no_error;
        public System.Windows.Forms.CheckBox disable_champions_cost_5_more;
        public System.Windows.Forms.CheckBox disable_champions_cost_5;
        public System.Windows.Forms.CheckBox disable_champions_cost_4;
        public System.Windows.Forms.CheckBox disable_champions_cost_3;
        public System.Windows.Forms.CheckBox disable_champions_cost_2;
        public System.Windows.Forms.CheckBox disable_champions_cost_1;
        public System.Windows.Forms.Button CreateButton;
        public System.Windows.Forms.RichTextBox output;
        public System.Windows.Forms.ListBox exclude_trait;
        public System.Windows.Forms.ListBox default_trait;
        public System.Windows.Forms.ListBox include_trait;
        public System.Windows.Forms.ListBox exclude_champion;
        public System.Windows.Forms.ListBox default_champion;
        public System.Windows.Forms.ListBox include_champion;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.CheckBox limit_champions_cost_5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TLink;
        private System.Windows.Forms.TextBox compBox;
        private System.Windows.Forms.LinkLabel linkBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown minTraits;
        private System.Windows.Forms.TabPage quickActions;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton ratio2_5;
        private System.Windows.Forms.RadioButton ratio2_4;
        private System.Windows.Forms.RadioButton ratio1_4;
        private System.Windows.Forms.RadioButton ratio1_3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.Button FineTune;
        public System.Windows.Forms.RichTextBox BadCompsBox;
        public System.Windows.Forms.RichTextBox GoodCompsBox;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.ComboBox traitFocusNames;
        public System.Windows.Forms.ComboBox traitFocusValue;
    }
}

