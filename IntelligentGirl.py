class IntelligentGirl:
    def CountEvens(self, numbers):
        """
        Count no.of evens in array using DP

        :param numbers: Array of numbers
        :return: void
        """
        dp = [-1] * (len(numbers) + 1)

        def CountEvens(i):
            # Solve small sub-problems
            if i == len(numbers):
                dp[i] = 0
                return 0

            # Divide
            currentEvenCount = 1 if numbers[i] % 2 == 0 else 0

            if dp[i + 1] == -1: CountEvens(i + 1)
            remainingEvensCount = dp[i + 1]

            # Combine
            dp[i] = currentEvenCount + remainingEvensCount
            return dp[i]

        countEvens = ""
        for i in range(len(numbers)):
            if dp[i] == -1: CountEvens(i)
            countEven = dp[i]
            countEvens += f" {countEven}"

        print(countEvens.lstrip())

    #######################################################################################################

    def CountEvensMerge(self, numbers):
        """
        Count no.of evens in array using Merge Sort algorithm.

        :param numbers: Array of numbers
        :return: void
        """
        dp = [[-1] * len(numbers) for _ in range(len(numbers))]

        def CountEvens(start, end=len(numbers) - 1):
            # Solve small sub-problems
            if start == end:
                dp[start][end] = 1 if numbers[start] % 2 == 0 else 0
                return dp[start][end]

            # Divide
            mid = (start + end) // 2

            if dp[start][mid] == -1: CountEvens(start, mid)
            evensInLeft = dp[start][mid]
            if dp[mid + 1][end] == -1: CountEvens(mid + 1, end)
            evensInRight = dp[mid + 1][end]

            # Combine
            dp[start][end] = evensInLeft + evensInRight
            return dp[start][end]

        countEvens = ""
        for i in range(len(numbers)):
            if dp[i][len(numbers) - 1] == -1: CountEvens(i)
            countEven = dp[i][len(numbers) - 1]
            countEvens += f" {countEven}"

        print(countEvens.lstrip())

    @staticmethod
    def Work():
        numbers = [3, 2, 7, 8]  # Ans: 2 2 1 1
        # numbers = [5, 7, 4, 6, 7, 4, 5, 4, 6, 4, 7, 6]  # Ans: 7 7 7 6 5 5 4 4 3 2 1 1

        # IntelligentGirl().CountEvens(numbers)
        IntelligentGirl().CountEvensMerge(numbers)
