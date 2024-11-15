using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using static TFT_Comp_Creator_2.Utility;

namespace TFT_Comp_Creator_2
{
    public class Setup
    {
        public static ListBox exclude_trait = new ListBox();
        public static ListBox default_trait = new ListBox();
        public static ListBox include_trait = new ListBox();
        public static ListBox exclude_champion = new ListBox();
        public static ListBox default_champion = new ListBox();
        public static ListBox include_champion = new ListBox();
        public static ListBox default_spatula = new ListBox();
        public static ListBox include_spatula = new ListBox();

        public static ComboBox setList = new ComboBox();


        public static void SetFormSetup(
            ListBox exclude_trait_,
            ListBox default_trait_,
            ListBox include_trait_,
            ListBox exclude_champion_,
            ListBox default_champion_,
            ListBox include_champion_,
            ListBox default_spatula_,
            ListBox include_spatula_,
            ComboBox setList_
        )
        {
            exclude_trait = exclude_trait_;
            default_trait = default_trait_;
            include_trait = include_trait_;
            exclude_champion = exclude_champion_;
            default_champion = default_champion_;
            include_champion = include_champion_;
            default_spatula = default_spatula_;
            include_spatula = include_spatula_;
            setList = setList_;
        }



        public static dynamic FirstRun(int setData_ID)
        {
            try
            {
                dynamic Master = new JObject(
                    new JProperty("Champions", new JObject()),
                    new JProperty("TraitList", new JObject()),
                    new JProperty("TraitChampions", new JObject()),
                    new JProperty("Costs", new JObject(
                            new JProperty("1", new JArray()),
                            new JProperty("2", new JArray()),
                            new JProperty("3", new JArray()),
                            new JProperty("4", new JArray()),
                            new JProperty("5", new JArray())
                        ))
                );

                // Create temporary space
                JObject JDownload = new JObject();

                string url = "https://raw.communitydragon.org/latest/cdragon/tft/en_us.json";
                url = "https://raw.communitydragon.org/pbe/cdragon/tft/en_us.json";

                // If our custom file already exists, then load it
                //if (File.Exists("set.json")) { Master = JObject.Parse(File.ReadAllText("set.json")); Print("File loaded! "); return Master; }



                if (!File.Exists("en_us.json"))
                {

                    Print("Downloaded " + url + Environment.NewLine);

                    // If our file does not exist, we download it (this is the link for the most recent update)
                    //var downloaded = new WebClient().DownloadString("https://raw.communitydragon.org/latest/cdragon/tft/en_us.json");
                    var downloaded = new WebClient().DownloadString(url);
                    JDownload = JObject.Parse(downloaded);

                    File.WriteAllText("en_us.json", JDownload.ToString());
                }
                else
                {

                    Print("Set loaded " + Environment.NewLine);
                    JDownload = JObject.Parse(File.ReadAllText("en_us.json")); ;
                }

                // 26 October 2024: fill setup combo box to enable set switching
                if (setList.Items.Count == 0)
                {
                    dynamic setData = JDownload["setData"];
                    foreach (dynamic obj in setData)
                    {
                        setList.Items.Add(obj["mutator"]);
                    }

                    setList.SelectedIndex = 1;
                }

                // now that we got our file, it's time to process it
                // 1) Put all champions into the Champions object
                // 2) Put all traits into Trait_List & Populate Trait_Champions
                // 3) Put all champions into the their respective traits in Trait_Champions

                // Store basic info
                dynamic TraitList = JDownload["setData"][setData_ID]["traits"];
                dynamic ChampionList = JDownload["setData"][setData_ID]["champions"];

                // Create population of traits
                int i = 0;
                foreach (dynamic items in TraitList)
                {
                    if (i == TraitList.Count) { break; }

                    // Store current trait
                    int breakPoints = (int)JDownload["setData"][setData_ID]["traits"][i]["effects"].Count();

                    string TraitName = (string)JDownload["setData"][setData_ID]["traits"][i]["name"];

                    if (breakPoints <= 0) { i++; continue; } // Undanted stuff

                    // Add trait to the trait list with their respective min breakpoints
                    JArray br = new JArray();
                    for (int b = 0; b < breakPoints; b++)
                    {
                        int en = (int)JDownload["setData"][setData_ID]["traits"][i]["effects"][b]["minUnits"];

                        br.Add(en);
                    }


                    // Insert trait's peroperties
                    string Trait = (string)JDownload["setData"][setData_ID]["traits"][i]["name"];
                    
                    JProperty item_properties =
                        new JProperty(Trait,
                            new JObject(
                                new JProperty("Breakpoints", br)
                            )
                        );
                    Master["TraitList"].Add(item_properties);


                    // Also add it as an array
                    JObject adder = (JObject)Master["TraitChampions"];
                    adder.Add(new JProperty(Trait, new JArray()));

                    i++;
                }




                // Create population of champions
                i = 0;
                foreach (dynamic items in ChampionList)
                {
                    if (i >= ChampionList.Count) { break; }

                    string ChampionName = (string)JDownload["setData"][setData_ID]["champions"][i]["name"];
                    ChampionName = ChampionName.Replace(" & Willump", "");
                    ChampionName = ChampionName.Replace("'", "");

                    // Ignore duplicates, unless the same champion is considered different (compare its traits first)
                    if (Master["Champions"].ContainsKey(ChampionName))
                    {

                        JArray LoggedChampionTraits = Master["Champions"][ChampionName]["Traits"];
                        var PotentialNew = JDownload["setData"][setData_ID]["champions"][i]["traits"];

                        if (LoggedChampionTraits == PotentialNew) { i++; continue; }

                        List<string> Original = LoggedChampionTraits.Select(j => (string)j).ToList();
                        List<string> New = PotentialNew.Select(j => (string)j).ToList();

                        // Find differences
                        // Retrieve elements that are not in common
                        var notInCommon = Original.Except(New).Union(New.Except(Original)).ToList().Last();

                        ChampionName += "-(" + notInCommon + ")";

                    }

                    // Champion info
                    int cost = (int)JDownload["setData"][setData_ID]["champions"][i]["cost"];

                    // Amount of traits the current champion has
                    int traitCount = (int)JDownload["setData"][setData_ID]["champions"][i]["traits"].Count();

                    // Ignore invalid champions, they usually cost more than 5 gold or have no traits
                    if (traitCount < 1 || cost <= 0 || cost > 5) { i++; continue; }

                    // Verify if trait exists in our previously defined traitlist
                    bool should_skip = false;
                    for (int qq = 0; qq < traitCount; qq++)
                    {
                        string currentTrait = (string)JDownload["setData"][setData_ID]["champions"][i]["traits"][qq];

                        // check if it exists
                        if (!Master["TraitChampions"].ContainsKey(currentTrait)) { should_skip = true; break; }
                    }

                    // Check validity
                    JObject obj = (JObject)JDownload["setData"][setData_ID]["champions"][i]["stats"];
                    foreach (var property in obj.Properties())
                    {
                        if (property.Value == null || property.Value.Type == JTokenType.Null)
                        {
                            //should_skip = true;
                            break;
                        }
                    }
                    if (should_skip) { i++; continue; }

                    int Armor = 0;
                    int MagicR = 0;
                    double AtkSpeed = 0;

                    var armorValue = JDownload?["setData"]?[setData_ID]?["champions"]?[i]?["stats"]?["armor"];
                    if (armorValue != null)
                    {
                        Armor = (int)armorValue;
                    }
                    var MRValue = JDownload?["setData"]?[setData_ID]?["champions"]?[i]?["stats"]?["armor"];
                    if (MRValue != null)
                    {
                        Armor = (int)MRValue;
                    }
                    var AtkSpeedValue = JDownload?["setData"]?[setData_ID]?["champions"]?[i]?["stats"]?["armor"];
                    if (AtkSpeedValue != null)
                    {
                        AtkSpeed = (int)AtkSpeedValue;
                    }



                    // Add current champion to its trait list in --> TraitChampions
                    JArray br = new JArray();
                    for (int q = 0; q < traitCount; q++)
                    {
                        string currentTrait = (string)JDownload["setData"][setData_ID]["champions"][i]["traits"][q];
                        Master["TraitChampions"][currentTrait].Add(ChampionName);
                        br.Add(currentTrait);
                    }

                    // Copy stats to champion's structure
                    JObject st = new JObject();

                    var stats = JDownload["setData"][setData_ID]["champions"][i]["stats"];

                    foreach (dynamic item in stats)
                    {
                        st.Add(item);
                    }

                    // Add Champion properties to the champion pool
                    JProperty item_properties = new JProperty(ChampionName,
                        new JObject(
                            new JProperty("ChampionName", ChampionName),
                            new JProperty("cost", cost),
                            new JProperty("Armor", Armor),
                            new JProperty("MR", MagicR),
                            new JProperty("AtkSpeed", AtkSpeed),
                            new JProperty("Traits", br),
                            new JProperty("stats", st)
                        )
                    );

                    Master["Champions"].Add(item_properties);

                    // Add current champion to its relative cost array
                    Master["Costs"][cost.ToString()].Add(ChampionName);

                    // 
                    i++;
                }

                // TODO: If a trait has no champions, it is removed

                File.WriteAllText("set.json", Master.ToString());

                return Master;
            }
            catch (Exception ex) { Print(ex); return Master; }



        }

