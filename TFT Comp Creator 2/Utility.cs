using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static TFT_Comp_Creator_2.Scoring;

namespace TFT_Comp_Creator_2
{
    class Utility
    {
        public static JArray TFData = JArray.Parse("[\n{ name: \"Alistar\", id: \"662\" }\n,{ name: \"Annie\", id: \"663\" }\n,{ name: \"Aphelios\", id: \"664\" }\n,{ name: \"Ashe\", id: \"665\" }\n,{ name: \"Aurelion Sol\", id: \"666\" }\n,{ name: \"Belveth\", id: \"667\" }\n,{ name: \"Blitzcrank\", id: \"668\" }\n,{ name: \"Camille\", id: \"669\" }\n,{ name: \"Chogath\", id: \"670\" }\n,{ name: \"Draven\", id: \"671\" }\n,{ name: \"Ekko\", id: \"672\" }\n,{ name: \"Ezreal\", id: \"673\" }\n,{ name: \"Fiddlesticks\", id: \"674\" }\n,{ name: \"Fiora\", id: \"675\" }\n,{ name: \"Galio\", id: \"676\" }\n,{ name: \"Gangplank\", id: \"677\" }\n,{ name: \"Janna\", id: \"678\" }\n,{ name: \"Jax\", id: \"679\" }\n,{ name: \"Jinx\", id: \"680\" }\n,{ name: \"Kaisa\", id: \"681\" }\n,{ name: \"Kayle\", id: \"682\" }\n,{ name: \"Leblanc\", id: \"683\" }\n,{ name: \"Lee Sin\", id: \"684\" }\n,{ name: \"Leona\", id: \"685\" }\n,{ name: \"Lulu\", id: \"686\" }\n,{ name: \"Lux\", id: \"687\" }\n,{ name: \"Malphite\", id: \"688\" }\n,{ name: \"Miss Fortune\", id: \"689\" }\n,{ name: \"Mordekaiser\", id: \"690\" }\n,{ name: \"Nasus\", id: \"691\" }\n,{ name: \"Nilah\", id: \"692\" }\n,{ name: \"Nunu\", id: \"693\" }\n,{ name: \"Poppy\", id: \"694\" }\n,{ name: \"Rammus\", id: \"695\" }\n,{ name: \"Rell\", id: \"696\" }\n,{ name: \"Renekton\", id: \"697\" }\n,{ name: \"Riven\", id: \"698\" }\n,{ name: \"Samira\", id: \"699\" }\n,{ name: \"Sejuani\", id: \"700\" }\n,{ name: \"Senna\", id: \"701\" }\n,{ name: \"Sett\", id: \"702\" }\n,{ name: \"Sivir\", id: \"703\" }\n,{ name: \"Sona\", id: \"704\" }\n,{ name: \"Soraka\", id: \"705\" }\n,{ name: \"Sylas\", id: \"706\" }\n,{ name: \"Syndra\", id: \"707\" }\n,{ name: \"Taliyah\", id: \"708\" }\n,{ name: \"Talon\", id: \"709\" }\n,{ name: \"Urgot\", id: \"710\" }\n,{ name: \"Vayne\", id: \"711\" }\n,{ name: \"Velkoz\", id: \"712\" }\n,{ name: \"Vi\", id: \"713\" }\n,{ name: \"Viego\", id: \"714\" }\n,{ name: \"Wukong\", id: \"715\" }\n,{ name: \"Yasuo\", id: \"716\" }\n,{ name: \"Yuumi\", id: \"717\" }\n,{ name: \"Zac\", id: \"718\" }\n,{ name: \"Zed\", id: \"719\" }\n,{ name: \"Zoe\", id: \"720\" }\n]\n");


        public static RichTextBox formObj = new RichTextBox();
        public static NumericUpDown targetNodes = new NumericUpDown();
        public static Label label14 = new Label();

        public static dynamic Master = new JObject();
        public static int Pet_SynergyBest = 0;
        public static int Pet_PowerBest = 0;
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
            if (comp.Count < 1) { return; }

