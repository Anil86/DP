class MaxSumProblem:
    def CalculateMaxSumAfterDivisionsMemo(self, num):
        dp = [-1] * (num + 1)

        def CalculateMaxSumAfterDivisions(n):
            # Solve small sub-problems
            if n <= 11:
                dp[n] = n
                return n

            # Divide
            quotient2 = n // 2
            if dp[quotient2] == -1:
                dp[quotient2] = CalculateMaxSumAfterDivisions(quotient2)

            quotient3 = n // 3
            if dp[quotient3] == -1:
                dp[quotient3] = CalculateMaxSumAfterDivisions(quotient3)

            quotient4 = n // 4
            if dp[quotient4] == -1:
                dp[quotient4] = CalculateMaxSumAfterDivisions(quotient4)

            # Combine
            partsSum = dp[quotient2] + dp[quotient3] + dp[quotient4]
            dp[n] = max(n, partsSum)
            return dp[n]

        return CalculateMaxSumAfterDivisions(num)

    def CalculateMaxSumAfterDivisionsTab(self, num):
        dp = [-1] * (num + 1)

        for n in range(num + 1):
            # Solve small sub-problems
            if n <= 11:
                dp[n] = n
                continue

            # Divide
            partsSum = dp[n // 2] + dp[n // 3] + dp[n // 4]

            # Combine
            dp[n] = max(n, partsSum)

        return dp[num]

    @staticmethod
    def Work():
        n = 12  # 13
        # n = 24  # 27

        maxSum = MaxSumProblem().CalculateMaxSumAfterDivisionsTab(n)
        print(maxSum)
