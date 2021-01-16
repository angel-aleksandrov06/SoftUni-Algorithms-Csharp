namespace _05._GeneratingCombinations
{
    using System;
    using System.Linq;

    class Program
    {
        private static void GenCombs(int[] set, int[] arr, int index, int border)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = border + 1; i <= set.Length; i++)
                {
                    arr[index] = set[i-1];
                    GenCombs(set, arr, index + 1, i);
                }
            }
        }

        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var k = int.Parse(Console.ReadLine());
            var vector = new int[k];

            GenCombs(inputArr, vector, 0, 0);
        }
    }
}
