using Aoc2020.Day15;
using Xunit;

namespace Aoc2020.Tests.Day15
{
    public class RambunctiousRecitationTests
    {
        [Fact]
        public void GetValuesSum_ValidInput_ReturnsValidSum()
        {
            var input = new int[] { 6, 13, 1, 15, 2, 0 };

            var result = RambunctiousRecitation.GetSpokenNumber(input);

            Assert.Equal(1194, result);
        }
    }
}
