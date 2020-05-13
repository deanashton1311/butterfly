using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ButterflyCalc.Tests.CalculatorServiceTests
{
    public class DivisionTests : BaseServiceTest
    {
        [Theory]
        [InlineData(12, 6, 2)]
        [InlineData(24, 6, 4)]
        [InlineData(58, 8, 7.25)]
        [InlineData(81, 10, 8.1)]
        [InlineData(-88.88, 4.4, -20.2)]
        public void DivideByValidNumbers(decimal start, decimal by, decimal expected)
        {
            var result = calc.Divide(start, by);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivideByZero()
        {
            Exception ex = Assert.Throws<DivideByZeroException>(() => calc.Divide(9, 0));
            Assert.Equal("Attempted to divide by zero.", ex.Message);

            ex = Assert.Throws<DivideByZeroException>(() => calc.Divide(0.0m, 0.0m));
            Assert.Equal("Attempted to divide by zero.", ex.Message);

            ex = Assert.Throws<DivideByZeroException>(() => calc.Divide(9.0m, 0.0m));
            Assert.Equal("Attempted to divide by zero.", ex.Message);

            ex = Assert.Throws<DivideByZeroException>(() => calc.Divide(11, 0.0m));
            Assert.Equal("Attempted to divide by zero.", ex.Message);
        }

    }
}
