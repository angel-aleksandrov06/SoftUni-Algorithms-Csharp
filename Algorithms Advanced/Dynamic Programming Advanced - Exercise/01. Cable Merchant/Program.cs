namespace _01._Cable_Merchant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<int> prices;
        private static int[] bestPrices;

        static void Main(string[] args)
        {
            prices = new List<int> { 0 };

            prices.AddRange(Console.ReadLine().Split().Select(int.Parse));

            var connectorPrice = int.Parse(Console.ReadLine());

            bestPrices = new int[prices.Count];

            var result = new List<int>();

            for (int length = 1; length < prices.Count; length++)
            {
                var bestprices = CutCable(length, connectorPrice);

                result.Add(bestprices);
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static int CutCable(int length, int connectorPrice)
        {
            if (length == 0)
            {
                return 0;
            }

            if (bestPrices[length] != 0)
            {
                return bestPrices[length];
            }

            var bestPrice = prices[length];

            for (int i = 1; i < length; i++)
            {
                var currPrice = prices[i] + CutCable(length - i, connectorPrice) - 2 * connectorPrice;

                if (currPrice > bestPrice)
                {
                    bestPrice = currPrice;
                }
            }

            bestPrices[length] = bestPrice;

            return bestPrice;
        }
    }
}
