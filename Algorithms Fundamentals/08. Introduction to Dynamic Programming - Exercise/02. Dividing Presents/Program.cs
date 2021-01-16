namespace _02._Dividing_Presents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sums = CalcSums(presents);

            var totalScore = presents.Sum();
            var bobScore = GetBobScore(sums, totalScore);
            var alanScore = totalScore - bobScore;

            var alanPresents = GetPresents(sums, alanScore);

            Console.WriteLine($"Difference: {bobScore - alanScore}");
            Console.WriteLine($"Alan:{alanScore} Bob:{bobScore}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> GetPresents(Dictionary<int, int> sums, int target)
        {
            var result = new List<int>();

            while (target != 0)
            {
                var present = sums[target];
                result.Add(present);

                target -= present;
            }

            return result;
        }

        private static int GetBobScore(Dictionary<int, int> sums, int totalScore)
        {
            var bobScore = (int)Math.Ceiling(totalScore / 2.0);
            while (!sums.ContainsKey(bobScore))
            {
                bobScore++;
            }

            return bobScore;
        }

        private static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int> { { 0, 0 } };

            foreach (var number in numbers)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var newSums = sum + number;

                    if (!result.ContainsKey(newSums))
                    {
                        result.Add(newSums, number);
                    }
                }
            }

            return result;
        }
    }
}
