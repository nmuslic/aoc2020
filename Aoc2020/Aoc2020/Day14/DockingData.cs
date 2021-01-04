using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day14
{
    public static class DockingData
    {
        public static long GetValuesSum(string input)
        {
            string[] lines = input.Split('\n')[..^1].ToArray();
            Dictionary<long, long> memory = new Dictionary<long, long>();

            (long And, long Or) = (0, 0);

            foreach (string line in lines)
            {
                if (line.Substring(0, 4) == "mask")
                {
                    And = Convert.ToInt64((line[7..].Replace('X', '1')), 2);
                    Or = Convert.ToInt64((line[7..].Replace('X', '0')), 2);
                }
                else
                {
                    long location = long.Parse(line[4..].Split("]")[0]);
                    long value = And & (Or | long.Parse(line.Split("=")[1][1..]));

                    if (memory.ContainsKey(location))
                    {
                        memory[location] = value;
                    }
                    else
                    {
                        memory.Add(location, value);
                    }
                }
            }

            return memory.Select(x => x.Value).Sum();
        }
    }
}
