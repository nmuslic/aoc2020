using Aoc2020.Day7;
using Xunit;

namespace Aoc2020.Tests.Day7
{
    public class HandyHaversacksTests
    {
        [Fact]
        public void GetNumberOfBags_ValidInput_ReturnsValidBagNumber()
        {
            string input = Resources.ResourceFiles.HandyHaversacksInput;

            int result = HandyHaversacks.GetNumberOfBags(input);

            Assert.Equal(132, result);
        }

        [Fact]
        public void GetRequiredBags_ValidInput_GetRequiredBagsSum()
        {
            string input = Resources.ResourceFiles.HandyHaversacksInput;

            int result = HandyHaversacks.GetRequiredBags(input);

            Assert.Equal(11261, result);
        }
    }
}