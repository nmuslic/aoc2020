using Aoc2020.Day12;
using Xunit;

namespace Aoc2020.Tests.Day12
{
    public class RainRiskTests
    {
        [Fact]
        public void GetManhattanDistance_ValidInput_ReturnsValidDistance()
        {
            string input = Resources.ResourceFiles.RainRiskInput;

            var result = RainRisk.GetManhattanDistance(input);

            Assert.Equal(2228, result);
        }

        [Fact]
        public void GetRelativeManhattanDistance_ValidInput_ReturnsValidDistance()
        {
            string input = Resources.ResourceFiles.RainRiskInput;

            var result = RainRisk.GetRelativeManhattanDistance(input);

            Assert.Equal(42908, result);
        }
    }
}
