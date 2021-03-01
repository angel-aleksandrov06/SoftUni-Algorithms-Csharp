namespace _01._Black_Friday
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static HashSet<int> forest;
        private static int result;

        static void Main(string[] args)
        {
            var shops = int.Parse(Console.ReadLine());
            var streets = int.Parse(Console.ReadLine());

            edgesByNode = ReadGraph(shops, streets);
            forest = new HashSet<int>();
            result = 0;

            foreach (var node in edgesByNode.Keys)
            {
                if (!forest.Contains(node))
                {
                    Prim(node);
                }
            }

            Console.WriteLine(result);
        }

        private static void Prim(int node)
        {
            forest.Add(node);

            var queue = new OrderedBag<Edge>(edgesByNode[node], Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            while (queue.Count > 0)
            {
                var edge = queue.RemoveFirst();
                var nonTreeNode = GetNonTreeNode(edge.First, edge.Second);

                if (nonTreeNode == -1)
                {
                    continue;
                }

                result += edge.Weight;

                forest.Add(nonTreeNode);
                queue.AddMany(edgesByNode[nonTreeNode]);
            }
        }

        private static int GetNonTreeNode(int first, int second)
        {
            var nonTreeNode = -1;

            if (forest.Contains(first) && !forest.Contains(second))
            {
                nonTreeNode = second;
            }
            else if (!forest.Contains(first) && forest.Contains(second))
            {
                nonTreeNode = first;
            }

            return nonTreeNode;
        }

        private static Dictionary<int, List<Edge>> ReadGraph(int shops, int streets)
        {
            var result = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < streets; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];
                var weight = edgeData[2];

                if (!result.ContainsKey(firstNode))
                {
                    result.Add(firstNode, new List<Edge>());
                }

                if (!result.ContainsKey(secondNode))
                {
                    result.Add(secondNode, new List<Edge>());
                }

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight,
                };

                result[firstNode].Add(edge);
                result[secondNode].Add(edge);
            }

            return result;
        }
    }
}
