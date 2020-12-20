using Aoc2020.Day10;
using Xunit;

namespace Aoc2020.Tests.Day10
{
    public class AdapterArrayTests
    {
        [Fact]
        public void GetAccumulatorBeforeInfiniteLoop_ValidInput_ReturnsValidAccumulator()
        {
            string input = Resources.ResourceFiles.AdapterArrayInput;

            var result = AdapterArray.GetJoltDifferencesMultiplied(input);

            Assert.Equal(1890, result);
        }

        [Fact]
        public void GetUniqueArrangements_ValidInput_ReturnsValidUniqueArrangements()
        {
            string input = Resources.ResourceFiles.AdapterArrayInput;

            var result = AdapterArray.GetUniqueArrangements(input);

            Assert.Equal(49607173328384, result);
        }
    }
}
