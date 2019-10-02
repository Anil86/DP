from collections import namedtuple


class XsquareAndChocolatesBars:
    # def CountRemainingCandies(self, bar):
    #     dp = [-1] * (len(bar) + 2)
    #
    #     def CountDifferentCandiesSets(current):
    #         XsquareAndChocolatesBars._count += 1
    #         # Solve small sub-problems
    #         if current >= len(bar) - 1:
    #             dp[current] = 0
    #             return 0
    #
    #         # Divide
    #         # Consider current
    #         if bar[current - 1] == bar[current] and bar[current] == bar[current + 1]:
    #             if dp[current + 1] == -1:
    #                 dp[current + 1] = CountDifferentCandiesSets(current + 1)
    #             return dp[current + 1]
    #
    #         if dp[current + 3] == -1:
    #             dp[current + 3] = CountDifferentCandiesSets(current + 3)
    #         setsWithCurrent = 1 + dp[current + 3]
    #
    #         # Skip current
    #         if dp[current + 1] == -1:
    #             dp[current + 1] = CountDifferentCandiesSets(current + 1)
    #         setsWithoutCurrent = dp[current + 1]
    #
    #         # Combine
    #         dp[current] = max(setsWithCurrent, setsWithoutCurrent)
    #         return dp[current]
    #
    #     differentCandiesSetCount = CountDifferentCandiesSets(1)
    #     return len(bar) - 3 * differentCandiesSetCount

    # def CountRemainingCandies(self, bar):
    #     dp = [ReturnValues(candySetsCount=-1, canConsiderCurrent=False) for _ in range(len(bar) + 2)]
    #
    #     def CountConsecutiveDifferentCandySets(current):
    #         XsquareAndChocolatesBars._count += 1
    #         # Solve small sub-problems
    #         if current >= len(bar) - 1:
    #             dp[current] = ReturnValues(candySetsCount=0, canConsiderCurrent=False)
    #             return dp[current]
    #
    #         # Divide
    #         # Case 1: Consider current
    #         # Case 1.1: If same chocolate set
    #         withCurrent = ReturnValues(candySetsCount=0, canConsiderCurrent=False)
    #         # Case 1.2: If different chocolate set
    #         if bar[current - 1] != bar[current] or bar[current] != bar[current + 1]:
    #             if dp[current + 3].candySetsCount == -1:
    #                 dp[current + 3] = CountConsecutiveDifferentCandySets(current + 3)
    #             withCurrent = ReturnValues(candySetsCount=1 + dp[current + 3].candySetsCount, canConsiderCurrent=True) \
    #                 if dp[current + 3].canConsiderCurrent else \
    #                 ReturnValues(candySetsCount=1, canConsiderCurrent=True)
    #
    #         # Case 2: Consider next
    #         if dp[current + 1].candySetsCount == -1:
    #             dp[current + 1] = CountConsecutiveDifferentCandySets(current + 1)
    #         withoutCurrent = dp[current + 1]
    #
    #         # Combine
    #         dp[current] = withCurrent if withCurrent.candySetsCount > withoutCurrent.candySetsCount else withoutCurrent
    #         return dp[current]
    #
    #     (consecutiveDifferentCandySetCount, _) = CountConsecutiveDifferentCandySets(1)
    #     return len(bar) - 3 * consecutiveDifferentCandySetCount

    def CountRemainingCandies(self, bar):
        def CountConsecutiveSets(current):
            XsquareAndChocolatesBars._count += 1
            # Solve small sub-problems
            if current >= len(bar) - 1: return 0

            # Divide
            # Case 1: If same candies
            if bar[current - 1] == bar[current] and bar[current] == bar[current + 1]:
                return CountConsecutiveSets(current + 1)

            # Case 2: If different candies
            # Case 2.1: Consider current
            withCurrent = 1 + CountConsecutiveSets(current + 3)
            # Case 2.2: Ignore current
            withoutCurrent = CountConsecutiveSets(current + 1)

            # Combine
            return max(withCurrent, withoutCurrent)

        consecutiveSetsCount = CountConsecutiveSets(1)
        return len(bar) - 3 * consecutiveSetsCount

    _count = 0

    @staticmethod
    def Work():
        # bar = "CCCCCCCCC"  # Ans: 9
        # bar = "SSSSCSCCC"  # Ans: 3   # C: 16  9
        # bar = "SSCCSSSCS"  # Ans: 0   # C: 34   10
        # bar = "CCSSSSC"  # Ans: 1   # C: 14  7
        bar = "CCCSCCSSSCSCCSCSSCSCCCSSCCSCCCSCCSSSCCSCCCSCSCCCSSSCCSSSSCSCCCSCSSCSSSCSSSCSCCCSCSCSCSSSCS"  # Ans: 39  C: 91

        remainingCandies = XsquareAndChocolatesBars().CountRemainingCandies(bar)
        print(remainingCandies)
        print(f"C: {XsquareAndChocolatesBars._count}")


ReturnValues = namedtuple("ReturnValues", ["candySetsCount", "canConsiderCurrent"])
