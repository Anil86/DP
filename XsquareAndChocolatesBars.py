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

    def CountRemainingCandies(self, bar):
        dp = [ReturnValues(candySetsCount=-1, canConsiderCurrent=False) for _ in range(len(bar) + 2)]

        def CountConsecutiveDifferentCandySets(current):
            XsquareAndChocolatesBars._count += 1
            # Solve small sub-problems
            if current >= len(bar) - 1:
                dp[current] = ReturnValues(candySetsCount=0, canConsiderCurrent=False)
                return dp[current]

            # Divide
            # Case 1: Consider current
            # Case 1.1: If same chocolate set
            withCurrent = ReturnValues(candySetsCount=0, canConsiderCurrent=False)
            # Case 1.2: If different chocolate set
            if bar[current - 1] != bar[current] or bar[current] != bar[current + 1]:
                if dp[current+3].candySetsCount==-1: dp[current+3] = CountConsecutiveDifferentCandySets(current + 3)
                tempWithCurrent = CountConsecutiveDifferentCandySets(current + 3)
                withCurrent = ReturnValues(candySetsCount=1 + tempWithCurrent.candySetsCount, canConsiderCurrent=True) \
                    if tempWithCurrent.canConsiderCurrent else \
                    ReturnValues(candySetsCount=1, canConsiderCurrent=True)

                # Consider next
            withoutCurrent = CountConsecutiveDifferentCandySets(current + 1)

            # Combine
            return withCurrent if withCurrent.candySetsCount > withoutCurrent.candySetsCount else withoutCurrent

        (consecutiveDifferentCandySetCount, _) = CountConsecutiveDifferentCandySets(1)
        return len(bar) - 3 * consecutiveDifferentCandySetCount

    _count = 0

    @staticmethod
    def Work():
        # bar = "CCCCCCCCC"   # Ans: 9
        # bar = "SSSSCSCCC"  # Ans: 3   # C: 16
        # bar = "SSCCSSSCS"  # Ans: 0   # C: 34
        bar = "CCSSSSC"  # Ans: 1   # C: 14
        # bar = "CCCSCCSSSCSCCSCSSCSCCCSSCCSCCCSCCSSSCCSCCCSCSCCCSSSCCSSSSCSCCCSCSSCSSSCSSSCSCCCSCSCSCSSSCS"  # Ans: 39  C: 91

        remainingCandies = XsquareAndChocolatesBars().CountRemainingCandies(bar)
        print(remainingCandies)
        print(f"C: {XsquareAndChocolatesBars._count}")


ReturnValues = namedtuple("ReturnValues", ["candySetsCount", "canConsiderCurrent"])
