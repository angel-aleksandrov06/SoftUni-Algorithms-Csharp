using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Path_Finder
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount);

            var pairsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pairsCount; i++)
            {
                var pair = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var steps = GetShortestPath(pair);

                if (!steps)
                {
                    Console.WriteLine("no");
                }
                else
                {
                    Console.WriteLine("yes");
                }
            }
        }

        private static bool GetShortestPath(int[] pairs)
        {
            int item = pairs[0];
            bool isPath = true;

            for (int i = 0; i < pairs.Length -1; i++)
            {
                if (graph[item].Count ==0)
                {
                    isPath = false;
                    break;
                }

                if (graph[item].Contains(pairs[i+1]))
                {
                    item = graph[item].FirstOrDefault(x => x == pairs[i+1]);
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return isPath;
        }

        private static Dictionary<int, List<int>> ReadGraph(int nodesCount)
        {
            var result = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodesCount; i++)
            {
                var node = i;

                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    result[node] = new List<int>();
                    continue;
                }

                var children = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                result[node] = children;
            }

            return result;
        }
    }
}
