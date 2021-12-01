using Aoc2020.Day21;
using Xunit;

namespace Aoc2020.Tests.Day21
{
    public class AllergenAssessmentTests
    {
        [Fact]
        public void GetNonAllergenCount_ValidInput_ReturnsValidCount()
        {
            string input = Resources.ResourceFiles.AllergenAssessmentInput;

            var result = AllergenAssessment.GetNonAllergenCount(input);

            Assert.Equal(1945, result);
        }
    }
}
