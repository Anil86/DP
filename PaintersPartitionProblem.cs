using System;
using static System.Console;

namespace DP
{
    public class PaintersPartitionProblem
    {
        private int MinimizeMaxWorkDp(int noOfPainters, int[] boards)
        {
            int[,] dp = new int[boards.Length, noOfPainters + 1];

            // No.of boards is 0 based, hence boards.Length - 1
            return MinimizeMaxWork(boards.Length - 1, noOfPainters);



            int MinimizeMaxWork(int noOfBoards, int painters)
            {
                // Solve small sub-problems
                if (noOfBoards == 0) return dp[0, painters] = boards[0];   // No.of boards = 1

                // no.of painters ≥ No.of boards, return max
                if (noOfBoards + 1 <= painters)
                {
                    int max = int.MinValue;
                    for (int i = 0; i <= noOfBoards; i++) max = Math.Max(max, boards[i]);
                    return dp[noOfBoards, painters] = max;
                }

                if (painters == 1) return dp[noOfBoards, 1] = SumWork(0, noOfBoards);   // No.of painters = 1


                int minimizedMaxWork = int.MaxValue;
                for (int i = 0; i < noOfBoards; i++)
                {
                    // Divide
                    // Max of previous sub-array [0 : i]
                    // Painters = painters - last painter
                    int prevPaintersMax = dp[i, painters - 1] == 0
                        ? dp[i, painters - 1] = MinimizeMaxWork(i, painters - 1)
                        : dp[i, painters - 1];
                    int lastPainterSum = SumWork(i + 1, noOfBoards);   // Last sub-array "[i + 1 : end]" sum


                    // Combine
                    // Find max of previous & last sub-array
                    int currentMaxWork = Math.Max(prevPaintersMax, lastPainterSum);


                    // Minimize max sub-array
                    minimizedMaxWork = Math.Min(currentMaxWork, minimizedMaxWork);
                }

                return dp[noOfBoards, painters] = minimizedMaxWork;
            }


            int SumWork(int start, int end)
            {
                int totalTime = 0;

                for (int i = start; i <= end; i++) totalTime += boards[i];

                return totalTime;
            }
        }



        internal static void Work()
        {
            int noOfPainters = 2;
            //int[] boards = { 10, 10, 10, 10 };   // Ans: 20
            int[] boards = { 10, 20, 30, 40 };   // Ans: 60

            //int noOfPainters = 5;
            //int[] boards = { 2, 8, 9, 1 };   // Ans: 9

            //int noOfPainters = 14;
            //int[] boards =
            //{
            //    189, 107, 444, 400, 84, 270, 225, 334, 410, 433, 249, 193, 487, 312, 493, 430, 422, 208, 90, 245, 337,
            //    234, 168, 360
            //};
            // Ans: 740   // Calls: 222

            //int noOfPainters = 26;
            //int[] boards =
            //{
            //    274, 465, 130, 135, 254, 45, 70, 122, 149, 95, 453, 65, 392, 331, 316, 484, 372, 339, 45, 46, 31, 167,
            //    351, 415, 387, 275, 355, 440, 290, 462, 436, 416, 279, 66, 403, 33, 464, 473, 8, 113, 420, 461, 30, 312
            //};
            // Ans: 647   // Calls: 776

            int fairMaxWork = new PaintersPartitionProblem().MinimizeMaxWorkDp(noOfPainters, boards);
            WriteLine(fairMaxWork);
        }
    }
}