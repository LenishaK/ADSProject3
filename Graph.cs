using System;
using System.Collections.Generic;

namespace ADSProject3
{
    public class Graph
    {
        private Dictionary<string, List<(string neighbour, int weight)>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<string, List<(string neighbour, int weight)>>();
        }

        public IEnumerable<string> Nodes => adjacencyList.Keys;

        public void AddNode(string node)
        {
            if (!adjacencyList.ContainsKey(node))
            {
                adjacencyList[node] = new List<(string neighbour, int weight)>();
            }
        }

        public void AddEdge(string node1, string node2, int weight = 1)
        {
            AddNode(node1);
            AddNode(node2);

            adjacencyList[node1].Add((node2, weight));
            adjacencyList[node2].Add((node1, weight));
        }

        public List<(string neighbour, int weight)> GetNeighbours(string node)
        {
            return adjacencyList[node];
        }

        public void PrintGraph()
        {
            foreach (var node in adjacencyList)
            {
                Console.Write($"{node.Key} -> ");
                foreach (var neighbour in node.Value)
                {
                    Console.Write($"({neighbour.neighbour}, weight={neighbour.weight}) ");
                }
                Console.WriteLine();
            }
        }
    }
}