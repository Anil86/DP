class LongestPalindromicSubsequence:
    def FindLpsLengthMemo(self, s):
        def FindLpsLength(start, end):
            # Solve small sub-problems
            # If start & end coincide, it's a palindrome of length 1.
            # Also no more processing needed.
            # So return 0.
            if start == end: return 1

            # If start crosses end, then no more processing required. So return 0.
            if end < start: return 0

            # Divide
            # Match start & end char
            # Case 1: Chars match
            # Take count 2 &
            # find remaining matches
            if s[start] == s[end]: return 2 + FindLpsLength(start + 1, end - 1)

            # Case: 2 Chars don't match
            # Take count 0 &
            # match unmatched chars in remaining chars
            # Case 2.1: Match start char w/ end's previous char
            noOfMatchSkipEnd = FindLpsLength(start, end - 1)

            # Case 2.2: Match end char w/ start's next char
            noOfMatchSkipStart = FindLpsLength(start + 1, end)

            # Combine
            return max(noOfMatchSkipEnd, noOfMatchSkipStart)

        return FindLpsLength(0, len(s) - 1)

    @staticmethod
    def Work():
        # s = "elrmenmet"  # Ans: 5
        # s = "ameewmea"   # Ans: 6
        # s = "abccbua"   # Ans: 6
        # s = "mamdrdm"   # Ans: 5
        s = "mqadasm"   # Ans: 5

        longestPalindromeCount = LongestPalindromicSubsequence().FindLpsLengthMemo(s)
        print(longestPalindromeCount)
