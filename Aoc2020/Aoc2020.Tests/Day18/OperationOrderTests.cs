using Aoc2020.Day18;
using Xunit;

namespace Aoc2020.Tests.Day18
{
    public class OperationOrderTests
    {
        [Fact]
        public void GetExpressionSum_ValidInput_ReturnsValidSum()
        {           
            string input = Resources.ResourceFiles.OperationOrderInput;

            var result = OperationOrder.GetExpressionSum(input);

            Assert.Equal(21022630974613, result);
        }
    }
}
