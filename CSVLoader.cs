using System;
using System.IO;
using System.Linq;

namespace ADSProject3
{
    public static class CsvLoader
    {
        public static Graph LoadUnweightedGraphFromCsv()
        {
            Graph graph = new Graph();

            string filePath = Path.Combine(AppContext.BaseDirectory, "unweighted_network.csv");

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');

                if (parts.Length >= 2)
                {
                    string node1 = parts[0].Trim();
                    string node2 = parts[1].Trim();

                    graph.AddEdge(node1, node2);
                }
            }

            return graph;
        }

        public static Graph LoadWeightedGraphFromCsv()
        {
            Graph graph = new Graph();

            string filePath = Path.Combine(AppContext.BaseDirectory, "weighted_network.csv");

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');

                if (parts.Length >= 3)
                {
                    string node1 = parts[0].Trim();
                    string node2 = parts[1].Trim();
                    int weight = int.Parse(parts[2].Trim());

                    graph.AddEdge(node1, node2, weight);
                }
            }

            return graph;
        }
    }
}