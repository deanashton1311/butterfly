using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ButterflyCalc.Common.Dtos;

namespace ButterflyCalc.Biz.Services
{

    public class CalculatorService : ICalculatorService
    {
        private readonly ILogger logger;

        public CalculatorService(ILogger<CalculatorService> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Add - add two integers together, checks for int overflow
        /// </summary>
        /// <param name="start">the first number</param>
        /// <param name="amount">amount to add to the first number</param>
        /// <returns>decimal - two numbers added together</returns>
        public decimal Add(decimal start, decimal amount)
        {
            logger.LogInformation($"Adding: {start} + {amount}");
            try
            {
                var result = start + amount;
                logger.LogInformation($"Addition result: {start} + {amount} = {result}");
                return result;
            }
            catch (OverflowException)
            {
                logger.LogError($"Overflow exception when doing {start} + {amount}");
                throw;
            }
        }

        /// <summary>
        /// Divide - divide one number from another, checks for int overflow and rounds properly
        /// </summary>
        /// <param name="numerator">number to be divided</param>
        /// <param name="denominator">number to divide by</param>
        /// <returns>decimal - 'start' divided by 'by'</returns>
        public decimal Divide(decimal numerator, decimal denominator)
        {
            logger.LogInformation($"Dividing: {numerator} / {denominator}");

            if (denominator == 0 || (numerator.Equals(0.0) && denominator.Equals(0.0)))
                throw new DivideByZeroException();

            var result = numerator / denominator;

            logger.LogInformation($"Division result: {numerator} / {denominator} = {result}");
            return result;
        }

        /// <summary>
        /// Multiply - multiply two numbers together, checks for in overflow
        /// </summary>
        /// <param name="start">first number</param>
        /// <param name="by">number to multiply the first number by</param>
        /// <returns>decimal - two numbers multiplied together</returns>
        public decimal Multiply(decimal start, decimal by)
        {
            logger.LogInformation($"Multiplying: {start} * {by}");
            try
            {
                var result = start * by;
                logger.LogInformation($"Multiplication result: {start} * {by} = {result}");
                return result;
            }
            catch (OverflowException)
            {
                logger.LogError($"Overflow exception when doing {start} * {by}");
                throw;
            }
        }

        /// <summary>
        /// Subtract - subtract one number from another number, checks for int overflow
        /// </summary>
        /// <param name="start">first number</param>
        /// <param name="amount">amount to subtract from first number</param>
        /// <returns>decimal - 'start' minus 'amount'</returns>
        public decimal Subtract(decimal start, decimal amount)
        {
            logger.LogInformation($"Subtracting: {start} - {amount}");

            try
            {
                var result = start - amount;
                logger.LogInformation($"Subtraction result: {start} - {amount} = {result}");
                return result;
            }
            catch (OverflowException)
            {
                logger.LogError($"Overflow exception when doing {start} - {amount}");
                throw;
            }
        }

        /// <summary>
        /// Check result of an operation has not gone over integer min / max values as we return ints from calc
        /// </summary>
        /// <param name="result">the add/subtract/multiply/divide result to check</param>
        /// <param name="operation">name of operation performed, used for logging</param>
        //private void CheckForIntegerOverflow(long result, string operation)
        //{
        //    if (result > int.MaxValue)
        //    {
        //        logger.LogInformation($"{operation} overflow exception: beyond max value of {int.MaxValue}");
        //        throw new OverflowException($"{operation} beyond max value of {int.MaxValue}");
        //    }

        //    if (result < int.MinValue)
        //    {
        //        logger.LogInformation($"{operation} overflow exception: beyond min value of {int.MinValue}");
        //        throw new OverflowException($"{operation} beyond min value of {int.MinValue}");
        //    }
        //}

        /// <summary>
        /// Throws overflow exception if the result of the calc is more than max, or less than min, decimal value
        /// </summary>
        /// <param name="result">The calculated result from calc operation</param>
        /// <param name="operation">what type of operation calc is performing, used for logging</param>
        //private void CheckForDecimalOverflow(decimal result, string operation)
        //{
        //    if (decimal.MaxValue < result)
        //    {
        //        logger.LogInformation($"{operation} overflow exception: beyond max value of {int.MaxValue}");
        //        throw new OverflowException($"{operation} beyond max value of {int.MaxValue}");
        //    }
        //    if (decimal.MinValue > result)
        //    {
        //        logger.LogInformation($"{operation} overflow exception: beyond min value of {int.MinValue}");
        //        throw new OverflowException($"{operation} beyond min value of {int.MinValue}");
        //    }
        //}
    }

}
