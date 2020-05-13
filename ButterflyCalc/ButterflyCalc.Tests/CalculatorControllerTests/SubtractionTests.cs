using System;
using System.Collections.Generic;
using System.Text;
using ButterflyCalc.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ButterflyCalc.Tests.CalculatorControllerTests
{
    public class SubtractionTests : BaseControllerTest
    {
        [Theory]
        [InlineData(6, 3, 3)]
        [InlineData(20, 10, 10)]
        [InlineData(84, 51, 33)]
        [InlineData(14, 0, 14)]
        [InlineData(-14, 10, -24)]
        [InlineData(0, 0, 0)]
        public void SubtractValidNumbers(decimal start, decimal amount, decimal expected)
        {
            // act
            var request = new SubtractRequestDto() { Start = start, Amount = amount };
            var result = controller.Subtract(request);
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expected, okResult.Value);
        }

        [Fact]
        public void SubtractPastMax()
        {
            var request = new SubtractRequestDto() { Start = decimal.MaxValue, Amount = -100 };

            var result = controller.Subtract(request);
            var controllerResult = result as ObjectResult;

            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);
        }

        [Fact]
        public void SubtractPastMin()
        {
            var request = new SubtractRequestDto() { Start = decimal.MinValue, Amount = 100 };

            var result = controller.Subtract(request);
            var controllerResult = result as ObjectResult;

            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);
        }

    }

}
