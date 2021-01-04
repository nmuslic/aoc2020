using Aoc2020.Day15;
using Xunit;

namespace Aoc2020.Tests.Day15
{
    public class RambunctiousRecitationTests
    {
        [Theory]
        [InlineData(2020, 1194)]
        [InlineData(30000000, 48710)]
        public void GetValuesSum_ValidInput_ReturnsValidSum(int count, int expected)
        {
            var input = new int[] { 6, 13, 1, 15, 2, 0 };

            var result = RambunctiousRecitation.GetSpokenNumber(input, count);

            Assert.Equal(expected, result);
        }
    }
}
