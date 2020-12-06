using System.Linq;

namespace Aoc2020.Day6
{
    public static class CustomCustoms
    {
        public static int GetSumOfGroupUniqueAnswers(string input)
        {
            return input.Split("\n\n").Select(x => x.Replace("\n", ""))
                        .Select(x => x.Distinct().Count())
                        .Sum();
        }

        public static int GetSumOfGroupMutualAnswers(string input)
        {
           return input.Split("\n\n")
                  .Select(x => x.Split("\n").Aggregate((p, n) => new string(p.Intersect(n).ToArray())).Length)
                  .Sum();
        }
    }
}