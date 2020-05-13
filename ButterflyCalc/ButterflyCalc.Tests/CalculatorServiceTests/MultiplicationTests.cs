using System;
using System.Collections.Generic;
using System.Text;
using ButterflyCalc.Common.Dtos;
using Xunit;

namespace ButterflyCalc.Tests.CalculatorServiceTests
{
    public class MultiplicationTests : BaseServiceTest
    {
        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 3, 3)]
        [InlineData(10, 11, 110)]
        [InlineData(6, 10, 60)]
        [InlineData(-14, -2, 28)]
        [InlineData(-15, 3, -45)]
        [InlineData(5, 0, 0)]
        [InlineData(-5.5, 10.7, -58.85)]
        [InlineData(5.5, -3.7, -20.35)]
        [InlineData(9.9, 3.2, 31.68)]
        public void MultiplyValidNumbers(decimal start, decimal by, decimal expected)
        {
            var result = calc.Multiply(start, by);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplyPastMax()
        {
            var start = decimal.MaxValue;
            var by = 2;

            Exception ex = Assert.Throws<OverflowException>(() => calc.Multiply(start, by));
        }

        [Fact]
        public void MultiplyPastMin()
        {
            var start = decimal.MinValue;
            var by = 2;

            Exception ex = Assert.Throws<OverflowException>(() => calc.Multiply(start, by));
        }

    }
}
