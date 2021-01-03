using System;

namespace _08._Set_Cover
{
    public class Program
    {
        static void Main(string[] args)
        {
            var selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                var currentSet = sets
                  .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                  .FirstOrDefault();
                foreach (var number in currentSet)
                { universe.Remove(number); }

                sets.Remove(currentSet);
                selectedSets.Add(currentSet);
            }

        }
    }
}
