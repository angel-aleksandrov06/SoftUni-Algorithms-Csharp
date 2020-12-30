using System;

namespace _01._Permutations_without_Repetition
{
    public class Program
    {
        static void Main()
        {
            // Time complexity: n! *n | Memory complexity 3 * N
            var allPermutationsWithMoreMemoryComplexity = new WithMoreMemory();
            allPermutationsWithMoreMemoryComplexity.AllPermutations();

            // Time complexity: n! *n | Memory complexity N
            var allPermutationsOptimized = new WithLessMemory();
            allPermutationsOptimized.AllPermutations();
        }
    }
}
