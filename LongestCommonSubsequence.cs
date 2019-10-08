using System;
using static System.Console;

namespace DP
{
    public class LongestCommonSubsequence
    {
        private int FindLcsLengthMemo(string str1, string str2)
        {
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];
            for (int i1 = 0; i1 < dp.GetLength(0); i1++)
                for (int i2 = 0; i2 < dp.GetLength(1); i2++)
                    dp[i1, i2] = -1;

            return FindLcsLength(0, 0);



            int FindLcsLength(int i1, int i2)
            {
                // Solve small sub-problems
                if (i1 == str1.Length || i2 == str2.Length)
                    return dp[str1.Length, i2] = dp[i1, str2.Length] = 0;


                // Divide
                // Case 1: Equal chars
                if (str1[i1] == str2[i2])
                {
                    if (dp[i1 + 1, i2 + 1] == -1)
                        dp[i1 + 1, i2 + 1] = FindLcsLength(i1 + 1, i2 + 1);
                    return dp[i1, i2] = 1 + dp[i1 + 1, i2 + 1];
                }

                // Case 2: Unequal chars
                // Case 2.1: Find str1 char match in str2
                if (dp[i1, i2 + 1] == -1) dp[i1, i2 + 1] = FindLcsLength(i1, i2 + 1);
                // Case 2.2: Find str2 char match in str1
                if (dp[i1 + 1, i2] == -1) dp[i1 + 1, i2] = FindLcsLength(i1 + 1, i2);


                // Combine
                return dp[i1, i2] = Math.Max(dp[i1, i2 + 1], dp[i1 + 1, i2]);
            }
        }


        private int FindLcsLengthTab(string str1, string str2)
        {
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];

            // Solve small sub-problems
            // Last row & column already 0.


            // Divide
            // Matrix filled column-wise (instead of row-wise) because
            // DP Table is filled column-wise
            for (var i2 = dp.GetLength(1) - 2; i2 >= 0; i2--)
                for (var i1 = dp.GetLength(0) - 2; i1 >= 0; i1--)
                {
                    // Case 1: Equal chars
                    if (str1[i1] == str2[i2]) dp[i1, i2] = 1 + dp[i1 + 1, i2 + 1];
                    else
                    {
                        // Case 2: Unequal chars
                        // Case 2.1: Find str1 char match in str2
                        int matchStr1Length = dp[i1, i2 + 1];
                        // Case 2.2: Find str2 char match in str1
                        int matchStr2Length = dp[i1 + 1, i2];


                        // Combine
                        dp[i1, i2] = Math.Max(matchStr1Length, matchStr2Length);
                    }
                }

            return dp[0, 0];
        }


        internal static void Work()
        {
            #region Longest Common Subsequence

            string s1 = "elephant",
                s2 = "eretpat";   // Ans: 5
            //string s1 = "houdini",
            //    s2 = "hdupti";   // Ans: 3
            //string s1 = "text",
            //    s2 = "set";   // Ans: 2

            int longestSubsequence = new LongestCommonSubsequence().FindLcsLengthTab(s1, s2);
            WriteLine(longestSubsequence);

            #endregion
        }
    }
}