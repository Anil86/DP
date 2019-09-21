using System;
using static System.Console;

namespace DP
{
    public class LongestCommonSubsequence
    {
        private int FindLcsLengthMemo(string str1, string str2)
        {
            return FindLcsLength(0, 0);



            int FindLcsLength(int i1, int i2)
            {
                // Solve small sub-problems
                if (i1 == str1.Length || i2 == str2.Length) return 0;


                // Divide
                // Case 1: Equal chars
                if (str1[i1] == str2[i2]) return 1 + FindLcsLength(i1 + 1, i2 + 1);

                // Case 2: Unequal chars
                // Case 2.1: Find str1 char match in str2
                int matchesSkipStr2 = FindLcsLength(i1, i2 + 1);
                // Case 2.2: Find str2 char match in str1
                int matchesSkipStr1 = FindLcsLength(i1 + 1, i2);


                // Combine
                return Math.Max(matchesSkipStr2, matchesSkipStr1);
            }
        }



        internal static void Work()
        {
            //string s1 = "elephant",
            //    s2 = "eretpat";   // Ans: 5
            string s1 = "houdini",
                s2 = "hdupti";   // Ans: 3
            //string s1 = "text",
            //    s2 = "set";   // Ans: 2

            int longestSubsequence = new LongestCommonSubsequence().FindLcsLengthMemo(s1, s2);
            WriteLine(longestSubsequence);
        }
    }
}