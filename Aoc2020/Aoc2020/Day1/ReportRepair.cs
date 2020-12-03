using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day1
{
    //https://adventofcode.com/2020/day/1
    public class ReportRepair
    {
        private readonly Dictionary<int, int> entriesSet = new Dictionary<int, int>();
        private readonly int[] entries;

        public ReportRepair(string input)
        {
            string[] values = input.Split('\n');
            entries = values[..^1].Select(x => int.Parse(x)).ToArray();

            this.entriesSet = new Dictionary<int, int>();

            foreach (int entry in entries)
            {
                if (entriesSet.ContainsKey(entry))
                {
                    entriesSet[entry]++;
                }
                else
                {
                    entriesSet.Add(entry, 1);
                }
            }

        }

        public int GetMultipliedSumOfTwo(int sum)
        {
            var numbers = FindTwoEntries(sum);

            return numbers[0] * numbers[1];
        }

        public int GetMultipliedSumOfThree(int sum)
        {
            foreach (int entry in entries)
            {
                var numbers = FindTwoEntries(sum - entry, entry);

                if (numbers != null)
                {
                    return entry * numbers[0] * numbers[1];
                }
            }

            return 0;
        }

        public int[] FindTwoEntries(int sum, int? ignoredNumber = null)
        {
            foreach (int entry in entries)
            {
                int missingEntry = sum - entry;

                if (entriesSet.ContainsKey(missingEntry) && (entry != missingEntry || entriesSet[missingEntry] > 1))
                {
                    if (ignoredNumber == null || (ignoredNumber != null &&
                        (ignoredNumber == missingEntry && ignoredNumber == entry && entriesSet[entry] > 2 ||
                        ((entry != ignoredNumber || entriesSet[entry] > 1) && (missingEntry != ignoredNumber || entriesSet[missingEntry] > 1)))))

                        return new int[] { entry, missingEntry };
                }
            }

            return null;
        }
    }
}
