using Aoc2020.Day4;
using Xunit;

namespace Aoc2020.Tests.Day4
{
    public class PassportProcessingTests
    {
        [Fact]
        public void GetValidFieldsPassportCount_ValidInput_ReturnsNumberOfValidPassports()
        {
            string input = Resources.ResourceFiles.PassportProcessingInput;

            int result = PassportProcessing.GetValidFieldsPassportCount(input);

            Assert.Equal(264, result);
        }

        [Fact]
        public void GetValidValuesPassportCount_ValidInput_ReturnsNumberOfValidPassports()
        {
            string input = Resources.ResourceFiles.PassportProcessingInput;

            int result = PassportProcessing.GetValidValuesPassportCount(input);

            Assert.Equal(224, result);
        }
    }
}
