namespace _02._Battle_Points
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var requiredEnergy = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var battlePoints = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var enemies = requiredEnergy.Length;

            var initialEnergy = int.Parse(Console.ReadLine());

            var dp = new int[enemies + 1, initialEnergy +1];
            //var included = new bool[enemies + 1, initialEnergy + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var enemyIdx = row - 1;
                var enemyEnergy = requiredEnergy[enemyIdx];
                var enemyBattlePoints = battlePoints[enemyIdx];

                for (int energy = 1; energy < dp.GetLength(1); energy++)
                {
                    var skip = dp[row - 1, energy];
                    if (enemyEnergy > energy)
                    {
                        dp[row, energy] = skip;
                        continue;
                    }

                    var take = enemyBattlePoints + dp[row - 1, energy - enemyEnergy];

                    //if (take > skip)
                    //{
                    //    dp[row, energy] = take;
                    //    included[row, energy] = true;
                    //}
                    //else
                    //{
                    //    dp[row, energy] = skip;
                    //}

                    dp[row, energy] = Math.Max(skip, take);
                }
            }

            Console.WriteLine(dp[enemies, initialEnergy]);

            //var currEnergy = initialEnergy;

            //for (int row = enemies; row >= 0; row--)
            //{
            //    if (included[row, currEnergy])
            //    {
            //        var enemyInx = row - 1;

            //        Console.WriteLine(enemyInx);
            //        currEnergy -= requiredEnergy[enemyInx];

            //        if (currEnergy == 0)
            //        {
            //            break;
            //        }
            //    }
            //}
        }
    }
}
