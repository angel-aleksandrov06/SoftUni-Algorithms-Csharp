namespace _05._Word_Differences
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var firstStr = Console.ReadLine();
            var secondStr = Console.ReadLine();

            var table = new int[firstStr.Length + 1, secondStr.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r;
            }

            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[0, c] = c;
            }

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (firstStr[r - 1] == secondStr[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1];
                    }
                    else
                    {
                        table[r, c] = Math.Min(table[r, c - 1], table[r - 1, c]) + 1;
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {table[firstStr.Length, secondStr.Length]}");
        }
    }
}
