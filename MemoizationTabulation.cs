using static System.Console;

namespace DP
{
    public class MemoizationTabulation
    {
        private long FibonacciMemoization(int num)
        {
            long[] dp = new long[num + 1];

            return FibonacciMemoizationLocal(num);


            long FibonacciMemoizationLocal(int n)
            {
                // Solve small sub-problems
                if (n <= 1) return dp[n] = n;


                // Divide
                if (dp[n - 1] == 0) dp[n - 1] = FibonacciMemoizationLocal(n - 1);
                long augend = dp[n - 1];
                if (dp[n - 2] == 0) dp[n - 2] = FibonacciMemoizationLocal(n - 2);
                long addend = dp[n - 2];


                // Combine
                return dp[n] = augend + addend;
            }
        }



        private long FibonacciTabulation(int num)
        {
            long[] dp = new long[num + 1];

            // Solve small sub-problems
            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= num; i++)
            {
                // Divide
                long augend = dp[i - 1];   // Augend
                long addend = dp[i - 2];   // Addend


                // Combine
                dp[i] = augend + addend;
            }

            return dp[num];
        }



        internal static void Work()
        {
            int n = 5;   // Ans: 5   Count: 15
            //int n = 20;   // Ans: 6765   Count: 21891   21
            //int n = 50;   // Ans: 12586269025   Count: Very long time   51

            //long fibonacciNumber = new MemoizationTabulation().FibonacciMemoization(n);
            long fibonacciNumber = new MemoizationTabulation().FibonacciTabulation(n);
            WriteLine(fibonacciNumber);
        }
    }
}