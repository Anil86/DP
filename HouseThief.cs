using System;
using static System.Console;

namespace DP
{
    public class HouseThief
    {
        private int StealMaxValueMemo(int[] houses)
        {
            int[] dp = new int[houses.Length + 2];

            return StealMaxValue(0);



            int StealMaxValue(int current)
            {
                // Solve small sub-problems
                if (current >= houses.Length) return dp[current] = 0;


                // Divide
                if (dp[current + 2] == 0) dp[current + 2] = StealMaxValue(current + 2);
                int valueWithCurrent = houses[current] + dp[current + 2];
                if (dp[current + 1] == 0) dp[current + 1] = StealMaxValue(current + 1);
                int valueWoCurrent = dp[current + 1];


                // Combine
                return dp[current] = Math.Max(valueWithCurrent, valueWoCurrent);
            }
        }


        private int StealMaxValueTab(int[] houses)
        {
            int[] dp = new int[houses.Length + 2];

            // Solve small sub-problems
            //dp[houses.Length] = dp[houses.Length + 1] = 0;   // Already 0, so need to update


            for (var current = houses.Length - 1; current >= 0; current--)
            {
                // Divide
                int valueWithCurrent = houses[current] + dp[current + 2];
                int valueWoCurrent = dp[current + 1];


                // Combine
                dp[current] = Math.Max(valueWithCurrent, valueWoCurrent);
            }

            return dp[0];
        }



        public static void Work()
        {
            int[] houses = { 6, 7, 1, 30, 8, 2, 4 };   // Ans: 41
            //int[] houses = { 20, 5, 1, 13, 6, 11, 40 };   // Ans: 73

            //int value = new HouseThief().StealMaxValueMemo(houses);
            int value = new HouseThief().StealMaxValueTab(houses);
            WriteLine(value);
        }
    }
}