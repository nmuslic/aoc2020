using Aoc2020.Day1;
using Xunit;

namespace Aoc2020.Tests.Day1
{
    public class ReportRepairTests
    {
        [Fact]
        public void GetMultipliedSumOfTwo__ReportRepairInput_ReturnsMultipliedNumber()
        {
            string input = Resources.ResourceFiles.ReportRepairInput;

            ReportRepair reportRepair = new ReportRepair(input);

            int result = reportRepair.GetMultipliedSumOfTwo(2020);

            Assert.Equal(996996, result);
        }

        [Fact]
        public void GetMultipliedSumOfTwo__ReportRepairSampleInput_ReturnsMultipliedNumber()
        {
            string input = Resources.ResourceFiles.ReportRepairSampleInput;

            ReportRepair reportRepair = new ReportRepair(input);

            int result = reportRepair.GetMultipliedSumOfTwo(2020);

            Assert.Equal(514579, result);
        }

        [Fact]
        public void GetMultipliedSumOfThree__ReportRepairInput_ReturnsMultipliedNumber()
        {
            string input = Resources.ResourceFiles.ReportRepairInput;

            ReportRepair reportRepair = new ReportRepair(input);

            int result = reportRepair.GetMultipliedSumOfThree(2020);

            Assert.Equal(9210402, result);
        }

    }
}
