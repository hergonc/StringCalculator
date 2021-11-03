using System;
using Xunit;

namespace StringCalculator.Test
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("1,2", 3)]
        [InlineData("2,2", 4)]
        public void Add1String(string value, int resultExpected)
        {
            int result = Calculator.Add(value);
            Assert.Equal(resultExpected, result);
        }
    }
}
