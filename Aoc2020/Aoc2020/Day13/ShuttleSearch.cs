using System.Linq;

namespace Aoc2020.Day13
{
    public static class ShuttleSearch
    {
        public static int GetEarliestBusByMinutes(string input)
        {
            string[] lines = input.Split('\n')[..^1].ToArray();

            var result = lines[1].Split(",").Where(x => x != "x")
                        .Select(x => (x, int.Parse(x) - int.Parse(lines[0]) % int.Parse(x)))
                        .OrderBy(x => x.Item2)
                        .First();

            return int.Parse(result.x) * result.Item2;
        }

        public static long GetEarliestTimestamp(string input)
        {
            string[] lines = input.Split('\n')[..^1].ToArray();

            var timeline = lines[1].Replace('x', '0').Split(",").Select(x => long.Parse(x)).ToArray();

            long result = 0;
            long current = timeline[0];
            for (int i = 1; i < timeline.Length; i++)
            {
                if (timeline[i] != 0)
                {
                    do
                    {
                        result += current;
                    } while (((result + i) % timeline[i] != 0));

                    current *= timeline[i];
                }
            }

            return result;
        }
    }
}