            comp = comp.OrderBy(x => x).ToList();

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


        public static List<string> GetNodes2(List<string> comp)
        {
            // Now get the nodes into a list, list must contain traits
            List<string> traits = new List<string>();

            for (int i = 0; i < comp.Count; i++)
            {
                // Get the champions's traits
                int numberOfTraits = Master["Champions"][comp[i]]["Traits"].Count;
                for (int k = 0; k < numberOfTraits; k++)
                {
                    // Check if trait can be added (exclusion)

                    string trait = Master["Champions"][comp[i]]["Traits"][k].ToString();

                    if (!exclude_trait.Items.Contains(trait))
                    {
                        traits.Add(trait);
                    }

                }
            }

            traits = traits.Distinct().ToList();

            //Print("Initial nodes: ");
            //PrintComp(traits);


            // Now initiate a list of champions that have that trait
            List<string> championNodes = new List<string>();

            for (int i = 0; i < traits.Count; i++)
            {
                int ChampionsInTrait = Master["TraitChampions"][traits[i]].Count;

                for (int k = 0; k < ChampionsInTrait; k++)
                {
                    // Check filters
                    string champion = Master["TraitChampions"][traits[i]][k];
                    int cost = Master["Champions"][champion]["cost"];

                    if (disable_champions_cost_1.Checked && cost == 1) { continue; }
                    else if (disable_champions_cost_2.Checked && cost == 2) { continue; }
                    else if (disable_champions_cost_3.Checked && cost == 3) { continue; }
                    else if (disable_champions_cost_4.Checked && cost == 4) { continue; }
                    else if (disable_champions_cost_5.Checked && cost == 5) { continue; }
                    else if (disable_champions_cost_5_more.Checked && cost > 5) { continue; }

                    championNodes.Add(champion);
                }

            }

            championNodes = championNodes.Distinct().ToList();
            List<string> championNodeStrings = championNodes.Distinct().Select(node => node.ToString()).ToList();

            return championNodeStrings;

        }

        /// <summary>
        /// This is a recursive function that generates all possible combinations of a given size from a list of elements (nodes) and 
        /// checks whether each combination is valid. 
        /// 
        /// A combination is considered valid if it has not been seen before (determined by checking whether it is present in the alreadySeenCombinations set) and
        /// if it meets certain criteria (determined by the CheckCompValidity and CalculateSynergy functions).
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

                int Synergy = CalculateSynergy(comp);
                //int Power = ComputePowerLevel(comp);

