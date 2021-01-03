namespace _06._Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<string> names;
        private static string[] seats;
        private static HashSet<int> locked;

        static void Main(string[] args)
        {
            names = Console.ReadLine().Split(", ").ToList();
            seats = new string[names.Count];
            locked = new HashSet<int>();

            string line = Console.ReadLine();
            while (line != "generate")
            {
                var parts = line.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                seats[position] = name;
                locked.Add(position);
                names.Remove(name);

                line = Console.ReadLine();
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                // list<string> names -> current permutation

                var namesIndex = 0;
                for (int i = 0; i < seats.Length; i++)
                {
                    if (locked.Contains(i))
                    {
                        continue;
                    }

                    seats[i] = names[namesIndex];
                    namesIndex++;
                }

                Console.WriteLine(string.Join(" ", seats));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }
    }
}
