using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static TFT_Comp_Creator_2.Utility;

namespace TFT_Comp_Creator_2
{
    public class Scoring
    {
        public static dynamic Master = new JObject();
        private static ComboBox scoringAlgo = new ComboBox();
        private static CheckBox no_error = new CheckBox();
        private static CheckBox limit_champions_cost_5 = new CheckBox();
        private static NumericUpDown minActiveTRaits = new NumericUpDown();

        public static bool ForceStop = false;
        public static void SetFromScoring(dynamic M, ComboBox S, CheckBox NO, CheckBox limit_champions_cost_5_, NumericUpDown minActiveTRaits_)
        {
            Master = M;
            scoringAlgo = S;
            no_error = NO;
            limit_champions_cost_5 = limit_champions_cost_5_;
            minActiveTRaits = minActiveTRaits_;
        }

        /// <summary>
        /// 
        /// This function calculates the synergy score of a list of "champions" by considering their traits. 
        /// It first creates a dictionary called championsData which maps each champion to a list of their traits. 
        ///
        /// Then loops through each champion in the input comp and calculates the contribution of each trait to the synergy score. 
        /// The contribution is equal to the number of champions in comp that have that trait. Finally, it returns the total synergy score.
        /// 
        /// NOTE: Some champions have 3 traits, therefore there's inevitable bias towards champions that have a higher number of traits
        ///       the effect is reduced by the contribution amount, but there's still a slight bias !
        /// 
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static int CalculateSynergy(List<string> comp)
        {
            if (ForceStop) { return 0; }

            // Access the property of the checkbox here.
            bool isChecked = no_error.Checked;

            try
            {
                // Create and populate championsData
                Dictionary<string, List<string>> championsData = new Dictionary<string, List<string>>();


                foreach (var champ in comp)
                {
                    var champTraitsAmount = Master["Champions"][champ]["Traits"].Count - 1;

                    List<string> champTraitList = new List<string>();

                    for (int i = 0; i < champTraitsAmount; i++)
                    {
                        champTraitList.Add((string)Master["Champions"][champ]["Traits"][i]);
                    }

                    championsData.Add(champ, champTraitList);
                }

                // Keep track of the synergy score
                int synergyScore = 0;

                // Loop through each fruit name and calculate its contribution to the synergy score
                foreach (var champ in comp)
                {
                    // Get the list of categories for the current fruit
                    var traits = championsData[champ];

                    // Loop through each category and calculate its contribution to the synergy score
                    foreach (var trait in traits)
                    {
                        // Each category contributes the number of fruits in the fruitNames list that belong to that category
                        synergyScore += comp.Count(f => championsData[f].Contains(trait));
                    }

                }

                // Return the total synergy score
                return synergyScore;
            }
            catch (Exception ex) { Print(ex); return 999; } // This should never get hit, in case it happens the search will stop

        }

