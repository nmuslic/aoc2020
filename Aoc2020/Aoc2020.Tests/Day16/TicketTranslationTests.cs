using Aoc2020.Day16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aoc2020.Tests.Day16
{
    public class TicketTranslationTests
    {
        [Fact]
        public void GetTicketScanningErrorRate_ValidInput_ReturnsErrorRate()
        {
            string input = Resources.ResourceFiles.TicketTranslationInput;

            var result = TicketTranslation.GetTicketScanningErrorRate(input);

            Assert.Equal(26009, result);
        }
    }
}
