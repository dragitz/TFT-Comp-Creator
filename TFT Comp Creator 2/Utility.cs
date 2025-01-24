using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TFT_Comp_Creator_2.Scoring;

namespace TFT_Comp_Creator_2
{
    class Utility
    {
        public static RichTextBox formObj = new RichTextBox();
        public static RichTextBox debugBox = new RichTextBox();
        public static NumericUpDown targetNodes = new NumericUpDown();
        public static Label status_text = new Label();

        public static dynamic Master = new JObject();

        public static int Pet_SynergyBest = 0;
        public static int Pet_SynergyBest_backup = 0;
        public static bool ForceStop = false;

        public static NumericUpDown max_cost_5_amount = new NumericUpDown();
        public static NumericUpDown max_cost_4_amount = new NumericUpDown();
        public static NumericUpDown max_cost_3_amount = new NumericUpDown();
        public static NumericUpDown max_cost_2_amount = new NumericUpDown();
        public static NumericUpDown max_cost_1_amount = new NumericUpDown();
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

        public static CheckBox goldTrait = new CheckBox();
        // Create reference of output richtextbox located in Form1, will be ran once
        public static void SetFormUtility(
            RichTextBox box,
            RichTextBox debugBox_,
            NumericUpDown targetNodes_, Label status_text_,
            NumericUpDown max_cost_5_amount_,
            NumericUpDown max_cost_4_amount_,
            NumericUpDown max_cost_3_amount_,
            NumericUpDown max_cost_2_amount_,
            NumericUpDown max_cost_1_amount_,
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
            ListBox include_champion_,

            CheckBox goldTrait_

            )
        {
            formObj = box;
            debugBox = debugBox_;
            targetNodes = targetNodes_;
            status_text = status_text_;

            max_cost_5_amount = max_cost_5_amount_;
            max_cost_4_amount = max_cost_4_amount_;
            max_cost_3_amount = max_cost_3_amount_;
            max_cost_2_amount = max_cost_2_amount_;
            max_cost_1_amount = max_cost_1_amount_;
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

            goldTrait = goldTrait_;

        }
        public static void InformUtility(dynamic M)
        {
            Master = M;
        }

        // My favourite function, it has saved me so much time :D
        public static void Print(dynamic data)
        {
            // Also a try catch in this case isn't the best, but you never know :eyes:
            try
            {
                formObj.AppendText(data.ToString() + Environment.NewLine);
            }
            catch (Exception e) { formObj.AppendText(e.ToString()); }
        }
        public static void PrintDebug(dynamic data)
        {
            // Also a try catch in this case isn't the best, but you never know :eyes:
            try
            {
                debugBox.AppendText(data.ToString() + Environment.NewLine);
            }
            catch (Exception e) { debugBox.AppendText(e.ToString()); }
        }

        public static HashSet<string> hashmap = new HashSet<string>();

        public static void PrintComp(List<string> comp, int score)
        {
            if (score == 9999) { hashmap.Clear(); return; }
            if (comp.Count < 1) { return; }

            // quick fix to avoid repetitive spam
            if (Pet_SynergyBest > Pet_SynergyBest_backup) { hashmap.Clear(); Pet_SynergyBest_backup = Pet_SynergyBest; } // fixed printing bug

            if (comp.All(element => hashmap.Contains(element))) { return; }

            // this hashmap is pretty useful when dealing with resets (optimize checkbox)
            // this way we don't get identical comps with different scores caused by the include trait (preferred) bias in Scoring.cs
            if (hashmap.Count() > 20)
            {
                hashmap.Remove(hashmap.First());
            }
            hashmap.UnionWith(comp);

            comp = comp.OrderBy(component => Master["Champions"][component]["cost"])
                .ThenBy(component => Master["Champions"][component]["ChampionName"])
                .ToList();

            Print(score + " - " + String.Join("-", comp));
        }


        public static List<string> GetChampionsFromTrait(string trait)
        {
            List<string> champions = new List<string>();
            dynamic array = Master["TraitChampions"][trait];

            foreach (string item in array)
            {
                int cost = Master["Champions"][item]["cost"];

                // Check for disabled or quantity set to 0
                int[] maxCostAmounts = {
                    Convert.ToInt32(max_cost_1_amount.Value),
                    Convert.ToInt32(max_cost_2_amount.Value),
                    Convert.ToInt32(max_cost_3_amount.Value),
                    Convert.ToInt32(max_cost_4_amount.Value),
                    Convert.ToInt32(max_cost_5_amount.Value)
                };

                CheckBox[] disableChampionsCheckboxes = {
                    disable_champions_cost_1,
                    disable_champions_cost_2,
                    disable_champions_cost_3,
                    disable_champions_cost_4,
                    disable_champions_cost_5
                };

                if (cost >= 1 && cost <= 5 && (maxCostAmounts[cost - 1] == 0 || disableChampionsCheckboxes[cost - 1].Checked))
                    continue;


                champions.Add(item);
            }

            return champions;
        }
        public static List<string> GetTraitsFromChampion(string champion)
        {
            List<string> traits = new List<string>();
            dynamic array = Master["Champions"][champion]["Traits"];

            foreach (string item in array)
            {
                traits.Add(item);
            }

            return traits;
        }

