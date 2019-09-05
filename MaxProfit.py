from enum import Enum


class MaxProfit:
    def CollectMax(self, array1, array2, penalty):
        dp = [[None] * 2 for _ in range(len(array1) + 1)]

        def CollectMax(i, previousArray):
            # Solve small sub-problems
            if i == len(array1):
                dp[i][previousArray.value] = 0
                return 0

            # Divide
            p = 0 if i == 0 else penalty   # No penalty when picking 1st item

            # Choice 1: Pick array1
            if dp[i + 1][PreviousArray.Array1.value] is None:
                dp[i + 1][PreviousArray.Array1.value] = CollectMax(i + 1, PreviousArray.Array1)
            # If previous from array1, pick current array1 & find max from remaining
            # If previous from array2, pick current array1, deduct penalty & find max from remaining
            maxA = array1[i] + dp[i + 1][PreviousArray.Array1.value] \
                if previousArray == PreviousArray.Array1 else \
                array1[i] - p + dp[i + 1][PreviousArray.Array1.value]

            # Choice 2: Pick array2
            if dp[i + 1][PreviousArray.Array2.value] is None:
                dp[i + 1][PreviousArray.Array2.value] = CollectMax(i + 1, PreviousArray.Array2)
            # If previous from array1, pick current array2, deduct penalty & find max from remaining
            # If previous from array2, pick current array2 & find max from remaining
            maxB = array2[i] - p + dp[i + 1][PreviousArray.Array2.value] \
                if previousArray == PreviousArray.Array1 else \
                array2[i] + dp[i + 1][PreviousArray.Array2.value]

            # Combine
            # Find max from choice 1 & 2
            dp[i][previousArray.value] = max(maxA, maxB)
            return dp[i][previousArray.value]

        # Start from 1st item & previous array = array1
        return CollectMax(0, PreviousArray.Array1)

    @staticmethod
    def Work():
        array1 = [1, 2, 3]
        array2 = [4, 5, 1]
        penalty = 2  # Ans: 10

        # array1 = [1, 2, 3, 4, 7, 1]
        # array2 = [4, 5, 1, 4, 1, 7]
        # penalty = 2  # Ans: 26

        maxTotal = MaxProfit().CollectMax(array1, array2, penalty)
        print(maxTotal)


PreviousArray = Enum("PreviousArray", {"Array1": 0, "Array2": 1})
