using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day16
{
    public static class TicketTranslation
    {
        public static int GetTicketScanningErrorRate(string input)
        {
            IEnumerable<(int x, int y)> intervals =
                            input.Split("\n\n")[0].Split('\n')
                            .Select(x => x.Split(": ")[1].Split(" or ")
                            .Select(y => (int.Parse(y.Split('-')[0]), int.Parse(y.Split('-')[1]))))
                            .SelectMany(z => z);

            var nearbyTickets = input.Split("\n\n")[2].Split('\n')[1..]
                                     .Select(x => x.Split(',').Select(x => int.Parse(x)))
                                     .SelectMany(x => x);

            return nearbyTickets.Sum(ticket => intervals.Any(i => ticket >= i.x && ticket <= i.y)
                                                     ? 0 : ticket);
        }
    }
}