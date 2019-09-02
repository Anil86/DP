class WackyWorkouts:
    def CalculateWorkoutWays(self, days):
        dp = [-1] * (days + 3)

        def Count(n):
            # Solve small sub-problems
            if n == days:  # Last day
                dp[days] = 1
                return 1
            if n > days:  # > last day
                dp[n] = 0
                return 0

            # Divide
            if dp[n + 2] == -1: dp[n + 2] = Count(n + 2)
            pick = 1 + dp[n + 2]  # Workout current day
            if dp[n + 1] == -1: dp[n + 1] = Count(n + 1)
            notPick = dp[n + 1]  # Don't workout current day

            # Combine
            dp[n] = pick + notPick  # total ways = picked + not picked
            return dp[n]

        # Start considering from day 1
        return Count(1) + 1  # There is a possibility of workout not done on any day. Add 1 for this possibility

    @staticmethod
    def Work():
        # days = 4  # Ans: 8
        # days = 5   # Ans: 13
        days = 6  # Ans: 21

        ways = WackyWorkouts().CalculateWorkoutWays(days)
        print(ways)
