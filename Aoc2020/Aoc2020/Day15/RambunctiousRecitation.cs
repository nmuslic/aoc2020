using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day15
{
    public static class RambunctiousRecitation
    {
        public static int GetSpokenNumber(int[] numbers)
        {
            Dictionary<int, int> spokenNums = Enumerable.Range(0, numbers.Length).ToDictionary(x => numbers[x]);
            int current = 0;

            for (int i = numbers.Length + 2; i <= 2020; i++)
            {
                if (spokenNums.ContainsKey(current))
                {
                    int temp = current;
                    current = i - spokenNums[current] - 2;
                    spokenNums[temp] = i - 2;
                }
                else
                {
                    spokenNums.Add(current, i - 2);
                    current = 0;
                }
            }

            return current;

        }
    }
}
