using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static TFT_Comp_Creator_2.Form1;
using static TFT_Comp_Creator_2.Utility;

namespace TFT_Comp_Creator_2
{
    class Markov
    {
        public class Node
        {
            public int Synergy { get; set; } = 0;
            public int Visits { get; set; } = 0;

            // Will contain the championId of the comp (for faster iteration)
            public List<int> comp { get; set; } = new List<int>();

            public List<Node> Subnodes { get; set; } = new List<Node>();
        }

        public static Dictionary<string, Node> seen = new Dictionary<string, Node>();
        public static int RecordVisits = 0;
        public static Node BestNode = new Node();

        private static string CompKey(List<int> comp)
        {
            return string.Join(",", comp);
        }

        public static void GetHighestVisitedNode(Node node)
        {

            // Find highest visited node
            for (int i = 0; i < node.Subnodes.Count; i++)
            {
                GetHighestVisitedNode(node.Subnodes[i]);
            }


            if (node.Visits > RecordVisits && node.comp.Count <= 5)
            {
                BestNode = node;
                RecordVisits = node.Visits;

                // Get string names given indexes
                List<string> compStr = new List<string>();
                for (int j = 0; j < node.comp.Count; j++)
                {
                    int index = node.comp[j];
                    string name = ChampionList.Keys.ToList()[index];
                    compStr.Add(name);
                }

                Print("Best node: " + BestNode.Visits);
                PrintComp(compStr, 0);

            }

        }

        public static void ExpandNode(Node node, Dictionary<string, Champion> ChampionList, int depth)
        {
            if (depth <= 0) { return; }

            GetNextNode(node, ChampionList);

            for (int i = 0; i < node.Subnodes.Count; i++)
            {
                ExpandNode(node.Subnodes[i], ChampionList, depth - 1);
            }

        }

        // Markov tree
        public static void mk(ListBox include_champion, Dictionary<string, Champion> ChampionList, Dictionary<string, Trait> TraitList)
        {
            // Reset
            seen.Clear();
            RecordVisits = 0;
            BestNode = new Node(); // empty



            // This will hold everything
            Node Root = new Node();


            // Take currently included champions and add them to the comp
            for (int i = 0; i < include_champion.Items.Count; i++)
            {
                string CurrentChampionName = include_champion.Items[i].ToString();

                // Get the id of the champion from the stored one in the setup
                int index = ChampionList.Keys.ToList().IndexOf(CurrentChampionName);

                Root.comp.Add(index);
            }



            // Get first series of nodes
            if (Root.comp.Count == 0)
            {
                //

            }
            else
            {
                
            }
            Root = GetNextNode(Root, ChampionList);
            //Root = GetNextNodeSmart(Root, ChampionList);

            // Now construct new possible nodes
            int depth = 2; // simulate specified nodes in gui, since we already have 1 depth, subtract in for loop
            ExpandNode(Root, ChampionList, depth);

            // Find highest visited node
            GetHighestVisitedNode(Root);

            seen.Clear();
            Node newRoot = BestNode;
            RecordVisits = 0;
            
            // Now iterate from best
            int iterations = 2;
            ExpandNode(newRoot, ChampionList, iterations);
            GetHighestVisitedNode(newRoot);
            
        }

        public static Node GetNextNode(Node node, Dictionary<string, Champion> ChampionList)
        {
            List<string> ChampionListKeys = ChampionList.Keys.ToList();

            // Find all champions not in the node and create a new node with that champion in it
            int totalChampions = ChampionList.Count;
            for (int i = 0; i < totalChampions; i++)
            {
                // Avoid duplicate champions
                if (node.comp.Contains(i)) { continue; }


                // Only allow lvl 1 champions
                string champion = ChampionListKeys[i];
                if (ChampionList[champion].cost != 1) {  continue; }


                Node newNode = new Node();

                newNode.comp = new List<int>(node.comp);
                newNode.comp.Add(i);
                newNode.comp.Sort(); // <--


                //if (!CheckCompValidity(compStr)) { continue; } // removed this due to being an old function and does not what I wanted


                string key = CompKey(newNode.comp);
                if (seen.ContainsKey(key))
                {
                    seen[key].Visits++;
                    node.Subnodes.Add(seen[key]);

                }
                else
                {
                    newNode.Visits++;
                    seen[key] = newNode;
                    node.Subnodes.Add(newNode);
                }

            }

            return node;
        }

        // Same as above, but it considers the chammpions that share at least one trait with all available traits in the node.comp
        public static Node GetNextNodeSmart(Node node, Dictionary<string, Champion> ChampionList)
        {
            List<string> ChampionListKeys = ChampionList.Keys.ToList();
            List<string> compTraits = new List<string>();

            for (int i = 0; i < node.comp.Count; i++)
            {
                int index = node.comp[i];
                string champion = ChampionListKeys[index];

                List<string> currentChampionTraits = GetTraitsFromChampion(champion);

                for (int j = 0; j < currentChampionTraits.Count; j++)
                {
                    string trait = currentChampionTraits[j];
                    if (compTraits.Contains(trait)) { continue; }

                    compTraits.Add(trait);
                }
            }

            List<string> smartChampions = new List<string>();
            for (int i = 0; i < compTraits.Count; i++)
            {
                List<string> championsInTrait = GetChampionsFromTrait(compTraits[i]);
                for (int j = 0; j < championsInTrait.Count; j++)
                {
                    string champ = championsInTrait[j];
                    if (smartChampions.Contains(champ)) { continue; }
                    smartChampions.Add(champ);
                }
            }

            // Now we have our list

            // Find all champions not in the node and create a new node with that champion in it
            int totalChampions = smartChampions.Count;
            for (int i = 0; i < totalChampions; i++)
            {
                int smartChampIndex = ChampionListKeys.IndexOf(smartChampions[i]);

                // Avoid duplicate champions
                if (node.comp.Contains(smartChampIndex)) { continue; }

                Node newNode = new Node();

                newNode.comp = new List<int>(node.comp);
                newNode.comp.Add(smartChampIndex);
                newNode.comp.Sort();

                // Get string names given indexes
                List<string> compStr = new List<string>();
                for (int j = 0; j < newNode.comp.Count; j++)
                {
                    int index = newNode.comp[j];
                    string name = ChampionListKeys[index];
                    compStr.Add(name);
                }


                string key = CompKey(newNode.comp);
                if (seen.ContainsKey(key))
                {
                    seen[key].Visits++;
                    node.Subnodes.Add(seen[key]);
                }
                else
                {
                    newNode.Visits++;
                    seen[key] = newNode;
                    node.Subnodes.Add(newNode);
                }

            }

            return node;
        }

    }

}
