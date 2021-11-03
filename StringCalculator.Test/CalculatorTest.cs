using System;
using Xunit;

namespace StringCalculator.Test
{
    public class CalculatorTest
    {
        [Fact]
        public void AddEmptyString()
        {
            int result = Calculator.Add("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Add1String(string value, int resultExpected)
        {
            int result = Calculator.Add(value);
            Assert.Equal(resultExpected, result);
        }
    }
}
