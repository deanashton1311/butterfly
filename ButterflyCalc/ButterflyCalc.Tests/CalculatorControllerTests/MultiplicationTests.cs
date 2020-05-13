using System;
using System.Collections.Generic;
using System.Text;
using ButterflyCalc.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ButterflyCalc.Tests.CalculatorControllerTests
{
    public class MultiplicationTests : BaseControllerTest
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
        [InlineData(5.5, -3.7, 20.35)]
        public void MultiplyValidNumbers(decimal start, decimal by, decimal expected)
        {
            // act
            var request = new MultiplyRequestDto() { Start = start, By = by };
            var result = controller.Multiply(request);
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expected, (decimal)okResult.Value);
        }

        [Fact]
        public void MultiplyPastMax()
        {
            var request = new MultiplyRequestDto() { Start = decimal.MaxValue, By = 2 };

            var result = controller.Multiply(request);
            var controllerResult = result as ObjectResult;

            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);
        }

        [Fact]
        public void MultiplyPastMin()
        {
            var request = new MultiplyRequestDto() { Start = decimal.MinValue, By = 2 };

            var result = controller.Multiply(request);
            var controllerResult = result as ObjectResult;

            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);
        }

    }
}
