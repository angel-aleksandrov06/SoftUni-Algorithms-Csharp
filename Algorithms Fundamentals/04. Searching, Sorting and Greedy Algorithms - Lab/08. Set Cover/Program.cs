using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._Set_Cover
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> universe = Console.ReadLine().Split(", ").Select(int.Parse).ToHashSet();
            HashSet<HashSet<int>> sets = new HashSet<HashSet<int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                HashSet<int> set = input.Split(", ").Select(int.Parse).ToHashSet();
                sets.Add(set);
            }

            HashSet<HashSet<int>> smallestSubset = GetSmallestSubset(universe, sets);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Sets to take ({smallestSubset.Count}):");

            foreach (HashSet<int> set in smallestSubset)
            {
                stringBuilder.AppendLine(string.Join(", ", set));
            }

            Console.WriteLine(stringBuilder.ToString().TrimEnd());
        }

        private static HashSet<HashSet<int>> GetSmallestSubset(HashSet<int> universe, HashSet<HashSet<int>> sets)
        {
            HashSet<HashSet<int>> smallestSubset = new HashSet<HashSet<int>>();

            while (universe.Count > 0)
            {
                HashSet<int> greedySet = GetGreedySet(universe, sets);
                universe.ExceptWith(greedySet);

                smallestSubset.Add(greedySet);
            }

            return smallestSubset;
        }

        private static HashSet<int> GetGreedySet(HashSet<int> universe, HashSet<HashSet<int>> sets)
        {
            HashSet<int> greedySet = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            foreach (HashSet<int> set in sets)
            {
                HashSet<int> current = set.Intersect(universe).ToHashSet();
                if (greedySet.Count < current.Count)
                {
                    greedySet = current;
                    result = set;
                }
            }

            return result;
        }
    }
}
