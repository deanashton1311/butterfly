using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ButterflyCalc.Tests.CalculatorServiceTests
{
    public class AdditionTests : BaseServiceTest
    {
        [Theory]
        [InlineData(3, 3, 6)]
        [InlineData(33, 51, 84)]
        [InlineData(14, 0, 14)]
        [InlineData(-14, 10, -4)]
        [InlineData(0, 0, 0)]
        [InlineData(0, -10, -10)]
        [InlineData(10.1, 5.2, 15.3)]
        [InlineData(5.5, -10.4, -4.9)]
        [InlineData(10.005, 20.041, 30.046)]
        public void AddValidNumbers(decimal start, decimal amount, decimal expected)
        {
            var result = calc.Add(start, amount);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddPastMax()
        {
            var start = decimal.MaxValue;
            var amount = 1000;

            Exception ex = Assert.Throws<OverflowException>(() => calc.Add(start, amount));
        }

        [Fact]
        public void AddPastMin()
        {
            var start = decimal.MinValue;
            var amount = -1000;

            Exception ex = Assert.Throws<OverflowException>(() => calc.Add(start, amount));
        }

    }
}