        public static void Populate(dynamic Master)
        {

            // Champions
            dynamic Champions = Master["Champions"];
            dynamic Traits = Master["TraitList"];

            foreach (dynamic item in Champions)
            {
                JProperty n = (JProperty)item;
                string name = n.Name;

                default_champion.Items.Add(name);

                // TotalChampions++;
            }

            foreach (dynamic item in Traits)
            {


                JProperty n = (JProperty)item;
                string name = n.Name;

                int Amount = Master["TraitChampions"][name].Count;

                if (Amount < 1)
                    continue;

                int bp_total = Master["TraitList"][name]["Breakpoints"].Count;
                int biggest_bp = Master["TraitList"][name]["Breakpoints"][bp_total - 1];

                if (bp_total == 1 && biggest_bp <= 1)
                    continue;

                default_trait.Items.Add(name);

                int totalBreakPoints = Master["TraitList"][name]["Breakpoints"].Count;

                if (totalBreakPoints > 1)
                {


                    // If a trait doesn't have enough champions to fully complete it, it means we have a spatula (or so I think?)
                    int maxBreakpoint = (int)Master["TraitList"][name]["Breakpoints"][Master["TraitList"][name]["Breakpoints"].Count - 1];
                    if (Amount <= maxBreakpoint)
                    {
                        // Include spatulas + headliner
                        for (int i = 0; i < maxBreakpoint - Amount + 1; i++)
                        {
                            default_spatula.Items.Add(name);
                        }

                    }

                    default_spatula.Items.Add(name);
                }

            }
            default_trait.SelectedIndex = 0;


        }

    }
}
