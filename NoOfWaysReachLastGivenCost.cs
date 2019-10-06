using static System.Console;

namespace DP
{
    public class NoOfWaysReachLastGivenCost
    {
        private int NoOfWays(int[,] array, int cost)
        {
            int[,,] dp = new int[array.GetLength(0), array.GetLength(1), cost + 1];
            for (var i = 0; i < dp.GetLength(0); i++)
                for (var j = 0; j < dp.GetLength(1); j++)
                    for (var k = 0; k < dp.GetLength(2); k++)
                        dp[i, j, k] = -1;

            return NoOfWays(array.GetLength(0) - 1, array.GetLength(1) - 1, cost);



            int NoOfWays(int row, int column, int c)
            {
                int balance = c - array[row, column];

                // Solve small sub-problems
                if (balance < 0)
                    if (c < 0)
                        return dp[row, column, 0] = 0;
                    else
                        return dp[row, column, c] = 0;

                if (row == 0 && column == 0)
                    if (balance == 0)
                        return dp[0, 0, c] = 1;
                    else
                        return dp[0, 0, c] = 0;


                // Optimizations
                // 1st row
                if (row == 0)
                {
                    if (dp[0, column - 1, balance] == -1)
                        dp[0, column - 1, balance] = NoOfWays(0, column - 1, balance);
                    return dp[0, column - 1, balance];
                }

                // 1st column
                if (column == 0)
                {
                    if (dp[row - 1, 0, balance] == -1)
                        dp[row - 1, 0, balance] = NoOfWays(row - 1, 0, balance);
                    return dp[row - 1, 0, balance];
                }


                // Divide
                if (dp[row, column - 1, balance] == -1)
                    dp[row, column - 1, balance] = NoOfWays(row, column - 1, balance);
                int waysFromLeft = dp[row, column - 1, balance];
                if (dp[row - 1, column, balance] == -1)
                    dp[row - 1, column, balance] = NoOfWays(row - 1, column, balance);
                int waysFromTop = dp[row - 1, column, balance];


                // Combine
                return dp[row, column, c] = waysFromLeft + waysFromTop;
            }
        }



        internal static void Work()
        {
            //int[,] array =
            //{
            //    {4, 7, 1, 6},
            //    {5, 7, 3, 9},
            //    {3, 2, 1, 2},
            //    {7, 1, 6, 3}
            //};
            //int cost = 25;   // Ans: 2   63   49

            //int[,] array =
            //{
            //    {4, 7, 1},
            //    {7, 1, 3}
            //};
            //int cost = 15;   // Ans: 3   9   6

            int[,] array =
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };
            int cost = 5;   // Ans: 6   19   9

            int noOfWays = new NoOfWaysReachLastGivenCost().NoOfWays(array, cost);
            WriteLine(noOfWays);
        }
    }
}