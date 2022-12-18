using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static TFT_Comp_Creator_2.Scoring;

namespace TFT_Comp_Creator_2
{
    class Utility
    {
        public static RichTextBox formObj = new RichTextBox();
        public static NumericUpDown targetNodes = new NumericUpDown();
        public static Label label14 = new Label();

        public static dynamic Master = new JObject();
        public static int Pet_SynergyBest = 0;
        public static bool ForceStop = false;

        public static CheckBox limit_champions_cost_5 = new CheckBox();
        public static CheckBox disable_champions_cost_1 = new CheckBox();
        public static CheckBox disable_champions_cost_2 = new CheckBox();
        public static CheckBox disable_champions_cost_3 = new CheckBox();
        public static CheckBox disable_champions_cost_4 = new CheckBox();
        public static CheckBox disable_champions_cost_5 = new CheckBox();
        public static CheckBox disable_champions_cost_5_more = new CheckBox();

        public static ListBox exclude_trait = new ListBox();
        public static ListBox default_trait = new ListBox();
        public static ListBox include_trait = new ListBox();
        public static ListBox exclude_champion = new ListBox();
        public static ListBox default_champion = new ListBox();
        public static ListBox include_champion = new ListBox();

        // Create reference of output richtextbox located in Form1, will be ran once
        public static void SetFormUtility(
            RichTextBox box, NumericUpDown targetNodes_, Label label14_,
            CheckBox limit_champions_cost_5_,
            CheckBox disable_champions_cost_1_,
            CheckBox disable_champions_cost_2_,
            CheckBox disable_champions_cost_3_,
            CheckBox disable_champions_cost_4_,
            CheckBox disable_champions_cost_5_,
            CheckBox disable_champions_cost_5_more_,
            ListBox exclude_trait_,
            ListBox default_trait_,
            ListBox include_trait_,
            ListBox exclude_champion_,
            ListBox default_champion_,
            ListBox include_champion_
            )
        {
            formObj = box;
            targetNodes = targetNodes_;
            label14 = label14_;

            limit_champions_cost_5 = limit_champions_cost_5_;
            disable_champions_cost_1 = disable_champions_cost_1_;
            disable_champions_cost_2 = disable_champions_cost_2_;
            disable_champions_cost_3 = disable_champions_cost_3_;
            disable_champions_cost_4 = disable_champions_cost_4_;
            disable_champions_cost_5 = disable_champions_cost_5_;
            disable_champions_cost_5_more = disable_champions_cost_5_more_;

            exclude_trait = exclude_trait_;
            default_trait = default_trait_;
            include_trait = include_trait_;
            exclude_champion = exclude_champion_;
            default_champion = default_champion_;
            include_champion = include_champion_;

        }
        public static void InformUtility(dynamic M)
        {
            Master = M;
        }

        // My favourite function, it has saved me so much time :D
        public static void Print(dynamic data)
        {
            formObj.AppendText(data.ToString() + Environment.NewLine);
        }

        public static void PrintComp(List<string> comp)
        {
            if (comp.Count <= 0) { return; }

            Print(String.Join("-", comp));

        }

