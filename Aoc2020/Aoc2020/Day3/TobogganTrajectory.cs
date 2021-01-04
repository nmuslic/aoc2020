using System.Collections.Generic;

namespace Aoc2020.Day3
{
    //https://adventofcode.com/2020/day/3
    public static class TobogganTrajectory
    {
        public static long GetAllSlopesMultiplied(string input)
        {
            var slopes = new List<Slope>
            {
                new Slope { Right = 1, Down = 1 },
                new Slope { Right = 3, Down = 1 },
                new Slope { Right = 5, Down = 1 },
                new Slope { Right = 7, Down = 1 },
                new Slope { Right = 1, Down = 2 }
            };

            CalculateTreeCount(input, slopes);

            long result = 1;

            foreach (var slope in slopes)
            {
                result *= slope.TreeCount;
            }

            return result;
        }

        public static int GetTreeCount(string input)
        {
            var slopes = new List<Slope>
            {
                new Slope { Right = 3, Down = 1 },
            };

            CalculateTreeCount(input, slopes);

            return slopes[0].TreeCount;
        }

        private static void CalculateTreeCount(string input, List<Slope> slopes)
        {
            string[] rows = input.Split('\n');

            for (int i = 0; i < rows.Length - 1; i++)
            {
                foreach (var slope in slopes)
                {
                    if (i % slope.Down == 0)
                    {
                        slope.CurrentPositon = GetPosition(rows[i], slope.CurrentPositon + slope.Right);

                        if (rows.Length > i + slope.Down && rows[i + slope.Down][slope.CurrentPositon] == '#')
                        {
                            slope.TreeCount++;
                        }
                    }
                }
            }
        }

        private static int GetPosition(string row, int position)
        {
            return row.Length <= position ? position - row.Length : position;
        }
    }
}
