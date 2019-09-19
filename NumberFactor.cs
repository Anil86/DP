using static System.Console;

namespace DP
{
    public class NumberFactor
    {
        private int NoOfCombinationsMemo(int n)
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


        private int NoOfCombinationsTab(int n)
        {
            int[] dp = new int[n + 1];

            // Solve small sub-problems
            dp[0] = dp[1] = dp[2] = 1;
            dp[3] = 2;

            for (int i = 4; i <= n; i++)
            {
                // Divide
                int nMinus1Ways = dp[i - 1];
                int nMinus3Ways = dp[i - 3];
                int nMinus4Ways = dp[i - 4];


                // Combine
                dp[i] = nMinus1Ways + nMinus3Ways + nMinus4Ways;
            }

            return dp[n];
        }



        public static void Work()
        {
            //int n = 4;   // Ans: 4
            //int n = 5;   // Ans: 6
            //int n = 6;   // Ans: 9
            int n = 7;   // Ans: 15

            //int noOfTimes = new NumberFactor().NoOfCombinationsMemo(n);
            int noOfTimes = new NumberFactor().NoOfCombinationsTab(n);
            WriteLine(noOfTimes);
        }
    }
}