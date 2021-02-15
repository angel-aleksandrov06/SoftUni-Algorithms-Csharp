namespace _03._Undefined
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            edges = ReadGraph(nodesCount, edgesCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distances = new double[nodesCount +1];
            var prev = new int[nodesCount +1];

            for (int node = 0; node < nodesCount +1; node++)
            {
                distances[node] = double.PositiveInfinity;
                prev[node] = -1;
            }

            distances[source] = 0;

            for (int i = 0; i < nodesCount - 1; i++)
            {
                var updated = false;
                foreach (var edge in edges)
                {
                    if (double.IsPositiveInfinity(distances[edge.First]))
                    {
                        continue;
                    }

                    var newDistance = distances[edge.First] + edge.Weight;
                    if (newDistance < distances[edge.Second])
                    {
                        distances[edge.Second] = newDistance;
                        prev[edge.Second] = edge.First;
                        updated = true;
                    }
                }

                if (!updated)
                {
                    break;
                }
            }

            foreach (var edge in edges)
            {
                var newDistance = distances[edge.First] + edge.Weight;
                if (newDistance < distances[edge.Second])
                {
                    Console.WriteLine("Undefined");
                    return;
                }
            }

            var path = GetPath(prev, destination);

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distances[destination]);
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

        private static List<Edge> ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var first = edgeData[0];
                var second = edgeData[1];
                var weight = edgeData[2];

                result.Add(new Edge
                {
                    First = first,
                    Second = second,
                    Weight = weight,
                });
            }

            return result;
        }
    }
}
