using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Big_Trip
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.First} {this.Second} {this.Weight}";
        }
    }

    public class Program
    {
        private static List<Edge>[] graph;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distances = new double[graph.Length];
            var prev = new int[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                prev[i] = -1;
                distances[i] = double.NegativeInfinity;
            }

            distances[source] = 0;

            var sortedNodes = TopologicalSort();

            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph[node])
                {
                    var newDistance = distances[node] + edge.Weight;
                    if (newDistance > distances[edge.Second])
                    {
                        prev[edge.Second] = node;
                        distances[edge.Second] = newDistance;
                    }
                }
            }

            Console.WriteLine(distances[destination]);
            Console.WriteLine(string.Join(" ", GetPath(prev, destination)));
        }

        private static Stack<int> TopologicalSort()
        {
            var visited = new bool[graph.Length];
            var sorted = new Stack<int>();

            for (int node = 0; node < graph.Length; node++)
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
                DFS(edge.Second, visited, sorted);
            }

            sorted.Push(node);
        }

        private static Stack<int> GetPath(int[] prev, int node)
        {
            var result = new Stack<int>();

            while (node != -1)
            {
                result.Push(node);
                node = prev[node];
            }

            return result;
        }

        private static List<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<Edge>[nodesCount +1];

            for (int i = 0; i < nodesCount+1; i++)
            {
                result[i] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var first = edgeData[0];
                var second = edgeData[1];
                var weight = edgeData[2];

                var edge = new Edge
                {
                    First = first,
                    Second = second,
                    Weight = weight,
                };

                result[first].Add(edge);
            }

            return result;
        }
    }
}
