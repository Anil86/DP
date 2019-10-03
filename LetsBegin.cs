using System;
using static System.Console;

namespace DP
{
    public class LetsBegin
    {
        private int NoOfPrimes(int n)
        {
            int[] dp = new int[n + 1];

            int primesCount = NoOfPrimesLocal(n);
            if (primesCount == int.MaxValue) primesCount = -1;
            return primesCount;


            int NoOfPrimesLocal(int num)
            {
                _count++;
                // Solve small sub-problems
                switch (num)
                {
                    case int r when r < 2:
                        return dp[0] = dp[1] = int.MaxValue;
                    case 2:
                    case 3:
                    case 5:
                    case 7: return dp[num] = 1;
                }


                // Divide
                int take7Count = int.MaxValue,
                    take5Count = int.MaxValue,
                    take3Count = int.MaxValue,
                    take2Count = int.MaxValue;
                int balance;

                balance = num - 7;
                if (balance >= 2)
                {
                    if (dp[balance] == 0)
                        dp[balance] = NoOfPrimesLocal(balance);
                    take7Count = 1 + dp[balance];
                }

                balance = num - 5;
                if (balance >= 2)
                {
                    if (dp[balance] == 0)
                        dp[balance] = NoOfPrimesLocal(balance);
                    take5Count = 1 + dp[balance];
                }

                balance = num - 3;
                if (balance >= 2)
                {
                    if (dp[balance] == 0)
                        dp[balance] = NoOfPrimesLocal(balance);
                    take3Count = 1 + dp[balance];
                }

                balance = num - 2;
                if (balance >= 2)
                {
                    if (dp[balance] == 0)
                        dp[balance] = NoOfPrimesLocal(balance);
                    take2Count = 1 + dp[balance];
                }


                // Combine
                return dp[num] = Math.Min(take7Count, Math.Min(take5Count, Math.Min(take3Count, take2Count)));
            }
        }


        private static int _count;
        internal static void Work()
        {
            int n = 11;   // Ans: 3   45  9
            //int n = 14;   // Ans: 2   101  12
            //int n = 10;   // Ans: 2   17  8
            //int n = 7;   // Ans: 1

            int primesCount = new LetsBegin().NoOfPrimes(n);
            WriteLine(primesCount); WriteLine($"C: {_count}");
        }
    }
}