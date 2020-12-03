using Aoc2020.Day3;
using Xunit;

namespace Aoc2020.Tests.Day3
{
    public class TobogganTrajectoryTests
    {
        [Fact]
        public void GetTreeCount_ValidInput_ReturnsNumberOfTrees()
        {
            string input = Resources.ResourceFiles.TobogganTrajectoryInput;

            int result = TobogganTrajectory.GetTreeCount(input);

            Assert.Equal(250, result);
        }

        [Fact]
        public void GetAllSlopesMultiplied_ValidInput_ReturnsMultipliedTreeCount()
        {
            string input = Resources.ResourceFiles.TobogganTrajectoryInput;

            long result = TobogganTrajectory.GetAllSlopesMultiplied(input);

            Assert.Equal(1592662500, result);
        }
    }
}