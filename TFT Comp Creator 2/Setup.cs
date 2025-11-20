using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using static TFT_Comp_Creator_2.Form1;
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

        public static void saveToJson()
        {
            var data = new
            {
                Champions = ChampionList,
                Traits = TraitList
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("set.json", json);
        }

        // This function will handle the downloaded set, in case it gets deleted.
        public static void LoadDownloadedSet(JObject JDownload, JObject JDownload_planner)
        {
            // This must be changed every patch
            string SetID = "16";
            string SetName = "TFTSet16";
            int i = 0;

            // Check validity for SetName and SetID
            //if (JDownload["sets"][SetID]["traits"] == null || JDownload_planner[SetName] == null)
            //{
            //    return;
            //}

            JArray plannerArr = (JArray)JDownload_planner[SetName];
            Dictionary<string, string> plannerMap = new Dictionary<string, string>();
            for (int q = 0; q < plannerArr.Count; q++)
            {
                
                string apiName = (string)plannerArr[q]["character_id"];
                string code = (string)plannerArr[q]["team_planner_code"];

                plannerMap.Add(apiName, code);
            }




            // Create trait data
            dynamic DownladedTraitList = JDownload["sets"][SetID]["traits"];
            i = 0;
            foreach (var item in DownladedTraitList)
            {
                Trait tr = new Trait();
                tr.name = (string)JDownload["sets"][SetID]["traits"][i]["name"];

                tr.Breakpoints = new List<int>();
                tr.Champions = new List<string>();

                int breakPoints = (int)JDownload["sets"][SetID]["traits"][i]["effects"].Count();
                for (int q = 0; q < breakPoints; q++)
                {
                    int minValue = (int)JDownload["sets"][SetID]["traits"][i]["effects"][q]["minUnits"];
                    tr.Breakpoints.Add(minValue);
                }

                // will populate later when iterating champions
                tr.Champions = new List<string> { };

                //TraitList[tr.name].Add(tr); // wrong way to do this (
                TraitList.Add(tr.name, tr);

                i++;
            }

            // Iterate all trough champions
            dynamic DownladedChampionList = JDownload["sets"][SetID]["champions"];
            i = 0;
            string role = "";

            foreach (JObject CH in DownladedChampionList)
            {
                // check if champion is valid
                role = (string)JDownload["sets"][SetID]["champions"][i]["role"];
                if (role == null) { i++; continue; }


                Champion Champ = new Champion();
                Champ.name = ((string)JDownload["sets"][SetID]["champions"][i]["name"]).TrimEnd(); // empty space at the end
                Champ.apiName = (string)JDownload["sets"][SetID]["champions"][i]["apiName"];
                Champ.role = (string)JDownload["sets"][SetID]["champions"][i]["role"];
                Champ.cost = (int)JDownload["sets"][SetID]["champions"][i]["cost"];
                if (plannerMap.TryGetValue(Champ.apiName, out string code))
                {
                    Champ.planner_id = code;
                }
                else
                {
                    Champ.planner_id = "";
                    Print("invalid planner_id for champion: " + Champ.name + " - apiName: " + Champ.apiName);
                }




                var statsJson = JDownload["sets"][SetID]["champions"][i]["stats"];
                Champ.stats = new ChampionStats
                {
                    armor = (float?)(statsJson["armor"]) ?? 0f,
                    magicResist = (float?)(statsJson["magicResist"]) ?? 0f,
                    attackSpeed = (float?)(statsJson["attackSpeed"]) ?? 0f,
                    critChance = (float?)(statsJson["critChance"]) ?? 0f,
                    critMultiplier = (float?)(statsJson["critMultiplier"]) ?? 0f,
                    damage = (float?)(statsJson["damage"]) ?? 0f,
                    hp = (float?)(statsJson["hp"]) ?? 0f,
                    initialMana = (float?)(statsJson["initialMana"]) ?? 0f,
                    mana = (float?)(statsJson["mana"]) ?? 0f,
                    range = (int?)(statsJson["range"]) ?? 0
                };


                if ((int)JDownload["sets"][SetID]["champions"][i]["traits"].Count() < 1) { i++; continue; }

                Champ.Traits = new List<string>();
                dynamic CurrentChampionTraits = JDownload["sets"][SetID]["champions"][i]["traits"];
                foreach (string CurrentTrait in CurrentChampionTraits)
                {
                    Champ.Traits.Add(CurrentTrait);

                    // Add current champion to the currently added trait
                    //TraitList[CurrentTrait].Champions.Add(Champ.name); // this only modifies the copy, not update
                    Trait t = TraitList[CurrentTrait];
                    t.Champions.Add(Champ.name);
                    TraitList[CurrentTrait] = t;

                }

                // Keep this empty, I'll manually fill it in the set.json file
                // it's a new thing added to set 16, might remove it in later patches if unused (or null check it)
                Champ.isLocked = false;
                Champ.UnlockConditions = new UnlockConditions();
                
                Champ.UnlockConditions.Champions = new List<string> {};
                Champ.UnlockConditions.minChampions = new List<int> {};

                Champ.UnlockConditions.Traits = new List<string> { };
                Champ.UnlockConditions.TraitMinBP = new List<int> { };

                Champ.UnlockConditions.ChampTraitCount = new List<string> { };
                Champ.UnlockConditions.minChampTraitCount = new List<int> { };

                Champ.UnlockConditions.minLevel = 0;
                Champ.UnlockConditions.isAnd = false;

                //ChampionList.Add(Champ);
                ChampionList.Add(Champ.name, Champ);

                i++;
            }
            saveToJson();

            Print("Unlock data must be manually set in the .json !!");
            Print("Please use the one provided in the download or edit it yourself");
        }


        // This funcion loads the necessary data from the generated set.json file
        public static void LoadSet()
        {
            JObject Data = JObject.Parse(File.ReadAllText("set.json"));

            JObject Traits = (JObject)Data["Traits"];
            foreach (var kv in Traits)
            {
                string traitName = kv.Key;
                var traitJson = kv.Value;

                Trait tr = new Trait();
                tr.name = (string)Data["Traits"][traitName]["name"];

                // c# is weird
                tr.Breakpoints = traitJson["Breakpoints"]?.Select(x => (int)x).ToList() ?? new List<int>();
                tr.Champions = traitJson["Champions"]?.Select(x => (string)x).ToList() ?? new List<string>();

                int breakPoints = Data["Traits"][traitName]["Breakpoints"].Count();
                



                JArray championsArray = (JArray)Data["Traits"][traitName]["Champions"];
                tr.Champions = championsArray.Select(x => (string)x).ToList();

                //TraitList[tr.name].Add(tr); // wrong way to do this (
                TraitList.Add(tr.name, tr);
            }

            ///////////////////////////////////////////////////////////
            JObject Champions = (JObject)Data["Champions"];
            foreach (var kv in Champions)
            {
                string champName = kv.Key;
                var champJson = kv.Value;

                Champion Champ = new Champion();
                Champ.name = (string)Data["Champions"][champName]["name"];
                Champ.apiName = (string)Data["Champions"][champName]["apiName"];
                Champ.role = (string)Data["Champions"][champName]["role"];
                Champ.cost = (int)Data["Champions"][champName]["cost"];
                Champ.planner_id = (string)Data["Champions"][champName]["planner_id"];

                var statsJson = Data["Champions"][champName]["stats"];
                Champ.stats = new ChampionStats
                {
                    armor = (float?)(statsJson["armor"]) ?? 0f,
                    magicResist = (float?)(statsJson["magicResist"]) ?? 0f,
                    attackSpeed = (float?)(statsJson["attackSpeed"]) ?? 0f,
                    critChance = (float?)(statsJson["critChance"]) ?? 0f,
                    critMultiplier = (float?)(statsJson["critMultiplier"]) ?? 0f,
                    damage = (float?)(statsJson["damage"]) ?? 0f,
                    hp = (float?)(statsJson["hp"]) ?? 0f,
                    initialMana = (float?)(statsJson["initialMana"]) ?? 0f,
                    mana = (float?)(statsJson["mana"]) ?? 0f,
                    range = (int?)(statsJson["range"]) ?? 0
                };


                Champ.Traits = new List<string>();
                dynamic CurrentChampionTraits = (JArray)Data["Champions"][champName]["Traits"];
                
                foreach (string CurrentTrait in CurrentChampionTraits)
                {
                    Champ.Traits.Add(CurrentTrait);

                    // Add current champion to the currently added trait
                    //TraitList[CurrentTrait].Champions.Add(Champ.name); // this only modifies the copy, not update
                    Trait t = TraitList[CurrentTrait];
                    t.Champions.Add(Champ.name);
                    TraitList[CurrentTrait] = t;

                }

                Champ.isLocked = (bool)Data["Champions"][champName]["isLocked"];
                
                Champ.UnlockConditions = new UnlockConditions();

                // sorry for the ugly naming, it's my own pet project after all !
                JArray unlockChampionsArray = (JArray)Data["Champions"][champName]["UnlockConditions"]["Champions"];
                JArray unlockChampionsArrayminChampions = (JArray)Data["Champions"][champName]["UnlockConditions"]["minChampions"];
                Champ.UnlockConditions.Champions = unlockChampionsArray.Select(x => (string)x).ToList();
                Champ.UnlockConditions.minChampions = unlockChampionsArrayminChampions.Select(x => (int)x).ToList();

                JArray unlockChampionsArrayTraits = (JArray)Data["Champions"][champName]["UnlockConditions"]["Traits"];
                JArray unlockChampionsArrayTraitMinBP = (JArray)Data["Champions"][champName]["UnlockConditions"]["TraitMinBP"];
                Champ.UnlockConditions.Traits = unlockChampionsArrayTraits.Select(x => (string)x).ToList();
                Champ.UnlockConditions.TraitMinBP = unlockChampionsArrayTraitMinBP.Select(x => (int)x).ToList();

                JArray unlockChampionsArrayChampTraitCount = (JArray)Data["Champions"][champName]["UnlockConditions"]["ChampTraitCount"];
                JArray unlockChampionsArrayminChampionsChampTraitCount = (JArray)Data["Champions"][champName]["UnlockConditions"]["minChampTraitCount"];
                Champ.UnlockConditions.ChampTraitCount = unlockChampionsArrayChampTraitCount.Select(x => (string)x).ToList();
                Champ.UnlockConditions.minChampTraitCount = unlockChampionsArrayminChampionsChampTraitCount.Select(x => (int)x).ToList();

                Champ.UnlockConditions.minLevel = (int)Data["Champions"][champName]["UnlockConditions"]["minLevel"];
                Champ.UnlockConditions.isAnd = (bool)Data["Champions"][champName]["UnlockConditions"]["isAnd"];


                //ChampionList.Add(Champ);
                ChampionList.Add(Champ.name, Champ);
            }
            Print("Loaded set");
        }

        public static void FirstRun(int setData_ID)
        {

            // Create temporary space
            JObject JDownload = new JObject();
            JObject JDownload_planner = new JObject();

            string url = "https://raw.communitydragon.org/pbe/cdragon/tft/en_us.json";
            string url_comp_codes = "https://raw.communitydragon.org/pbe/plugins/rcp-be-lol-game-data/global/default/v1/tftchampions-teamplanner.json";

            // If our custom file already exists, then load it
            if (File.Exists("set.json"))
            {
                Print("Loading from set.json..." + Environment.NewLine);
                LoadSet();
                return;
            }

            // Download necessary files if they don't exist
            if (!File.Exists("en_us.json"))
            {
                Print("Downloading " + url + Environment.NewLine);
                var downloaded = new WebClient().DownloadString(url);
                JDownload = JObject.Parse(downloaded);
                File.WriteAllText("en_us.json", JDownload.ToString());
            }
            else
            {
                JDownload = JObject.Parse(File.ReadAllText("en_us.json"));
            }

            if (!File.Exists("tftchampions-teamplanner.json"))
            {
                Print("Downloading " + url_comp_codes + Environment.NewLine);
                var downloaded_planner = new WebClient().DownloadString(url_comp_codes);
                JDownload_planner = JObject.Parse(downloaded_planner);
                File.WriteAllText("tftchampions-teamplanner.json", JDownload_planner.ToString());
            }
            else
            {
                JDownload_planner = JObject.Parse(File.ReadAllText("tftchampions-teamplanner.json"));
            }

            LoadDownloadedSet(JDownload, JDownload_planner);
        }

        public static void Populate()
        {
            // Champions
            foreach (string name in ChampionList.Keys)
            {
                default_champion.Items.Add(name);
            }

            foreach (string name in TraitList.Keys)
            {
                var trait = TraitList[name];

                int Amount = trait.Champions.Count;
                if (Amount < 1)
                    continue;

                int bp_total = trait.Breakpoints.Count;
                if (bp_total == 0)
                    continue; // niente breakpoints, salta

                int biggest_bp = trait.Breakpoints[bp_total - 1]; // ultimo valore sicuro

                if (bp_total == 1 && biggest_bp <= 1)
                    continue;

                default_trait.Items.Add(name);

                if (bp_total > 1)
                {
                    int maxBreakpoint = biggest_bp;

                    if (Amount <= maxBreakpoint)
                    {
                        for (int i = 0; i < maxBreakpoint - Amount + 1; i++)
                        {
                            default_spatula.Items.Add(name);
                        }
                    }

                    default_spatula.Items.Add(name);
                }
            }

            if (default_trait.Items.Count > 0)
                default_trait.SelectedIndex = 0;
        }

    }
}
