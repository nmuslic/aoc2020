using Aoc2020.Day2;
using Xunit;

namespace Aoc2020.Tests.Day2
{
    public class PasswordPhilosophyTests
    {
        [Fact]
        public void GetNumberOfValidPasswordsCounted_ValidInput_ReturnsNumberOfValidPasswords()
        {
            string input = Resources.ResourceFiles.PasswordPhilosophyInput;

            int result = PasswordPhilosophy.GetNumberOfValidPasswordsCounted(input);

            Assert.Equal(628, result);
        }

        [Fact]
        public void GetNumberOfValidPasswordsPositioned_ValidInput_ReturnsNumberOfValidPasswords()
        {
            string input = Resources.ResourceFiles.PasswordPhilosophyInput;

            int result = PasswordPhilosophy.GetNumberOfValidPasswordsPositioned(input);

            Assert.Equal(705, result);
        }
    }
}
