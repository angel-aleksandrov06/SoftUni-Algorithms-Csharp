using System;

namespace _03._Combinations_with_Repetition
{
    public class Program
    {
        private static int[] elements;
        private static int[] combinations;
        private static int k;

        static void Main(string[] args)
        {
            int countElements = int.Parse(Console.ReadLine());
            elements = new int[countElements];

            for (int i = 1; i <= countElements; i++)
            {
                elements[i - 1] = i;
            }
            k = int.Parse(Console.ReadLine());

            combinations = new int[k];

            Combinations(0, 0);
        }

        private static void Combinations(int combIndex, int elementsStartIndex)
        {
            if (combIndex >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[combIndex] = elements[i];
                Combinations(combIndex + 1, i);
            }
        }
    }
}
