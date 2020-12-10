using Aoc2020.Day9;
using Xunit;

namespace Aoc2020.Tests.Day9
{
    public class EncodingErrorTests
    {
        [Fact]
        public void GetAccumulatorBeforeInfiniteLoop_ValidInput_ReturnsValidAccumulator()
        {
            string input = Resources.ResourceFiles.EncodingErrorInput;

            var result = EncodingError.GetFirstWeakNumber(input);

            Assert.Equal(133015568, result);
        }

        [Fact]
        public void GetWeakNumberRangeSum_ValidInput_ReturnsValidAccumulator()
        {
            string input = Resources.ResourceFiles.EncodingErrorInput;

            var result = EncodingError.GetWeakNumberRangeSum(input);

            Assert.Equal(16107959, result);
        }
    }
}