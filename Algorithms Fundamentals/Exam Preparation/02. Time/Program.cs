namespace _02._Time
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var positions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var table = new int[numbers.Length + 1, positions.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (numbers[r - 1] == positions[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }

            var row = numbers.Length;
            var col = positions.Length;

            var stack = new Stack<int>();

            while (row > 0 && col > 0)
            {
                if (numbers[row - 1] == positions[col - 1])
                {
                    row--;
                    col--;

                    stack.Push(numbers[row]);
                }
                else if (table[row - 1, col] > table[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            Console.WriteLine(string.Join(" ", stack));
            Console.WriteLine(table[numbers.Length, positions.Length]);
        }
    }
}
