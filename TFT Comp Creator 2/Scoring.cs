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
        private static NumericUpDown max_comp_cost = new NumericUpDown();
        private static NumericUpDown minActiveTraits = new NumericUpDown();
        private static NumericUpDown maxActiveTraits = new NumericUpDown();
        private static NumericUpDown maxInctiveTraits = new NumericUpDown();
        private static NumericUpDown minUpgrades = new NumericUpDown();
        private static NumericUpDown minRanged = new NumericUpDown();
        private static NumericUpDown maxRanged = new NumericUpDown();
        private static NumericUpDown minTank = new NumericUpDown();
        private static NumericUpDown maxTank = new NumericUpDown();
        private static NumericUpDown trait_3_limiter = new NumericUpDown();
        private static NumericUpDown min_upgrades_included = new NumericUpDown();
        private static CheckBox bronze_traits = new CheckBox();
        private static CheckBox carryCheck = new CheckBox();


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
            NumericUpDown max_comp_cost_,
            NumericUpDown minActiveTraits_,
            NumericUpDown maxActiveTraits_,
            NumericUpDown maxInctiveTraits_,
            NumericUpDown minUpgrades_,
            NumericUpDown minRanged_,
            NumericUpDown maxRanged_,
            NumericUpDown minTank_,
            NumericUpDown maxTank_,
            NumericUpDown trait_3_limiter_,
            NumericUpDown min_upgrades_included_,
            ListBox include_spatula_,
            CheckBox bronze_traits_,
            CheckBox carryCheck_
            )
        {
            Master = M;
            no_error = NO;
            exclusion_allow_base_trait = exclusion_allow_base_trait_;
            max_cost_5_amount = max_cost_5_amount_;
            max_cost_4_amount = max_cost_4_amount_;
            max_cost_3_amount = max_cost_3_amount_;
            max_cost_2_amount = max_cost_2_amount_;
            max_cost_1_amount = max_cost_1_amount_;
            max_comp_cost = max_comp_cost_;
            minActiveTraits = minActiveTraits_;
            maxActiveTraits = maxActiveTraits_;
            maxInctiveTraits = maxInctiveTraits_;
            minUpgrades = minUpgrades_;
            minRanged = minRanged_;
            maxRanged = maxRanged_;
            minTank = minTank_;
            maxTank = maxTank_;
            trait_3_limiter = trait_3_limiter_;
            min_upgrades_included = min_upgrades_included_;

            include_spatula = include_spatula_;

            bronze_traits = bronze_traits_;
            carryCheck = carryCheck_;

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
        public static int CalculateSynergy(List<string> comp, List<string> excluded_comp_champions, List<string> tempIncludeTrait, List<string> tempIncludeSpatula)
        {
            if (ForceStop) { return 0; }

            /*
            List<string> excluded_comp_champions = excludedComp.Text.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(s => s.Trim())
                                       .ToList();

            // Temporary lists for traits and spatulas to avoid modifying the original ListBox items
            List<string> tempIncludeTrait = include_trait.Items.Cast<string>().ToList();
            List<string> tempIncludeSpatula = include_spatula.Items.Cast<string>().ToList();
            */

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
                float synergyScore = 0;
                List<string> userPreferredTraits = new List<string>();

                foreach (string trait in tempIncludeTrait)
                {
                    userPreferredTraits.Add(trait);
                }
                foreach (string trait in tempIncludeSpatula)
                {
                    userPreferredTraits.Add(trait);
                }
                foreach (string champion in include_champion.Items)
                {
                    JArray traits = Master["Champions"][champion]["Traits"];
                    foreach (string trait in traits)
                    {
                        userPreferredTraits.Add(trait);
                    }
                }

                // This weight helps with scoring a comp that adheres to included traits
                // meaning preferences have a higher impact (1.3 - 2.0 is an ok range)
                float preferredTraitWeight = 1.3f; // anti bias

                object lockObject = new object();

                foreach (var champ in comp)
                {
                    var traits = championsData[champ];

                    foreach (var trait in traits)
                    {
                        float traitContribution = comp.Count(f => championsData[f].Contains(trait));

                        // Check if the trait is in the user's preferred traits list
                        if (userPreferredTraits != null && userPreferredTraits.Contains(trait))
                        {
                            // If the trait is preferred, apply a higher weight
                            traitContribution *= preferredTraitWeight;
                        }

                        synergyScore += traitContribution;
                    }
                }


                // Spatula traits / Headliners
                foreach (var champTraits in championsData.Values)
                {
                    // Increase synergy score if the trait is present in the List<string> comp
                    synergyScore += champTraits.Count(trait => tempIncludeSpatula.Contains(trait));
                }


                // Return the total synergy score
                return Convert.ToInt32(synergyScore);
            }
            catch (Exception) { return 0; } // This should never get hit, in case it happens the search will stop

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
        public static bool CheckCompValidity(List<string> comp, List<string> excluded_comp_champions)
        {

            JObject JTraits = new JObject();
            List<string> JTraits_active = new List<string>();

            int cost5Amount = 0;
            int cost4Amount = 0;
            int cost3Amount = 0;
            int cost2Amount = 0;
            int cost1Amount = 0;
            int totalCost = 0;

            int rangedAmount = 0;
            int tankAmount = 0;


            List<string> TraitsInComp = new List<string>();

            foreach (var champion in comp)
            {
                // Avoid contected comp
                if (excluded_comp_champions.Contains(champion)) { return false; }

                int cost = (int)Master["Champions"][champion]["cost"];

                if ((int)Master["Champions"][champion]["stats"]["range"] >= 4)
                    rangedAmount++;

                if ((int)Master["Champions"][champion]["stats"]["range"] <= 1)
                    tankAmount++;


                // Count the amount of 5 cost champions
                switch (cost)
                {
                    case 1:
                        if (disable_champions_cost_1.Checked) { return false; }
                        cost1Amount++;
                        totalCost += 1;
                        break;
                    case 2:
                        if (disable_champions_cost_2.Checked) { return false; }
                        cost2Amount++;
                        totalCost += 2;
                        break;
                    case 3:
                        if (disable_champions_cost_3.Checked) { return false; }
                        cost3Amount++;
                        totalCost += 3;
                        break;
                    case 4:
                        if (disable_champions_cost_4.Checked) { return false; }
                        cost4Amount++;
                        totalCost += 4;
                        break;
                    case 5:
                        if (disable_champions_cost_5.Checked) { return false; }
                        cost5Amount++;
                        totalCost += 5;
                        break;
                }

                if (totalCost > Convert.ToInt32(max_comp_cost.Value))
                    return false;

                if (cost > 5 && disable_champions_cost_5_more.Checked)
                    return false;

                // Size can't be higher than x
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

            // this one isn't good, keep it for reference
            //if (!CarryWorth(JTraits, comp)) { return false; }

            // this one focuses on 4 cost
            //if (!CarryWorth2(JTraits, comp)) { return false; }

            // this one focuses on included champions
            if (include_champion.Items.Count > 0 && carryCheck.Checked)
            {
                List<string> carry = new List<string>();
                foreach(string champion in  include_champion.Items)
                {
                    carry.Add(champion);
                }
                if (!CarryWorth3(JTraits, carry)) { return false; }
            }


            // Ensure n amount of ranged & tank
            if (rangedAmount < Convert.ToInt32(minRanged.Value) || rangedAmount > Convert.ToInt32(maxRanged.Value)) { return false; }
            if (tankAmount < Convert.ToInt32(minTank.Value) || tankAmount > Convert.ToInt32(maxTank.Value)) { return false; }

            // Ensure all emblems can be used
            if (!canSpatulaBeUsed(JTraits, comp) && include_spatula.Items.Count > 0)
                return false;

            // Add spatula to jtraits
            foreach (string trait in include_spatula.Items)
            {
                if (JTraits.ContainsKey(trait))
                {
                    JTraits[trait] = (int)JTraits[trait] + 1;
                }
                else { JTraits[trait] = 1; }
            }

            //
            // Check if comp is balanced
            if (no_error.Checked && !isCompBalanced(JTraits))
                return false;


            // Included / Excluded champion check
            if (exclude_champion.Items.Count > 0)
            {
                foreach (string champion in exclude_champion.Items)
                {
                    //excluded_champions.Add(champion);
                    if (isChampionPresent(comp, champion))
                        return false;
                }

            }

            if (include_champion.Items.Count > 0)
            {
                foreach (string champion in include_champion.Items)
                {
                    //excluded_champions.Add(champion);
                    if (!isChampionPresent(comp, champion))
                        return false;
                }
            }



            // Included / Excluded trait check
            foreach (string Trait in include_trait.Items)
            {
                if (!isTraitActive(JTraits, Trait))
                    return false;
            }

            foreach (string Trait in exclude_trait.Items)
            {
                if (!exclusion_allow_base_trait.Checked)
                {
                    if (isTraitActive(JTraits, Trait))
                        return false;
                }
                else
                {
                    int BP = CheckBreakPointAmount(JTraits, Trait);

                    if (isTraitActive(JTraits, Trait) && BP > 1)
                        return false;
                }
            }

            
       

            // Ensure specified emblems are used
            foreach (string Trait in include_spatula.Items)
            {
                if (!isTraitActive(JTraits, Trait))
                    return false;
            }

            // Get ActiveTraits
            // Get InactiveTraits
            int ActiveTraits = 0;
            int InactiveTraits = 0;
            foreach (dynamic Obj in JTraits.Properties())
            {
                string Trait = Obj.Name;

                // All bronze traits check
                if (bronze_traits.Checked)
                {
                    int BP = CheckBreakPointAmount(JTraits, Trait);
                    if(BP > 1) { return false; }
                }

                if (isTraitActive(JTraits, Trait))
                {
                    ActiveTraits++;
                }
                else
                {
                    InactiveTraits++;
                }
            }
            if (InactiveTraits > Convert.ToInt32(maxInctiveTraits.Value)) { return false; }
            if (ActiveTraits < Convert.ToInt32(minActiveTraits.Value) || ActiveTraits > Convert.ToInt32(maxActiveTraits.Value)) { return false; }


            // Get TotalUpgrades
            if (getTotalUpgrades(JTraits) < minUpgrades.Value) { return false; }


            // Min upgrades for specified (included) traits
            int min_upgrades_included_value = Convert.ToInt32(min_upgrades_included.Value);
            if (min_upgrades_included_value > 0)
            {
                for (int i = 0; i < include_trait.Items.Count; i++)
                {
                    string include_trait_name = (string)include_trait.Items[i];

                    int breakpoints_hit = CheckBreakPointAmount(JTraits, include_trait_name);
                    if (breakpoints_hit < min_upgrades_included_value)
                        return false;
                }
            }

            // Check if all champions have contributed to the whole comp
            foreach (string champion in comp)
            {
                List<string> champion_traits = GetTraitsFromChampion(champion);
                //bool has_contributed = false;
                foreach (string trait in champion_traits)
                {
                    if (isTraitActive(JTraits, trait))
                        JTraits_active.Add(trait);
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

            return true;
        }

    }
}
