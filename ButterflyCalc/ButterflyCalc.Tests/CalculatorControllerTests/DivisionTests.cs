using System;
using System.Collections.Generic;
using System.Text;
using ButterflyCalc.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ButterflyCalc.Tests.CalculatorControllerTests
{
    public class DivisionTests : BaseControllerTest
    {
        [Theory]
        [InlineData(12, 6, 2)]
        [InlineData(24, 6, 4)]
        [InlineData(58, 8, 7.25)]
        [InlineData(81, 10, 8.1)]
        [InlineData(-88.88, 4.4, -20.2)]
        public void DivideByValidNumbers(decimal start, decimal by, decimal expected)
        {
            // act
            var request = new DivideRequestDto() { Numerator = start, Denominator = by };
            var result = controller.Divide(request);
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expected, okResult.Value);
        }

        [Fact]
        public void DivideByZero()
        {
            var request = new DivideRequestDto() { Numerator = 11, Denominator = 0.0m };
            var result = controller.Divide(request);
            var controllerResult = result as ObjectResult;
            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);

            request = new DivideRequestDto() { Numerator = 0.0m, Denominator = 0.0m };
            result = controller.Divide(request);
            controllerResult = result as ObjectResult;
            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);

            request = new DivideRequestDto() { Numerator = 9.0m, Denominator = 0.0m };
            result = controller.Divide(request);
            controllerResult = result as ObjectResult;
            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);

            request = new DivideRequestDto() { Numerator = 9m, Denominator = 0.0m };
            result = controller.Divide(request);
            controllerResult = result as ObjectResult;
            // assert
            Assert.NotNull(controllerResult);
            Assert.Equal(500, controllerResult.StatusCode);
        }

    }
}
