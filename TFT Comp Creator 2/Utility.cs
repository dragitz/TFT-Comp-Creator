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
        public static JArray TFData = JArray.Parse("[\n{ name: \"Alistar\", id: \"662\" }\n,{ name: \"Annie\", id: \"663\" }\n,{ name: \"Aphelios\", id: \"664\" }\n,{ name: \"Ashe\", id: \"665\" }\n,{ name: \"Aurelion Sol\", id: \"666\" }\n,{ name: \"Belveth\", id: \"667\" }\n,{ name: \"Blitzcrank\", id: \"668\" }\n,{ name: \"Camille\", id: \"669\" }\n,{ name: \"Chogath\", id: \"670\" }\n,{ name: \"Draven\", id: \"671\" }\n,{ name: \"Ekko\", id: \"672\" }\n,{ name: \"Ezreal\", id: \"673\" }\n,{ name: \"Fiddlesticks\", id: \"674\" }\n,{ name: \"Fiora\", id: \"675\" }\n,{ name: \"Galio\", id: \"676\" }\n,{ name: \"Gangplank\", id: \"677\" }\n,{ name: \"Janna\", id: \"678\" }\n,{ name: \"Jax\", id: \"679\" }\n,{ name: \"Jinx\", id: \"680\" }\n,{ name: \"Kaisa\", id: \"681\" }\n,{ name: \"Kayle\", id: \"682\" }\n,{ name: \"Leblanc\", id: \"683\" }\n,{ name: \"Lee Sin\", id: \"684\" }\n,{ name: \"Leona\", id: \"685\" }\n,{ name: \"Lulu\", id: \"686\" }\n,{ name: \"Lux\", id: \"687\" }\n,{ name: \"Malphite\", id: \"688\" }\n,{ name: \"Miss Fortune\", id: \"689\" }\n,{ name: \"Mordekaiser\", id: \"690\" }\n,{ name: \"Nasus\", id: \"691\" }\n,{ name: \"Nilah\", id: \"692\" }\n,{ name: \"Nunu\", id: \"693\" }\n,{ name: \"Poppy\", id: \"694\" }\n,{ name: \"Rammus\", id: \"695\" }\n,{ name: \"Rell\", id: \"696\" }\n,{ name: \"Renekton\", id: \"697\" }\n,{ name: \"Riven\", id: \"698\" }\n,{ name: \"Samira\", id: \"699\" }\n,{ name: \"Sejuani\", id: \"700\" }\n,{ name: \"Senna\", id: \"701\" }\n,{ name: \"Sett\", id: \"702\" }\n,{ name: \"Sivir\", id: \"703\" }\n,{ name: \"Sona\", id: \"704\" }\n,{ name: \"Soraka\", id: \"705\" }\n,{ name: \"Sylas\", id: \"706\" }\n,{ name: \"Syndra\", id: \"707\" }\n,{ name: \"Taliyah\", id: \"708\" }\n,{ name: \"Talon\", id: \"709\" }\n,{ name: \"Urgot\", id: \"710\" }\n,{ name: \"Vayne\", id: \"711\" }\n,{ name: \"Velkoz\", id: \"712\" }\n,{ name: \"Vi\", id: \"713\" }\n,{ name: \"Viego\", id: \"714\" }\n,{ name: \"Wukong\", id: \"715\" }\n,{ name: \"Yasuo\", id: \"716\" }\n,{ name: \"Yuumi\", id: \"717\" }\n,{ name: \"Zac\", id: \"718\" }\n,{ name: \"Zed\", id: \"719\" }\n,{ name: \"Zoe\", id: \"720\" }\n]\n");


        public static RichTextBox formObj = new RichTextBox();
        public static NumericUpDown targetNodes = new NumericUpDown();
        public static Label status_text = new Label();

        public static dynamic Master = new JObject();

        public static int Pet_SynergyBest = 0;
        public static int Pet_PowerBest = 0;
        public static bool ForceStop = false;

        public static NumericUpDown max_cost_5_amount = new NumericUpDown();
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
            RichTextBox box, NumericUpDown targetNodes_, Label status_text_,
            NumericUpDown max_cost_5_amount_,
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
            status_text = status_text_;

            max_cost_5_amount = max_cost_5_amount_;
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

        public static HashSet<string> hashmap = new HashSet<string>();

        public static void PrintComp(List<string> comp, int score)
        {
            if (score == 9999) { hashmap.Clear(); return; }
            if (comp.Count < 1) { return; }

            // quick fix to avoid repetitive spam
            if (comp.All(element => hashmap.Contains(element))) { return; }
            if (hashmap.Count() > 5)
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

        public static List<string> GetTopTraits(List<string> championList, int depthLevel)
        {
            Dictionary<string, int> traitCount = new Dictionary<string, int>();

            foreach (string championName in championList)
            {
                JObject championData = Master["Champions"][championName];

                if (championData != null)
                {
                    JArray traitsArray = (JArray)championData["Traits"];

                    // Count the traits for each champion
                    foreach (var trait in traitsArray)
                    {
                        string traitName = trait.ToString();
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
        public static void FindCombinations2(int CompSize, List<string> items)
        {
            var combinations = GetCombs(items.Count(), CompSize);

            List<string> comp = new List<string>();


            foreach (var combination in combinations)
            {
                if (Pet_SynergyBest >= 999 ||
                    ForceStop == true
                    ) { return; }

                comp = string.Join("-", combination.Select(index => items[index]))
                               .Split(new[] { "-" }, StringSplitOptions.None)
                               .ToList();


                int Synergy = CalculateSynergy(comp);

                if (Synergy >= Pet_SynergyBest && CheckCompValidity(comp))
                {
                    Pet_SynergyBest = Synergy;

                    PrintComp(comp, Synergy);

                    status_text.Text = "Synergy: " + Pet_SynergyBest;
                }

            }
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
