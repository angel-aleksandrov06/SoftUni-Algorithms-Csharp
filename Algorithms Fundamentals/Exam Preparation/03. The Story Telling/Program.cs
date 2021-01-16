using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Story_Telling
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static Stack<string> stack;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            stack = new Stack<string>();

            foreach (var node in graph.Keys)
            {
                DFS(node);
            }

            Console.WriteLine(string.Join(" ", stack));
        }

        private static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            stack.Push(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var graphResult = new Dictionary<string, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                var parts = line.Split("->", StringSplitOptions.RemoveEmptyEntries);

                var preStory = parts[0].Trim();

                if (parts.Length == 1)
                {
                    graphResult[preStory] = new List<string>();
                }
                else
                {
                    var children = parts[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    graphResult[preStory] = children;
                }
            }

            return graphResult;
        }
    }
}
