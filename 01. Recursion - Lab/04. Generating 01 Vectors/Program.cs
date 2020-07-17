using System;

namespace _04._Generating_01_Vectors
{
    class Program
    {
        private static void Gen01(int index, int[] arr)
        {
            if(index == arr.Length)
            {
                Console.WriteLine(string.Join("",arr));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    arr[index] = i;
                    Gen01(index + 1, arr);
                }
            }
        }

        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var arr = new int[input];

            Gen01(0, arr);
        }
    }
}
