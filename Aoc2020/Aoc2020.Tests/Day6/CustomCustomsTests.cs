using Aoc2020.Day6;
using Xunit;

namespace Aoc2020.Tests.Day6
{
    public class CustomCustomsTests
    {
        [Fact]
        public void GetSumOfGroupUniqueAnswers_ValidInput_ReturnsValidSum()
        {
            string input = Resources.ResourceFiles.CustomCustomsInput;

            int result = CustomCustoms.GetSumOfGroupUniqueAnswers(input);

            Assert.Equal(6726, result);
        }

        [Fact]
        public void GetSumOfGroupMutualAnswers_ValidInput_ReturnsValidSum()
        {
            string input = Resources.ResourceFiles.CustomCustomsInput;

            int result = CustomCustoms.GetSumOfGroupMutualAnswers(input);

            Assert.Equal(3316, result);
        }
    }
}