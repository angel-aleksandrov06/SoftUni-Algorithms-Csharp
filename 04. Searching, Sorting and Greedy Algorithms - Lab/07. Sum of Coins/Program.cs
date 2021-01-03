using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Sum_of_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            var sortedCoins = new SortedSet<int>(input);
            var result = 0;

            var sb = new StringBuilder();
            while (target > 0 && 0 < sortedCoins.Count)
            {
                var maxCoin = sortedCoins.Max;
                sortedCoins.Remove(maxCoin);

                if (maxCoin > target)
                {
                    continue;
                }

                var counter = target/maxCoin;
                result += counter;

                target = target - maxCoin * counter;
                sb.AppendLine($"{counter} coin(s) with value {maxCoin}");
            }

            if (target > 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {result}");
                Console.WriteLine(sb.ToString());
            }

            
        }
    }
}