        // Important function that returns a score.
        // It's an outdated function, but I want to keep it in case I need some of its functionalities.
        /// <summary>
        /// 
        /// The GetScore function takes in a List of strings representing champions and an integer called debug, and returns a score 
        /// based on certain statistics about the traits of the champions in the List. 
        ///
        /// These statistics include the number of active and inactive traits in the List, whether certain traits are balanced or unbalanced, and 
        /// whether certain traits have upgrades available.
        ///
        /// The function also checks for certain conditions, such as the number of champions with specific traits, and returns 0 if these conditions are met.
        /// 
        /// return 0 means the comp is bad.
        /// 
        /// </summary>
        /// <param name="comp"></param>
        /// <param name="debug"></param>
        /// <returns></returns>
        public static int GetScore(List<string> comp, int debug)
        {
            if (ForceStop) { return 0; }

            int ActiveTraits = 0;
            int InactiveTraits = 0;
            int BalancedTraits = 0;
            int UnbalancedTraits = 0;

            int Opportunities = 0;

            int BreakPoints = 0;    // Upgrades
            int TraitsWithUpgrades = 0;

            int cost5Amount = 0;

            int includedTraitsScore = 0;
            int includedChampionsScore = 0;


            // Fill TraitsInComp
            // Loop through the comp
            List<string> TraitsInComp = new List<string>();
            JObject JTraits = new JObject();

            for (int i = 0; i < comp.Count; i++)
            {
                string ChampionName = comp[i].ToString();

                int cost = Master["Champions"][ChampionName]["cost"];
                if (cost == 5)
                    cost5Amount += 1;

                // Make sure that champion has been added, by checking user specified champion inclusion
                for (int qq = 0; qq < include_champion.Items.Count; qq++)
                {
                    if (ChampionName == include_champion.Items[qq].ToString()) { includedChampionsScore++; break; }
                }

                // Compute amount of traits that the current champion has
                int TraitsAmount = Master["Champions"][ChampionName]["Traits"].Count;

                //avgArmor += Master["Champions"][ChampionName]["Traits"]
                for (int k = 0; k < TraitsAmount; k++)
                {
                    string CurrentTrait = (string)Master["Champions"][ChampionName]["Traits"][k];

                    if (!TraitsInComp.Contains(CurrentTrait))
                    {

                        TraitsInComp.Add(CurrentTrait);
                        JProperty item_properties = new JProperty(CurrentTrait, 0);
                        JTraits.Add(item_properties);
                    }
                }
                for (int k = 0; k < TraitsAmount; k++)
                {
                    string CurrentTrait = (string)Master["Champions"][ChampionName]["Traits"][k];

                    if (TraitsInComp.Contains(CurrentTrait))
                    {
                        JTraits[CurrentTrait] = (int)JTraits[CurrentTrait] + 1;

                    }

                    // Check if current comp has all user-defined included traits
                    for (int qq = 0; qq < include_trait.Items.Count; qq++)
                    {
                        if (CurrentTrait == include_trait.Items[qq].ToString()) { includedTraitsScore++; break; }
                    }
                }


            }
            //
            // Active traits is calculated separately for a different reason
            foreach (dynamic item in JTraits)
            {
                int BreakpointAmount = Master["TraitList"][item.Key]["Breakpoints"].Count;
                int Step = (int)item.Value;

                bool isActive = false;


                int minBreakPoint = (int)Master["TraitList"][item.Key]["Breakpoints"][0];
                int maxBreakPoint = (int)Master["TraitList"][item.Key]["Breakpoints"][BreakpointAmount - 1];


                for (int i = 0; i < BreakpointAmount; i++)
                {
                    // is in/active?
                    if (Step >= minBreakPoint)
                    {

                        isActive = true;
                    }
                }

                // Compute flags
                if (isActive) { ActiveTraits++; } else { InactiveTraits++; }

            }


            if (debug == 3)
            {
                PrintComp(comp);

                return ActiveTraits + InactiveTraits;
            }

            // Calculate stats
            foreach (dynamic item in JTraits)
            {
                int BreakpointAmount = Master["TraitList"][item.Key]["Breakpoints"].Count;
                int Step = (int)item.Value;

                bool isBalanced = false;
                bool isActive = false;
                bool hasTraitUpgrade = false;

                int minBreakPoint = (int)Master["TraitList"][item.Key]["Breakpoints"][0];
                int maxBreakPoint = (int)Master["TraitList"][item.Key]["Breakpoints"][BreakpointAmount - 1];

                string CurrentTrait = "";

                for (int i = 0; i < BreakpointAmount; i++)
                {
                    CurrentTrait = item.Key;

                    // is in/active?
                    if (Step >= minBreakPoint)
                    {
                        isActive = true;

                        // Make sure that trait can be added, by checking user specified traits exclusion
                        for (int qq = 0; qq < exclude_trait.Items.Count; qq++)
                        {
                            if (exclude_trait.Items[qq].ToString() == CurrentTrait) { return 0; }
                        }
                    }

                    // is missed opportunity?
                    if (Step + 1 == minBreakPoint) { Opportunities++; }

                    // is un/balanced ?
                    if (Step == (int)Master["TraitList"][CurrentTrait]["Breakpoints"][i])
                    {

                        isBalanced = true;

                    }

                    // breakpoints
                    if (Step >= (int)Master["TraitList"][CurrentTrait]["Breakpoints"][i] && i > 0)
                    {
                        BreakPoints++;

                    }

                    // TraitsWithUpgrades
                    if (BreakpointAmount > 1)
                    {
                        if (Step >= (int)Master["TraitList"][item.Key]["Breakpoints"][1])
                        {
                            //TraitsWithUpgrades++;
                            hasTraitUpgrade = true;
                        }

                    }

                    // if comp size is surpassed, exclude
                    if (Step > maxBreakPoint) { return 0; }


                }


                if (hasTraitUpgrade) { TraitsWithUpgrades++; }

                if (isBalanced) { BalancedTraits++; }
                else
                {
                    if (isActive)
                    {
                        UnbalancedTraits++;
                    }
                }

            }


            // debugging
            if (debug == 1)
            {
                Print(JTraits.ToString());

                Print("ActiveTraits: " + ActiveTraits);
                Print("InactiveTraits: " + InactiveTraits);
                Print("BalancedTraits: " + BalancedTraits);
                Print("UnbalancedTraits: " + UnbalancedTraits);

                Print("BreakPoints: " + BreakPoints);
                Print("TraitsWithUpgrades: " + TraitsWithUpgrades);
                Print("Opportunities: " + Opportunities);
            }

            // Hardcoded rules
            // 
            // These rules affects the quality of the output, 
            if (ActiveTraits < 4) { return 0; }     // Comp must have at least x active traits
            //if (BreakPoints < 1) { return 0; }      // Comp must have at least x upgrades (combined)

            //if (InactiveTraits > 10) { return 0; }
            if (UnbalancedTraits > 0 && no_error.Checked) { return 0; }
            if (Opportunities > 20) { return 0; }
            if (cost5Amount > 1 && limit_champions_cost_5.Checked) { return 0; }

            // Inclusion scoring
            if (includedTraitsScore != include_trait.Items.Count) { return 0; }
            if (includedChampionsScore != include_champion.Items.Count) { return 0; }


            // Scoring
            int Score = 0;
            switch (scoringAlgo.Text)
            {
                case ("Balanced"):
                    //Score = ActiveTraits * 2 - InactiveTraits * 1 + BalancedTraits * 5 - UnbalancedTraits * 5 + BestBreakPoint * 1 + BreakPoints * 2; //bad

                    Score = ActiveTraits * 3 - InactiveTraits * 1 + BreakPoints * 4 + TraitsWithUpgrades * 3 + Opportunities * 1;
                    break;

                case ("Punish"):
                    Score = ActiveTraits * 3 - InactiveTraits * 3 + BreakPoints * 3 + TraitsWithUpgrades * 2 + Opportunities * 1;
                    break;

                case ("Reward"):
                    Score = ActiveTraits * 4 - InactiveTraits * 0 + BreakPoints * 1 + TraitsWithUpgrades * 2 - Opportunities * 1;
                    break;

                default:
                    break;
            }
            if (debug == 1)
            {
                Print("Score: " + Score);
            }
            return Score;
        }


