using System;

namespace _01._Reverse_Array
{
    public class Program
    {
        static void Main()
        {
            // firtst variant
            //Console.WriteLine(String.Join(" ", Console.ReadLine().Split(" ").Reverse()));

            var arr = Console.ReadLine().Split();

            // second variant
            //for (int left = 0; left < arr.Length / 2; left++)
            //{
            //    var right = arr.Length - 1 - left;
            //    Swap(arr, left, right);
            //}

            ReverseArray(0, arr);

            Console.WriteLine(String.Join(" ", arr));
        }

        private static void ReverseArray(int left, string[] arr)
        {
            if (left >= arr.Length /2 )
            {
                return;
            }

            var right = arr.Length - 1 - left;
            Swap(arr, left, right);
            ReverseArray(left + 1, arr);
        }

        private static void Swap(string[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
