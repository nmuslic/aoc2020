using Aoc2020.Day11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aoc2020.Tests.Day11
{
    public class SeatingSystemTests
    {
        [Fact]
        public void GetOccupiedSeats_ValidInput_ReturnsValidSeatCount()
        {
            string input = Resources.ResourceFiles.SeatingSystemInput;

            var result = SeatingSystem.GetOccupiedSeats(input);

            Assert.Equal(2481, result);
        }

        [Fact]
        public void GetVisibleOccupiedSeats_ValidInput_ReturnsValidSeatCount()
        {
            string input = Resources.ResourceFiles.SeatingSystemInput;

            var result = SeatingSystem.GetVisibleOccupiedSeats(input);

            Assert.Equal(2227, result);
        }
    }
}
