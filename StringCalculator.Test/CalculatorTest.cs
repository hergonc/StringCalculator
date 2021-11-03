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
    }
}
