using System;
using Microsoft.Extensions.Logging;
using Moq;

namespace ButterflyCalc.Tests.CalculatorServiceTests
{
    public class BaseServiceTest
    {
        public readonly Biz.Services.ICalculatorService calc;
        public readonly Mock<ILogger<Biz.Services.CalculatorService>> loggerMock;

        public BaseServiceTest()
        {
            this.loggerMock = new Mock<ILogger<Biz.Services.CalculatorService>>();
            this.calc = new Biz.Services.CalculatorService(loggerMock.Object);
        }


    }
}
