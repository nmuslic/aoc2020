using System;
using System.Linq;

namespace Aoc2020.Day12
{
    public static class RainRisk
    {
        public static int GetManhattanDistance(string input)
        {
            string[] instructions = input.Split('\n')[..^1].ToArray();
            var positions = (0, 0);

            char currentDirection = 'E';

            foreach (string instruction in instructions)
            {
                char action = instruction[0] == 'F' ? currentDirection : instruction[0];
                int value = int.Parse(instruction[1..]);

                switch (action)
                {
                    case 'N':
                        positions.Item2 += value;
                        break;
                    case 'S':
                        positions.Item2 -= value;
                        break;
                    case 'E':
                        positions.Item1 += value;
                        break;
                    case 'W':
                        positions.Item1 -= value;
                        break;
                    case 'L':
                    case 'R':
                        currentDirection = GetNewDirection(currentDirection, action, value);
                        break;
                }
            }

            return Math.Abs(positions.Item1) + Math.Abs(positions.Item2);
        }

        private static char GetNewDirection(char current, char turn, int angle) =>
                turn == 'L' ? "ENWS"[("ENWS".IndexOf(current) + angle / 90) % 4] :
                          "ESWN"[("ESWN".IndexOf(current) + angle / 90) % 4];

        public static int GetRelativeManhattanDistance(string input)
        {
            string[] instructions = input.Split('\n')[..^1].ToArray();

            var waypoint = (10, 1);
            var positions = (0, 0);

            foreach (string instruction in instructions)
            {
                char action = instruction[0];
                int value = int.Parse(instruction[1..]);

                if (action == 'F')
                {
                    positions.Item1 += waypoint.Item1 * value;
                    positions.Item2 += waypoint.Item2 * value;
                }
                else
                {
                    switch (action)
                    {
                        case 'N':
                            waypoint.Item2 += value;
                            break;
                        case 'S':
                            waypoint.Item2 -= value;
                            break;
                        case 'E':
                            waypoint.Item1 += value;
                            break;
                        case 'W':
                            waypoint.Item1 -= value;
                            break;
                        case 'L':
                            while (value > 0)
                            {
                                (waypoint.Item1, waypoint.Item2) = (-waypoint.Item2, waypoint.Item1);
                                value -= 90;
                            }
                            break;
                        case 'R':
                            while (value > 0)
                            {
                                (waypoint.Item1, waypoint.Item2) = (waypoint.Item2, -waypoint.Item1);
                                value -= 90;
                            }
                            break;
                    }
                }
            }
            
            return Math.Abs(positions.Item1) + Math.Abs(positions.Item2);
        }
    }
}