using System;
using static System.Console;

namespace DP
{
    public class PaintersPartitionProblem
    {
        private int MinimizeMaxBoards(int[] boards, int noOfPainters)
        {
            int[,] dp = new int[boards.Length, noOfPainters + 1];

            // No.of boards is 0 based, hence boards.Length - 1
            return MinimizeMaxBoards(boards.Length - 1, noOfPainters);



            int MinimizeMaxBoards(int noOfBoards, int painters)
            {
                // Note: noOfBoards is 0 based

                // Solve small sub-problems
                if (noOfBoards == 0) return dp[0, painters] = boards[0];   // If only 1 board, return it
                if (painters == 1) return dp[noOfBoards, 1] = AddBoards(0, noOfBoards);   // If only 1 painter, he paints all boards

                if (painters >= noOfBoards + 1)   // If painters >= boards, return max board
                {
                    int maxBoard = int.MinValue;
                    for (int i = 0; i <= noOfBoards; i++) maxBoard = Math.Max(boards[i], maxBoard);
                    return dp[noOfBoards, painters] = maxBoard;
                }

                int minimumMaxBoardsSegment = int.MaxValue;
                for (int board = 0; board < noOfBoards; board++)
                {
                    // Divide
                    // Problem 2: Max of previous sub-array [0 : i]
                    // Painters = painters - last painter
                    int prevPartitionsMax = dp[board, painters - 1] == 0
                        ? dp[board, painters - 1] = MinimizeMaxBoards(board, painters - 1)
                        : dp[board, painters - 1];
                    // Problem 1: Last sub-array "[i + 1 : noOfBoards]" sum
                    int lastPartition = AddBoards(board + 1, noOfBoards);


                    // Combine
                    // Time taken = max segment
                    int maxBoardsSegment = Math.Max(prevPartitionsMax, lastPartition);


                    // Minimum of all possible max boards segment
                    minimumMaxBoardsSegment = Math.Min(maxBoardsSegment, minimumMaxBoardsSegment);
                }

                return dp[noOfBoards, painters] = minimumMaxBoardsSegment;
            }


            int AddBoards(int start, int end)
            {
                int sum = 0;
                for (int i = start; i <= end; i++) sum += boards[i];
                return sum;
            }
        }


        internal static void Work()
        {
            //int noOfPainters = 2;
            //int[] boards = { 10, 10, 10, 10 };   // Ans: 20
            //int[] boards = { 10, 20, 30, 40 };   // Ans: 60

            int noOfPainters = 5;
            int[] boards = { 2, 8, 9, 1 };   // Ans: 9

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

            int fairMaxWork = new PaintersPartitionProblem().MinimizeMaxBoards(boards, noOfPainters);
            WriteLine(fairMaxWork);
        }
    }
}