namespace _05._Break_Cycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Edge
    {
        public Edge(string first, string second)
        {
            this.First = first;
            this.Second = second;
        }

        public string First { get; set; }

        public string Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} - {this.Second}";
        }

        public string ToStringReversed()
        {
            return $"{this.Second} - {this.First}";
        }
    }

    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            ProcesInput(n);

            edges = edges.OrderBy(e => e.First).ThenBy(e => e.Second).ToList();

            var removeEdges = new List<Edge>();
            var blackList = new HashSet<string>();

            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                graph[first].Remove(second);
                graph[second].Remove(first);

                if (HasPath(first, second))
                {
                    if (blackList.Contains(edge.ToString()))
                    {
                        continue;
                    }
                    removeEdges.Add(edge);
                    blackList.Add(edge.ToStringReversed());
                }
                else
                {
                    graph[first].Add(second);
                    graph[second].Add(first);
                }
            }

            Console.WriteLine($"Edges to remove: {removeEdges.Count}");

            
            foreach (var edge in removeEdges)
            {
                Console.WriteLine(edge.ToString());
            }
        }

        private static bool HasPath(string source, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(source);

            var visited = new HashSet<string> { source };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        private static void ProcesInput(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var node = parts[0];
                var children = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                foreach (var child in children)
                {
                    graph[node].Add(child);
                    edges.Add(new Edge(node, child));
                }
            }
        }
    }
}
