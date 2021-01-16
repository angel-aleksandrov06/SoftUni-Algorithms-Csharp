namespace _02._Recursive_Factorial
{
    using System;

    class Program
    {
        static long Factorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }

            return num * Factorial(num - 1);
        }

        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(inputNumber));
        }
    }
}