        /// <summary>
        /// TL;DR
        /// This function takes in a list of strings and returns a list of strings that includes a specified number of elements 
        /// based on the number of occurrences of certain traits in a dictionary. 
        /// 
        /// It also removes any elements in a separate list from the final list before returning it.
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static List<string> GetNodes(List<string> comp)
        {

            // Store all traits in the comp
            List<string> allTraits = new List<string>();

            for (int i = 0; i < comp.Count; i++)
            {
                if (comp[i] == "") { continue; }

                string Champion = comp[i];

                // Check if Master contains the "Champions" key
                if (Master.ContainsKey("Champions"))
                {
                    // Get the "Champions" dictionary
                    var Champions = Master["Champions"];

                    // Check if the "Champions" dictionary contains the champion we're looking for
                    if (Champions.ContainsKey(Champion))
                    {
                        // Get the champion's traits
                        var Traits = Champions[Champion]["Traits"];

                        // Check if the traits exist
                        if (Traits != null)
                        {
                            // Loop through the champion's traits and add them to the allTraits list
                            for (int q = 0; q < Traits.Count; q++)
                            {

                                allTraits.Add(Traits[q].ToString());
                            }
                        }
                    }
                }

            }


            // From allTraits find champions occourences, order them by biggest number and add number of nodes equal to the specified amount in the GUI ( targetNodes.Value )
            List<string> list = new List<string>();

            int target = Convert.ToInt32(targetNodes.Value);

            foreach (var currentTrait in allTraits)
            {
                var count = Master["TraitChampions"][currentTrait].Count;

                for (int i = 0; i < count && list.Count < target; i++)
                {
                    string champion = Master["TraitChampions"][currentTrait][i];

                    int cost = Master["Champions"][champion]["cost"];

                    if (disable_champions_cost_1.Checked && cost == 1) { continue; }
                    else if (disable_champions_cost_2.Checked && cost == 2) { continue; }
                    else if (disable_champions_cost_3.Checked && cost == 3) { continue; }
                    else if (disable_champions_cost_4.Checked && cost == 4) { continue; }
                    else if (disable_champions_cost_5.Checked && cost == 5) { continue; }
                    else if (disable_champions_cost_5_more.Checked && cost > 5) { continue; }

                    list.Add(champion.ToString());
                }
            }

            // Filter out excluded champions
            if (exclude_champion.Items.Count > 0)
            {
                for (int i = 0; i < exclude_champion.Items.Count; i++)
                {
                    list.Remove(exclude_champion.Items[i].ToString());
                }
            }

            return list;
        }

        /// <summary>
        /// This is a recursive function that generates all possible combinations of a given size from a list of elements (nodes) and 
        /// checks whether each combination is valid. 
        /// 
        /// A combination is considered valid if it has not been seen before (determined by checking whether it is present in the alreadySeenCombinations set) and
        /// if it meets certain criteria (determined by the GetScore and CalculateSynergy functions).
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="TargetCompSize"></param>
        /// <param name="alreadySeenCombinations"></param>
        /// <param name="comp"></param>
        public static void FindCombinations(List<string> nodes, int TargetCompSize, HashSet<string> alreadySeenCombinations, List<string> comp)
        {
            if (Pet_SynergyBest >= 999 ||
                ForceStop == true
                ) { return; }

            // Base case: if the combination size is 0, then we have found a valid combination
            if (comp.Count == TargetCompSize)
            {
                // Convert the combination to a string and add it to the set of already seen combinations
                string combinationString = string.Join("-", comp);
                alreadySeenCombinations.Add(combinationString);

                // Print the combination
                //PrintComp(comp);

                // Evaluate score
                int Score = GetScore(comp, 0);
                int Synergy = CalculateSynergy(comp);

                if (Synergy > Pet_SynergyBest && Score > 0)
                {
                    Pet_SynergyBest = Synergy;

                    PrintComp(comp);

                    label14.Text = "Synergy: " + Pet_SynergyBest;
                }

                return;
            }

            // Base case: if the nodes list is empty, then there are no more elements to add to the combination
            if (nodes.Count == 0)
            {
                return;
            }

            // Try including the first element in the combination
            string firstElement = nodes[0];
            List<string> remainingElements = nodes.Skip(1).ToList();

            // Only add the element to the combination if it is not already present
            if (!comp.Contains(firstElement))
            {
                comp.Add(firstElement);
                FindCombinations(remainingElements, TargetCompSize, alreadySeenCombinations, comp);
                comp.RemoveAt(comp.Count - 1);
            }

            // Try not including the first element in the combination
            FindCombinations(remainingElements, TargetCompSize, alreadySeenCombinations, comp);
        }







    }
}
