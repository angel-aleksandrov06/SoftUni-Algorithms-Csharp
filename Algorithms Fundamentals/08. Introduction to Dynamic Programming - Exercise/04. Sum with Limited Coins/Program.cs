namespace _04._Sum_with_Limited_Coins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            var sumCount = GetCount(coins, target);
            Console.WriteLine(sumCount);

            //var sums = CalcSums(coins);
            //Console.WriteLine(sums[target]);
        }

        private static int GetCount(int[] numbers, int target)
        {
            var sums = new HashSet<int> { 0 };
            var count = 0;

            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    newSums.Add(number + sum);

                    if (number + sum == target)
                    {
                        count++;
                    }
                }

                sums.UnionWith(newSums);
            }

            return count;
        }

        //private static Dictionary<int, int> CalcSums(int[] numbers)
        //{
        //    var result = new Dictionary<int, int> { { 0, 1 } };

        //    foreach (var number in numbers)
        //    {
        //        var sums = result.Keys.ToArray();
        //        foreach (var sum in sums)
        //        {
        //            var newSum = sum + number;

        //            if (!result.ContainsKey(newSum))
        //            {
        //                result[newSum] = 1;
        //            }
        //            else
        //            {
        //                result[newSum]++;
        //            }
        //        }
        //    }

        //    return result;
        //}
    }
}