        public static bool isGoldTraitPresent(JObject JTraits)
        {
            foreach (var item in JTraits.Properties())
            {
                string trait = item.Name;
                int result = CheckBreakPointAmount(JTraits, trait);

                if (result >= 3)
                    return true;
            }
            return false;

        }
        public static int CheckBreakPointAmount(JObject JTraits, string Trait)
        {

            dynamic BreakPoints = Master["TraitList"][Trait]["Breakpoints"];
            int maxBreakpointValue = (int)Master["TraitList"][Trait]["Breakpoints"][BreakPoints.Count - 1];

            if (!JTraits.ContainsKey(Trait) || maxBreakpointValue <= 1)
                return 0;

            int Score = (int)JTraits[Trait];
            int BP = 0;

            for (int i = 0; i < BreakPoints.Count; i++)
            {
                //Print(Trait + " - " +Score + "  " + (int)BreakPoints[i]);
                if (Score >= (int)BreakPoints[i])
                    BP = i + 1;
            }
            return BP;
        }

        // (test function) ensure champions with 3 or more traits have all of them active
        // note: doesn't actually produce better comps, just weird ones, but cool function to have just in case
        public static bool CarryWorth(JObject JTraits, List<string> comp)
        {
            List<string> cost3champions = new List<string>();
            foreach (string champion in comp)
            {
                int traitsAmount = (int)Master["Champions"][champion]["Traits"].Count;
                if (traitsAmount < 3)
                    continue;

                cost3champions.Add(champion);
            }

            if (cost3champions.Count == 0) return false;

            foreach (string champion in cost3champions)
            {
                // every trait must be active
                foreach (string trait in Master["Champions"][champion]["Traits"])
                {
                    if (!isTraitActive(JTraits, trait))
                        return false;
                }
            }

            return true;
        }
        public static bool CarryWorth2(JObject JTraits, List<string> comp)
        {
            int worth = 0;
            List<string> carryList = new List<string>();
            foreach (string champion in comp)
            {
                int range = (int)Master["Champions"][champion]["stats"]["range"];
                int cost = (int)Master["Champions"][champion]["cost"];
                if (range >= 4 && cost > 3)
                    carryList.Add(champion);
            }

            // if a trait from a unit surpasses x amount of BPs, then empowered will increase by 1 for each trait that surpasses that threshold
            // then --> empowered += 2
            // the higher, the better (usually)
            int empowered = 0;
            // if our empowered requirement is at 2
            // comps that are allowed to pass are either a single unit with two active traits, that have reached at least the 2nd BP
            // could also mean, two units with range >= 4 and cost >= 3, that each have a trait that surpasses BP 2 (or defined by code)

            foreach (string champion in carryList)
            {
                int traitsAmount = Master["Champions"][champion]["Traits"].Count;
                int activeTraits = 0;
                foreach (string trait in Master["Champions"][champion]["Traits"])
                {
                    int totalBP = Master["TraitList"][trait]["Breakpoints"].Count;
                    if (isTraitActive(JTraits, trait))
                    {
                        activeTraits++;
                        if (CheckBreakPointAmount(JTraits, trait) >= 2)
                            empowered++;
                    }
                }

                if (activeTraits == traitsAmount)
                    worth++;
            }

            if (worth == 0 || empowered < 1)
                return false;

            return true;
        }
        public static bool CarryWorth3(JObject JTraits, List<string> carryList)
        {
            int worth = 0;

            // if a trait from a unit surpasses x amount of BPs, then empowered will increase by 1 for each trait that surpasses that threshold
            // then --> empowered += 2
            // the higher, the better (usually)
            int empowered = 0;
            // if our empowered requirement is at 2
            // comps that are allowed to pass are either a single unit with two active traits, that have reached at least the 2nd BP
            // could also mean, two units with range >= 4 and cost >= 3, that each have a trait that surpasses BP 2 (or defined by code)

            foreach (string champion in carryList)
            {
                int traitsAmount = Master["Champions"][champion]["Traits"].Count;
                int activeTraits = 0;
                foreach (string trait in Master["Champions"][champion]["Traits"])
                {
                    int totalBP = Master["TraitList"][trait]["Breakpoints"].Count;
                    if (isTraitActive(JTraits, trait))
                    {
                        activeTraits++;
                        if (CheckBreakPointAmount(JTraits, trait) >= 2)
                            empowered++;
                    }
                }

                if (activeTraits == traitsAmount)
                    worth++;
            }

            if (worth == 0 || empowered < 1)
                return false;

            return true;
        }

