using System;

namespace _02._Nested_Loops
{
    public class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var arr = new int[number];

            Gen01(0, arr, number);
        }

        private static void Gen01(int index, int[] arr, int number)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 1; i <= number; i++)
                {
                    arr[index] = i;
                    Gen01(index + 1, arr, number);
                }
            }
        }
    }
}
