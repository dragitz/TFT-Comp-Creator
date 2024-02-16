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
        private static CheckBox no_error = new CheckBox();
        private static CheckBox exclusion_allow_base_trait = new CheckBox();
        private static NumericUpDown max_cost_5_amount = new NumericUpDown();
        private static NumericUpDown max_cost_4_amount = new NumericUpDown();
        private static NumericUpDown max_cost_3_amount = new NumericUpDown();
        private static NumericUpDown max_cost_2_amount = new NumericUpDown();
        private static NumericUpDown max_cost_1_amount = new NumericUpDown();
        private static NumericUpDown minActiveTRaits = new NumericUpDown();
        private static NumericUpDown minUpgrades = new NumericUpDown();
        private static NumericUpDown minRanged = new NumericUpDown();
        private static NumericUpDown maxRanged = new NumericUpDown();
        private static NumericUpDown trait_3_limiter = new NumericUpDown();

        public static ListBox include_spatula = new ListBox();

        public static bool ForceStop = false;
        public static void SetFromScoring(
            dynamic M,
            CheckBox NO,
            CheckBox exclusion_allow_base_trait_,
            NumericUpDown max_cost_5_amount_,
            NumericUpDown max_cost_4_amount_,
            NumericUpDown max_cost_3_amount_,
            NumericUpDown max_cost_2_amount_,
            NumericUpDown max_cost_1_amount_,
            NumericUpDown minActiveTRaits_,
            NumericUpDown minUpgrades_,
            NumericUpDown minRanged_,
            NumericUpDown maxRanged_,
            NumericUpDown trait_3_limiter_,
            ListBox include_spatula_)
        {
            Master = M;
            no_error = NO;
            exclusion_allow_base_trait = exclusion_allow_base_trait_;
            max_cost_5_amount = max_cost_5_amount_;
            max_cost_4_amount = max_cost_4_amount_;
            max_cost_3_amount = max_cost_3_amount_;
            max_cost_2_amount = max_cost_2_amount_;
            max_cost_1_amount = max_cost_1_amount_;
            minActiveTRaits = minActiveTRaits_;
            minUpgrades = minUpgrades_;
            minRanged = minRanged_;
            maxRanged = maxRanged_;
            trait_3_limiter = trait_3_limiter_;

            include_spatula = include_spatula_;

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

            JObject JTraits = new JObject();

            try
            {
                // Create and populate championsData
                Dictionary<string, List<string>> championsData = new Dictionary<string, List<string>>();


                foreach (var champ in comp)
                {
                    var champTraitsAmount = Master["Champions"][champ]["Traits"].Count - 1;

                    List<string> champTraitList = new List<string>();

                    foreach (var trait in Master["Champions"][champ]["Traits"])
                    {
                        champTraitList.Add((string)trait);
                    }

                    championsData.Add(champ, champTraitList);
                }

                // Keep track of the synergy score
                int synergyScore = 0;

                foreach (var champ in comp)
                {

                    var traits = championsData[champ];

                    // Loop through each trait and calculate its contribution to the synergy score
                    foreach (var trait in traits)
                    {
                        synergyScore += comp.Count(f => championsData[f].Contains(trait));
                    }

                }

                // Spatula traits / Headliners
                foreach (var champTraits in championsData.Values)
                {
                    // Increase synergy score if the trait is present in the List<string> comp
                    synergyScore += champTraits.Count(trait => include_spatula.Items.Contains(trait));
                }





                // Return the total synergy score
                return synergyScore;
            }
            catch (Exception) { return 0; } // This should never get hit, in case it happens the search will stop

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
            int cost4Amount = 0;
            int cost3Amount = 0;
            int cost2Amount = 0;
            int cost1Amount = 0;

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
                if (cost == 4)
                    cost4Amount += 1;
                if (cost == 3)
                    cost3Amount += 1;
                if (cost == 2)
                    cost2Amount += 1;
                if (cost == 1)
                    cost1Amount += 1;

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
                PrintComp(comp, 9999);

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

            // Cost limiter
            if (cost5Amount > Convert.ToInt32(max_cost_5_amount.Value)) { return 0; }
            if (cost4Amount > Convert.ToInt32(max_cost_4_amount.Value)) { return 0; }
            if (cost3Amount > Convert.ToInt32(max_cost_3_amount.Value)) { return 0; }
            if (cost2Amount > Convert.ToInt32(max_cost_2_amount.Value)) { return 0; }
            if (cost1Amount > Convert.ToInt32(max_cost_1_amount.Value)) { return 0; }

            // Inclusion scoring
            if (includedTraitsScore != include_trait.Items.Count) { return 0; }
            if (includedChampionsScore != include_champion.Items.Count) { return 0; }


            // Scoring
            int Score = 0;
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
            List<string> JTraits_active = new List<string>();

            int cost5Amount = 0;
            int cost4Amount = 0;
            int cost3Amount = 0;
            int cost2Amount = 0;
            int cost1Amount = 0;

            int rangedAmount = 0;


            List<string> TraitsInComp = new List<string>();

            foreach (var champion in comp)
            {
                int cost = (int)Master["Champions"][champion]["cost"];

                if ((int)Master["Champions"][champion]["stats"]["range"] >= 4)
                    rangedAmount++;

                // Count the amount of 5 cost champions
                switch (cost)
                {
                    case 1:
                        if (disable_champions_cost_1.Checked) { return false; }
                        cost1Amount++;
                        break;
                    case 2:
                        if (disable_champions_cost_2.Checked) { return false; }
                        cost2Amount++;
                        break;
                    case 3:
                        if (disable_champions_cost_3.Checked) { return false; }
                        cost3Amount++;
                        break;
                    case 4:
                        if (disable_champions_cost_4.Checked) { return false; }
                        cost4Amount++;
                        break;
                    case 5:
                        if (disable_champions_cost_5.Checked) { return false; }
                        cost5Amount++;
                        break;
                }
                if (cost > 5 && disable_champions_cost_5_more.Checked)
                    return false;

                // Size can't be higher than 1
                if (cost5Amount > Convert.ToInt32(max_cost_5_amount.Value)) { return false; }
                if (cost4Amount > Convert.ToInt32(max_cost_4_amount.Value)) { return false; }
                if (cost3Amount > Convert.ToInt32(max_cost_3_amount.Value)) { return false; }
                if (cost2Amount > Convert.ToInt32(max_cost_2_amount.Value)) { return false; }
                if (cost1Amount > Convert.ToInt32(max_cost_1_amount.Value)) { return false; }


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
                    }
                }


            }


            int found = 0;
            int mustFind = include_spatula.Items.Count;

            // Spatula traits can be added here (to be coded)
            for (int k = 0; k < include_spatula.Items.Count; k++)
            {
                string spatulaTrait = include_spatula.Items[k].ToString();


                bool foundChamp = false;

                foreach (var champion in comp)
                {
                    dynamic Traits = Master["Champions"][champion]["Traits"];


                    foreach (string Trait in Traits)
                    {
                        if (Traits.Contains(spatulaTrait))
                            break;

                        foundChamp = true;
                        found++;
                        break;
                    }
                    if (foundChamp) { break; }
                }

                if (!foundChamp) { return false; }


                if (TraitsInComp.Contains(spatulaTrait))
                {
                    JTraits[spatulaTrait] = (int)JTraits[spatulaTrait] + 1;
                }
                else
                {
                    TraitsInComp.Add(spatulaTrait);
                    JProperty item_properties = new JProperty(spatulaTrait, 0);
                    JTraits.Add(item_properties);
                }
            }
            if (found < mustFind && mustFind > 0) { return false; }



            // Ensure n amount of ranged
            if (rangedAmount < Convert.ToInt32(minRanged.Value) || rangedAmount > Convert.ToInt32(maxRanged.Value)) { return false; }

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

            int TotalUpgrades = 0;

            // Iterate through all 
            foreach (string Trait in TraitsInComp)
            {
                // Included / Excluded traits check

                // Check if trait appears in the excluded list, as well as the included list
                if (!exclusion_allow_base_trait.Checked)
                {
                    if (exclude_trait.Items.Contains(Trait))
                        return false;
                    //for (int i = 0; i < exclude_trait.Items.Count; i++)
                    //{
                    //    if (Trait == exclude_trait.Items[i].ToString())
                    //        return false;
                    //}
                }


                int minBreakPoint = (int)Master["TraitList"][Trait]["Breakpoints"][0];
                int totalBreakPoints = Master["TraitList"][Trait]["Breakpoints"].Count;

                if (exclusion_allow_base_trait.Checked && (int)JTraits[Trait] > minBreakPoint && exclude_trait.Items.Contains(Trait) && totalBreakPoints > 1)
                {
                    return false;
                }

                // Make sure the trait is active
                // Trait must not be unique per champion (eg. a 5 cost that has its own trait does not count as having more active traits), aka more than 1 BP
                if ((int)JTraits[Trait] >= minBreakPoint && totalBreakPoints > 1)
                {
                    for (int i = 0; i < include_trait.Items.Count; i++)
                    {
                        if (Trait == include_trait.Items[i].ToString() && !IncludedTraitFoundLIst.Contains(Trait))
                            IncludedTraitFoundLIst.Add(Trait);
                    }

                    int maxBreakpoint = (int)Master["TraitList"][Trait]["Breakpoints"][Master["TraitList"][Trait]["Breakpoints"].Count - 1]; // This is a test, might leave it here

                    ActiveTraits++;

                    JTraits_active.Add(Trait);

                    int BreakpointAmount = (int)Master["TraitList"][Trait]["Breakpoints"].Count;


                    bool isBalanced = false;
                    for (int i = 0; i < BreakpointAmount; i++)
                    {
                        if ((int)Master["TraitList"][Trait]["Breakpoints"][i] == (int)JTraits[Trait] || (int)Master["TraitList"][Trait]["Breakpoints"][i] > maxBreakpoint)
                        {

                            isBalanced = true;

                            if (BreakpointAmount > 1 && i > 0)
                            {
                                TotalUpgrades += i;
                            }

                        }
                    }

                    if (!isBalanced && no_error.Checked) { return false; }


                }
            }


            int championsWith_3_traits_or_more = 0;
            // Ensure all champions have contributed to the active trait list at least once
            foreach (string champion in comp)
            {
                JArray ChampTraits = Master["Champions"][champion]["Traits"];

                bool has_contributed = false;

                foreach (string Trait in ChampTraits)
                {
                    if (JTraits_active.Contains(Trait)) { has_contributed = true; break; };
                }
                if (!has_contributed) { return false; }


                int NumberOfTraits = Master["Champions"][champion]["Traits"].Count;

                if (NumberOfTraits >= 3)
                    championsWith_3_traits_or_more++;

                if (championsWith_3_traits_or_more > Convert.ToInt32(trait_3_limiter.Value))
                    return false;
            }



            // Ensure desired traits are active
            if (include_trait.Items.Count != IncludedTraitFoundLIst.Count) { return false; }

            // Ensure minimum amount of upgrades
            if (TotalUpgrades < minUpgrades.Value) { return false; }

            // less than x traits makes the comp invalid
            if (ActiveTraits < Convert.ToInt32(minActiveTRaits.Value)) { return false; }


            return true;
        }
        // Unused function that I keep in case I need it
        public static int ComputePowerLevel(List<string> comp)
        {
            if (ForceStop) { return 0; }

            // Define weights for each stat, based on its relative importance in determining the character's power level
            float damageWeight = 0.052f;
            float armorWeight = 0.0025f;
            float magicResistanceWeight = -0.0025f;
            float critChanceWeight = 0.025f;
            float critMultiplierWeight = 0.0013f;
            float maxManaWeight = -0.0023f;
            float hpWeight = 0.007f;
            float attackSpeedWeight = -131.1f;
            float initialManaWeight = 1.001f;
            float attackDistanceWeight = 0.0014f;

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
                //powerLevel += attackSpeed * attackSpeedWeight + armor * armorWeight + magicResistance * magicResistanceWeight + attackDistance * attackDistanceWeight + damage * damageWeight + maxMana * maxManaWeight + initialMana * initialManaWeight + hp * hpWeight + critChance * critChanceWeight + critMultiplier * critMultiplierWeight;
                powerLevel +=
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

                // Alistar-Aphelios-Fiddlesticks-Janna-Leona-Mordekaiser-Nunu-Syndra
            }

            return Convert.ToInt32(powerLevel);
        }

    }
}
