using Aoc2020.Day13;
using Xunit;

namespace Aoc2020.Tests.Day13
{
    public class ShuttleSearchTests
    {
        [Fact]
        public void GetEarliestBusByMinutes_ValidInput_ReturnsValidMinutes()
        {
            string input = Resources.ResourceFiles.ShuttleSearchInput;

            var result = ShuttleSearch.GetEarliestBusByMinutes(input);

            Assert.Equal(3606, result);
        }

        [Fact]
        public void GetEarliestTimestamp_ValidInput_ReturnsValidTimestamp()
        {
            string input = Resources.ResourceFiles.ShuttleSearchInput;

            var result = ShuttleSearch.GetEarliestTimestamp(input);

            Assert.Equal(379786358533423, result);
        }
    }
}
