using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace DP
{
    public class RhezoAndPrimeProblems
    {
        private int CalculateMaxPrimePartitionsSum(int[] array)
        {
            int[] dp = new int[array.Length + 1];
            Array.Fill(dp, -1);

            int[] zeroAndPrimes = GetPrimesAndPrefix0(array.Length);

            return CalculateMaxPrimePartitionsSum(0);


            int CalculateMaxPrimePartitionsSum(int start)
            {
                _count++;
                // Optimizations
                // If whole partition is prime, return total sum
                if (IsPartitionPrime(start)) return dp[start] = Sum(start, array.Length - 1);


                // Solve small sub-problems
                if (start >= array.Length - 1) return dp[start] = 0;


                // Divide
                int maxSum = int.MinValue;
                for (var i = 0; i < zeroAndPrimes.Length; i++)
                {
                    int currentPlusRemainingPartitionSum;
                    if (i == 0)
                    {
                        if (dp[start + 1] == -1)
                            dp[start + 1] = CalculateMaxPrimePartitionsSum(start + 1);
                        currentPlusRemainingPartitionSum = dp[start + 1];
                    }
                    else
                    {
                        // Optimization
                        // If partition size > remaining items, current & more bigger partitions cannot be taken.
                        // So break
                        if (zeroAndPrimes[i] > array.Length - start) break;

                        int currentPartitionSum = Sum(start, start + zeroAndPrimes[i] - 1);
                        if (dp[start + zeroAndPrimes[i] + 1] == -1)
                            dp[start + zeroAndPrimes[i] + 1] =
                                CalculateMaxPrimePartitionsSum(start + zeroAndPrimes[i] + 1);
                        int remainingPartitionSum = dp[start + zeroAndPrimes[i] + 1];
                        currentPlusRemainingPartitionSum = currentPartitionSum + remainingPartitionSum;
                    }


                    // Combine
                    if (currentPlusRemainingPartitionSum > maxSum) maxSum = currentPlusRemainingPartitionSum;
                }

                return dp[start] = maxSum;
            }


            int Sum(int start, int end)
            {
                int sum = 0;
                for (int i = start; i <= end; i++) sum += array[i];

                return sum;
            }


            bool IsPartitionPrime(int start)
            {
                int partitionLength = array.Length - start;
                int partitionIndex = Array.BinarySearch(zeroAndPrimes, partitionLength);
                return partitionIndex >= 0;
            }
        }


        private int[] GetPrimes(int limit)
        {
            return SieveOfAtkin().ToArray();



            // Get primes using Sieve of Atkin
            IEnumerable<int> SieveOfAtkin()
            {
                // 2 and 3 are known to be prime 
                yield return 2;
                if (limit == 2) yield break;

                yield return 3;
                if (limit == 3) yield break;

                // Initialise the sieve array with 
                // false values 
                bool[] sieve = new bool[limit + 1];

                /* Mark sieve[n] is true if one of the 
                following is true: 
                a) n = (4*x*x)+(y*y) has odd number  
                   of solutions, i.e., there exist  
                   odd number of distinct pairs  
                   (x, y) that satisfy the equation  
                   and    n % 12 = 1 or n % 12 = 5. 
                b) n = (3*x*x)+(y*y) has odd number  
                   of solutions and n % 12 = 7 
                c) n = (3*x*x)-(y*y) has odd number  
                   of solutions, x > y and n % 12 = 11 */
                for (int x = 1; x * x < limit; x++)
                    for (int y = 1; y * y < limit; y++)
                    {
                        // Main part of Sieve of Atkin 
                        int n = (4 * x * x) + (y * y);
                        if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                            sieve[n] ^= true;

                        n = (3 * x * x) + (y * y);
                        if (n <= limit && n % 12 == 7)
                            sieve[n] ^= true;

                        n = (3 * x * x) - (y * y);
                        if (x > y && n <= limit && n % 12 == 11)
                            sieve[n] ^= true;
                    }

                // Mark all multiples of squares as 
                // non-prime 
                for (int r = 5; r * r < limit; r++)
                    if (sieve[r])
                        for (int i = r * r; i < limit; i += r * r)
                            sieve[i] = false;

                // Print primes using sieve[] 
                for (int a = 5; a <= limit; a++)
                    if (sieve[a])
                        yield return a;
            }
        }


        private int[] GetPrimesAndPrefix0(int n)
        {
            int[] primes = GetPrimes(n);

            int[] zeroAndPrimes = new int[primes.Length + 1];
            primes.CopyTo(zeroAndPrimes, 1);
            return zeroAndPrimes;
        }


        private static int _count;
        internal static void Work()
        {
            //int[] array = { 7, 6, 1, 8, 9, 10 };   // Ans: 40 
            //int[] array = { 1, 1, 3, 2, 3, 2 };   // Ans: 11
            //int[] array = { 5, 6, 3, 8, 9, 1, 2 };   // Ans: 34

            //int maxSum = new RhezoAndPrimeProblems().CalculateMaxPrimePartitionsSum(array);
            //WriteLine(maxSum); WriteLine($"Count: {_count}");


            using (StreamReader file =
                new StreamReader(@"E:\Tutorials\C# Programming\App Business Logic\Algorithms\Books\Sample.txt"))
            {
                file.ReadLine();
                string[] array1String = file.ReadLine().Split();
                int[] array1 = Array.ConvertAll(array1String, int.Parse);

                int maxSum = new RhezoAndPrimeProblems().CalculateMaxPrimePartitionsSum(array1);
                WriteLine(maxSum); WriteLine($"Count: {_count}");   // Ans: 973271   332   303   20
            }
        }
    }
}