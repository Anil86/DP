using System;
using static System.Console;

namespace DP
{
    public class XsquareAnd2Arrays
    {
        /// <inheritdoc />
        public XsquareAnd2Arrays(int[] a, int[] b)
        {
            _a = a;
            _b = b;
            _dp = new long[2, _a.Length + 1];   // dp[startArray, startIndex]
        }


        private long ZigZagSum(ArrayType startArray, int start, int end)
        {
            // Solve small sub-problems
            if (start > end)
            {
                // Only store value when range's end is last item
                // End = right end
                // So store
                if (end == _a.Length - 1) _dp[(int)startArray, start] = 0;

                return 0;
            }

            // Divide & Combine
            if (end < _a.Length - 1)   // Start start → end is in-between 2 ends
            {
                // Divide
                if (_dp[(int)startArray, start] == 0)
                    _dp[(int)startArray, start] = ZigZagSum(startArray, start, _a.Length - 1);
                long whole = _dp[(int)startArray, start];   // Minuend: Larger range

                // Find start array for Subtrahend (smaller range)
                // If end - start = even: Different start array than start
                // else same array
                if ((end - start) % 2 == 0)
                    startArray = startArray == ArrayType.A ? ArrayType.B : ArrayType.A;

                if (_dp[(int)startArray, end + 1] == 0)
                    _dp[(int)startArray, end + 1] = ZigZagSum(startArray, end + 1, _a.Length - 1);
                long remaining = _dp[(int)startArray, end + 1];   // Subtrahend: Smaller range

                // Combine
                return whole - remaining;   // Sum of start → end
            }

            // Find current picked number & 
            // start array for next value
            int pickedNumber;
            ArrayType nextStartArray;
            if (startArray == ArrayType.A)
            {
                pickedNumber = _a[start];   // Pick value from current start array
                nextStartArray = ArrayType.B;   // Set next value's start array to other array
            }
            else
            {
                pickedNumber = _b[start];
                nextStartArray = ArrayType.A;
            }

            // Pick current value + find remaining values when end = last item
            if (end == _a.Length - 1)
            {
                // Store result in dp[,] because end is last item
                if (_dp[(int)nextStartArray, start + 1] == 0)
                    _dp[(int)nextStartArray, start + 1] = ZigZagSum(nextStartArray, start + 1, end);

                return _dp[(int)startArray, start] = pickedNumber + _dp[(int)nextStartArray, start + 1];
            }

            // Pick current value + find remaining values
            return pickedNumber + ZigZagSum(nextStartArray, start + 1, end);
        }



        internal static void Work()
        {
            int[] a = { 1, 2, 3, 4, 5 },
                b = { 5, 4, 3, 2, 1 };

            ValueTuple<ArrayType, int, int>[] queries =
            {
                (ArrayType.A, 0, a.Length - 1),   // 15
                (ArrayType.B, 0, a.Length - 1),   // 15
                (ArrayType.A, 1, 3),   // 9
                (ArrayType.B, 1, 3),   // 9
                (ArrayType.A, 2, a.Length - 1)   // 10
            };

            foreach (var (startArray, start, end) in queries)
            {
                long total = new XsquareAnd2Arrays(a, b).ZigZagSum(startArray, start, end);
                WriteLine(total);
            }
        }


        private readonly int[] _a, _b;
        private readonly long[,] _dp;
    }


    enum ArrayType
    {
        A,
        B
    }
}