        public static bool isCarryPresent(JObject JTraits, List<string> comp)
        {
            foreach (string champion in comp)
            {
                int traitsAmount = Master["Champions"][champion]["Traits"].Count;

                if (Master["Champions"][champion]["cost"] < 3 || traitsAmount < 2)
                    continue;

                int activeTraits = 0;
                foreach (string trait in Master["Champions"][champion]["Traits"])
                {
                    int totalBP = Master["TraitList"][trait]["Breakpoints"].Count;
                    if (isTraitActive(JTraits, trait))
                    {
                        activeTraits++;
                    }
                }

                if (traitsAmount == activeTraits) { return true; }
            }
            return false;
        }

        public static bool isTraitActive(JObject JTraits, string Trait)
        {
            if (!JTraits.ContainsKey(Trait))
                return false;

            // Unique traits do not count as active
            if ((int)Master["TraitList"][Trait]["Breakpoints"].Count <= 1)
                return false;

            //Print("AAAA: "+(int)JTraits["Ninja"]);

            int TraitScore = (int)JTraits[Trait];
            var breakpoints = Master["TraitList"][Trait]["Breakpoints"];
            int minBreakPoint = (int)breakpoints[0];

            // Specific case for Ninja trait (must be exactly 1 or 4)
            if (Trait == "Ninja")
            {
                int secondBreakPoint = (int)breakpoints[1];
                if (TraitScore != minBreakPoint && TraitScore != secondBreakPoint)
                    return false; // Ninja is inactive if TraitScore isn't 1 or 4
                return true; // Ninja is active for 1 or 4
            }

            // General case
            if (TraitScore >= minBreakPoint)
                return true;

            return false;
        }
        public static bool isChampionPresent(List<string> comp, string champion)
        {

            if (comp.Contains(champion))
                return true;

            return false;
        }

        public static bool hasTraitContibuted()
        {
            return false;
        }
        public static int getTotalUpgrades(JObject JTraits)
        {
            int TotalUpgrades = 0;
            foreach (dynamic Obj in JTraits.Properties())
            {
                string Trait = Obj.Name;
                int totalBreakPoints = Master["TraitList"][Trait]["Breakpoints"].Count;
                for (int i = 0; i < totalBreakPoints; i++)
                {
                    if ((int)Master["TraitList"][Trait]["Breakpoints"][i] == (int)JTraits[Trait]) // 
                    {
                        if (totalBreakPoints > 1 && i > 0)
                        {
                            TotalUpgrades += i;
                        }

                    }
                }
            }
            return TotalUpgrades;
        }
        public static bool isCompBalanced(JObject JTraits)
        {
            foreach (dynamic Obj in JTraits.Properties())
            {
                bool isBalanced = false;

                string Trait = Obj.Name;
                if (!isTraitActive(JTraits, Trait))
                    continue;

                int totalBreakPoints = Master["TraitList"][Trait]["Breakpoints"].Count;
                for (int i = 0; i < totalBreakPoints; i++)
                {
                    if ((int)Master["TraitList"][Trait]["Breakpoints"][i] == (int)JTraits[Trait])
                    {
                        isBalanced = true;
                        break;
                    }
                }
                if (!isBalanced)
                    return false;
            }
            return true;
        }
        public static bool canSpatulaBeUsed(JObject JTraits, List<string> comp)
        {
            Dictionary<string, int> usedEmblems = new Dictionary<string, int>();

            // Initialize the usage dictionary for included_spatula traits
            foreach (string included_spatula in include_spatula.Items)
            {
                usedEmblems[included_spatula] = 0; // Start with 0 used emblems
            }

            // Iterate through champions in the comp
            foreach (string champion in comp)
            {
                JArray championTraits = (JArray)Master["Champions"][champion]["Traits"];
                bool hasEmblem = false;

                // Check if the champion can hold an emblem from include_spatula
                foreach (string included_spatula in include_spatula.Items)
                {
                    if (championTraits != null && championTraits.Contains(included_spatula))
                    {
                        usedEmblems[included_spatula]++;
                        hasEmblem = true;
                        break; // A champion can only hold one emblem
                    }
                }

                // If the champion doesn't have any of the emblems, it's a free slot
                if (!hasEmblem)
                {
                    // Logic to handle completely free champions can go here (if needed)
                }
            }

            // Validate the usage of emblems
            foreach (string included_spatula in include_spatula.Items)
            {
                int championsWithTrait = JTraits[included_spatula] != null ? (int)JTraits[included_spatula] : 0;
                int totalPotential = comp.Count;

                // Check if there's space to add more emblems
                if (usedEmblems[included_spatula] + championsWithTrait > totalPotential)
                {
                    return false; // Not enough free slots
                }
            }

            return true; // All emblems can be applied
        }

