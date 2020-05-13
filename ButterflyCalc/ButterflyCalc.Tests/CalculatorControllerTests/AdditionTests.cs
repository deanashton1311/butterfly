using System;
using System.Collections.Generic;
using System.Text;
using ButterflyCalc.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;

namespace ButterflyCalc.Tests.CalculatorControllerTests
{
    public class AdditionTests : BaseControllerTest
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
            // act
            var request = new AddRequestDto() { Start = start, Amount = amount };
            var result = controller.Add(request);
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expected, okResult.Value);
        }

        [Fact]
        public void AddPastMax()
        {
            var request = new AddRequestDto() { Start = decimal.MaxValue, Amount = 100 };

            var result = controller.Add(request);
            var controllerResult = result as ObjectResult;

            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);
        }

        [Fact]
        public void AddPastMin()
        {
            var request = new AddRequestDto() { Start = decimal.MinValue, Amount = -100 };

            var result = controller.Add(request);
            var controllerResult = result as ObjectResult;

            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);
        }

    }
}