                //if (Synergy < 20 && CheckCompValidity(comp))
                if (Synergy > Pet_SynergyBest && CheckCompValidity(comp))
                {
                    Pet_SynergyBest = Synergy;
                    //Pet_PowerBest = Power;

                    PrintComp(comp);
                    //PrintCompLink(comp);

                    label14.Text = "Synergy: " + Pet_SynergyBest + " - Power: ";
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

        public static string PrintCompLink(List<string> comp)
        {
            JObject TFStructure = new JObject(

                new JProperty("chosen", true),
                new JProperty("set", 8),
                new JProperty("team", new JArray(// { position: "1", id: "1234", level: 0, items: []}
                                                 )
                )
            );

            // Add obj to the team array
            JArray arr = (JArray)TFStructure["team"];
            int i = 0;

            foreach (string champion in comp)
            {
                i++;
                string id = "";

                // Get the id of the champion
                foreach (var currentChampionObj in TFData)
                {
                    // Find the champion id
                    string ch = (string)currentChampionObj["name"];
                    if (ch.ToLower() == champion.ToLower()) { id = (string)currentChampionObj["id"]; }
                }

                // Make sure id is valid
                if (id == "") { continue; }

                // Create team
                JObject obj = new JObject();
                obj["id"] = id;
                obj["items"] = new JArray();
                obj["level"] = 0;
                obj["position"] = i.ToString();

                arr.Add(obj);
            }


            // Serialize the JSON string to a byte array
            byte[] jsonBytes = Encoding.UTF8.GetBytes(TFStructure.ToString());

            // Convert the byte array to a base64 string
            string base64String = Convert.ToBase64String(jsonBytes);

            // Replace any forward slashes in the base64 string with a tilde
            base64String = base64String.Replace("/", "~");

            return "https://tftactics.gg/team-builder/" + base64String;

        }


        public static void GenerateCombinations(int[] array, int combinationLength)
        {
            int[] combination = new int[combinationLength];
            GenerateCombinationsRecursive(array, combination, 0, 0);
        }

        private static void GenerateCombinationsRecursive(int[] array, int[] combination, int currentIndex, int currentCombinationLength)
        {
            if (currentCombinationLength == combination.Length)
            {
                //Print(string.Join(", ", combination));
                return;
            }

            for (int i = currentIndex; i < array.Length; i++)
            {
                if (i > currentIndex && array[i] == array[i - 1])
                {
                    continue;
                }

                combination[currentCombinationLength] = array[i];
                GenerateCombinationsRecursive(array, combination, i + 1, currentCombinationLength + 1);
            }

        }

        public static void FineTunePowerLevel(List<List<string>> goodComps, List<List<string>> badComps)
        {

            int averageSize = 50;

            float[] averageDamage = new float[averageSize];
            float[] averagearmorWeight = new float[averageSize];
            float[] averagemagicResistanceWeight = new float[averageSize];
            float[] averagecritChanceWeight = new float[averageSize];
            float[] averagecritMultiplierWeight = new float[averageSize];
            float[] averagemaxManaWeight = new float[averageSize];
            float[] averagehpWeight = new float[averageSize];
            float[] averageattackSpeedWeight = new float[averageSize];
            float[] averageinitialManaWeight = new float[averageSize];
            float[] averageattackDistanceWeight = new float[averageSize];

            for (int times = 0; times < averageSize; times++)
            {

                //Print(times);

                Random random = new Random();
                // Define weights for each stat, based on its relative importance in determining the character's power level
                float damageWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                float armorWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                float magicResistanceWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                float critChanceWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                float critMultiplierWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                float maxManaWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                float hpWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                float attackSpeedWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                float initialManaWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                float attackDistanceWeight = (float)(random.NextDouble() * 0.14 - 0.07);



                float averageGood = -1.0f;
                float averageBad = 1.0f;

                while ((averageGood - 1.0f) < averageBad)
                {
                    float[] powerGood = new float[goodComps.Count];
                    float[] powerBad = new float[badComps.Count];

                    for (int compID = 0; compID < goodComps.Count(); compID++)
                    {

                        // Create comp
                        List<string> comp = goodComps[compID];

                        //PrintComp(goodComps[compID]);


                        for (int i = 0; i < comp.Count(); i++)
                        {

                            string championName = comp[i];



                            int attackSpeed = (int)Master["Champions"][championName]["stats"]["attackSpeed"];
                            int armor = (int)Master["Champions"][championName]["stats"]["armor"];
                            int magicResistance = (int)Master["Champions"][championName]["stats"]["magicResist"];
                            int attackDistance = (int)Master["Champions"][championName]["stats"]["range"];
                            int damage = (int)Master["Champions"][championName]["stats"]["damage"];
                            int maxMana = (int)Master["Champions"][championName]["stats"]["mana"];
                            int initialMana = (int)Master["Champions"][championName]["stats"]["initialMana"];
                            int hp = (int)Master["Champions"][championName]["stats"]["hp"];
                            float critChance = (float)Master["Champions"][championName]["stats"]["critChance"];
                            float critMultiplier = (float)Master["Champions"][championName]["stats"]["critMultiplier"];

                            // 
                            // Compute the power level as a weighted sum of the character's stats
                            powerGood[compID] =
                                attackSpeed * attackSpeedWeight +
                                armor * armorWeight +
                                magicResistance * magicResistanceWeight +
                                attackDistance * attackDistanceWeight +
                                damage * damageWeight +
                                maxMana * maxManaWeight +
                                initialMana * initialManaWeight +
                                hp * hpWeight +
                                critChance * critChanceWeight +
                                critMultiplier * critMultiplierWeight;

                            //Print(powerGood[compID]);

                            //Print(championName);
                        }
                    }

                    for (int compID = 0; compID < badComps.Count(); compID++)
                    {
                        // Create comp
                        List<string> comp = badComps[compID];

                        for (int i = 0; i < comp.Count(); i++)
                        {
                            string championName = comp[i];

                            int attackSpeed = (int)Master["Champions"][championName]["stats"]["attackSpeed"];
                            int armor = (int)Master["Champions"][championName]["stats"]["armor"];
                            int magicResistance = (int)Master["Champions"][championName]["stats"]["magicResist"];
                            int attackDistance = (int)Master["Champions"][championName]["stats"]["range"];
                            int damage = (int)Master["Champions"][championName]["stats"]["damage"];
                            int maxMana = (int)Master["Champions"][championName]["stats"]["mana"];
                            int initialMana = (int)Master["Champions"][championName]["stats"]["initialMana"];
                            int hp = (int)Master["Champions"][championName]["stats"]["hp"];
                            float critChance = (float)Master["Champions"][championName]["stats"]["critChance"];
                            float critMultiplier = (float)Master["Champions"][championName]["stats"]["critMultiplier"];

                            // 
                            // Compute the power level as a weighted sum of the character's stats
                            powerBad[compID] =
                                attackSpeed * attackSpeedWeight +
                                armor * armorWeight +
                                magicResistance * magicResistanceWeight +
                                attackDistance * attackDistanceWeight +
                                damage * damageWeight +
                                maxMana * maxManaWeight +
                                initialMana * initialManaWeight +
                                hp * hpWeight +
                                critChance * critChanceWeight +
                                critMultiplier * critMultiplierWeight;
                        }
                    }


                    //averageGood = powerGood.Average();
                    //averageBad = powerBad.Average();

                    averageGood = (float)powerGood.Average();
                    averageBad = (float)powerBad.Average();

                    damageWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                    armorWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                    magicResistanceWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                    critChanceWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                    critMultiplierWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                    maxManaWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                    hpWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                    attackSpeedWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                    initialManaWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                    attackDistanceWeight = (float)(random.NextDouble() * 0.14 - 0.07);
                }

                if (hpWeight > averagehpWeight.Average())
                {
                    averageDamage[times] = damageWeight;
                    averagearmorWeight[times] = armorWeight;
                    averagemagicResistanceWeight[times] = magicResistanceWeight;
                    averagecritChanceWeight[times] = critChanceWeight;
                    averagecritMultiplierWeight[times] = critMultiplierWeight;
                    averagemaxManaWeight[times] = maxManaWeight;
                    averagehpWeight[times] = hpWeight;
                    averageattackSpeedWeight[times] = attackSpeedWeight;
                    averageinitialManaWeight[times] = initialManaWeight;
                    averageattackDistanceWeight[times] = attackDistanceWeight;
                }



            }

            Print(
                "damageWeight = " + averageDamage.Average() + "f;" + Environment.NewLine +
                "armorWeight = " + averagearmorWeight.Average() + "f;" + Environment.NewLine +
                "magicResistanceWeight = " + averagemagicResistanceWeight.Average() + "f;" + Environment.NewLine +
                "critChanceWeight = " + averagecritChanceWeight.Average() + "f;" + Environment.NewLine +
                "critMultiplierWeight = " + averagecritMultiplierWeight.Average() + "f;" + Environment.NewLine +
                "maxManaWeight = " + averagemaxManaWeight.Average() + "f;" + Environment.NewLine +
                "hpWeight = " + averagehpWeight.Average() + "f;" + Environment.NewLine +
                "attackSpeedWeight = " + averageattackSpeedWeight.Average() + "f;" + Environment.NewLine +
                "initialManaWeight = " + averageinitialManaWeight.Average() + "f;" + Environment.NewLine +
                "attackDistanceWeight = " + averageattackDistanceWeight.Average() + "f;" + Environment.NewLine
                );
            return;
        }
    }
}
