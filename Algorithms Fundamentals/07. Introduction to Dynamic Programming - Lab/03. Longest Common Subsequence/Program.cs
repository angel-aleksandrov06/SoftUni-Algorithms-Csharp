namespace _03._Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var firstWord = Console.ReadLine();
            var secondWord = Console.ReadLine();

            var table = new int[firstWord.Length + 1, secondWord.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (firstWord[r-1] == secondWord[c -1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }

            Console.WriteLine(table[firstWord.Length, secondWord.Length]);

            //var row = firstWord.Length;
            //var col = secondWord.Length;

            //var stack = new Stack<char>();

            //while (row > 0 && col > 0)
            //{
            //    if (firstWord[row-1] == secondWord[col-1])
            //    {
            //        row--;
            //        col--;

            //        stack.Push(firstWord[row]);
            //    }
            //    else if (table[row-1, col]> table[row, col-1])
            //    {
            //        row--;
            //    }
            //    else
            //    {
            //        col--;
            //    }
            //}

            //Console.WriteLine(string.Join(" ", stack));
        }
    }
}
