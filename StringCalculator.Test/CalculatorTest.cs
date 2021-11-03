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

        [Fact]
        public void Add1String()
        {
            int result = Calculator.Add("1");
            Assert.Equal(1, result);
        }
    }
}
