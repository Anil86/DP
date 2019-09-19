using System;
using static System.Console;

namespace DP
{
    public class HouseThief
    {
        private int StealMaxValue(int[] houses)
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


        public static void Work()
        {
            int[] houses = { 6, 7, 1, 30, 8, 2, 4 };   // Ans: 41
            //int[] houses = { 20, 5, 1, 13, 6, 11, 40 };   // Ans: 73

            int value = new HouseThief().StealMaxValue(houses);
            WriteLine(value);
        }
    }
}