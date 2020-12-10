using Aoc2020.Day8;
using Xunit;

namespace Aoc2020.Tests.Day8
{
    public class HandheldHaltingTests
    {
        [Fact]
        public void GetAccumulatorBeforeInfiniteLoop_ValidInput_ReturnsValidAccumulator()
        {
            string input = Resources.ResourceFiles.HandheldHaltingInput;

            int result = HandheldHalting.GetAccumulatorBeforeInfiniteLoop(input);

            Assert.Equal(1337, result);
        }

        [Fact]
        public void GetAcuumulatorAfterTermination_ValidInput_ReturnsValidAccumulator()
        {
            string input = Resources.ResourceFiles.HandheldHaltingInput;

            int result = HandheldHalting.GetAcuumulatorAfterTermination(input);

            Assert.Equal(1358, result);
        }
    }
}
