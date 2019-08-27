using static System.Console;

namespace DP
{
    public class MaxSumProblem
    {
        private int MaximizeCombinedSum(int num)
        {
            int[] dp = new int[num + 1];

            return MaxCombineSum(num);



            int MaxCombineSum(int n)
            {
                // Solve small sub-problems
                //if (n <= 4) return dp[n] = n;   // If num <= 4, combined sum always = num
                if (n <= 11) return dp[n] = n;   // Optimization: If num <= 11, combined sum always = num


                // Divide
                int part = n / 2;   // Sub-problem 1
                int nBy2 = dp[part] == 0 ? dp[part] = MaxCombineSum(part) : dp[part];

                part = n / 3;   // Sub-problem 2
                int nBy3 = dp[part] == 0 ? dp[part] = MaxCombineSum(part) : dp[part];

                part = n / 4;   // Sub-problem 3
                int nBy4 = dp[part] == 0 ? dp[part] = MaxCombineSum(part) : dp[part];



                // Combine
                int sum = nBy2 + nBy3 + nBy4;   // Combined sum
                switch (sum)
                {
                    case int s when s <= n: return dp[n] = n;   // Ignore sum <= num; instead return num
                    default: return dp[n] = sum;   // sum > num; return sum
                }
            }
        }


        internal static void Work()
        {
            int n = 12;
            //int n = 24;

            int maxCombinedSum = new MaxSumProblem().MaximizeCombinedSum(n);
            WriteLine(maxCombinedSum);
        }
    }
}