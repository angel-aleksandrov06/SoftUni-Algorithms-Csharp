namespace _02._Paths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            visited = new bool[n+1];

            graph = ReadGraph(n);

            for (int node = 0; node < graph.Count; node++)
            {
                var component = new List<int>();
                DFS(node, component);
            }
        }

        private static Dictionary<int, List<int>> ReadGraph(int nodesCount)
        {
            var result = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodesCount; i++)
            {
                var node = i;

                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    result[node] = new List<int>();
                    continue;
                }

                var children = line
                    .Split(" ")
                    .Select(int.Parse)
                    .ToList();

                result[node] = children;
            }

            return result;
        }

        private static void DFS(int node, List<int> component)
        {
            if (component.Contains(node))
            {
                return;
            }

            component.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child, component);
                if (graph[child].Count == 0)
                {
                    Console.WriteLine(string.Join(" ", component));
                }
                
                var last = component.Last();
                component.Remove(last);
            }
        }
    }
}
