from collections import OrderedDict


class MaxSumProblemTest:
    def __init__(self):
        self._inputs = OrderedDict()
        self._maxInput = 0
        self._dp = None

        t = int(input())
        for _ in range(t):
            self._inputs[int(input())] = -1

        self._maxInput = max(self._inputs)
        self._dp = [-1] * (self._maxInput + 1)

    def CalculateMaxSumAfterDivisionsTab(self, num):
        for n in range(num + 1):
            # Solve small sub-problems
            if n <= 11:
                self._dp[n] = n
                continue

            # Divide
            partsSum = self._dp[n // 2] + self._dp[n // 3] + self._dp[n // 4]

            # Combine
            self._dp[n] = max(n, partsSum)

        return self._dp[num]

    @staticmethod
    def Work():
        maxProblemTest = MaxSumProblemTest()
        _ = maxProblemTest.CalculateMaxSumAfterDivisionsTab(maxProblemTest._maxInput)

        for k in maxProblemTest._inputs:
            print(maxProblemTest._dp[k])
