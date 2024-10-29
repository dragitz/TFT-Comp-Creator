using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

                float preferredTraitWeight = 2.0f; // anti bias

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

            // Min BP on highest trait

            //string HighestTrait = JTraits.Properties().Aggregate((max, current) => (int)max.Value > (int)current.Value ? max : current).Name;
            //int HighestTraitValue = (int)JTraits[HighestTrait];
            //
            //JArray BP_list = Master["TraitList"][HighestTrait]["Breakpoints"];
            //
            //int total_BP = 0;
            //foreach (int BP in BP_list)
            //{
            //    if (HighestTraitValue > BP)
            //        total_BP++;
            //}
            //if (total_BP < Convert.ToInt32(min_bp_main_trait.Value))
            //    return false;


            // Spatula traits can be added here (to be coded)
            int found = 0;
            int mustFind = include_spatula.Items.Count;

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



            // Ensure n amount of ranged & tank
            if (rangedAmount < Convert.ToInt32(minRanged.Value) || rangedAmount > Convert.ToInt32(maxRanged.Value)) { return false; }
            if (tankAmount < Convert.ToInt32(minTank.Value) || tankAmount > Convert.ToInt32(maxTank.Value)) { return false; }

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
            int InactiveTraits = 0;

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

                // Do not let traits overflow unique traits
                int ChampionsInTrait = (int)Master["TraitChampions"][Trait].Count; // This is a test, might leave it here
                int maxBreakpointValue = (int)Master["TraitList"][Trait]["Breakpoints"][totalBreakPoints - 1]; // This is a test, might leave it here

                if ((int)JTraits[Trait] > maxBreakpointValue && maxBreakpointValue == 1)
                    return false;

                // Make sure the trait is active
                // Trait must not be unique per champion (eg. a 5 cost that has its own trait does not count as having more active traits), aka more than 1 BP
                if ((int)JTraits[Trait] >= minBreakPoint && totalBreakPoints > 1)
                {
                    for (int i = 0; i < include_trait.Items.Count; i++)
                    {
                        if (Trait == include_trait.Items[i].ToString() && !IncludedTraitFoundLIst.Contains(Trait))
                            IncludedTraitFoundLIst.Add(Trait);
                    }

                    ActiveTraits++;

                    JTraits_active.Add(Trait);

                    bool isBalanced = false;
                    for (int i = 0; i < totalBreakPoints; i++)
                    {
                        if ((int)Master["TraitList"][Trait]["Breakpoints"][i] == (int)JTraits[Trait]) // 
                        {

                            isBalanced = true;
                            if (totalBreakPoints > 1 && i > 0)
                            {
                                TotalUpgrades += i;
                            }

                        }
                    }

                    if (!isBalanced && no_error.Checked) { return false; }


                }
                else
                {
                    if (totalBreakPoints > 1)
                    {
                        InactiveTraits++;
                        if (InactiveTraits > Convert.ToInt32(maxInctiveTraits.Value)) { return false; }
                    }

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

            // Ensure specified spatula items are considered to be active
            //foreach(string currentSpatulaTrait in include_spatula.Items)
            //{
                //if (!IncludedTraitFoundLIst.Contains(currentSpatulaTrait)) { return false; }
            //}


            // Ensure desired traits are active
            if (include_trait.Items.Count != IncludedTraitFoundLIst.Count) { return false; }

            // Ensure minimum amount of upgrades
            if (TotalUpgrades < minUpgrades.Value) { return false; }

            // less than x traits makes the comp invalid
            if (ActiveTraits < Convert.ToInt32(minActiveTraits.Value) || ActiveTraits > Convert.ToInt32(maxActiveTraits.Value)) { return false; }


            return true;
        }


    }
}
