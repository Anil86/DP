using static System.Console;

namespace DP
{
    public class NumberFactor
    {
        private int NoOfCombinations(int n)
        {
            int[] dp = new int[n + 1];

            return NoOfCombinationsLocal(n);


            int NoOfCombinationsLocal(int num)
            {
                // Solve small sub-problems
                switch (num)
                {
                    case int numb when numb <= 2: return dp[numb] = 1;
                    case 3: return dp[3] = 2;
                }


                // Divide
                if (dp[num - 1] == 0) dp[num - 1] = NoOfCombinationsLocal(num - 1);
                if (dp[num - 3] == 0) dp[num - 3] = NoOfCombinationsLocal(num - 3);
                if (dp[num - 4] == 0) dp[num - 4] = NoOfCombinationsLocal(num - 4);


                // Combine
                return dp[num] = dp[num - 1] + dp[num - 3] + dp[num - 4];
            }
        }


        public static void Work()
        {
            //int n = 4;   // Ans: 4
            //int n = 5;   // Ans: 6
            int n = 6;   // Ans: 9

            int noOfTimes = new NumberFactor().NoOfCombinations(n);
            WriteLine(noOfTimes);
        }
    }
}