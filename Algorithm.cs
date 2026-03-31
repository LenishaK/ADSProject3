using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject3
{
    public static class Algorithms
    {
        public static Dictionary<string, int> BFS(Graph graph, string start)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            Queue<string> queue = new Queue<string>();

            foreach (string node in graph.Nodes)
            {
                distances[node] = int.MaxValue;
            }

            distances[start] = 0;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();

                foreach (var neighbour in graph.GetNeighbours(current))
                {
                    if (distances[neighbour.neighbour] == int.MaxValue)
                    {
                        distances[neighbour.neighbour] = distances[current] + 1;
                        queue.Enqueue(neighbour.neighbour);
                    }
                }
            }

            return distances;
        }

        public static Dictionary<string, int> Dijkstra(Graph graph, string start)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            HashSet<string> visited = new HashSet<string>();

            foreach (string node in graph.Nodes)
            {
                distances[node] = int.MaxValue;
            }

            distances[start] = 0;

            while (visited.Count < graph.Nodes.Count())
            {
                string current = null;
                int smallestDistance = int.MaxValue;

                foreach (string node in graph.Nodes)
                {
                    if (!visited.Contains(node) && distances[node] < smallestDistance)
                    {
                        smallestDistance = distances[node];
                        current = node;
                    }
                }

                if (current == null)
                {
                    break;
                }

                visited.Add(current);

                foreach (var neighbour in graph.GetNeighbours(current))
                {
                    if (distances[current] != int.MaxValue)
                    {
                        int newDistance = distances[current] + neighbour.weight;

                        if (newDistance < distances[neighbour.neighbour])
                        {
                            distances[neighbour.neighbour] = newDistance;
                        }
                    }
                }
            }

            return distances;
        }

        public static Dictionary<string, double> InfluenceUnweighted(Graph graph)
        {
            Dictionary<string, double> scores = new Dictionary<string, double>();
            int n = graph.Nodes.Count();

            foreach (string node in graph.Nodes)
            {
                Dictionary<string, int> distances = BFS(graph, node);

                if (distances.Values.Any(d => d == int.MaxValue))
                {
                    scores[node] = 0;
                    continue;
                }

                double totalDistance = distances.Values.Where(d => d != 0).Sum();
                scores[node] = (double)(n - 1) / totalDistance;
            }

            return scores.OrderByDescending(x => x.Value)
                         .ToDictionary(x => x.Key, x => x.Value);
        }

        public static Dictionary<string, double> InfluenceWeighted(Graph graph)
        {
            Dictionary<string, double> scores = new Dictionary<string, double>();
            int n = graph.Nodes.Count();

            foreach (string node in graph.Nodes)
            {
                Dictionary<string, int> distances = Dijkstra(graph, node);

                if (distances.Values.Any(d => d == int.MaxValue))
                {
                    scores[node] = 0;
                    continue;
                }

                double totalDistance = distances.Values.Where(d => d != 0).Sum();
                scores[node] = (double)(n - 1) / totalDistance;
            }

            return scores.OrderByDescending(x => x.Value)
                         .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}