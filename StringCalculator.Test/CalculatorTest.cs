using System;
using FluentAssertions;
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
        [InlineData("2,1001", 2)]
        [InlineData("1,2,1", 4)]
        [InlineData("1,2,2", 5)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2\n3\n4", 10)]
        [InlineData("//;\n1;2", 3)]
        public void AddString(string value, int resultExpected)
        {
            int result = Calculator.Add(value);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData("1,-2")]
        [InlineData("-5,-3")]
        [InlineData("1\n2,-3")]
        [InlineData("//;\n-1;2")]
        [InlineData("//[***]\n1***2***-3")]
        public void ExceptionWithNegativeNumber(string negativeValue)
        {
            Action action = () => Calculator.Add(negativeValue);
            action.Should()
                .Throw<ArgumentException>()
                .Where(e => e.Message.StartsWith("negatives not allowed"));
        }

        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[++]\n1++2++3", 6)]
        [InlineData("//[////]\n1////2////3////4", 10)]
        public void AddStringWithDelimiterCanBeAnyLength(string value, int resultExpected)
        {
            int result = Calculator.Add(value);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData("//[*][%]\n1*2%3", 6)]
        [InlineData("//[;][+]\n1;2+3;4", 10)]
        [InlineData("//[**][%%]\n1**2%%3", 6)]
        public void AddStringWithMultipleDelimiters(string value, int resultExpected)
        {
            int result = Calculator.Add(value);
            Assert.Equal(resultExpected, result);
        }
    }
}
