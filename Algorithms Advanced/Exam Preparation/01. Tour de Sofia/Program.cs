namespace _01._Tour_de_Sofia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Distance { get; set; }
    }

    public class Program
    {
        private static List<Edge>[] graph;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());
            var startNode = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);

            var distance = new double[nodesCount];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
            }

            var queue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));

            foreach (var edge in graph[startNode])
            {
                distance[edge.To] = edge.Distance;
                queue.Add(edge.To);
            }

            var visitedNodes = new HashSet<int> { startNode };

            while (queue.Count > 0)
            {
                var node = queue.RemoveFirst();
                visitedNodes.Add(node);

                if (node == startNode)
                {
                    break;
                }

                foreach (var edge in graph[node])
                {
                    var child = edge.To;

                    if (double.IsPositiveInfinity(distance[child]))
                    {
                        queue.Add(child);
                    }

                    var newDistance = distance[node] + edge.Distance;

                    if (newDistance < distance[child])
                    {
                        distance[child] = newDistance;
                        queue = new OrderedBag<int>(
                            queue,
                            Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
                    }
                }
            }

            if (double.IsPositiveInfinity(distance[startNode]))
            {
                Console.WriteLine(visitedNodes.Count);
            }
            else
            {
                Console.WriteLine(distance[startNode]);
            }
        }

        private static List<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<Edge>[nodesCount];

            for (int node = 0; node < result.Length; node++)
            {
                result[node] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edgreData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var from = edgreData[0];
                var to = edgreData[1];
                var destance = edgreData[2];

                result[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Distance =  destance
                });
            }

            return result;
        }
    }
}
