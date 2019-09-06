class IntelligentGirl:
    def CountEvens(self, numbers):
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

    @staticmethod
    def Work():
        numbers = [3, 2, 7, 8]   # Ans: 2 2 1 1
        # numbers = [5, 7, 4, 6, 7, 4, 5, 4, 6, 4, 7, 6]  # Ans: 7 7 7 6 5 5 4 4 3 2 1 1

        IntelligentGirl().CountEvens(numbers)
