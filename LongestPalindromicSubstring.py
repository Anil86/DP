class LongestPalindromicSubstring:
    def FindLpsLengthMemo(self, s):
        dp = [[-1 for _ in range(len(s))] for _ in range(len(s))]

        def FindLpsLength(start, end):
            # Solve small sub-problems
            if start == end:
                dp[start][end] = 1
                return 1

            if end < start:
                dp[start][end] = 0
                return 0

            # Divide
            # Case 1: Equal chars
            if s[start] == s[end]:
                noOfInBetweenChars = end - start - 1
                if dp[start + 1][end - 1] == -1:
                    dp[start + 1][end - 1] = FindLpsLength(start + 1, end - 1)
                noOfPalindromicChars = dp[start + 1][end - 1]
                if noOfInBetweenChars == noOfPalindromicChars:
                    dp[start][end] = 2 + noOfPalindromicChars
                    return dp[start][end]

            # Case 2: Unequal chars
            # Case 2.1: Match start char w/ end's previous char
            if dp[start][end - 1] == -1:
                dp[start][end - 1] = FindLpsLength(start, end - 1)
            noOfMatchesStart = dp[start][end - 1]
            # Case 2.2: Match end char w/ start's next char
            if dp[start + 1][end] == -1:
                dp[start + 1][end] = FindLpsLength(start + 1, end)
            noOfMatchesEnd = dp[start + 1][end]

            # Combine
            dp[start][end] = max(noOfMatchesStart, noOfMatchesEnd)
            return dp[start][end]

        return FindLpsLength(0, len(s) - 1)

    def FindLpsLengthTab(self, s):
        length = len(s)
        dp = [[0 for _ in range(length)] for _ in range(length)]

        for end in range(length):
            for start in range(end, -1, -1):
                # Solve small sub-problems
                if start == end:
                    dp[start][end] = 1
                    continue

                # Divide
                # Case 1: Equal chars
                if s[start] == s[end]:
                    noOfInBetweenChars = end - start - 1
                    noOfPalindromicChars = dp[start + 1][end - 1]
                    if noOfInBetweenChars == noOfPalindromicChars:
                        dp[start][end] = 2 + noOfPalindromicChars
                        continue

                # Case 2: Unequal chars
                # Case 2.1: Match start char w/ end's previous char
                noOfMatchesStart = dp[start][end - 1]
                # Case 2.2: Match end char w/ start's next char
                noOfMatchesEnd = dp[start + 1][end]

                # Combine
                dp[start][end] = max(noOfMatchesStart, noOfMatchesEnd)

        return dp[0][length - 1]

    @staticmethod
    def Work():
        s = "amadamb"  # Ans: 5
        # s = "abccbua"  # Ans: 4   105   29
        # s = "mamdrdm"   # Ans: 5   110   20
        # s = "mqadasm"  # Ans: 3   118   28

        longestPalindromeCount = LongestPalindromicSubstring().FindLpsLengthTab(s)
        print(longestPalindromeCount)