        /// <summary>
        /// 
        /// This CheckCompValidity method checks the validity of a list of champions (comp) based on various criteria.
        /// 
        /// It does this by creating a list of traits for each champion in the list and then counting the number of champions with each trait.
        /// It also checks whether the list of champions meets certain criteria, such as:
        ///     * whether it must include or exclude certain champions 
        ///     * whether the number of champions of certain costs is within certain limits.
        ///     
        /// If the list of champions meets all of the specified criteria, the method returns true, otherwise it returns false.
        /// 
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool CheckCompValidity(List<string> comp)
        {
            JObject JTraits = new JObject();

            int cost5Amount = 0;

            List<string> TraitsInComp = new List<string>();
            foreach (var champion in comp)
            {
                int cost = (int)Master["Champions"][champion]["cost"];

                int ChampionTraitsAmount = (int)Master["Champions"][champion]["Traits"].Count;

                // Count the amount of 5 cost champions
                switch (cost)
                {
                    case 1:
                        if (disable_champions_cost_1.Checked) { return false; }
                        break;
                    case 2:
                        if (disable_champions_cost_2.Checked) { return false; }
                        break;
                    case 3:
                        if (disable_champions_cost_3.Checked) { return false; }
                        break;
                    case 4:
                        if (disable_champions_cost_4.Checked) { return false; }
                        break;
                    case 5:
                        if (disable_champions_cost_5.Checked) { return false; }
                        cost5Amount++;
                        break;
                }
                if (cost > 5 && disable_champions_cost_5_more.Checked)
                    return false;


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
                for (int k = 0; k < ChampionTraitsAmount; k++)
                {
                    string CurrentTrait = (string)Master["Champions"][champion]["Traits"][k];

                    if (TraitsInComp.Contains(CurrentTrait))
                    {
                        JTraits[CurrentTrait] = (int)JTraits[CurrentTrait] + 1;
                    }
                }

            }

            // Size can't be higher than 1
            if (limit_champions_cost_5.Checked && cost5Amount > 1) { return false; }


            // Included / Excluded champion check
            List<string> IncludedChampsFoundLIst = new List<string>();
            foreach (string champion in comp)
            {
                // Check if champ appears in the excluded list, as well as the included list
                for (int i = 0; i < exclude_champion.Items.Count; i++)
                {
                    if (champion == exclude_champion.Items[i].ToString())
                        return false;
                }

                for (int i = 0; i < include_champion.Items.Count; i++)
                {
                    if (champion == include_champion.Items[i].ToString() && !IncludedChampsFoundLIst.Contains(champion))
                        IncludedChampsFoundLIst.Add(champion);
                }
            }
            if (include_champion.Items.Count != IncludedChampsFoundLIst.Count) { return false; }


            int ActiveTraits = 0;

            // Let's check if the comp is balanced
            List<string> IncludedTraitFoundLIst = new List<string>();

            // Iterate through all 
            foreach (string Trait in TraitsInComp)
            {
                int minBreakPoint = (int)Master["TraitList"][Trait]["Breakpoints"][0];

                // Make sure the trait is active
                if ((int)JTraits[Trait] >= minBreakPoint)
                {
                    ActiveTraits++;

                    int BreakpointAmount = (int)Master["TraitList"][Trait]["Breakpoints"].Count;

                    // Checkbox must be toggled
                    if (no_error.Checked)
                    {
                        bool isBalanced = false;
                        for (int i = 0; i < BreakpointAmount; i++)
                        {
                            if ((int)Master["TraitList"][Trait]["Breakpoints"][i] == (int)JTraits[Trait])
                                isBalanced = true;
                        }

                        if (!isBalanced) { return false; }
                    }


                    // Included / Excluded traits check

                    // Check if trait appears in the excluded list, as well as the included list
                    for (int i = 0; i < exclude_trait.Items.Count; i++)
                    {
                        if (Trait == exclude_trait.Items[i].ToString())
                            return false;
                    }

                    for (int i = 0; i < include_trait.Items.Count; i++)
                    {
                        if (Trait == include_trait.Items[i].ToString() && !IncludedTraitFoundLIst.Contains(Trait))
                            IncludedTraitFoundLIst.Add(Trait);
                    }



                }
            }

            if (include_trait.Items.Count != IncludedTraitFoundLIst.Count) { return false; }

            // less than x traits makes the comp invalid
            if (ActiveTraits < Convert.ToInt32(minActiveTRaits.Value)) { return false; }

            return true;
        }
        // Unused function that I keep in case I need it
        public static int ComputePowerLevel(List<string> comp)
        {
            if (ForceStop) { return 0; }

            // Define weights for each stat, based on its relative importance in determining the character's power level
            float damageWeight = 0.08f;

            float armorWeight = 0.07f;
            float magicResistanceWeight = 0.07f;

            float critChanceWeight = 0.05f;
            float critMultiplierWeight = 0.05f;

            float maxManaWeight = 0.04f;

            float hpWeight = 0.03f;
            float attackSpeedWeight = 0.03f;
            float initialManaWeight = 0.03f;

            float attackDistanceWeight = 0.01f;

            ////////////////////////////////////

            float powerLevel = 0f;

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

                // Compute the power level as a weighted sum of the character's stats
                powerLevel += attackSpeed * attackSpeedWeight + armor * armorWeight + magicResistance * magicResistanceWeight + attackDistance * attackDistanceWeight + damage * damageWeight + maxMana * maxManaWeight + initialMana * initialManaWeight + hp * hpWeight + critChance * critChanceWeight + critMultiplier * critMultiplierWeight;

                // Alistar-Aphelios-Fiddlesticks-Janna-Leona-Mordekaiser-Nunu-Syndra
            }

            return Convert.ToInt32(powerLevel);
        }

    }
}
