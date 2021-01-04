namespace _03._Shortest_Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parants;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);
            visited = new bool[graph.Length];
            parants = new int[graph.Length];
            Array.Fill(parants, -1);

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            BFS(startNode, endNode);
        }

        private static void BFS(int node, int endNode)
        {
            if (visited[node])
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(node);

            visited[node] = true;

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                if (currNode == endNode)
                {
                    var path = ReconstructPath(endNode);

                    Console.WriteLine($"Shortest path length is: {path.Count -1}");
                    Console.WriteLine(string.Join(" ", path));

                    return;
                }

                foreach (var child in graph[currNode])
                {
                    if (!visited[child])
                    {
                        parants[child] = currNode;
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        private static Stack<int> ReconstructPath(int endNode)
        {
            var path = new Stack<int>();
            var index = endNode;

            while (index != -1)
            {
                path.Push(index);
                index = parants[index];
            }

            return path;
        }

        private static List<int>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<int>[nodesCount + 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var parent = edge[0];
                var child = edge[1];

                if (result[parent] == null)
                {
                    result[parent] = new List<int>();
                }

                result[parent].Add(child);
            }

            return result;
        }
    }
}
