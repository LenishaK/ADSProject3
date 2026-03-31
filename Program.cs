using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph unweightedGraph = new Graph();
            Graph weightedGraph = new Graph();

            // Sample data in case CSV is not loaded yet
            unweightedGraph.AddEdge("Alicia", "Britney");
            unweightedGraph.AddEdge("Britney", "Claire");
            unweightedGraph.AddEdge("Claire", "Diana");
            unweightedGraph.AddEdge("Diana", "Edward");
            unweightedGraph.AddEdge("Diana", "Harry");
            unweightedGraph.AddEdge("Edward", "Harry");
            unweightedGraph.AddEdge("Edward", "Gloria");
            unweightedGraph.AddEdge("Edward", "Fred");
            unweightedGraph.AddEdge("Gloria", "Fred");
            unweightedGraph.AddEdge("Harry", "Gloria");

            weightedGraph.AddEdge("A", "B", 1);
            weightedGraph.AddEdge("A", "C", 1);
            weightedGraph.AddEdge("A", "E", 5);
            weightedGraph.AddEdge("B", "C", 4);
            weightedGraph.AddEdge("B", "E", 1);
            weightedGraph.AddEdge("B", "G", 1);
            weightedGraph.AddEdge("B", "H", 1);
            weightedGraph.AddEdge("C", "D", 3);
            weightedGraph.AddEdge("C", "E", 1);
            weightedGraph.AddEdge("D", "E", 2);
            weightedGraph.AddEdge("D", "F", 1);
            weightedGraph.AddEdge("D", "G", 5);
            weightedGraph.AddEdge("E", "G", 2);
            weightedGraph.AddEdge("F", "G", 1);
            weightedGraph.AddEdge("G", "H", 2);
            weightedGraph.AddEdge("H", "I", 3);
            weightedGraph.AddEdge("I", "J", 3);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ADS Project 3: Recognising Key Influencers ===");
                Console.WriteLine("1. Show unweighted graph");
                Console.WriteLine("2. Show weighted graph");
                Console.WriteLine("3. Calculate unweighted influence scores");
                Console.WriteLine("4. Calculate weighted influence scores");
                Console.WriteLine("5. Load unweighted graph from CSV");
                Console.WriteLine("6. Load weighted graph from CSV");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("UNWEIGHTED GRAPH");
                        unweightedGraph.PrintGraph();
                        Pause();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("WEIGHTED GRAPH");
                        weightedGraph.PrintGraph();
                        Pause();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("UNWEIGHTED INFLUENCE SCORES");
                        ShowInfluenceScores(Algorithms.InfluenceUnweighted(unweightedGraph));
                        Pause();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("WEIGHTED INFLUENCE SCORES");
                        ShowInfluenceScores(Algorithms.InfluenceWeighted(weightedGraph));
                        Pause();
                        break;

                    case "5":
                        Console.Clear();
                        try
                        {
                            unweightedGraph = CsvLoader.LoadUnweightedGraphFromCsv();
                            Console.WriteLine("Unweighted graph loaded successfully from CSV.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error loading unweighted CSV: " + ex.Message);
                        }
                        Pause();
                        break;

                    case "6":
                        Console.Clear();
                        try
                        {
                            weightedGraph = CsvLoader.LoadWeightedGraphFromCsv();
                            Console.WriteLine("Weighted graph loaded successfully from CSV.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error loading weighted CSV: " + ex.Message);
                        }
                        Pause();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Pause();
                        break;
                }
            }
        }

        static void ShowInfluenceScores(Dictionary<string, double> scores)
        {
            foreach (var item in scores)
            {
                Console.WriteLine($"{item.Key}: {item.Value:F2}");
            }

            if (scores.Count > 0)
            {
                var top = scores.First();
                Console.WriteLine();
                Console.WriteLine($"Most influential node: {top.Key} with score {top.Value:F2}");
            }
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}