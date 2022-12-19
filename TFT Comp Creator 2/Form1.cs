using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static TFT_Comp_Creator_2.Scoring;
using static TFT_Comp_Creator_2.Setup;
using static TFT_Comp_Creator_2.Utility;
using static TFT_Comp_Creator_2.VisualForms;

namespace TFT_Comp_Creator_2
{

    public partial class Form1 : Form
    {
        public static string status;

        public dynamic Master = new JObject(
            new JProperty("Champions", new JObject()),
            new JProperty("TraitList", new JObject()),
            new JProperty("TraitChampions", new JObject()),
            new JProperty("Costs", new JObject(
                    new JProperty("1", new JArray()),
                    new JProperty("2", new JArray()),
                    new JProperty("3", new JArray()),
                    new JProperty("4", new JArray()),
                    new JProperty("5", new JArray())
                ))
        );

        HashSet<string> usedComps = new HashSet<string>();

        public bool ForceStop = false;

        public Form1()
        {
            InitializeComponent();


            try
            {
                // Setup part 1
                SetFormUtility(
                    output, targetNodes, label14,
                    limit_champions_cost_5,
                    disable_champions_cost_1,
                    disable_champions_cost_2,
                    disable_champions_cost_3,
                    disable_champions_cost_4,
                    disable_champions_cost_5,
                    disable_champions_cost_5_more,

                    exclude_trait,
                    default_trait,
                    include_trait,
                    exclude_champion,
                    default_champion,
                    include_champion
                    );

                SetFormSetup(
                    scoringAlgo,
                    addAlgorithm,
                    exclude_trait,
                    default_trait,
                    include_trait,
                    exclude_champion,
                    default_champion,
                    include_champion
                );

                // Setup part 2
                Master = FirstRun();

                SetFromScoring(Master, scoringAlgo, no_error, limit_champions_cost_5);

                Populate(Master);

                InformUtility(Master);

            }
            catch (Exception ex) { Print(ex); }
        }



        public void CreateButton_Click(object sender, EventArgs e)
        {
            Pet_SynergyBest = 0;

            label14.Text = "Synergy: " + Pet_SynergyBest;

            Thread t = new Thread(new ThreadStart(Creation))
            {
                IsBackground = true
            };
            t.Start();

        }


        public void Creation()
        {
            // Define random
            Random rnd = new Random();

            for (int k = 0; k < default_champion.Items.Count - 1; k++)
            {

                if (ForceStop)
                    CreateButton.Enabled = false;

                // Empty comp
                List<string> comp = new List<string>();

                // Fill missing slots with blank spots
                if (comp.Count() < min_comp_size.Value)
                {
                    while (comp.Count() < min_comp_size.Value)
                    {
                        comp.Add("");
                    }
                }

                // null comp check - will use the first champion in the default list
                if (comp[0] == "") { comp[0] = default_champion.Items[k].ToString(); }

                // Get nodes
                List<string> nodes = GetNodes(comp);

                // Failsafe check
                if (nodes.Count <= Convert.ToInt32(min_comp_size.Value) + 1) { continue; }

                // Fill blank spots
                int q = 0;
                for (int i = 0; i < comp.Count; i++)
                {
                    if (comp[i] == "")
                    {

                        if (comp.Contains(nodes[q])) // DEV NOTE: This does not check for nodes size, might cause out of bound crashes (in specific cases)
                            q++;

                        comp[i] = nodes[q];
                        q++;
                    }
                }


                switch (addAlgorithm.Text)
                {
                    case ("Random"):
                        for (int i = comp.Count(); i < min_comp_size.Value; i++)
                        {
                            int random = rnd.Next(0, default_champion.Items.Count);

                            if (!comp.Contains(default_champion.Items[random].ToString()))
                            {
                                comp.Add(default_champion.Items[random].ToString());
                            }
                        }
                        break;

                    case ("Pet"):

                        int size = Convert.ToInt32(min_comp_size.Value); // The target size of the comp

                        // Call the helper function with the empty defaultComp
                        FindCombinations(nodes, size, new HashSet<string>(), new List<string>());


                        break;

                    default:
                        break;

                }
            }
            Print("done");

            CreateButton.Enabled = true;

        }




        // Will move this stuff later
        private void Trait_default_to_exclude_Click(object sender, EventArgs e)
        {
            moveData(default_trait.SelectedItem, default_trait, exclude_trait);
        }
        private void Trait_exclude_to_default_Click(object sender, EventArgs e)
        {
            moveData(exclude_trait.SelectedItem, exclude_trait, default_trait);
        }
        private void Trait_default_to_include_Click(object sender, EventArgs e)
        {
            moveData(default_trait.SelectedItem, default_trait, include_trait);
        }
        private void Trait_include_to_default_Click(object sender, EventArgs e)
        {
            moveData(include_trait.SelectedItem, include_trait, default_trait);
        }
        private void Champion_default_to_exclude_Click(object sender, EventArgs e)
        {
            moveData(default_champion.SelectedItem, default_champion, exclude_champion);
        }
        private void Champion_exclude_to_default_Click(object sender, EventArgs e)
        {
            moveData(exclude_champion.SelectedItem, exclude_champion, default_champion);
        }
        private void Champion_default_to_include_Click(object sender, EventArgs e)
        {
            moveData(default_champion.SelectedItem, default_champion, include_champion);
        }
        private void Champion_include_to_default_Click(object sender, EventArgs e)
        {
            moveData(include_champion.SelectedItem, include_champion, default_champion);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            output.Text = "";

            PrintCompLink(new List<string> { "Taliyah", "Yuumi", "Syndra", "Ekko", "Rell", "KaiSa", "Nilah", "Lux" });
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ForceStop = true;
            Utility.ForceStop = true;
            Scoring.ForceStop = true;
        }

        private void TLink_Click(object sender, EventArgs e)
        {
            linkBox.Text = PrintCompLink(compBox.Text.Split('-').Select(x => x).ToList());
        }

        private void linkBox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(linkBox.Text.Contains("tft"))
                System.Diagnostics.Process.Start(linkBox.Text);
        }
    }
}
