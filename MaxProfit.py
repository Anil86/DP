from enum import Enum


class MaxProfit:
    _count = 0

    def CollectMax(self, array1, array2, penalty):
        def CollectMax(i, previousArray):
            MaxProfit._count += 1
            # Solve small sub-problems
            if i == len(array1): return 0

            # Divide
            p = 0 if i == 0 else penalty

            # Pick array1
            maxA = array1[i] + CollectMax(i + 1, PreviousArray.Array1) if previousArray == PreviousArray.Array1 else \
                array1[i] - p + CollectMax(i + 1, PreviousArray.Array1)

            # Pick array2
            maxB = array2[i] - p + CollectMax(i + 1, PreviousArray.Array2) if previousArray == PreviousArray.Array1 else \
                array2[i] + CollectMax(i + 1, PreviousArray.Array2)

            # Combine
            return max(maxA, maxB)

        return CollectMax(0, PreviousArray.Array1)

    @staticmethod
    def Work():
        # array1 = [1, 2, 3, 4, 7, 1]
        # array2 = [4, 5, 1, 4, 1, 7]
        # penalty = 2   # Ans: 26   # Calls: 127

        array1 = [1, 2, 3]
        array2 = [4, 5, 1]
        penalty = 2  # Ans: 10   # Calls: 15

        maxTotal = MaxProfit().CollectMax(array1, array2, penalty)
        print(maxTotal)
        print(MaxProfit._count)


PreviousArray = Enum("PreviousArray", ["Array1", "Array2"])
