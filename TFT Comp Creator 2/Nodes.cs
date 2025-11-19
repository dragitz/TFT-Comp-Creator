using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace TFT_Comp_Creator_2
{
    class Nodes
    {

        public static NumericUpDown max_cost_5_amount = new NumericUpDown();
        public static CheckBox disable_champions_cost_1 = new CheckBox();
        public static CheckBox disable_champions_cost_2 = new CheckBox();
        public static CheckBox disable_champions_cost_3 = new CheckBox();
        public static CheckBox disable_champions_cost_4 = new CheckBox();
        public static CheckBox disable_champions_cost_5 = new CheckBox();
        public static CheckBox disable_champions_cost_5_more = new CheckBox();

        public static ListBox exclude_trait = new ListBox();

        public static void SetNodes(
            NumericUpDown max_cost_5_amount_,
            CheckBox disable_champions_cost_1_,
            CheckBox disable_champions_cost_2_,
            CheckBox disable_champions_cost_3_,
            CheckBox disable_champions_cost_4_,
            CheckBox disable_champions_cost_5_,
            CheckBox disable_champions_cost_5_more_,
            ListBox exclude_trait_
        )
        {
            max_cost_5_amount = max_cost_5_amount_;
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

    }
}
