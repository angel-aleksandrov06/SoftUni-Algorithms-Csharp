using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._School_Teams
{
    public class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlsComb = new string[3];
            var girsList = new List<string[]>();
            Comb(0, 0, girlsComb, girls, girsList);

            var boysComb = new string[2];
            var boysList = new List<string[]>();
            Comb(0, 0, boysComb, boys, boysList);

            foreach (var currGirlsComb in girsList)
            {
                foreach (var currBoysComb in boysList)
                {
                    Console.WriteLine(
                        $"{string.Join(", ", currGirlsComb)}, {string.Join(", ", currBoysComb)}");
                }
            }
        }

        private static void Comb(
            int cellIndex, 
            int elementIndex, 
            string[] comb, 
            string[] elements, 
            List<string[]> result)
        {
            if (cellIndex >= comb.Length)
            {
                result.Add(comb.ToArray());
                return;
            }

            for (int i = elementIndex; i < elements.Length; i++)
            {
                comb[cellIndex] = elements[i];

                Comb(cellIndex + 1, i + 1, comb, elements, result);
            }
        }
    }
}
