namespace _07._Minimum_Edit_Distance
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var replace = int.Parse(Console.ReadLine());
            var insert = int.Parse(Console.ReadLine());
            var delete = int.Parse(Console.ReadLine());
            var firstStr = Console.ReadLine();
            var secondStr = Console.ReadLine();

            var table = new int[firstStr.Length + 1, secondStr.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r * delete;
            }

            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[0, c] = c * insert;
            }

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    var cost = firstStr[r - 1] == secondStr[c - 1] ? 0 : replace;

                    var del = table[r - 1, c] + delete;
                    var rep = table[r - 1, c -1] + cost;
                    var ins = table[r, c -1] + insert;

                    table[r, c] = Math.Min(Math.Min(del, ins), rep);
                }
            }

            Console.WriteLine($"Minimum edit distance: {table[firstStr.Length, secondStr.Length]}");
        }
    }
}
