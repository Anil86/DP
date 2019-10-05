class XsquareAndChocolatesBars:
    def CountRemainingCandiesMemo(self, bar):
        dp = [(0, 0) for _ in range(len(bar))]

        def CountConsecutiveSets(current):
            # Solve small sub-problems
            if current <= 1:
                dp[0] = dp[1] = 0, 0
                return 0, 0

            # Divide
            # Case 1: Consider current
            # If different candies
            withCurrent = 0
            if bar[current] != bar[current - 1] or bar[current] != bar[current - 2]:
                if current - 3 < 0: current = 0
                if dp[current - 3] == (0, 0):
                    dp[current - 3] = CountConsecutiveSets(current - 3)
                withCurrent = 1 + dp[current - 3][1]
            else:
                withCurrent = 0

            # Case 2: Ignore current
            if current - 1 < 0: current = 0
            if dp[current - 1] == (0, 0):
                dp[current - 1] = CountConsecutiveSets(current - 1)
            withoutCurrent = dp[current - 1][0]

            # Combine
            dp[current] = (max(withCurrent, withoutCurrent), withCurrent)
            return dp[current]

        consecutiveSetsCount = CountConsecutiveSets(len(bar) - 1)[0]
        return len(bar) - 3 * consecutiveSetsCount

    def CountRemainingCandiesTab(self, bar):
        dp = [(0, 0) for _ in range(len(bar))]

        for current in range(2, len(bar)):
            # Consider current
            withCurrent = 0
            if bar[current] != bar[current - 1] or bar[current] != bar[current - 2]:
                previous = current - 3
                if previous < 0: previous = 0
                withCurrent = 1 + dp[previous][1]
            else:
                withCurrent = 0

            # Ignore current
            previous = current - 1
            if previous < 0: previous = 0
            withoutCurrent = dp[previous][0]

            # Combine
            dp[current] = (max(withCurrent, withoutCurrent), withCurrent)

        consecutiveSetsCount = dp[len(bar) - 1][0]
        return len(bar) - 3 * consecutiveSetsCount

    _count = 0

    @staticmethod
    def Work():
        # bar = "CCCCCCCCC"  # Ans: 9
        # bar = "SSSSCSCCC"  # Ans: 3   # C: 16  9
        # bar = "SSCCSSSCS"  # Ans: 0   # C: 34   10
        # bar = "CCSSSSC"  # Ans: 1   # C: 14  7
        bar = "CCCSCCSSSCSCCSCSSCSCCCSSCCSCCCSCCSSSCCSCCCSCSCCCSSSCCSSSSCSCCCSCSSCSSSCSSSCSCCCSCSCSCSSSCS"  # Ans: 39  C: 91

        remainingCandies = XsquareAndChocolatesBars().CountRemainingCandiesTab(bar)
        print(remainingCandies)
