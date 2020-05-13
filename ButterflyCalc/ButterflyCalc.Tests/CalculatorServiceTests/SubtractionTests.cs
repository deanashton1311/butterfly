using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ButterflyCalc.Tests.CalculatorServiceTests
{
    public class SubtractionTests : BaseServiceTest
    {
        [Theory]
        [InlineData(6, 3, 3)]
        [InlineData(20, 10, 10)]
        [InlineData(84, 51, 33)]
        [InlineData(14, 0, 14)]
        [InlineData(-14, 10, -24)]
        [InlineData(0, 0, 0)]
        [InlineData(40.7, -10.5, 51.2)]
        [InlineData(-79.2, -7.1, -72.1)]
        [InlineData(11, 2.3, 8.7)]
        [InlineData(44.4, 22.2, 22.2)]
        [InlineData(-50.8, 20.4, -71.2)]
        [InlineData(88.8, -25.4, 114.2)]
        [InlineData(-79.2, 0, -79.2)]
        [InlineData(0, -7.1, 7.1)]
        public void SubtractValidNumbers(decimal start, decimal amount, decimal expected)
        {
            var result = calc.Subtract(start, amount);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SubtractPastMax()
        {
            var start = decimal.MaxValue;
            var amount = -10;

            Exception ex = Assert.Throws<OverflowException>(() => calc.Subtract(start, amount));
        }

        [Fact]
        public void SubtractPastMin()
        {
            var start = decimal.MinValue;
            var amount = 10;

            Exception ex = Assert.Throws<OverflowException>(() => calc.Subtract(start, amount));
        }

    }

}
