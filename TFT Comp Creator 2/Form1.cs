﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
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
                    output,
                    debugBox,
                    targetNodes, status_text,
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
                    include_champion,

                    goldTrait

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
                    include_spatula,
                    bronze_traits,
                    carryCheck,
                    carryCheck_unspecified,
                    mustMaxOutTraitLevel,
                    mustMaxOutTraitLevelCurrent

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



        public void CreateButton_Click(object sender, EventArgs e)
        {

            CreateButton.Enabled = false;
            StopButton.Enabled = true;

            Pet_SynergyBest = 0;
            Pet_SynergyBest_backup = 0;

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
        public bool CheckSettings()
        {
            if (minUpgrades.Value > 0 && bronze_traits.Checked)
            {
                Print("Can't have minUpgrades higher than 0 if bronze trait is checked");
                return false;
            }

            int maxChampions = 0;

            if (!disable_champions_cost_1.Checked)
                maxChampions += (int)max_cost_1_amount.Value;
            if (!disable_champions_cost_2.Checked)
                maxChampions += (int)max_cost_2_amount.Value;
            if (!disable_champions_cost_3.Checked)
                maxChampions += (int)max_cost_3_amount.Value;
            if (!disable_champions_cost_4.Checked)
                maxChampions += (int)max_cost_4_amount.Value;
            if (!disable_champions_cost_5.Checked)
                maxChampions += (int)max_cost_5_amount.Value;

            if ((int)min_comp_size.Value > maxChampions)
            {
                Print("Comp size is can't be higher than the max champ limitations. Increase champion pool");
                return false;
            }

            // by default this should not be hit, just in case I accidentally change something in the future
            if (minTraits.Value > maxTraits.Value)
            {
                Print("minTraits can't be higher than maxTraits (active)");
                return false;
            }

            int unitType = 0;
            unitType += (int)maxRanged.Value;
            unitType += (int)maxTank.Value;
            if ((int)min_comp_size.Value > unitType)
            {
                Print("Either increase maxTanks or maxRanged, as it is surpassed by comp size");
                return false;
            }


            return true;
        }

        public void Creation()
        {
            if (!CheckSettings())
            {
                ForceStop = false;
                Utility.ForceStop = false;
                Scoring.ForceStop = false;
                CreateButton.Enabled = true;
                StopButton.Enabled = false;

                return;
            }


            // Initialize empty lists for computation
            List<string> comp = new List<string>();
            List<string> nodes = new List<string>();
            List<string> excluded_comp_champions = excludedComp.Text.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(s => s.Trim())
                                                   .ToList();



            PrintComp(comp, 9999);

            JObject champions_found = new JObject();

            // i remember naming this variable in honor of my friend while I was in a call with him
            string trait_snake = "";

            //Dictionary<List<string>, int> allcomps = new Dictionary<List<string>, int>();
            //todo: use parallel
            for (int k = 0; k < default_trait.Items.Count; k++)
            {
                List<string> tempIncludeTrait = include_trait.Items.Cast<string>().ToList();
                List<string> tempIncludeSpatula = include_spatula.Items.Cast<string>().ToList();

                trait_snake = default_trait.Items[k].ToString();

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
                        Pet_SynergyBest = -500;
                        Pet_SynergyBest_backup = Pet_SynergyBest - 1;
                    }

                    hashmap.Clear();
                    //status_text.Text = "Synergy: " + Pet_SynergyBest;

                    // Use temporary lists instead of modifying the actual ListBox items
                    //tempIncludeTrait.Clear();
                    //tempIncludeTrait.AddRange(default_trait.Items.Cast<string>());
                    //Print(tempIncludeTrait);

                    tempIncludeTrait.Add((string)default_trait.Items[k]);

                    Print(String.Join("-", tempIncludeTrait));

                    
                    int bp_total = Master["TraitList"][trait_snake]["Breakpoints"].Count;
                    int biggest_bp = Master["TraitList"][trait_snake]["Breakpoints"][bp_total - 1];
                    int emblems_required = biggest_bp - Master["TraitChampions"][trait_snake].Count;

                    tempIncludeTrait.Add(trait_snake);

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


                List<string> newNodes = new List<string>();
                // Filter nodes using adjacency matrix
                var adjacencyMatrix = BuildAdjacencyMatrix(comp);

                foreach (var champion in adjacencyMatrix)
                {
                    foreach (var otherChampion in champion.Value)
                    {
                        if (otherChampion.Value <= 1) continue;

                        if (!newNodes.Contains(otherChampion.Key))
                            newNodes.Add(otherChampion.Key);
                    }
                }

                PrintComp(nodes, 9999);
                if (customNodeList.Text.Length > 0)
                {
                    nodes = excludedComp.Text.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(s => s.Trim())
                                                   .ToList();
                }


                // Failsafe to ensure minimum composition size
                int tries = 0;
                while (newNodes.Count < Convert.ToInt32(min_comp_size.Value) + 2 && Pet_SynergyBest < 999)
                {
                    tries += 1;
                    if (tries > 50)
                        break;

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


                // If the final list doesn't meet the required size, continue
                if (newNodes.Count < Convert.ToInt32(min_comp_size.Value)) continue;

                int size = Convert.ToInt32(min_comp_size.Value);



                ConcurrentDictionary<List<string>, int> parallel_results = FindCombinations2(size, nodes, excluded_comp_champions, tempIncludeTrait, tempIncludeSpatula, trait_snake);

                ConcurrentDictionary<List<string>, int> parallel_results_best = new ConcurrentDictionary<List<string>, int>();
                if (mustMaxOutTraitLevelCurrent.Checked)
                {
                    foreach (List<string> compParallel in parallel_results.Keys)
                    {
                        JObject JTraits = constructJTraits(compParallel);
                        if (!JTraits.ContainsKey(trait_snake)) { continue; } // Ignore if trait isn't present

                        int maxTotalChamps = Master["TraitChampions"][trait_snake].Count;
                        JArray breakpoints = Master["TraitList"][trait_snake]["Breakpoints"] as JArray;

                        // Get the highest breakpoint that can be reached without emblems
                        int maxValidBP = breakpoints.Where(bp => (int)bp <= maxTotalChamps).DefaultIfEmpty(0).Max(bp => (int)bp);

                        int result = (int)JTraits[trait_snake];

                        // If the highest breakpoint is unreachable without emblems, check previous valid BP
                        if (maxValidBP < breakpoints.Max(bp => (int)bp))  // There's a higher BP that we can't reach
                        {
                            if (result == maxValidBP)
                                parallel_results_best[compParallel] = parallel_results[compParallel];
                        }
                        else
                        {
                            if (result == maxValidBP)  // No need for `-1`, just compare with maxValidBP
                                parallel_results_best[compParallel] = parallel_results[compParallel];
                        }
                    }

                }
                else
                {
                    parallel_results_best = parallel_results;
                }

                

                // Filter, sort, and take the top 10
                var top10 = parallel_results_best
                    .Where(entry => entry.Value > Pet_SynergyBest)
                    .OrderByDescending(entry => entry.Value)
                    .Take(20);

                foreach (var obj in top10)
                {
                    if (obj.Value > Pet_SynergyBest)
                        Pet_SynergyBest = obj.Value;

                    PrintComp(obj.Key, obj.Value);

                    // analysis
                    //champions_found
                    foreach (string champion_in_comp in obj.Key)
                    {
                        if (champions_found[champion_in_comp] != null)
                        {
                            champions_found[champion_in_comp] = (int)champions_found[champion_in_comp] + 1;
                        }
                        else
                        {
                            champions_found[champion_in_comp] = 0;
                        }
                    }

                    //allcomps.Add(obj.Key, obj.Value);
                    //Console.WriteLine($"List: [{string.Join(", ", entry.Key)}], Score: {entry.Value}");
                }



            }

            //Creation();

            Print("done");

            // Reset form controls and variables
            System.Threading.Thread.Sleep(1000);
            ForceStop = false;
            Utility.ForceStop = false;
            Scoring.ForceStop = false;
            CreateButton.Enabled = true;
            StopButton.Enabled = false;
        }




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

            PrintDebug("initial score: " + score);

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
                            PrintDebug("[+] " + possibleBest + " [+]: " + String.Join("-", tempComp));

                            Optimizedcomp = tempComp;
                            score = possibleBest;
                        }
                    }
                }
            }

            if (comp.SequenceEqual(Optimizedcomp))
            {
                PrintDebug("Couldn't improve comp");
            }
            else { PrintDebug("done."); }


        }


        private void applySet_Click(object sender, EventArgs e)
        {
            ResetAllForms();

            Master = FirstRun(setList.SelectedIndex);

            //Populate(Master);
            //InformUtility(Master);

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
                                include_spatula,
                                bronze_traits,
                                carryCheck,
                                carryCheck_unspecified,
                                mustMaxOutTraitLevel,
                                mustMaxOutTraitLevelCurrent

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

        private void debugComp_Click(object sender, EventArgs e)
        {
            List<string> comp = compBox.Text.Split('-').ToList();

            JObject JTraits = new JObject();
            List<string> TraitsInComp = new List<string>();

            int rangedAmount = 0;
            int tankAmount = 0;
            foreach (var champion in comp)
            {
                int cost = (int)Master["Champions"][champion]["cost"];
                Print(champion + "  " + cost);

                if ((int)Master["Champions"][champion]["stats"]["range"] >= 4)
                    rangedAmount++;

                if ((int)Master["Champions"][champion]["stats"]["range"] <= 1)
                    tankAmount++;

                // Add the trait to the list
                dynamic Traits = Master["Champions"][champion]["Traits"];
                foreach (string Trait in Traits)
                {
                    if (TraitsInComp.Contains(Trait))
                        continue;

                    TraitsInComp.Add(Trait);
                    JProperty item_properties = new JProperty(Trait, 0);
                    JTraits.Add(item_properties);
                }

                // Populate JTraits
                int ChampionTraitsAmount = (int)Master["Champions"][champion]["Traits"].Count;

                dynamic TraitsArray = Master["Champions"][champion]["Traits"];

                for (int k = 0; k < ChampionTraitsAmount; k++)
                {
                    string CurrentTrait = (string)TraitsArray[k];

                    if (TraitsInComp.Contains(CurrentTrait))
                    {
                        JTraits[CurrentTrait] = (int)JTraits[CurrentTrait] + 1;
                        //Print(JTraits[CurrentTrait] + "  " + CurrentTrait + "   " + champion);
                    }
                }
            }
            // Add spatula to jtraits
            foreach (string trait in include_spatula.Items)
            {
                if (JTraits.ContainsKey(trait))
                {
                    JTraits[trait] = (int)JTraits[trait] + 1;
                }
                else { JTraits[trait] = 1; }
            }


            PrintDebug("isBalanced: " + isCompBalanced(JTraits));
            int ActiveTraits = 0;
            int InactiveTraits = 0;
            foreach (dynamic Obj in JTraits.Properties())
            {

                string Trait = Obj.Name;
                int BP = CheckBreakPointAmount(JTraits, Trait);

                if (isTraitActive(JTraits, Trait))
                {
                    ActiveTraits++;
                    PrintDebug("BreakPoint [" + Trait + "]: " + BP);
                    PrintDebug("JTraits[" + Trait + "]: " + (int)JTraits[Trait]);
                    PrintDebug("isTraitActive: "+ isTraitActive(JTraits, Trait));
                    PrintDebug("-");
                }
                else
                {
                    InactiveTraits++;
                }

            }
            PrintDebug("ActiveTraits: " + ActiveTraits);
            PrintDebug("InactiveTraits: " + InactiveTraits);
            PrintDebug("rangedAmount: " + rangedAmount);
            PrintDebug("tankAmount: " + tankAmount);

            JTraits = GetJTraits(comp);
            PrintDebug("Verticality: " + CalculateVerticalityScore(comp, JTraits));
            int score = CalculateSynergy(comp, new List<string> { }, new List<string> { }, new List<string> { });
            PrintDebug("Score: " + score);
            //PrintComp(GetChampionsFromTrait("Bastion"), 0);

        }

        private void getCompCode_Click(object sender, EventArgs e)
        {
            List<string> comp = compBox.Text.Split('-').ToList();

            if (comp.Count < 1)
            {
                PrintDebug("Invalid comp size");
                return;
            }

            string code = "02";
            foreach (string champion in comp)
            {
                //Print(champion);
                if (Master["Champions"][champion]["hex"] == "")
                {
                    PrintDebug("No hex data available for current comp/set: "+ champion);
                    return;
                }
                code += Master["Champions"][champion]["hex"];
            }

            // comps can be up to 10 champions, if below, fill it with zeros
            if (comp.Count < 10)
            {
                for (int i = 0; i < 10 - comp.Count; i++)
                {
                    code += "00";
                }
            }
            code += "0" + setList.Text; // todo: use a global variable, user might change the text without applying new set
            PrintDebug(code);
        }
    }
}
