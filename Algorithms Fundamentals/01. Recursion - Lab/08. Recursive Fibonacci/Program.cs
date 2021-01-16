using System;

namespace _08._Recursive_Fibonacci
{
    public class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(number));
        }

        private static int GetFibonacci(int number)
        {
            int result = 0;
            int previous = 1;

            for (int i = 0; i <= number; i++)
            {
                int temp = result;
                result = previous;
                previous = temp + previous;
            }

            return result;
        }
    }
}
