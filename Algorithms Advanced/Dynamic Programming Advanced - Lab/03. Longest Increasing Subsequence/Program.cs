namespace _03._Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var len = new int[numbers.Length];
            var prev = new int[numbers.Length];

            var bestLen = 0;
            var lastIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                prev[i] = -1;

                var currNumber = numbers[i];
                var currBestSeq = 1;

                for (int j = i -1; j >= 0; j--)
                {
                    var prevNumber = numbers[j];

                    if (prevNumber < currNumber && len[j] + 1 >= currBestSeq)
                    {
                        currBestSeq = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (currBestSeq > bestLen)
                {
                    bestLen = currBestSeq;
                    lastIndex = i;
                }

                len[i] = currBestSeq;
            }

            var stack = new Stack<int>();

            while (lastIndex != -1)
            {
                stack.Push(numbers[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
