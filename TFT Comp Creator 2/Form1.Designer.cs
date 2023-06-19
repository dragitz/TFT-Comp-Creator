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
            this.MenuTab = new System.Windows.Forms.TabControl();
            this.main = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRules = new System.Windows.Forms.TabPage();
            this.minUpgrades = new System.Windows.Forms.NumericUpDown();
            this.limit_champions_cost_5 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.no_error = new System.Windows.Forms.CheckBox();
            this.min_comp_size = new System.Windows.Forms.NumericUpDown();
            this.disable_champions_cost_5_more = new System.Windows.Forms.CheckBox();
            this.disable_champions_cost_5 = new System.Windows.Forms.CheckBox();
            this.minTraits = new System.Windows.Forms.NumericUpDown();
            this.disable_champions_cost_4 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.disable_champions_cost_3 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.disable_champions_cost_2 = new System.Windows.Forms.CheckBox();
            this.disable_champions_cost_1 = new System.Windows.Forms.CheckBox();
            this.tabOptimize = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.OptimizeComp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.compBox = new System.Windows.Forms.TextBox();
            this.error = new System.Windows.Forms.Label();
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
            this.label14 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.RichTextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.MenuTab.SuspendLayout();
            this.main.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minUpgrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_comp_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTraits)).BeginInit();
            this.tabOptimize.SuspendLayout();
            this.incEx.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuTab
            // 
            this.MenuTab.Controls.Add(this.main);
            this.MenuTab.Controls.Add(this.incEx);
            this.MenuTab.Location = new System.Drawing.Point(12, 12);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.SelectedIndex = 0;
            this.MenuTab.Size = new System.Drawing.Size(776, 248);
            this.MenuTab.TabIndex = 0;
            // 
            // main
            // 
            this.main.Controls.Add(this.tabControl1);
            this.main.Controls.Add(this.error);
            this.main.Location = new System.Drawing.Point(4, 22);
            this.main.Name = "main";
            this.main.Padding = new System.Windows.Forms.Padding(3);
            this.main.Size = new System.Drawing.Size(768, 222);
            this.main.TabIndex = 0;
            this.main.Text = "Main";
            this.main.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRules);
            this.tabControl1.Controls.Add(this.tabOptimize);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(762, 210);
            this.tabControl1.TabIndex = 48;
            // 
            // tabRules
            // 
            this.tabRules.Controls.Add(this.minUpgrades);
            this.tabRules.Controls.Add(this.limit_champions_cost_5);
            this.tabRules.Controls.Add(this.label5);
            this.tabRules.Controls.Add(this.no_error);
            this.tabRules.Controls.Add(this.min_comp_size);
            this.tabRules.Controls.Add(this.disable_champions_cost_5_more);
            this.tabRules.Controls.Add(this.disable_champions_cost_5);
            this.tabRules.Controls.Add(this.minTraits);
            this.tabRules.Controls.Add(this.disable_champions_cost_4);
            this.tabRules.Controls.Add(this.label10);
            this.tabRules.Controls.Add(this.disable_champions_cost_3);
            this.tabRules.Controls.Add(this.label12);
            this.tabRules.Controls.Add(this.disable_champions_cost_2);
            this.tabRules.Controls.Add(this.disable_champions_cost_1);
            this.tabRules.Location = new System.Drawing.Point(4, 22);
            this.tabRules.Name = "tabRules";
            this.tabRules.Padding = new System.Windows.Forms.Padding(3);
            this.tabRules.Size = new System.Drawing.Size(754, 184);
            this.tabRules.TabIndex = 0;
            this.tabRules.Text = "Rules";
            this.tabRules.UseVisualStyleBackColor = true;
            // 
            // minUpgrades
            // 
            this.minUpgrades.Location = new System.Drawing.Point(99, 74);
            this.minUpgrades.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.minUpgrades.Name = "minUpgrades";
            this.minUpgrades.Size = new System.Drawing.Size(120, 20);
            this.minUpgrades.TabIndex = 38;
            // 
            // limit_champions_cost_5
            // 
            this.limit_champions_cost_5.AutoSize = true;
            this.limit_champions_cost_5.Checked = true;
            this.limit_champions_cost_5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.limit_champions_cost_5.Location = new System.Drawing.Point(560, 103);
            this.limit_champions_cost_5.Name = "limit_champions_cost_5";
            this.limit_champions_cost_5.Size = new System.Drawing.Size(154, 17);
            this.limit_champions_cost_5.TabIndex = 47;
            this.limit_champions_cost_5.Text = "Limit cost 5 champions to 1";
            this.limit_champions_cost_5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Comp size";
            // 
            // no_error
            // 
            this.no_error.AutoSize = true;
            this.no_error.Location = new System.Drawing.Point(404, 149);
            this.no_error.Name = "no_error";
            this.no_error.Size = new System.Drawing.Size(149, 17);
            this.no_error.TabIndex = 46;
            this.no_error.Text = "Disallow unbalanced traits";
            this.no_error.UseVisualStyleBackColor = true;
            // 
            // min_comp_size
            // 
            this.min_comp_size.Location = new System.Drawing.Point(99, 13);
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
            // disable_champions_cost_5_more
            // 
            this.disable_champions_cost_5_more.AutoSize = true;
            this.disable_champions_cost_5_more.Checked = true;
            this.disable_champions_cost_5_more.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disable_champions_cost_5_more.Location = new System.Drawing.Point(404, 126);
            this.disable_champions_cost_5_more.Name = "disable_champions_cost_5_more";
            this.disable_champions_cost_5_more.Size = new System.Drawing.Size(153, 17);
            this.disable_champions_cost_5_more.TabIndex = 45;
            this.disable_champions_cost_5_more.Text = "Disable cost >5 champions";
            this.disable_champions_cost_5_more.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_5
            // 
            this.disable_champions_cost_5.AutoSize = true;
            this.disable_champions_cost_5.Location = new System.Drawing.Point(404, 103);
            this.disable_champions_cost_5.Name = "disable_champions_cost_5";
            this.disable_champions_cost_5.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_5.TabIndex = 44;
            this.disable_champions_cost_5.Text = "Disable cost 5 champions";
            this.disable_champions_cost_5.UseVisualStyleBackColor = true;
            // 
            // minTraits
            // 
            this.minTraits.Location = new System.Drawing.Point(99, 48);
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
            this.minTraits.TabIndex = 36;
            this.minTraits.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // disable_champions_cost_4
            // 
            this.disable_champions_cost_4.AutoSize = true;
            this.disable_champions_cost_4.Location = new System.Drawing.Point(404, 80);
            this.disable_champions_cost_4.Name = "disable_champions_cost_4";
            this.disable_champions_cost_4.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_4.TabIndex = 43;
            this.disable_champions_cost_4.Text = "Disable cost 4 champions";
            this.disable_champions_cost_4.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Min active traits";
            // 
            // disable_champions_cost_3
            // 
            this.disable_champions_cost_3.AutoSize = true;
            this.disable_champions_cost_3.Location = new System.Drawing.Point(404, 57);
            this.disable_champions_cost_3.Name = "disable_champions_cost_3";
            this.disable_champions_cost_3.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_3.TabIndex = 42;
            this.disable_champions_cost_3.Text = "Disable cost 3 champions";
            this.disable_champions_cost_3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Min upgrades";
            // 
            // disable_champions_cost_2
            // 
            this.disable_champions_cost_2.AutoSize = true;
            this.disable_champions_cost_2.Location = new System.Drawing.Point(404, 34);
            this.disable_champions_cost_2.Name = "disable_champions_cost_2";
            this.disable_champions_cost_2.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_2.TabIndex = 41;
            this.disable_champions_cost_2.Text = "Disable cost 2 champions";
            this.disable_champions_cost_2.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_1
            // 
            this.disable_champions_cost_1.AutoSize = true;
            this.disable_champions_cost_1.Location = new System.Drawing.Point(404, 11);
            this.disable_champions_cost_1.Name = "disable_champions_cost_1";
            this.disable_champions_cost_1.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_1.TabIndex = 40;
            this.disable_champions_cost_1.Text = "Disable cost 1 champions";
            this.disable_champions_cost_1.UseVisualStyleBackColor = true;
            // 
            // tabOptimize
            // 
            this.tabOptimize.Controls.Add(this.label11);
            this.tabOptimize.Controls.Add(this.label9);
            this.tabOptimize.Controls.Add(this.OptimizeComp);
            this.tabOptimize.Controls.Add(this.label1);
            this.tabOptimize.Controls.Add(this.compBox);
            this.tabOptimize.Location = new System.Drawing.Point(4, 22);
            this.tabOptimize.Name = "tabOptimize";
            this.tabOptimize.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptimize.Size = new System.Drawing.Size(754, 184);
            this.tabOptimize.TabIndex = 1;
            this.tabOptimize.Text = "Optimizer";
            this.tabOptimize.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(190, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Note: Include / Exclude rules still apply";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(361, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "This tool will try to optimize the inserted comp by bruteforcing all champions.";
            // 
            // OptimizeComp
            // 
            this.OptimizeComp.Location = new System.Drawing.Point(19, 142);
            this.OptimizeComp.Name = "OptimizeComp";
            this.OptimizeComp.Size = new System.Drawing.Size(75, 23);
            this.OptimizeComp.TabIndex = 5;
            this.OptimizeComp.Text = "Optimize";
            this.OptimizeComp.UseVisualStyleBackColor = true;
            this.OptimizeComp.Click += new System.EventHandler(this.OptimizeComp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Paste comp here";
            // 
            // compBox
            // 
            this.compBox.Location = new System.Drawing.Point(19, 116);
            this.compBox.Name = "compBox";
            this.compBox.Size = new System.Drawing.Size(282, 20);
            this.compBox.TabIndex = 3;
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
            this.StopButton.Enabled = false;
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
            this.tabControl1.ResumeLayout(false);
            this.tabRules.ResumeLayout(false);
            this.tabRules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minUpgrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_comp_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTraits)).EndInit();
            this.tabOptimize.ResumeLayout(false);
            this.tabOptimize.PerformLayout();
            this.incEx.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MenuTab;
        private System.Windows.Forms.TabPage main;
        private System.Windows.Forms.TabPage incEx;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label error;
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
        public System.Windows.Forms.Button CreateButton;
        public System.Windows.Forms.RichTextBox output;
        public System.Windows.Forms.ListBox exclude_trait;
        public System.Windows.Forms.ListBox default_trait;
        public System.Windows.Forms.ListBox include_trait;
        public System.Windows.Forms.ListBox exclude_champion;
        public System.Windows.Forms.ListBox default_champion;
        public System.Windows.Forms.ListBox include_champion;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOptimize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button OptimizeComp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox compBox;
        private System.Windows.Forms.TabPage tabRules;
        private System.Windows.Forms.NumericUpDown minUpgrades;
        public System.Windows.Forms.CheckBox limit_champions_cost_5;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox no_error;
        private System.Windows.Forms.NumericUpDown min_comp_size;
        public System.Windows.Forms.CheckBox disable_champions_cost_5_more;
        public System.Windows.Forms.CheckBox disable_champions_cost_5;
        private System.Windows.Forms.NumericUpDown minTraits;
        public System.Windows.Forms.CheckBox disable_champions_cost_4;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.CheckBox disable_champions_cost_3;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.CheckBox disable_champions_cost_2;
        public System.Windows.Forms.CheckBox disable_champions_cost_1;
    }
}

