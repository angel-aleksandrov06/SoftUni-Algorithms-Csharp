namespace _01._Binary_Search
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var numsbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int searchedNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numsbers, searchedNumber));
        }

        private static int BinarySearch(int[] numsbers, int searchedNumber)
        {
            var startIndex = 0;
            var endIndex = numsbers.Length - 1;

            while (startIndex <= endIndex)
            {
                var middleIndex = (endIndex + startIndex) / 2;

                if (numsbers[middleIndex] == searchedNumber)
                {
                    return middleIndex;
                }

                if (numsbers[middleIndex] < searchedNumber)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex - 1;
                }
            }

            return -1;
        }
    }
}
