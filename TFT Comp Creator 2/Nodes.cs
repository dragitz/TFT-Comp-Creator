﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using static TFT_Comp_Creator_2.Utility;

namespace TFT_Comp_Creator_2
{
    class Nodes
    {
        public static dynamic Master = new JObject();

        public static CheckBox limit_champions_cost_5 = new CheckBox();
        public static CheckBox disable_champions_cost_1 = new CheckBox();
        public static CheckBox disable_champions_cost_2 = new CheckBox();
        public static CheckBox disable_champions_cost_3 = new CheckBox();
        public static CheckBox disable_champions_cost_4 = new CheckBox();
        public static CheckBox disable_champions_cost_5 = new CheckBox();
        public static CheckBox disable_champions_cost_5_more = new CheckBox();

        public static ListBox exclude_trait = new ListBox();

        public static void SetNodes(
            JObject _Master,
            CheckBox limit_champions_cost_5_,
            CheckBox disable_champions_cost_1_,
            CheckBox disable_champions_cost_2_,
            CheckBox disable_champions_cost_3_,
            CheckBox disable_champions_cost_4_,
            CheckBox disable_champions_cost_5_,
            CheckBox disable_champions_cost_5_more_,
            ListBox exclude_trait_
        )
        {
            Master = _Master;

            limit_champions_cost_5 = limit_champions_cost_5_;
            disable_champions_cost_1 = disable_champions_cost_1_;
            disable_champions_cost_2 = disable_champions_cost_2_;
            disable_champions_cost_3 = disable_champions_cost_3_;
            disable_champions_cost_4 = disable_champions_cost_4_;
            disable_champions_cost_5 = disable_champions_cost_5_;
            disable_champions_cost_5_more = disable_champions_cost_5_more_;

            exclude_trait = exclude_trait_;
        }

        static int CountSharedTraits(JArray chosenChampion_traits, JArray traits)
        {

            int sharedTraits = 0;

            for (int q = 0; q < chosenChampion_traits.Count; q++)
            {
                string cTrait = (string)chosenChampion_traits[q];

                for (int i = 0; i < traits.Count; i++)
                {
                    if (cTrait == (string)traits[i])
                    {
                        sharedTraits++;
                    }
                }
            }

            return sharedTraits;
        }

        public static List<string> GetChampionNodes(string chosen_champion)
        {
            JArray chosen_champion_traits = Master["Champions"][chosen_champion]["Traits"];

            JObject champion_list = Master["Champions"];

            List<string> nodes = new List<string>();

            foreach (dynamic item in champion_list)
            {
                string current_champion = item.Value["ChampionName"];
                JArray traits = item.Value["Traits"];

                if (CountSharedTraits(chosen_champion_traits, traits) > 0)
                {
                    nodes.Add(current_champion);
                }
            }

            return nodes;
        }

        public static List<string> Carry()
        {
            JArray cost4 = Master["Costs"]["4"];

            List<string> nodes = new List<string>();


            return nodes;
        }
    }
}