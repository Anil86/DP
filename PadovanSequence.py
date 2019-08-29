class PadovanSequence:
    def CalculatePadovan(self, k):
        _dp = [0] * (k + 1)

        def CalculatePadovanLocal(n):
            # Solve small sub-problems
            if n <= 2:
                _dp[n] = 1
                return _dp[n]

            # Divide
            if _dp[n - 2] == 0: _dp[n - 2] = CalculatePadovanLocal(n - 2)
            if _dp[n - 3] == 0: _dp[n - 3] = CalculatePadovanLocal(n - 3)

            # Combine
            return _dp[n - 2] + _dp[n - 3]

        return CalculatePadovanLocal(k)

    @staticmethod
    def Work():
        n = 40  # Ans: 55, 405

        padovanN = PadovanSequence().CalculatePadovan(n)
        print(padovanN)
