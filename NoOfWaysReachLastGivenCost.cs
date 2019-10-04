using static System.Console;

namespace DP
{
    public class NoOfWaysReachLastGivenCost
    {
        private int NoOfWays(int[,] array, int cost)
        {
            return NoOfWays(array.GetLength(0) - 1, array.GetLength(1) - 1, cost);



            int NoOfWays(int row, int column, int c)
            {
                _count++;
                int balance = c - array[row, column];

                // Solve small sub-problems
                if (balance < 0) return 0;

                if (row == 0 && column == 0) return balance == 0 ? 1 : 0;


                // Optimizations
                // 1st row
                if (row == 0) return NoOfWays(0, column - 1, balance);
                // 1st column
                if (column == 0) return NoOfWays(row - 1, 0, balance);


                // Divide
                int waysFromLeft = NoOfWays(row, column - 1, balance);
                int waysFromTop = NoOfWays(row - 1, column, balance);


                // Combine
                return waysFromLeft + waysFromTop;
            }
        }


        private static int _count;
        internal static void Work()
        {
            //int[,] array =
            //{
            //    {4, 7, 1, 6},
            //    {5, 7, 3, 9},
            //    {3, 2, 1, 2},
            //    {7, 1, 6, 3}
            //};
            //int cost = 25;   // Ans: 2   63

            int[,] array =
            {
                {4, 7, 1},
                {7, 1, 3}
            };
            int cost = 15;   // Ans: 3   9

            int noOfWays = new NoOfWaysReachLastGivenCost().NoOfWays(array, cost);
            WriteLine(noOfWays); WriteLine($"C: {_count}");
        }
    }
}