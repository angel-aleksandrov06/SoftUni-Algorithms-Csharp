namespace _03._Road_Trip
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var value = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var weight = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var items = value.Length;

            var maxCapacity = int.Parse(Console.ReadLine());

            var dp = new int[items + 1, maxCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var itemValue = value[row - 1];
                var itemWeight = weight[row - 1];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var skip = dp[row - 1, capacity];

                    if (itemWeight > capacity)
                    {
                        dp[row, capacity] = skip;
                        continue;
                    }

                    var take = itemValue + dp[row - 1, capacity - itemWeight];

                    if (take > skip)
                    {
                        dp[row, capacity] = take;
                    }
                    else
                    {
                        dp[row, capacity] = skip;
                    }
                }
            }
            var maxValue = dp[items, maxCapacity];
            Console.WriteLine($"Maximum value: {maxValue}");
        }
    }
}
