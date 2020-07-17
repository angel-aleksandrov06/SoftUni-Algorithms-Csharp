namespace _03._Recursive_Drawing
{
    using System;

    class Program
    {
        static void Print(int index)
        {
            if(index == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', index));

            Print(index - 1);

            Console.WriteLine(new string('#', index));

        }

        static void Main()
        {
            var inputCount = int.Parse(Console.ReadLine());

            Print(inputCount);
        }
    }
}
