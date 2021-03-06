class IntelligentGirl:
    def CountEvensMemo(self, s):
        dp = [-1] * (len(s) + 1)

        def CountEvens(current):
            # Solve small sub-problems
            if current == len(s):
                dp[current] = 0
                return 0

            # Divide
            # Current is even
            if int(s[current]) % 2 == 0:
                if dp[current + 1] == -1:
                    dp[current + 1] = CountEvens(current + 1)
                dp[current] = 1 + dp[current + 1]
            else:
                # Current is odd
                if dp[current + 1] == -1:
                    dp[current + 1] = CountEvens(current + 1)
                dp[current] = dp[current + 1]

            # Combine
            return dp[current]

        CountEvens(0)
        return dp

    def CountEvensTab(self, s):
        dp = [0] * (len(s) + 1)

        # Divide & Combine
        for current in range(len(s) - 1, -1, -1):
            dp[current] = 1 + dp[current + 1] if int(s[current]) % 2 == 0 else dp[current + 1]

        return dp

    @staticmethod
    def Work():
        # s = "6476"   # 3
        s = "574674546476"  # 7

        evensCount = IntelligentGirl().CountEvensTab(s)
        evensCountString = ""
        for i in range(len(evensCount) - 1): evensCountString += f" {evensCount[i]}"
        print(evensCountString.lstrip())
