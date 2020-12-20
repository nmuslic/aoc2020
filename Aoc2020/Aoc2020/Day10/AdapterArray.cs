using System;
using System.Linq;

namespace Aoc2020.Day10
{
    public static class AdapterArray
    {
        public static int GetJoltDifferencesMultiplied(string input)
        {
            int[] numbers = input.Split('\n')[..^1].Select(x => int.Parse(x)).ToArray();
            Array.Sort(numbers);

            int[] differences = new int[numbers.Length];
            int current = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                differences[i] = numbers[i] - current;

                current = numbers[i];
            }

            int oneJoltDiff = differences.Where(x => x == 1).Count();
            int threeJoltDiff = differences.Where(x => x == 3).Count() + 1;

            return oneJoltDiff * threeJoltDiff;
        }

        public static long GetUniqueArrangements(string input)
        {
            var numbers = input.Split('\n')[..^1].Select(x => int.Parse(x)).Append(0).ToList();
            numbers.Sort();

            long[] diffs = new long[numbers.Count];

            diffs[0] = 1;
            diffs[1] = 1;

            for (int i = 2; i < numbers.Count; i++)
            {
                int last = numbers[i - 1];

                if (numbers[i] - numbers[i - 1] <= 3)
                {
                    diffs[i] += diffs[i - 1];
                }

                if (numbers[i] - numbers[i-2] <= 3)
                {
                    diffs[i] += diffs[i - 2];
                }

                if (i > 2 && numbers[i] - numbers[i - 3] <= 3)
                {
                    diffs[i] += diffs[i - 3];
                }

            }
            return diffs.Last();
        }
    }
}