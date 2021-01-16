using System;
using System.Linq;

namespace _05._Quicksort
{
    public class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (arr[left] > arr[pivot] &&
                    arr[right] < arr[pivot])
                {
                    Swap(arr, left, right);
                }

                if (arr[left] <= arr[pivot])
                {
                    left++;
                }

                if (arr[right] >= arr[pivot])
                {
                    right--;
                }
            }

            Swap(arr, pivot, right);

            var isSubLeftArraySmaller = right - 1 - start < end -(right + 1);

            if (isSubLeftArraySmaller)
            {
                QuickSort(arr, start, right - 1);
                QuickSort(arr, right + 1, end);
            }
            else
            {
                QuickSort(arr, right + 1, end);
                QuickSort(arr, start, right - 1);
            }
        }

        private static void Swap(int[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
