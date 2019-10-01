class MinCostReachArrayEnd:
    def FindMinCost(self, array):
        dp = [[-1 for _ in range(len(array[0]))] for _ in range(len(array))]

        def FindMinCost(row, column):
            # Solve small sub-problems
            if row == 0 and column == 0:
                dp[0][0] = array[0][0]
                return array[0][0]

            # Optimizations
            # 1st row
            if row == 0:
                if dp[0][column - 1] == -1:
                    dp[0][column - 1] = FindMinCost(0, column - 1)
                return array[0][column] + dp[0][column - 1]
            # 1st column
            if column == 0:
                if dp[row - 1][0] == -1:
                    dp[row - 1][0] = FindMinCost(row - 1, 0)
                return array[row][0] + dp[row - 1][0]

            # Divide
            if dp[row][column - 1] == -1:
                dp[row][column - 1] = FindMinCost(row, column - 1)
            costTillLeft = dp[row][column - 1]
            if dp[row - 1][column] == -1:
                dp[row - 1][column] = FindMinCost(row - 1, column)
            costTillTop = dp[row - 1][column]

            # Combine
            minCostTillPrevious = min(costTillLeft, costTillTop)
            dp[row][column] = array[row][column] + minCostTillPrevious
            return dp[row][column]

        return FindMinCost(len(array) - 1, len(array[0]) - 1)

    @staticmethod
    def Work():
        array = [[4, 7, 8, 6, 4],
                 [6, 7, 3, 9, 2],
                 [2, 9, 8, 9, 3],
                 [3, 8, 1, 2, 4],
                 [7, 1, 7, 3, 7]]  # Ans: 36

        # array = [[4, 7, 8],
        #          [6, 7, 3]]  # Ans: 20

        minCost = MinCostReachArrayEnd().FindMinCost(array)
        print(minCost)
