class LongestPalindromicSubstring:
    def FindLpsLengthMemo(self, s):
        def FindLpsLength(start, end):
            # Solve small sub-problems
            if start == end: return 1

            if end < start: return 0

            # Divide
            # Case 1: Equal chars
            if s[start] == s[end]:
                noOfInBetweenChars = end - start - 1
                noOfPalindromicChars = FindLpsLength(start + 1, end - 1)
                if noOfInBetweenChars == noOfPalindromicChars: return 2 + noOfPalindromicChars

            # Case 2: Unequal chars
            # Case 2.1: Match start char w/ end's previous char
            noOfMatchesStart = FindLpsLength(start, end - 1)
            # Case 2.2: Match end char w/ start's next char
            noOfMatchesEnd = FindLpsLength(start + 1, end)

            # Combine
            return max(noOfMatchesStart, noOfMatchesEnd)

        return FindLpsLength(0, len(s) - 1)

    @staticmethod
    def Work():
        # s = "amadamb"  # Ans: 5
        # s = "abccbua"   # Ans: 4
        # s = "mamdrdm"   # Ans: 5
        s = "mqadasm"   # Ans: 3

        longestPalindromeCount = LongestPalindromicSubstring().FindLpsLengthMemo(s)
        print(longestPalindromeCount)
