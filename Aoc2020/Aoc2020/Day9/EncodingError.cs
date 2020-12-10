using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day9
{
    public static class EncodingError
    {
        private static long[] numbers;
        public static long GetFirstWeakNumber(string input)
        {
            numbers = GetNumbers(input);

            int weakNumberIndex = 25;
            int current = 0;
            bool isWeak = false;

            while (!isWeak)
            {
                HashSet<long> rangeNumbers = numbers.Skip(current).Take(25).ToHashSet();
                isWeak = true;
                for (int i = current; i < current + 25; i++)
                {
                    if (rangeNumbers.Contains(numbers[weakNumberIndex] - numbers[i]))
                    {
                        isWeak = false;
                        break;
                    }
                }

                if (!isWeak)
                {
                    weakNumberIndex++;
                    current++;
                }
            }

            return numbers[weakNumberIndex];
        }

        public static long GetWeakNumberRangeSum(string input)
        {
            long weakNumber = GetFirstWeakNumber(input);

            int currentRangeIndex = 0;
            long currentSum = 0;

            for (long i = 0; i < numbers.Length; i++)
            {
                currentSum += numbers[i];

                if (currentSum > weakNumber)
                {
                    currentSum -= numbers[currentRangeIndex];
                    currentRangeIndex++;
                    while (currentSum > weakNumber)
                    {
                        currentSum -= numbers[i];
                        i--;
                    }
                }

                if (currentSum == weakNumber)
                {
                    long min = int.MaxValue;
                    long max = int.MinValue;
                    for (int j = currentRangeIndex; j <= i; j++)
                    {
                        min = Math.Min(numbers[j], min);
                        max = Math.Max(numbers[j], max);
                    }

                    return min + max;
                }
            }

            return 0;
        }

        private static long[] GetNumbers(string input) => input.Split('\n')[..^1].Select(x => long.Parse(x)).ToArray();
    }
}
