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
                    traitFocusNames,
                    exclude_trait,
                    default_trait,
                    include_trait,
                    exclude_champion,
                    default_champion,
                    include_champion
                );

                // Setup part 2
                Master = FirstRun();

                SetFromScoring(Master, no_error, limit_champions_cost_5, traitFocusNames, traitFocusValue, minTraits);

                Populate(Master);

                InformUtility(Master);

            }
            catch (Exception ex) { Print(ex); }
        }

        // Test
        private static void GenerateCombinationsThread()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

            int combinationLength = 8;
            GenerateCombinations(array, combinationLength);

            Print("done..");
        }

        public void CreateButton_Click(object sender, EventArgs e)
        {
            CreateButton.Enabled = false;

            Pet_SynergyBest = 10;
            Pet_PowerBest = -999;

            label14.Text = "Synergy: " + Pet_SynergyBest;

            if (traitFocusNames.Text != "NONE")
            {

                bool isThere = false;

                for (int i = 0; i < include_trait.Items.Count; i++)
                {
                    if (include_trait.Items[i] == traitFocusNames.Text) { isThere = true; break; }
                }

                if (!isThere)
                {
                    for (int q = 0; q < default_trait.Items.Count; q++)
                    {
                        if (default_trait.Items[q].ToString() == traitFocusNames.Text)
                        {
                            default_trait.SelectedItem = q;
                            default_trait.SelectedIndex = q;
                            moveData(default_trait.SelectedItem, default_trait, include_trait);
                            break;
                        }
                    }
                }
            }

            Thread t = new Thread(new ThreadStart(Creation))
            {
                IsBackground = true
            };
            t.Start();

        }


        public void Creation()
        {

            for (int k = 0; k < default_champion.Items.Count - 1; k++)
            {

                if (ForceStop)
                    CreateButton.Enabled = false;

                // Empty comp
                List<string> comp = new List<string>();

                // null comp check - will use the first champion in the default list
                if (comp.Count <= 0) { comp.Add(default_champion.Items[k].ToString()); }

                // setup comp with initial champions
                for (int i = 0; i < include_champion.Items.Count; i++)
                {
                    comp.Add(include_champion.Items[i].ToString());
                }


                // Get nodes
                List<string> nodes = GetNodes2(comp);

                //PrintComp(nodes);
                // Failsafe check
                if (nodes.Count < Convert.ToInt32(min_comp_size.Value)) { continue; }

                //PrintComp(nodes);

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


                int size = Convert.ToInt32(min_comp_size.Value); // The target size of the comp

                // Call the helper function with the empty defaultComp
                FindCombinations(nodes, size, new HashSet<string>(), new List<string>());

            }
            Print("done");

            System.Threading.Thread.Sleep(100);

            ForceStop = false;
            Utility.ForceStop = false;
            Scoring.ForceStop = false;

            CreateButton.Enabled = true;

            //ThreadsRunning--;

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

            compBox.Text = "";
        }

        private void linkBox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkBox.Text.Contains("tft"))
                System.Diagnostics.Process.Start(linkBox.Text);
        }

        private void FineTune_Click(object sender, EventArgs e)
        {
            List<List<string>> goodComps = new List<List<string>>();
            List<List<string>> badComps = new List<List<string>>();

            for (int i = 0; i < GoodCompsBox.Lines.Count(); i++)
            {
                goodComps.Add(GoodCompsBox.Lines[i].Split('-').ToList());
            }


            for (int i = 0; i < BadCompsBox.Lines.Count(); i++)
            {
                badComps.Add(BadCompsBox.Lines[i].Split('-').ToList());
            }



            FineTunePowerLevel(goodComps, badComps);

        }

        private void traitFocusNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (traitFocusNames.Text != "NONE")
            {
                traitFocusValue.Items.Clear();

                dynamic bp = Master["TraitList"][traitFocusNames.Text]["Breakpoints"];

                for (int i = 0; i < bp.Count; i++)
                {
                    traitFocusValue.Items.Add(bp[i].ToString());
                }

                traitFocusValue.SelectedIndex = 0;
            }
            else
            {

                traitFocusValue.Items.Clear();
            }
        }


        private void GetNodes2_Click(object sender, EventArgs e)
        {



        }
    }
}
