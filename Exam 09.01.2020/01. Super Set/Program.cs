using System;

namespace _01._Super_Set
{
    public class Program
    {
        private static string[] elements;
        private static string[] combinations;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(", ");
            k = elements.Length;

            for (int i = 0; i <= k; i++)
            {
                combinations = new string[i];

                Combinations(0, 0);
            }
        }

        private static void Combinations(int combIndex, int elementsStartIndex)
        {
            if (combIndex >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex ; i < elements.Length; i++)
            {
                combinations[combIndex] = elements[i];
                Combinations(combIndex + 1, i + 1);
            }
        }
    }
}
