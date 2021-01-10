using System;
using System.Linq;

namespace _02._Socks
{
     public class Program
    {
        static void Main(string[] args)
        {
            var firstString = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondString = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var table = new int[firstString.Length + 1, secondString.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (firstString[r-1] == secondString[c -1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }

            Console.WriteLine(table[firstString.Length, secondString.Length]);

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
