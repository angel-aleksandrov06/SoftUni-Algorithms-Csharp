﻿using System;

namespace _05._Combinations_without_Repetition
{
    public class Program
    {
        private static string[] elements;
        private static string[] combinations;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ");
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            Combinations(0, 0);
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
