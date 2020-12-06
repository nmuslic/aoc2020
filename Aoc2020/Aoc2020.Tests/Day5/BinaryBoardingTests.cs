using Aoc2020.Day5;
using Xunit;

namespace Aoc2020.Tests.Day5
{
    public class BinaryBoardingTests
    {
        [Fact]
        public void GetHighestSeatId_ValidInput_ReturnsValidSeatId()
        {
            string input = Resources.ResourceFiles.BinaryBoardingInput;

            int result = BinaryBoarding.GetHighestSeatId(input);

            Assert.Equal(850, result);
        }

        [Fact]
        public void GetMissingSeatId_ValidInput_ReturnsMissingSeatId()
        {
            string input = Resources.ResourceFiles.BinaryBoardingInput;

            int result = BinaryBoarding.GetMissingSeatId(input);

            Assert.Equal(599, result);
        }
    }
}
