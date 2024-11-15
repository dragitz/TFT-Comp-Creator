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
            this.bronze_traits = new System.Windows.Forms.CheckBox();
            this.min_upgrades_included = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.excludedComp = new System.Windows.Forms.TextBox();
            this.max_comp_cost = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.max_inactive_traits = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.score_reset = new System.Windows.Forms.CheckBox();
            this.champion_optimizer = new System.Windows.Forms.CheckBox();
            this.maxTraits = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.maxTank = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.minTank = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.trait_3_limiter = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.exclusion_allow_base_trait = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.maxRanged = new System.Windows.Forms.NumericUpDown();
            this.max_cost_5_amount = new System.Windows.Forms.NumericUpDown();
            this.max_cost_4_amount = new System.Windows.Forms.NumericUpDown();
            this.max_cost_3_amount = new System.Windows.Forms.NumericUpDown();
            this.max_cost_2_amount = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.max_cost_1_amount = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.minRanged = new System.Windows.Forms.NumericUpDown();
            this.depthLevel = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.minUpgrades = new System.Windows.Forms.NumericUpDown();
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
            this.debugComp = new System.Windows.Forms.Button();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.spatula_default_to_include = new System.Windows.Forms.Button();
            this.spatula_include_to_default = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.default_spatula = new System.Windows.Forms.ListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.include_spatula = new System.Windows.Forms.ListBox();
            this.setup = new System.Windows.Forms.TabPage();
            this.setList = new System.Windows.Forms.ComboBox();
            this.applySet = new System.Windows.Forms.Button();
            this.status_text = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.RichTextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.MenuTab.SuspendLayout();
            this.main.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.min_upgrades_included)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_comp_cost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_inactive_traits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTraits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trait_3_limiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRanged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_5_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_4_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_3_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_2_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_1_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRanged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minUpgrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_comp_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTraits)).BeginInit();
            this.tabOptimize.SuspendLayout();
            this.incEx.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.setup.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuTab
            // 
            this.MenuTab.Controls.Add(this.main);
            this.MenuTab.Controls.Add(this.incEx);
            this.MenuTab.Controls.Add(this.setup);
            this.MenuTab.Location = new System.Drawing.Point(12, 12);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.SelectedIndex = 0;
            this.MenuTab.Size = new System.Drawing.Size(905, 498);
            this.MenuTab.TabIndex = 0;
            // 
            // main
            // 
            this.main.Controls.Add(this.tabControl1);
            this.main.Controls.Add(this.error);
            this.main.Location = new System.Drawing.Point(4, 22);
            this.main.Name = "main";
            this.main.Padding = new System.Windows.Forms.Padding(3);
            this.main.Size = new System.Drawing.Size(897, 472);
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
            this.tabControl1.Size = new System.Drawing.Size(888, 464);
            this.tabControl1.TabIndex = 48;
            // 
            // tabRules
            // 
            this.tabRules.Controls.Add(this.bronze_traits);
            this.tabRules.Controls.Add(this.min_upgrades_included);
            this.tabRules.Controls.Add(this.label28);
            this.tabRules.Controls.Add(this.label27);
            this.tabRules.Controls.Add(this.excludedComp);
            this.tabRules.Controls.Add(this.max_comp_cost);
            this.tabRules.Controls.Add(this.label26);
            this.tabRules.Controls.Add(this.max_inactive_traits);
            this.tabRules.Controls.Add(this.label25);
            this.tabRules.Controls.Add(this.score_reset);
            this.tabRules.Controls.Add(this.champion_optimizer);
            this.tabRules.Controls.Add(this.maxTraits);
            this.tabRules.Controls.Add(this.label24);
            this.tabRules.Controls.Add(this.label14);
            this.tabRules.Controls.Add(this.label22);
            this.tabRules.Controls.Add(this.maxTank);
            this.tabRules.Controls.Add(this.label23);
            this.tabRules.Controls.Add(this.minTank);
            this.tabRules.Controls.Add(this.label21);
            this.tabRules.Controls.Add(this.trait_3_limiter);
            this.tabRules.Controls.Add(this.label20);
            this.tabRules.Controls.Add(this.exclusion_allow_base_trait);
            this.tabRules.Controls.Add(this.label17);
            this.tabRules.Controls.Add(this.maxRanged);
            this.tabRules.Controls.Add(this.max_cost_5_amount);
            this.tabRules.Controls.Add(this.max_cost_4_amount);
            this.tabRules.Controls.Add(this.max_cost_3_amount);
            this.tabRules.Controls.Add(this.max_cost_2_amount);
            this.tabRules.Controls.Add(this.label16);
            this.tabRules.Controls.Add(this.max_cost_1_amount);
            this.tabRules.Controls.Add(this.label15);
            this.tabRules.Controls.Add(this.minRanged);
            this.tabRules.Controls.Add(this.depthLevel);
            this.tabRules.Controls.Add(this.label13);
            this.tabRules.Controls.Add(this.minUpgrades);
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
            this.tabRules.Size = new System.Drawing.Size(880, 438);
            this.tabRules.TabIndex = 0;
            this.tabRules.Text = "Rules";
            this.tabRules.UseVisualStyleBackColor = true;
            this.tabRules.Click += new System.EventHandler(this.tabRules_Click);
            // 
            // bronze_traits
            // 
            this.bronze_traits.AutoSize = true;
            this.bronze_traits.Location = new System.Drawing.Point(589, 250);
            this.bronze_traits.Name = "bronze_traits";
            this.bronze_traits.Size = new System.Drawing.Size(140, 17);
            this.bronze_traits.TabIndex = 89;
            this.bronze_traits.Text = "Traits must all be bronze";
            this.bronze_traits.UseVisualStyleBackColor = true;
            // 
            // min_upgrades_included
            // 
            this.min_upgrades_included.Location = new System.Drawing.Point(317, 138);
            this.min_upgrades_included.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.min_upgrades_included.Name = "min_upgrades_included";
            this.min_upgrades_included.Size = new System.Drawing.Size(120, 20);
            this.min_upgrades_included.TabIndex = 87;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(224, 135);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(87, 26);
            this.label28.TabIndex = 88;
            this.label28.Text = "Min upgrades\r\non included traits";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(586, 384);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 13);
            this.label27.TabIndex = 86;
            this.label27.Text = "Exluded comp";
            // 
            // excludedComp
            // 
            this.excludedComp.Location = new System.Drawing.Point(589, 400);
            this.excludedComp.Name = "excludedComp";
            this.excludedComp.Size = new System.Drawing.Size(237, 20);
            this.excludedComp.TabIndex = 85;
            // 
            // max_comp_cost
            // 
            this.max_comp_cost.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.max_comp_cost.Location = new System.Drawing.Point(97, 248);
            this.max_comp_cost.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.max_comp_cost.Name = "max_comp_cost";
            this.max_comp_cost.Size = new System.Drawing.Size(120, 20);
            this.max_comp_cost.TabIndex = 83;
            this.max_comp_cost.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(28, 242);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 26);
            this.label26.TabIndex = 84;
            this.label26.Text = "Max comp\r\ncost";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // max_inactive_traits
            // 
            this.max_inactive_traits.Location = new System.Drawing.Point(97, 210);
            this.max_inactive_traits.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.max_inactive_traits.Name = "max_inactive_traits";
            this.max_inactive_traits.Size = new System.Drawing.Size(120, 20);
            this.max_inactive_traits.TabIndex = 81;
            this.max_inactive_traits.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(24, 208);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 26);
            this.label25.TabIndex = 82;
            this.label25.Text = "Max inactive\r\ntraits";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // score_reset
            // 
            this.score_reset.AutoSize = true;
            this.score_reset.Location = new System.Drawing.Point(607, 319);
            this.score_reset.Name = "score_reset";
            this.score_reset.Size = new System.Drawing.Size(145, 17);
            this.score_reset.TabIndex = 80;
            this.score_reset.Text = "Reset score for each trait";
            this.score_reset.UseVisualStyleBackColor = true;
            // 
            // champion_optimizer
            // 
            this.champion_optimizer.AutoSize = true;
            this.champion_optimizer.Location = new System.Drawing.Point(589, 296);
            this.champion_optimizer.Name = "champion_optimizer";
            this.champion_optimizer.Size = new System.Drawing.Size(69, 17);
            this.champion_optimizer.TabIndex = 78;
            this.champion_optimizer.Text = "Optimizer";
            this.champion_optimizer.UseVisualStyleBackColor = true;
            // 
            // maxTraits
            // 
            this.maxTraits.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.maxTraits.Location = new System.Drawing.Point(292, 173);
            this.maxTraits.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.maxTraits.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.maxTraits.Name = "maxTraits";
            this.maxTraits.Size = new System.Drawing.Size(120, 20);
            this.maxTraits.TabIndex = 76;
            this.maxTraits.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(223, 171);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 26);
            this.label24.TabIndex = 77;
            this.label24.Text = "Max active\r\ntraits";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(114, 345);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 75;
            this.label14.Text = "Atk. range <= 1";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(223, 363);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 13);
            this.label22.TabIndex = 74;
            this.label22.Text = "Max tank";
            // 
            // maxTank
            // 
            this.maxTank.Location = new System.Drawing.Point(292, 361);
            this.maxTank.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxTank.Name = "maxTank";
            this.maxTank.Size = new System.Drawing.Size(120, 20);
            this.maxTank.TabIndex = 73;
            this.maxTank.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(40, 363);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 13);
            this.label23.TabIndex = 72;
            this.label23.Text = "Min tank";
            // 
            // minTank
            // 
            this.minTank.Location = new System.Drawing.Point(97, 361);
            this.minTank.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minTank.Name = "minTank";
            this.minTank.Size = new System.Drawing.Size(120, 20);
            this.minTank.TabIndex = 71;
            this.minTank.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(114, 296);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 13);
            this.label21.TabIndex = 70;
            this.label21.Text = "Atk. range >= 4";
            // 
            // trait_3_limiter
            // 
            this.trait_3_limiter.Location = new System.Drawing.Point(97, 400);
            this.trait_3_limiter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trait_3_limiter.Name = "trait_3_limiter";
            this.trait_3_limiter.Size = new System.Drawing.Size(120, 20);
            this.trait_3_limiter.TabIndex = 69;
            this.trait_3_limiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trait_3_limiter.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 394);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 26);
            this.label20.TabIndex = 68;
            this.label20.Text = "Max champs \r\nwith 3 traits";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // exclusion_allow_base_trait
            // 
            this.exclusion_allow_base_trait.AutoSize = true;
            this.exclusion_allow_base_trait.Location = new System.Drawing.Point(589, 227);
            this.exclusion_allow_base_trait.Name = "exclusion_allow_base_trait";
            this.exclusion_allow_base_trait.Size = new System.Drawing.Size(239, 17);
            this.exclusion_allow_base_trait.TabIndex = 67;
            this.exclusion_allow_base_trait.Text = "Allow excluded traits to have the minimum BP";
            this.exclusion_allow_base_trait.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(223, 314);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 65;
            this.label17.Text = "Max ranged";
            // 
            // maxRanged
            // 
            this.maxRanged.Location = new System.Drawing.Point(292, 312);
            this.maxRanged.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxRanged.Name = "maxRanged";
            this.maxRanged.Size = new System.Drawing.Size(120, 20);
            this.maxRanged.TabIndex = 64;
            this.maxRanged.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // max_cost_5_amount
            // 
            this.max_cost_5_amount.Location = new System.Drawing.Point(747, 140);
            this.max_cost_5_amount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.max_cost_5_amount.Name = "max_cost_5_amount";
            this.max_cost_5_amount.Size = new System.Drawing.Size(120, 20);
            this.max_cost_5_amount.TabIndex = 63;
            this.max_cost_5_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.max_cost_5_amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // max_cost_4_amount
            // 
            this.max_cost_4_amount.Location = new System.Drawing.Point(747, 117);
            this.max_cost_4_amount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.max_cost_4_amount.Name = "max_cost_4_amount";
            this.max_cost_4_amount.Size = new System.Drawing.Size(120, 20);
            this.max_cost_4_amount.TabIndex = 62;
            this.max_cost_4_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.max_cost_4_amount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // max_cost_3_amount
            // 
            this.max_cost_3_amount.Location = new System.Drawing.Point(747, 94);
            this.max_cost_3_amount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.max_cost_3_amount.Name = "max_cost_3_amount";
            this.max_cost_3_amount.Size = new System.Drawing.Size(120, 20);
            this.max_cost_3_amount.TabIndex = 61;
            this.max_cost_3_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.max_cost_3_amount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // max_cost_2_amount
            // 
            this.max_cost_2_amount.Location = new System.Drawing.Point(747, 71);
            this.max_cost_2_amount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.max_cost_2_amount.Name = "max_cost_2_amount";
            this.max_cost_2_amount.Size = new System.Drawing.Size(120, 20);
            this.max_cost_2_amount.TabIndex = 60;
            this.max_cost_2_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.max_cost_2_amount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(802, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 59;
            this.label16.Text = "Max amount";
            // 
            // max_cost_1_amount
            // 
            this.max_cost_1_amount.Location = new System.Drawing.Point(747, 48);
            this.max_cost_1_amount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.max_cost_1_amount.Name = "max_cost_1_amount";
            this.max_cost_1_amount.Size = new System.Drawing.Size(120, 20);
            this.max_cost_1_amount.TabIndex = 58;
            this.max_cost_1_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.max_cost_1_amount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 314);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 57;
            this.label15.Text = "Min ranged";
            // 
            // minRanged
            // 
            this.minRanged.Location = new System.Drawing.Point(97, 312);
            this.minRanged.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minRanged.Name = "minRanged";
            this.minRanged.Size = new System.Drawing.Size(120, 20);
            this.minRanged.TabIndex = 56;
            this.minRanged.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // depthLevel
            // 
            this.depthLevel.Location = new System.Drawing.Point(97, 92);
            this.depthLevel.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.depthLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.depthLevel.Name = "depthLevel";
            this.depthLevel.Size = new System.Drawing.Size(120, 20);
            this.depthLevel.TabIndex = 54;
            this.depthLevel.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "Depth lvl.";
            // 
            // minUpgrades
            // 
            this.minUpgrades.Location = new System.Drawing.Point(97, 138);
            this.minUpgrades.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.minUpgrades.Name = "minUpgrades";
            this.minUpgrades.Size = new System.Drawing.Size(120, 20);
            this.minUpgrades.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Comp size";
            // 
            // no_error
            // 
            this.no_error.AutoSize = true;
            this.no_error.Checked = true;
            this.no_error.CheckState = System.Windows.Forms.CheckState.Checked;
            this.no_error.Location = new System.Drawing.Point(589, 187);
            this.no_error.Name = "no_error";
            this.no_error.Size = new System.Drawing.Size(149, 17);
            this.no_error.TabIndex = 46;
            this.no_error.Text = "Disallow unbalanced traits";
            this.no_error.UseVisualStyleBackColor = true;
            // 
            // min_comp_size
            // 
            this.min_comp_size.Location = new System.Drawing.Point(97, 30);
            this.min_comp_size.Maximum = new decimal(new int[] {
            11,
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
            9,
            0,
            0,
            0});
            // 
            // disable_champions_cost_5_more
            // 
            this.disable_champions_cost_5_more.AutoSize = true;
            this.disable_champions_cost_5_more.Checked = true;
            this.disable_champions_cost_5_more.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disable_champions_cost_5_more.Location = new System.Drawing.Point(589, 164);
            this.disable_champions_cost_5_more.Name = "disable_champions_cost_5_more";
            this.disable_champions_cost_5_more.Size = new System.Drawing.Size(153, 17);
            this.disable_champions_cost_5_more.TabIndex = 45;
            this.disable_champions_cost_5_more.Text = "Disable cost >5 champions";
            this.disable_champions_cost_5_more.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_5
            // 
            this.disable_champions_cost_5.AutoSize = true;
            this.disable_champions_cost_5.Location = new System.Drawing.Point(589, 141);
            this.disable_champions_cost_5.Name = "disable_champions_cost_5";
            this.disable_champions_cost_5.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_5.TabIndex = 44;
            this.disable_champions_cost_5.Text = "Disable cost 5 champions";
            this.disable_champions_cost_5.UseVisualStyleBackColor = true;
            // 
            // minTraits
            // 
            this.minTraits.Location = new System.Drawing.Point(97, 174);
            this.minTraits.Maximum = new decimal(new int[] {
            15,
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
            this.disable_champions_cost_4.Location = new System.Drawing.Point(589, 118);
            this.disable_champions_cost_4.Name = "disable_champions_cost_4";
            this.disable_champions_cost_4.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_4.TabIndex = 43;
            this.disable_champions_cost_4.Text = "Disable cost 4 champions";
            this.disable_champions_cost_4.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Min active traits";
            // 
            // disable_champions_cost_3
            // 
            this.disable_champions_cost_3.AutoSize = true;
            this.disable_champions_cost_3.Location = new System.Drawing.Point(589, 95);
            this.disable_champions_cost_3.Name = "disable_champions_cost_3";
            this.disable_champions_cost_3.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_3.TabIndex = 42;
            this.disable_champions_cost_3.Text = "Disable cost 3 champions";
            this.disable_champions_cost_3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Min upgrades";
            // 
            // disable_champions_cost_2
            // 
            this.disable_champions_cost_2.AutoSize = true;
            this.disable_champions_cost_2.Location = new System.Drawing.Point(589, 72);
            this.disable_champions_cost_2.Name = "disable_champions_cost_2";
            this.disable_champions_cost_2.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_2.TabIndex = 41;
            this.disable_champions_cost_2.Text = "Disable cost 2 champions";
            this.disable_champions_cost_2.UseVisualStyleBackColor = true;
            // 
            // disable_champions_cost_1
            // 
            this.disable_champions_cost_1.AutoSize = true;
            this.disable_champions_cost_1.Location = new System.Drawing.Point(589, 49);
            this.disable_champions_cost_1.Name = "disable_champions_cost_1";
            this.disable_champions_cost_1.Size = new System.Drawing.Size(147, 17);
            this.disable_champions_cost_1.TabIndex = 40;
            this.disable_champions_cost_1.Text = "Disable cost 1 champions";
            this.disable_champions_cost_1.UseVisualStyleBackColor = true;
            // 
            // tabOptimize
            // 
            this.tabOptimize.Controls.Add(this.debugComp);
            this.tabOptimize.Controls.Add(this.label11);
            this.tabOptimize.Controls.Add(this.label9);
            this.tabOptimize.Controls.Add(this.OptimizeComp);
            this.tabOptimize.Controls.Add(this.label1);
            this.tabOptimize.Controls.Add(this.compBox);
            this.tabOptimize.Location = new System.Drawing.Point(4, 22);
            this.tabOptimize.Name = "tabOptimize";
            this.tabOptimize.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptimize.Size = new System.Drawing.Size(880, 438);
            this.tabOptimize.TabIndex = 1;
            this.tabOptimize.Text = "Optimizer";
            this.tabOptimize.UseVisualStyleBackColor = true;
            // 
            // debugComp
            // 
            this.debugComp.Location = new System.Drawing.Point(226, 142);
            this.debugComp.Name = "debugComp";
            this.debugComp.Size = new System.Drawing.Size(75, 23);
            this.debugComp.TabIndex = 8;
            this.debugComp.Text = "debug";
            this.debugComp.UseVisualStyleBackColor = true;
            this.debugComp.Click += new System.EventHandler(this.debugComp_Click);
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
            this.incEx.Size = new System.Drawing.Size(897, 472);
            this.incEx.TabIndex = 1;
            this.incEx.Text = "Include / Exclude";
            this.incEx.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Location = new System.Drawing.Point(3, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(888, 293);
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
            this.tabPage4.Size = new System.Drawing.Size(880, 267);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Traits";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Trait_default_to_exclude
            // 
            this.Trait_default_to_exclude.ForeColor = System.Drawing.Color.Red;
            this.Trait_default_to_exclude.Location = new System.Drawing.Point(270, 43);
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
            this.Trait_default_to_include.Location = new System.Drawing.Point(538, 43);
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
            this.Trait_include_to_default.Location = new System.Drawing.Point(608, 72);
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
            this.Trait_exclude_to_default.Location = new System.Drawing.Point(199, 72);
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
            this.exclude_trait.Location = new System.Drawing.Point(19, 43);
            this.exclude_trait.Name = "exclude_trait";
            this.exclude_trait.Size = new System.Drawing.Size(174, 160);
            this.exclude_trait.TabIndex = 0;
            this.exclude_trait.DoubleClick += new System.EventHandler(this.Trait_exclude_to_default_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(429, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Default";
            // 
            // default_trait
            // 
            this.default_trait.FormattingEnabled = true;
            this.default_trait.Location = new System.Drawing.Point(355, 43);
            this.default_trait.Name = "default_trait";
            this.default_trait.Size = new System.Drawing.Size(174, 160);
            this.default_trait.Sorted = true;
            this.default_trait.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(754, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Include";
            // 
            // include_trait
            // 
            this.include_trait.FormattingEnabled = true;
            this.include_trait.Location = new System.Drawing.Point(689, 43);
            this.include_trait.Name = "include_trait";
            this.include_trait.Size = new System.Drawing.Size(174, 160);
            this.include_trait.TabIndex = 2;
            this.include_trait.DoubleClick += new System.EventHandler(this.Trait_include_to_default_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 19);
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
            this.tabPage5.Size = new System.Drawing.Size(880, 267);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Champions";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // champion_default_to_include
            // 
            this.champion_default_to_include.ForeColor = System.Drawing.Color.Red;
            this.champion_default_to_include.Location = new System.Drawing.Point(538, 43);
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
            this.champion_include_to_default.Location = new System.Drawing.Point(608, 72);
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
            this.champion_default_to_exclude.Location = new System.Drawing.Point(270, 43);
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
            this.champion_exclude_to_default.Location = new System.Drawing.Point(199, 72);
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
            this.exclude_champion.Location = new System.Drawing.Point(19, 43);
            this.exclude_champion.Name = "exclude_champion";
            this.exclude_champion.Size = new System.Drawing.Size(174, 160);
            this.exclude_champion.TabIndex = 6;
            this.exclude_champion.DoubleClick += new System.EventHandler(this.Champion_exclude_to_default_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(429, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Default";
            // 
            // default_champion
            // 
            this.default_champion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.default_champion.FormattingEnabled = true;
            this.default_champion.Location = new System.Drawing.Point(355, 43);
            this.default_champion.Name = "default_champion";
            this.default_champion.Size = new System.Drawing.Size(174, 160);
            this.default_champion.Sorted = true;
            this.default_champion.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(754, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Include";
            // 
            // include_champion
            // 
            this.include_champion.FormattingEnabled = true;
            this.include_champion.Location = new System.Drawing.Point(689, 43);
            this.include_champion.Name = "include_champion";
            this.include_champion.Size = new System.Drawing.Size(174, 160);
            this.include_champion.TabIndex = 8;
            this.include_champion.DoubleClick += new System.EventHandler(this.Champion_include_to_default_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(73, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Exclude";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.spatula_default_to_include);
            this.tabPage1.Controls.Add(this.spatula_include_to_default);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.default_spatula);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.include_spatula);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(880, 267);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Spatula (wip)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // spatula_default_to_include
            // 
            this.spatula_default_to_include.ForeColor = System.Drawing.Color.Red;
            this.spatula_default_to_include.Location = new System.Drawing.Point(483, 53);
            this.spatula_default_to_include.Name = "spatula_default_to_include";
            this.spatula_default_to_include.Size = new System.Drawing.Size(75, 23);
            this.spatula_default_to_include.TabIndex = 13;
            this.spatula_default_to_include.Text = "== >";
            this.spatula_default_to_include.UseVisualStyleBackColor = true;
            this.spatula_default_to_include.Click += new System.EventHandler(this.spatula_default_to_include_Click);
            // 
            // spatula_include_to_default
            // 
            this.spatula_include_to_default.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.spatula_include_to_default.Location = new System.Drawing.Point(553, 82);
            this.spatula_include_to_default.Name = "spatula_include_to_default";
            this.spatula_include_to_default.Size = new System.Drawing.Size(75, 23);
            this.spatula_include_to_default.TabIndex = 12;
            this.spatula_include_to_default.Text = "< ==";
            this.spatula_include_to_default.UseVisualStyleBackColor = true;
            this.spatula_include_to_default.Click += new System.EventHandler(this.spatula_include_to_default_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(374, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Default";
            // 
            // default_spatula
            // 
            this.default_spatula.FormattingEnabled = true;
            this.default_spatula.Location = new System.Drawing.Point(300, 53);
            this.default_spatula.Name = "default_spatula";
            this.default_spatula.Size = new System.Drawing.Size(174, 160);
            this.default_spatula.Sorted = true;
            this.default_spatula.TabIndex = 8;
            this.default_spatula.DoubleClick += new System.EventHandler(this.spatula_default_to_include_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(699, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Include";
            // 
            // include_spatula
            // 
            this.include_spatula.FormattingEnabled = true;
            this.include_spatula.Location = new System.Drawing.Point(634, 53);
            this.include_spatula.Name = "include_spatula";
            this.include_spatula.Size = new System.Drawing.Size(174, 160);
            this.include_spatula.TabIndex = 9;
            this.include_spatula.DoubleClick += new System.EventHandler(this.spatula_include_to_default_Click);
            // 
            // setup
            // 
            this.setup.Controls.Add(this.setList);
            this.setup.Controls.Add(this.applySet);
            this.setup.Location = new System.Drawing.Point(4, 22);
            this.setup.Name = "setup";
            this.setup.Size = new System.Drawing.Size(897, 472);
            this.setup.TabIndex = 2;
            this.setup.Text = "Setup";
            this.setup.UseVisualStyleBackColor = true;
            // 
            // setList
            // 
            this.setList.FormattingEnabled = true;
            this.setList.Location = new System.Drawing.Point(103, 61);
            this.setList.Name = "setList";
            this.setList.Size = new System.Drawing.Size(121, 21);
            this.setList.TabIndex = 1;
            // 
            // applySet
            // 
            this.applySet.Location = new System.Drawing.Point(230, 61);
            this.applySet.Name = "applySet";
            this.applySet.Size = new System.Drawing.Size(75, 23);
            this.applySet.TabIndex = 0;
            this.applySet.Text = "Change set";
            this.applySet.UseVisualStyleBackColor = true;
            this.applySet.Click += new System.EventHandler(this.applySet_Click);
            // 
            // status_text
            // 
            this.status_text.AutoSize = true;
            this.status_text.Location = new System.Drawing.Point(828, 629);
            this.status_text.Name = "status_text";
            this.status_text.Size = new System.Drawing.Size(69, 13);
            this.status_text.TabIndex = 28;
            this.status_text.Text = "Best score: 0";
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.Menu;
            this.output.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.output.Location = new System.Drawing.Point(12, 516);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(810, 235);
            this.output.TabIndex = 1;
            this.output.Text = "";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(828, 516);
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
            this.StopButton.Location = new System.Drawing.Point(828, 545);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(828, 594);
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
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(918, 763);
            this.Controls.Add(this.status_text);
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
            ((System.ComponentModel.ISupportInitialize)(this.min_upgrades_included)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_comp_cost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_inactive_traits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTraits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trait_3_limiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRanged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_5_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_4_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_3_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_2_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_cost_1_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRanged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthLevel)).EndInit();
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.setup.ResumeLayout(false);
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
        public System.Windows.Forms.Label status_text;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOptimize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button OptimizeComp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox compBox;
        private System.Windows.Forms.TabPage tabRules;
        private System.Windows.Forms.NumericUpDown minUpgrades;
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
        private System.Windows.Forms.NumericUpDown depthLevel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown minRanged;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown max_cost_1_amount;
        private System.Windows.Forms.NumericUpDown max_cost_5_amount;
        private System.Windows.Forms.NumericUpDown max_cost_4_amount;
        private System.Windows.Forms.NumericUpDown max_cost_3_amount;
        private System.Windows.Forms.NumericUpDown max_cost_2_amount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown maxRanged;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button spatula_default_to_include;
        private System.Windows.Forms.Button spatula_include_to_default;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.ListBox default_spatula;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.ListBox include_spatula;
        public System.Windows.Forms.CheckBox exclusion_allow_base_trait;
        private System.Windows.Forms.NumericUpDown trait_3_limiter;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown maxTank;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown minTank;
        private System.Windows.Forms.NumericUpDown maxTraits;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.CheckBox champion_optimizer;
        public System.Windows.Forms.CheckBox score_reset;
        private System.Windows.Forms.NumericUpDown max_inactive_traits;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown max_comp_cost;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TabPage setup;
        private System.Windows.Forms.ComboBox setList;
        private System.Windows.Forms.Button applySet;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox excludedComp;
        private System.Windows.Forms.NumericUpDown min_upgrades_included;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button debugComp;
        public System.Windows.Forms.CheckBox bronze_traits;
    }
}

