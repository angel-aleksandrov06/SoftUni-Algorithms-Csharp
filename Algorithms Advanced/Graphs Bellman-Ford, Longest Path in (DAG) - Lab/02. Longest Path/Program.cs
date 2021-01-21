namespace _02._Longest_Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.From} {this.To} {this.Weight}";
        }
    }

    public class Program
    {
        private static List<Edge>[] graph;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodes, edgesCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());


            var distances = GetLongestPaths(source);

            Console.WriteLine(distances[destination]);
            //Console.WriteLine(string.Join(" ", GetPath(prev, destination)));
        }

        private static double[] GetLongestPaths(int source)
        {
            var sortedNodes = TopologicalSorting();

            var distances = new double[graph.Length];
            Array.Fill(distances, double.NegativeInfinity); // change to double.PositiveInfinity for ShortestParth
            distances[source] = 0;

            //var prev = new int[graph.Length];
            //Array.Fill(prev, -1);

            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph[node])
                {
                    var newDistance = distances[node] + edge.Weight;
                    if (newDistance > distances[edge.To]) // change to < for ShortestParth
                    {
                        distances[edge.To] = newDistance;
                        //prev[edge.To] = node;
                    }
                }
            }

            return distances;
        }

        private static List<Edge>[] ReadGraph(int nodes, int edgesCount)
        {
            var result = new List<Edge>[nodes + 1];

            for (int node = 0; node < graph.Length; node++)
            {
                result[node] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edgesData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var from = edgesData[0];
                var to = edgesData[1];
                var weght = edgesData[2];

                var edge = new Edge
                {
                    From = from,
                    To = to,
                    Weight = weght,
                };

                result[from].Add(edge);
            }

            return result;
        }

        //private static Stack<int> GetPath(int[] prev, int node)
        //{
        //    var path = new Stack<int>();

        //    while (node != -1)
        //    {
        //        path.Push(node);
        //        node = prev[node];
        //    }

        //    return path;
        //}

        private static Stack<int> TopologicalSorting()
        {
            var visited = new bool[graph.Length];
            var sorted = new Stack<int>();

            for (int node = 1; node < graph.Length; node++)
            {
                DFS(node, visited, sorted);
            }

            return sorted;
        }

        private static void DFS(int node, bool[] visited, Stack<int> sorted)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var edge in graph[node])
            {
                DFS(edge.To, visited, sorted);
            }

            sorted.Push(node);
        }
    }
}
