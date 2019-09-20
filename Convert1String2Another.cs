using System;
using static System.Console;

namespace DP
{
    public class Convert1String2Another
    {
        private int CalculateNoOfEditsMemo(string str1, string str2)
        {
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];
            for (int i = 0; i < dp.GetLength(0); i++)
                for (int j = 0; j < dp.GetLength(1); j++)
                    dp[i, j] = -1;

            return CalculateNoOfEdits(0, 0);



            int CalculateNoOfEdits(int i1, int i2)
            {
                // Solve small sub-problems
                // If string-1 completes, remove remaining string-2 chars
                if (i1 == str1.Length) return dp[str1.Length, i2] = str2.Length - i2;
                // If string-2 completes, add remaining string-1 chars
                if (i2 == str2.Length) return dp[i1, str2.Length] = str1.Length - i1;


                // Divide
                // Case 1: 2 chars equal
                if (str1[i1] == str2[i2])
                {
                    if (dp[i1 + 1, i2 + 1] == -1)
                        dp[i1 + 1, i2 + 1] = CalculateNoOfEdits(i1 + 1, i2 + 1);
                    return dp[i1 + 1, i2 + 1];
                }

                // Case 2: 2 chars unequal
                // Case 2.1: Create
                if (dp[i1 + 1, i2] == -1) dp[i1 + 1, i2] = CalculateNoOfEdits(i1 + 1, i2);
                // Case 2.2: Update
                if (dp[i1 + 1, i2 + 1] == -1) dp[i1 + 1, i2 + 1] = CalculateNoOfEdits(i1 + 1, i2 + 1);
                // Case 2.3: Delete
                if (dp[i1, i2 + 1] == -1) dp[i1, i2 + 1] = CalculateNoOfEdits(i1, i2 + 1);


                // Combine
                return dp[i1, i2] = 1 + Math.Min(dp[i1 + 1, i2], Math.Min(dp[i1 + 1, i2 + 1], dp[i1, i2 + 1]));
            }
        }


        internal static void Work()
        {
            string s1 = "table",
                s2 = "tbres";   // Ans: 3

            int minEdits = new Convert1String2Another().CalculateNoOfEditsMemo(s1, s2);
            WriteLine(minEdits);
        }
    }
}