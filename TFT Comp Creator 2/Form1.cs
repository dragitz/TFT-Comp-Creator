using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static TFT_Comp_Creator_2.Nodes;
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

        public static HashSet<string> hashmap = new HashSet<string>();

        public bool ForceStop = false;

        public Form1()
        {
            InitializeComponent();


            try
            {
                // Setup part 1
                SetFormUtility(
                    output, targetNodes, label14,
                    max_cost_5_amount,
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
                    exclude_trait,
                    default_trait,
                    include_trait,
                    exclude_champion,
                    default_champion,
                    include_champion,
                    default_spatula,
                    include_spatula
                );

                // Setup part 2
                Master = FirstRun();

                SetFromScoring(
                    Master,
                    no_error,
                    exclusion_allow_base_trait,
                    max_cost_5_amount,
                    max_cost_4_amount,
                    max_cost_3_amount,
                    max_cost_2_amount,
                    max_cost_1_amount,
                    minTraits,
                    minUpgrades,
                    minRanged,
                    maxRanged,
                    trait_3_limiter,
                    include_spatula
                );

                SetNodes(
                    Master,
                    max_cost_5_amount,
                    disable_champions_cost_1,
                    disable_champions_cost_2,
                    disable_champions_cost_3,
                    disable_champions_cost_4,
                    disable_champions_cost_5,
                    disable_champions_cost_5_more,

                    exclude_trait
                    );

                Populate(Master);

                InformUtility(Master);

            }
            catch (Exception ex) { Print(ex); }
        }


        private void bruteForce_Click(object sender, EventArgs e)
        {
            bruteForce.Enabled = false;
            StopButton.Enabled = true;

            Pet_SynergyBest = 1;
            Pet_PowerBest = -999;

            label14.Text = "Synergy: " + Pet_SynergyBest;


            Thread t = new Thread(new ThreadStart(BruteCreation))
            {
                IsBackground = true
            };
            t.Start();


        }
        public void BruteCreation()
        {
            List<string> comp = new List<string>();
            List<string> nodes = new List<string>();

            for (int i = 0; i < default_champion.Items.Count; i++)
            {
                nodes.Add(default_champion.Items[i].ToString());
            }
            for (int i = 0; i < include_champion.Items.Count; i++)
            {
                nodes.Add(include_champion.Items[i].ToString());
            }

            int size = Convert.ToInt32(min_comp_size.Value); // The target size of the comp

            // Call the helper function with the empty defaultComp
            //FindCombinations(nodes, size, hashmap, comp);
            FindCombinations2(size, nodes);

            Print("done");

            ForceStop = false;
            Utility.ForceStop = false;
            Scoring.ForceStop = false;

            StopButton.Enabled = false;
            bruteForce.Enabled = true;

            hashmap.Clear();
        }

        public void CreateButton_Click(object sender, EventArgs e)
        {

            CreateButton.Enabled = false;
            StopButton.Enabled = true;

            Pet_SynergyBest = 1;
            Pet_PowerBest = -999;

            label14.Text = "Synergy: " + Pet_SynergyBest;

            Thread t = new Thread(new ThreadStart(Creation))
            {
                IsBackground = true
            };
            t.Start();

        }


        public void Creation()
        {

            // Empty comp
            List<string> comp = new List<string>();

            List<string> nodes = new List<string>();

            for (int k = 0; k < default_trait.Items.Count - 1; k++)
            {
                if (ForceStop)
                {
                    CreateButton.Enabled = false;
                    break;
                }


                // Reset
                comp.Clear();
                nodes.Clear();


                // Add champion preference
                for (int i = 0; i < include_champion.Items.Count; i++)
                {
                    comp.Add(include_champion.Items[i].ToString());

                    foreach (string trait in GetTraitsFromChampion(include_champion.Items[i].ToString()))
                    {
                        List<string> champs = GetChampionsFromTrait(trait);
                        nodes = nodes.Union(champs).ToList();
                    }
                }

                // Include champions from traits
                for (int i = 0; i < include_trait.Items.Count; i++)
                {
                    foreach (string champion in GetChampionsFromTrait(include_trait.Items[i].ToString()))
                    {
                        if (!nodes.Contains(champion) && !comp.Contains(champion))
                            nodes.Add(champion);
                    }
                }


                // Include champions from list of default traits as extra nodes
                foreach (string champion in GetChampionsFromTrait(default_trait.Items[k].ToString()))
                {
                    if (quick_discovery.Checked)
                        break;

                    if (!nodes.Contains(champion) && !comp.Contains(champion))
                        nodes.Add(champion);
                }

                // Failsafe check
                if (nodes.Count < Convert.ToInt32(min_comp_size.Value))
                {
                    List<string> Top3 = GetTopTraits(nodes, Convert.ToInt32(depthLevel.Value));
                    for (int q = 0; q < Top3.Count; q++)
                    {
                        foreach (string champion in GetChampionsFromTrait(Top3[q]))
                        {
                            if (!nodes.Contains(champion) && !comp.Contains(champion))
                                nodes.Add(champion);
                        }
                    }

                    //File.WriteAllText("nodes_debug.txt", String.Join("-", nodes.OrderBy(x => x).ToList()));
                }


                if (nodes.Count < Convert.ToInt32(min_comp_size.Value)) { continue; }


                int size = Convert.ToInt32(min_comp_size.Value); // The target size of the comp

                // Call the helper function with the empty defaultComp
                //FindCombinations(nodes, size, hashmap, comp);
                FindCombinations2(size, nodes);

                if (quick_discovery.Checked)
                    break;

            }
            Print("done");

            System.Threading.Thread.Sleep(100);

            ForceStop = false;
            Utility.ForceStop = false;
            Scoring.ForceStop = false;

            CreateButton.Enabled = true;
            StopButton.Enabled = false;

            //ThreadsRunning--;

            hashmap.Clear();

        }



        // Traits
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
        // Champions
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
        // Spatula
        private void spatula_default_to_include_Click(object sender, EventArgs e)
        {
            moveData(default_spatula.SelectedItem, default_spatula, include_spatula);
        }

        private void spatula_include_to_default_Click(object sender, EventArgs e)
        {
            moveData(include_spatula.SelectedItem, include_spatula, default_spatula);
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

        private void OptimizeComp_Click(object sender, EventArgs e)
        {
            if (compBox.Text.Length < 1)
                return;

            List<string> comp = compBox.Text.Split('-').ToList();
            List<string> Optimizedcomp = new List<string>(comp);

            int score = CalculateSynergy(comp);
            int possibleBest = score;

            Print("initial score: " + score);
            // Create our list of champions based on the remainign list of available champions
            List<string> championList = new List<string>();
            foreach (var item in default_champion.Items)
            {
                if (!comp.Contains(item.ToString())) { championList.Add(item.ToString()); }
            }


            for (int q = 0; q < comp.Count; q++)
            {
                // Ignore champions we want in the comp
                if (include_champion.Items.Contains(comp[q])) { continue; }

                List<string> tempComp = new List<string>(comp);

                for (int i = 0; i < championList.Count; i++)
                {
                    if (tempComp.Contains(championList[i])) { continue; } // weird bug happens if I don't add this. 19 june 2023

                    tempComp[q] = championList[i];

                    // ensure validity
                    if (CheckCompValidity(tempComp))
                    {
                        possibleBest = CalculateSynergy(tempComp);

                        if (possibleBest >= score - 2)
                        {
                            Print("[+] " + possibleBest + " [+]: " + String.Join("-", tempComp));

                            Optimizedcomp = tempComp;
                            score = possibleBest;
                        }
                    }
                }
            }

            if (comp.SequenceEqual(Optimizedcomp))
            {
                Print("Couldn't improve comp");
            }
            else { Print("done."); }


        }

    }
}