        public static List<string> GetTopTraits(List<string> championList, int depthLevel)
        {
            Dictionary<string, int> traitCount = new Dictionary<string, int>();
            string traitName;
            JObject championData;
            JArray traitsArray;

            foreach (string championName in championList)
            {
                championData = Master["Champions"][championName];

                if (championData != null)
                {
                    traitsArray = (JArray)championData["Traits"];

                    // Count the traits for each champion
                    foreach (var trait in traitsArray)
                    {
                        traitName = trait.ToString();
                        if (traitCount.ContainsKey(traitName))
                        {
                            traitCount[traitName]++;
                        }
                        else
                        {
                            traitCount[traitName] = 1;
                        }
                    }
                }
            }

            // Find the 3 most common traits in the comp
            var topTraits = traitCount.OrderByDescending(kv => kv.Value)
                                      .Take(depthLevel)
                                      .Select(kv => kv.Key)
                                      .ToList();

            return topTraits;
        }


        /**
        
        16 Jan. 2024: new method should increase speed by a lot and doesn't require any hashmap nor regression. ty 3blue1brown !

         */


        public static ConcurrentDictionary<List<string>, int> FindCombinations2(int CompSize, List<string> items, List<string> excluded_comp_champions, List<string> tempIncludeTrait, List<string> tempIncludeSpatula)
        {
            var combinations = GetCombs(items.Count(), CompSize);

            int Synergy = 0;

            // this new dictionary is thread safe, keep it or crash the whole program
            ConcurrentDictionary<List<string>, int> parallel_results = new ConcurrentDictionary<List<string>, int>();

            CancellationTokenSource cts = new CancellationTokenSource();
            Parallel.ForEach(combinations, new ParallelOptions { CancellationToken = cts.Token }, combination =>
            {
                List<string> comp = string.Join("-", combination.Select(index => items[index]))
                    .Split(new[] { "-" }, StringSplitOptions.None)
                    .ToList();

                Synergy = CalculateSynergy(comp, excluded_comp_champions, tempIncludeTrait, tempIncludeSpatula);

                if (CheckCompValidity(comp, excluded_comp_champions))
                {
                    // ensure we don't insert comp that has already been added by another thread
                    if (!parallel_results.ContainsKey(comp))
                    {
                        parallel_results.TryAdd(comp, Synergy);
                    }

                }

            });

            return parallel_results;
        }


        public static Dictionary<string, Dictionary<string, int>> BuildAdjacencyMatrix(List<string> nodes)
        {
            // Initialize adjacency matrix
            var adjacencyMatrix = new Dictionary<string, Dictionary<string, int>>();

            List<string> champions = new List<string>();
            for (int i = 0; i < default_champion.Items.Count; i++)
            {
                champions.Add(default_champion.Items[i].ToString());
            }
            for (int i = 0; i < include_champion.Items.Count; i++)
            {
                champions.Add(include_champion.Items[i].ToString());
            }

            // Populate adjacency matrix
            foreach (string champion in champions)
            {
                List<string> traits = GetTraitsFromChampion(champion);

                // Initialize row for the champion
                adjacencyMatrix[champion] = new Dictionary<string, int>();

                // Populate row based on champion's traits
                foreach (string otherChampion in champions)
                {
                    if (champion == otherChampion)
                    {
                        adjacencyMatrix[champion][otherChampion] = 0; // Same champion
                    }
                    else
                    {
                        List<string> otherTraits = GetTraitsFromChampion(otherChampion);

                        // Count common traits
                        int commonTraitsCount = CountCommonTraits(traits, otherTraits);

                        // Assign the count to the matrix
                        adjacencyMatrix[champion][otherChampion] = commonTraitsCount;
                    }
                }
            }

            return adjacencyMatrix;
        }

        public static int CountCommonTraits(List<string> traits1, List<string> traits2)
        {
            int count = 0;
            foreach (string trait in traits1)
            {
                if (traits2.Contains(trait))
                {
                    count++;
                }
            }
            return count;
        }

        static IEnumerable<IEnumerable<int>> GetCombs(int N, int CompSize)
        {
            var indices = Enumerable.Range(0, N);
            var combinations = indices.Combinations(CompSize);
            return combinations;
        }
    }

    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
                elements.SelectMany((e, i) =>
                    elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }
}
