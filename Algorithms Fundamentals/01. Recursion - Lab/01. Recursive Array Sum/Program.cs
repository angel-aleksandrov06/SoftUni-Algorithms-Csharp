namespace _01._Recursive_Array_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        static int Sum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + Sum(arr, index + 1);
        }

        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(Sum(inputNumbers, 0).ToString());
        }
    }
}
