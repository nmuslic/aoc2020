using Aoc2020.Day14;
using Xunit;

namespace Aoc2020.Tests.Day14
{
    public class DockingDataTests
    {

        [Fact]
        public void GetValuesSum_ValidInput_ReturnsValidSum()
        {
            string input = Resources.ResourceFiles.DockingDataInput;

            var result = DockingData.GetValuesSum(input);

            Assert.Equal(14722016054794, result);
        }
    }
}
