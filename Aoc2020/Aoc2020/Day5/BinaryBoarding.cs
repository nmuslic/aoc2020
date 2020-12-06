using System;

namespace Aoc2020.Day5
{
    public static class BinaryBoarding
    {
        private static int highestId;
        private static readonly bool[] assignedSeats = new bool[1024];

        public static int GetHighestSeatId(string input)
        {
            ParseSeats(input);

            return highestId;
        }

        public static int GetMissingSeatId(string input)
        {
            ParseSeats(input);

            for (int i = 1; i < assignedSeats.Length - 1; i++)
            {
                if (!assignedSeats[i] && assignedSeats[i - 1] && assignedSeats[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }

        public static void ParseSeats(string input)
        {
            string[] boardingPasses = input.Split('\n')[..^1];

            foreach (string pass in boardingPasses)
            {
                int row = Convert.ToInt32(pass.Substring(0, 7).Replace('F', '0').Replace('B', '1'), 2);
                int column = Convert.ToInt32(pass[7..].Replace('L', '0').Replace('R', '1'), 2);

                int seatId = row * 8 + column;

                highestId = Math.Max(highestId, seatId);
                assignedSeats[seatId] = true;
            }
        }
    }
}