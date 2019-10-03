using System;
using static System.Console;

namespace DP
{
    public class LetsBegin
    {
        private int NoOfPrimes(int n)
        {
            int primesCount = NoOfPrimesLocal(n);
            if (primesCount == int.MaxValue) primesCount = -1;
            return primesCount;


            int NoOfPrimesLocal(int num)
            {
                _count++;
                // Solve small sub-problems
                switch (num)
                {
                    case int r when r < 2: return int.MaxValue - 1;
                    case 2:
                    case 3:
                    case 5:
                    case 7: return 1;
                }


                // Divide
                int take7Count = 1 + NoOfPrimesLocal(num - 7);
                int take5Count = 1 + NoOfPrimesLocal(num - 5);
                int take3Count = 1 + NoOfPrimesLocal(num - 3);
                int take2Count = 1 + NoOfPrimesLocal(num - 2);


                // Combine
                return Math.Min(take7Count, Math.Min(take5Count, Math.Min(take3Count, take2Count)));
            }
        }


        private static int _count;
        internal static void Work()
        {
            int n = 11;   // Ans: 3   45
            //int n = 14;   // Ans: 2   101
            //int n = 10;   // Ans: 2   17
            //int n = 7;   // Ans: 1

            int primesCount = new LetsBegin().NoOfPrimes(n);
            WriteLine(primesCount);WriteLine($"C: {_count}");
        }
    }
}