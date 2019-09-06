class IntelligentGirl:
    def CountEvens(self, numbers):
        def CountEvens(i):
            # Solve small sub-problems
            if i == len(numbers): return 0

            # Divide
            currentEvenCount = 1 if numbers[i] % 2 == 0 else 0

            remainingEvensCount = CountEvens(i + 1)

            # Combine
            return currentEvenCount + remainingEvensCount

        return CountEvens(0)

    @staticmethod
    def Work():
        # numbers = [3, 2, 7, 8]
        numbers = [5, 7, 4, 6, 7, 4, 5, 4, 6, 4, 7, 6]

        countEvens = IntelligentGirl().CountEvens(numbers)
        print(countEvens)
