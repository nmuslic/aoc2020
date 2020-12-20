using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2020.Day11
{
    public static class SeatingSystem
    {
        public static int GetOccupiedSeats(string input)
        {
            char[][] seats = input.Split(Environment.NewLine)[..^1].Select(x => x.ToCharArray()).ToArray();
            char[][] occupiedSeats = OccupyAdjacentSeats(seats, out bool changed);

            while (changed)
            {
                seats = occupiedSeats;
                occupiedSeats = OccupyAdjacentSeats(seats, out changed);
            }

            return seats.Sum(x => x.Count(x => x == '#'));
        }

        private static char[][] OccupyAdjacentSeats(char[][] seats, out bool changed)
        {
            changed = false;
            char[][] result = new char[seats.GetLength(0)][];

            for (int i = 0; i < seats.GetLength(0); i++)
            {
                result[i] = new char[seats[i].Length];
                for (int j = 0; j < seats[i].Length; j++)
                {
                    switch (seats[i][j])
                    {
                        case '.':
                            result[i][j] = '.';
                            break;
                        case 'L':
                            result[i][j] = GetAdjacentOccupiedSeatsCount(seats, i, j) == 0 ? '#' : 'L';
                            break;
                        case '#':
                            result[i][j] = GetAdjacentOccupiedSeatsCount(seats, i, j) >= 4 ? 'L' : '#';
                            break;
                    }

                    changed = result[i][j] != seats[i][j] || changed;
                }
            }
            return result;
        }

        private static int GetAdjacentOccupiedSeatsCount(char[][] seatLayout, int row, int column)
        {
            int rowLength = seatLayout.GetLength(0);
            int columnLength = seatLayout[0].Length;

            bool[] adjacentSeats = new bool[8];
            adjacentSeats[0] = row > 0 && column > 0 && seatLayout[row - 1][column - 1] == '#';
            adjacentSeats[1] = row > 0 && seatLayout[row - 1][column] == '#';
            adjacentSeats[2] = row > 0 && column + 1 < columnLength && seatLayout[row - 1][column + 1] == '#';

            adjacentSeats[3] = column > 0 && seatLayout[row][column - 1] == '#';
            adjacentSeats[4] = column + 1 < columnLength && seatLayout[row][column + 1] == '#';

            adjacentSeats[5] = row + 1 < rowLength && column > 0 && seatLayout[row + 1][column - 1] == '#';
            adjacentSeats[6] = row + 1 < rowLength && seatLayout[row + 1][column] == '#';
            adjacentSeats[7] = row + 1 < rowLength && column + 1 < columnLength && seatLayout[row + 1][column + 1] == '#';

            return adjacentSeats.Count(x => x);
        }

        public static int GetVisibleOccupiedSeats(string input)
        {
            char[][] seats = input.Split(Environment.NewLine)[..^1].Select(x => x.ToCharArray()).ToArray();
            char[][] occupiedSeats = OccupyVisibleSeats(seats, out bool changed);

            while (changed)
            {
                seats = occupiedSeats;
                occupiedSeats = OccupyVisibleSeats(seats, out changed);
            }

            return seats.Sum(x => x.Count(x => x == '#'));
        }

        private static char[][] OccupyVisibleSeats(char[][] seats, out bool changed)
        {
            changed = false;
            char[][] result = new char[seats.GetLength(0)][];

            for (int i = 0; i < seats.GetLength(0); i++)
            {
                result[i] = new char[seats[i].Length];
                for (int j = 0; j < seats[i].Length; j++)
                {
                    switch (seats[i][j])
                    {
                        case '.':
                            result[i][j] = '.';
                            break;
                        case 'L':
                            result[i][j] = GetVisibleOccupiedSeatsCount(seats, i, j) == 0 ? '#' : 'L';
                            break;
                        case '#':
                            result[i][j] = GetVisibleOccupiedSeatsCount(seats, i, j) >= 5 ? 'L' : '#';
                            break;
                    }

                    changed = result[i][j] != seats[i][j] || changed;
                }
            }
            return result;
        }

        private static int GetVisibleOccupiedSeatsCount(char[][] seatLayout, int i, int j)
        {
            bool[] adjacentSeats = new bool[8];
            bool[] seenSeats = new bool[8];

            int rowLength = seatLayout.GetLength(0);
            int columnLength = seatLayout[0].Length;
            int d = 0;
            while (seenSeats.Any(x => !x) && d < rowLength / 2)
            {
                if (!seenSeats[0] && i - d > 0 && j - d > 0 && seatLayout[i - d - 1][j - d - 1] != '.')
                {
                    adjacentSeats[0] = seatLayout[i - d - 1][j - d - 1] == '#';
                    seenSeats[0] = true;
                }
                if (!seenSeats[1] && i - d > 0 && seatLayout[i - d - 1][j] != '.')
                {
                    adjacentSeats[1] = seatLayout[i - d - 1][j] == '#';
                    seenSeats[1] = true;
                }
                if (!seenSeats[2] && i - d > 0 && j + d + 1 < columnLength && seatLayout[i - d - 1][j + d + 1] != '.')
                {
                    adjacentSeats[2] = seatLayout[i - d - 1][j + d + 1] == '#';
                    seenSeats[2] = true;
                }
                if (!seenSeats[3] && j - d > 0 && seatLayout[i][j - d - 1] != '.')
                {
                    adjacentSeats[3] = seatLayout[i][j - d - 1] == '#';
                    seenSeats[3] = true;
                }
                if (!seenSeats[4] && j + d + 1 < columnLength && seatLayout[i][j + d + 1] != '.')
                {
                    adjacentSeats[4] = seatLayout[i][j + d + 1] == '#';
                    seenSeats[4] = true;
                }
                if (!seenSeats[5] && i + d + 1 < rowLength && j - d > 0 && seatLayout[i + d + 1][j - d - 1] != '.')
                {
                    adjacentSeats[5] = seatLayout[i + d + 1][j - d - 1] == '#';
                    seenSeats[5] = true;
                }
                if (!seenSeats[6] && i + d + 1 < rowLength && seatLayout[i + d + 1][j] != '.')
                {
                    adjacentSeats[6] = seatLayout[i + d + 1][j] == '#';
                    seenSeats[6] = true;
                }
                if (!seenSeats[7] && i + d + 1 < rowLength && j + d + 1 < columnLength && seatLayout[i + d + 1][j + d + 1] != '.')
                {
                    adjacentSeats[7] = seatLayout[i + d + 1][j + d + 1] == '#';
                    seenSeats[7] = true;
                }
                d++;
            }
            return adjacentSeats.Count(x => x);
        }
    }
}