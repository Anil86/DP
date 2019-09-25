using System;
using static System.Console;

namespace DP
{
    public class OnceUponTimeInTimeLand
    {
        private long CalculateLivesSumMax(int[] array, int interval)
        {
            interval++;

            long[] dp = new long[array.Length + 1];
            Array.Fill(dp, long.MinValue);

            return CalculateSumMax(0);



            long CalculateSumMax(int current)
            {
                // Solve small sub-problems
                // If crossed last item, no more items can be picked.
                // So return 0.
                if (current == array.Length) return dp[array.Length] = 0;


                // Divide
                // When next current >> array's length, its value will always be 0 i.e. dp[length]
                // So reduce next current by next current = array's length
                int nextCurrent = current + interval;
                if (nextCurrent > array.Length) nextCurrent = array.Length;

                // Option 1: Consider current
                if (dp[nextCurrent] == long.MinValue) dp[nextCurrent] = CalculateSumMax(nextCurrent);
                long sumWithCurrent = array[current] + dp[nextCurrent];
                // Option 2: Skip current
                if (dp[current + 1] == long.MinValue) dp[current + 1] = CalculateSumMax(current + 1);
                long sumWoCurrent = dp[current + 1];


                // Combine
                // Take max of 2 options
                return dp[current] = Math.Max(sumWithCurrent, sumWoCurrent);
            }
        }


        internal static void Work()
        {
            int[] array = { 1, 2, -3, -5, 4, 6, -3, 2, -1, 2 };
            int interval = 1;   // Ans: 12   C: 287
            //int[] array = { 1, 2, -3, -5, 4, 6, -3, 2, -1, 2 };
            //int interval = 2;   // Ans: 10   C: 119  11

            long livesSumMax = new OnceUponTimeInTimeLand().CalculateLivesSumMax(array, interval);
            WriteLine(livesSumMax);
        }
    }
}