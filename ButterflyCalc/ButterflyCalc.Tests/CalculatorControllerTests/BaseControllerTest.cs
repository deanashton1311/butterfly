using System;
using ButterflyCalc.Biz.Services;
using Microsoft.Extensions.Logging;
using Moq;
using ButterflyCalc.Api;

namespace ButterflyCalc.Tests.CalculatorControllerTests
{
    public class BaseControllerTest
    {
        public readonly Api.Controllers.CalculatorController controller;
        public readonly Mock<ILogger<Api.Controllers.CalculatorController>> mockLogger;
        public readonly Mock<ICalculatorService> mockCalcService;

        public BaseControllerTest()
        {
            this.mockLogger = new Mock<ILogger<Api.Controllers.CalculatorController>>();
            this.mockCalcService = new Mock<ICalculatorService>();

            this.mockCalcService.Setup(m => m.Add(3, 3)).Returns(6);
            this.mockCalcService.Setup(m => m.Add(33, 51)).Returns(84);
            this.mockCalcService.Setup(m => m.Add(14, 0)).Returns(14);
            this.mockCalcService.Setup(m => m.Add(-14, 10)).Returns(-4);
            this.mockCalcService.Setup(m => m.Add(0, 0)).Returns(0);
            this.mockCalcService.Setup(m => m.Add(0, -10)).Returns(-10);
            this.mockCalcService.Setup(m => m.Add(10.1m, 5.2m)).Returns(15.3m);
            this.mockCalcService.Setup(m => m.Add(5.5m, -10.4m)).Returns(-4.9m);
            this.mockCalcService.Setup(m => m.Add(10.005m, 20.041m)).Returns(30.046m);
            this.mockCalcService.Setup(m => m.Add(decimal.MaxValue, 100)).Throws(new OverflowException());
            this.mockCalcService.Setup(m => m.Add(decimal.MinValue, -100)).Throws(new OverflowException());

            this.mockCalcService.Setup(m => m.Subtract(6, 3)).Returns(3);
            this.mockCalcService.Setup(m => m.Subtract(20, 10)).Returns(10);
            this.mockCalcService.Setup(m => m.Subtract(84, 51)).Returns(33);
            this.mockCalcService.Setup(m => m.Subtract(14, 0)).Returns(14);
            this.mockCalcService.Setup(m => m.Subtract(-14, 10)).Returns(-24);
            this.mockCalcService.Setup(m => m.Subtract(0, 0)).Returns(0);
            this.mockCalcService.Setup(m => m.Subtract(decimal.MaxValue, -100)).Throws(new OverflowException());
            this.mockCalcService.Setup(m => m.Subtract(decimal.MinValue, 100)).Throws(new OverflowException());

            this.mockCalcService.Setup(m => m.Multiply(2, 3)).Returns(6);
            this.mockCalcService.Setup(m => m.Multiply(1, 1)).Returns(1);
            this.mockCalcService.Setup(m => m.Multiply(1, 3)).Returns(3);
            this.mockCalcService.Setup(m => m.Multiply(10, 11)).Returns(110);
            this.mockCalcService.Setup(m => m.Multiply(6, 10)).Returns(60);
            this.mockCalcService.Setup(m => m.Multiply(-14, -2)).Returns(28);
            this.mockCalcService.Setup(m => m.Multiply(-15, 3)).Returns(-45);
            this.mockCalcService.Setup(m => m.Multiply(5, 0)).Returns(0);
            this.mockCalcService.Setup(m => m.Multiply(-5.5m, 10.7m)).Returns(-58.85m);
            this.mockCalcService.Setup(m => m.Multiply(5.5m, -3.7m)).Returns(20.35m);
            this.mockCalcService.Setup(m => m.Multiply(decimal.MaxValue, 2)).Throws(new OverflowException());
            this.mockCalcService.Setup(m => m.Multiply(decimal.MinValue, 2)).Throws(new OverflowException());

            this.mockCalcService.Setup(m => m.Divide(12, 6)).Returns(2);
            this.mockCalcService.Setup(m => m.Divide(24, 6)).Returns(4);
            this.mockCalcService.Setup(m => m.Divide(58, 8)).Returns(7.25m);
            this.mockCalcService.Setup(m => m.Divide(81, 10)).Returns(8.1m);
            this.mockCalcService.Setup(m => m.Divide(-88.88m, 4.4m)).Returns(-20.2m);
            this.mockCalcService.Setup(m => m.Divide(9, 0)).Throws(new DivideByZeroException());
            this.mockCalcService.Setup(m => m.Divide(0.0m, 0.0m)).Throws(new DivideByZeroException());
            this.mockCalcService.Setup(m => m.Divide(9.0m, 0.0m)).Throws(new DivideByZeroException());
            this.mockCalcService.Setup(m => m.Divide(11, 0.0m)).Throws(new DivideByZeroException());

            this.controller = new Api.Controllers.CalculatorController(mockLogger.Object, mockCalcService.Object);
        }


    }
}
