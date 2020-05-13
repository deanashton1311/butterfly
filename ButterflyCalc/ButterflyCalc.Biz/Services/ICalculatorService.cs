using System;
using System.Collections.Generic;
using System.Text;

namespace ButterflyCalc.Biz.Services
{
    public interface ICalculatorService
    {
        decimal Add(decimal start, decimal amount);
        decimal Subtract(decimal start, decimal amount);
        decimal Multiply(decimal start, decimal by);
        public decimal Divide(decimal numerator, decimal denominator);
    }
}
