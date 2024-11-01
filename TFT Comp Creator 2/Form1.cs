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



        public bool ForceStop = false;

        public Form1()
        {
            InitializeComponent();


            try
            {
                // Setup part 1
                SetFormUtility(
                    output, targetNodes, status_text,
                    max_cost_5_amount,
                    max_cost_4_amount,
                    max_cost_3_amount,
                    max_cost_2_amount,
                    max_cost_1_amount,
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
                    include_spatula,
                    setList
                );

                // Setup part 2
                Master = FirstRun(0);

                SetFromScoring(
                    Master,
                    no_error,
                    exclusion_allow_base_trait,
                    max_cost_5_amount,
                    max_cost_4_amount,
                    max_cost_3_amount,
                    max_cost_2_amount,
                    max_cost_1_amount,
                    max_comp_cost,
                    minTraits,
                    maxTraits,
                    max_inactive_traits,
                    minUpgrades,
                    minRanged,
                    maxRanged,
                    minTank,
                    maxTank,
                    trait_3_limiter,
                    min_upgrades_included,
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
            Pet_SynergyBest_backup = 1;

            status_text.Text = "Synergy: " + Pet_SynergyBest;


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
            List<string> excluded_comp_champions = excludedComp.Text.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(s => s.Trim())
                                                   .ToList();

            // Temporary lists for traits and spatulas to avoid modifying the original ListBox items
            List<string> tempIncludeTrait = include_trait.Items.Cast<string>().ToList();
            List<string> tempIncludeSpatula = include_spatula.Items.Cast<string>().ToList();
            PrintComp(comp, 9999);

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
            FindCombinations2(size, nodes, excluded_comp_champions, tempIncludeTrait, tempIncludeSpatula);

            Print("done");

            ForceStop = false;
            Utility.ForceStop = false;
            Scoring.ForceStop = false;

            StopButton.Enabled = false;
            bruteForce.Enabled = true;

        }

        public void CreateButton_Click(object sender, EventArgs e)
        {

            CreateButton.Enabled = false;
            StopButton.Enabled = true;

            Pet_SynergyBest = 1;
            Pet_SynergyBest_backup = 1;

            status_text.Text = "Synergy: " + Pet_SynergyBest;

            Thread t = new Thread(new ThreadStart(Creation))
            {
                IsBackground = true
            };
            t.Start();

        }

        public void ResetAllForms()
        {
            include_spatula.Items.Clear();
            include_trait.Items.Clear();
            default_trait.Items.Clear();
            include_trait.Items.Clear();
            exclude_champion.Items.Clear();
            default_champion.Items.Clear();
            include_champion.Items.Clear();
            default_spatula.Items.Clear();
            include_spatula.Items.Clear();
        }

        public void Creation()
        {
            // Initialize empty lists for computation
            List<string> comp = new List<string>();
            List<string> nodes = new List<string>();
            List<string> excluded_comp_champions = excludedComp.Text.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(s => s.Trim())
                                                   .ToList();


            
            PrintComp(comp, 9999);

            string trait_snake = "";

            for (int k = 0; k < default_trait.Items.Count; k++)
            {
                List<string> tempIncludeTrait = include_trait.Items.Cast<string>().ToList();
                List<string> tempIncludeSpatula = include_spatula.Items.Cast<string>().ToList();

                if (ForceStop)
                {
                    CreateButton.Enabled = false;
                    break;
                }

                // Reset
                comp.Clear();
                nodes.Clear();

                if (champion_optimizer.Checked)
                {
                    if (score_reset.Checked)
                    {
                        Pet_SynergyBest = 1;
                        Pet_SynergyBest_backup = Pet_SynergyBest - 1;
                    }

                    hashmap.Clear();
                    status_text.Text = "Synergy: " + Pet_SynergyBest;

                    // Use temporary lists instead of modifying the actual ListBox items
                    //tempIncludeTrait.Clear();
                    //tempIncludeTrait.AddRange(default_trait.Items.Cast<string>());
                    //Print(tempIncludeTrait);

                    tempIncludeTrait.Add((string)default_trait.Items[k]);

                    Print(String.Join("-", tempIncludeTrait));
                    //break;
                    if (!no_spatula.Checked)
                    {
                        //tempIncludeSpatula.Clear();
                        //tempIncludeSpatula.AddRange(default_spatula.Items.Cast<string>());
                        
                        //foreach (string item in include_spatula.Items.Cast<object>().ToList())
                        //{
                        //    tempIncludeSpatula.Add(item);
                        //}
                        
                        Print("SPatula is bugged, disable it");
                    }

                    trait_snake = default_trait.Items[k].ToString();
                    int bp_total = Master["TraitList"][trait_snake]["Breakpoints"].Count;
                    int biggest_bp = Master["TraitList"][trait_snake]["Breakpoints"][bp_total - 1];
                    int emblems_required = biggest_bp - Master["TraitChampions"][trait_snake].Count;

                    tempIncludeTrait.Add(trait_snake);

                    if (emblems_required > 0 && !no_spatula.Checked)
                    {
                        for (int i = 0; i < emblems_required; i++)
                        {
                            tempIncludeSpatula.Add(trait_snake);
                        }
                    }
                }

                // Process champions in the 'include_champion' ListBox
                for (int i = 0; i < include_champion.Items.Count; i++)
                {
                    comp.Add(include_champion.Items[i].ToString());

                    foreach (string trait in GetTraitsFromChampion(include_champion.Items[i].ToString()))
                    {
                        List<string> champs = GetChampionsFromTrait(trait);
                        nodes = nodes.Union(champs).ToList();
                    }
                }

                // Process temporary trait list instead of the actual ListBox items
                foreach (var trait in tempIncludeTrait)
                {
                    foreach (string champion in GetChampionsFromTrait(trait))
                    {
                        if (!nodes.Contains(champion) && !comp.Contains(champion))
                            nodes.Add(champion);
                    }
                }

                // Process temporary spatula list instead of the actual ListBox items
                foreach (var spatulaTrait in tempIncludeSpatula)
                {
                    foreach (string champion in GetChampionsFromTrait(spatulaTrait))
                    {
                        if (!nodes.Contains(champion) && !comp.Contains(champion))
                            nodes.Add(champion);
                    }
                }

                // Include champions based on top traits
                List<string> Top3 = GetTopTraits(nodes, Convert.ToInt32(depthLevel.Value));
                foreach (var topTrait in Top3)
                {
                    foreach (string champion in GetChampionsFromTrait(topTrait))
                    {
                        if (!nodes.Contains(champion) && !comp.Contains(champion))
                            nodes.Add(champion);
                    }
                }

                // Filter nodes using adjacency matrix
                var adjacencyMatrix = BuildAdjacencyMatrix(comp);
                List<string> newNodes = new List<string>();

                foreach (var champion in adjacencyMatrix)
                {
                    foreach (var otherChampion in champion.Value)
                    {
                        if (otherChampion.Value <= 1) continue;

                        if (!newNodes.Contains(otherChampion.Key))
                            newNodes.Add(otherChampion.Key);
                    }
                }

                // Failsafe to ensure minimum composition size
                while (newNodes.Count < Convert.ToInt32(min_comp_size.Value) + 2 && Pet_SynergyBest < 999)
                {
                    List<string> TopX = GetTopTraits(newNodes, 3);
                    foreach (var topTrait in TopX)
                    {
                        foreach (string champion in GetChampionsFromTrait(topTrait))
                        {
                            if (!newNodes.Contains(champion) && !comp.Contains(champion))
                                newNodes.Add(champion);
                        }
                    }
                }

                // If the final list meets the required size, continue
                if (newNodes.Count < Convert.ToInt32(min_comp_size.Value)) continue;

                int size = Convert.ToInt32(min_comp_size.Value);
                FindCombinations2(size, nodes, excluded_comp_champions, tempIncludeTrait, tempIncludeSpatula);

                if (quick_discovery.Checked) break;
            }

            Print("done");

            // Reset form controls and variables
            System.Threading.Thread.Sleep(100);
            ForceStop = false;
            Utility.ForceStop = false;
            Scoring.ForceStop = false;
            CreateButton.Enabled = true;
            StopButton.Enabled = false;
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

            //Pet_SynergyBest = 999;
        }

        private void OptimizeComp_Click(object sender, EventArgs e)
        {
            if (compBox.Text.Length < 1)
                return;

            List<string> comp = compBox.Text.Split('-').ToList();
            List<string> Optimizedcomp = new List<string>(comp);
            
            List<string> excluded_comp_champions = excludedComp.Text.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(s => s.Trim())
                                                   .ToList();

            // Temporary lists for traits and spatulas to avoid modifying the original ListBox items
            List<string> tempIncludeTrait = include_trait.Items.Cast<string>().ToList();
            List<string> tempIncludeSpatula = include_spatula.Items.Cast<string>().ToList();

            int score = CalculateSynergy(comp, excluded_comp_champions, tempIncludeTrait, tempIncludeSpatula);
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
                    if (CheckCompValidity(tempComp, new List<string> { }))
                    {
                        possibleBest = CalculateSynergy(tempComp, excluded_comp_champions, tempIncludeTrait, tempIncludeSpatula);

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

        private void tabRules_Click(object sender, EventArgs e)
        {

        }

        private void applySet_Click(object sender, EventArgs e)
        {
            ResetAllForms();

            Master = FirstRun(setList.SelectedIndex);
            Populate(Master);
            InformUtility(Master);
        }
    }
}
