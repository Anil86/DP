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
                _count++;
                // Solve small sub-problems
                switch (num)
                {
                    case int numb when numb <= 2: dp[numb] = 1; break;
                    case 3: dp[3] = 2; break;
                        //case int numb when numb <= 2: return 1;
                        //case 3: return 2;
                }


                // Divide
                if (dp[num] == 0)
                {
                    int nMinus1Ways = NoOfCombinationsLocal(num - 1);
                    int nMinus3Ways = NoOfCombinationsLocal(num - 3);
                    int nMinus4Ways = NoOfCombinationsLocal(num - 4);

                    dp[num] = nMinus1Ways + nMinus3Ways + nMinus4Ways;
                }


                // Combine
                return dp[num];
            }
        }


        private static int _count;
        public static void Work()
        {
            //int n = 4;   // Ans: 4
            //int n = 5;   // Ans: 6
            int n = 6;   // Ans: 9   Count: 10  7  

            int noOfTimes = new NumberFactor().NoOfCombinations(n);
            WriteLine(noOfTimes); WriteLine($"Count: {_count}");
        }
    }
}