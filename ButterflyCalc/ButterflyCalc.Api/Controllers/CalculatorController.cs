using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterflyCalc.Biz.Services;
using ButterflyCalc.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ButterflyCalc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> logger;
        private readonly ICalculatorService calcService;

        public CalculatorController(ILogger<CalculatorController> logger, ICalculatorService calcService)
        {
            this.logger = logger;
            this.calcService = calcService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(AddRequestDto request)
        {
            var operation = $"{request.Start} + { request.Amount}";
            try
            {
                logger.LogInformation($"Add request received: {operation}");
                var result = calcService.Add(request.Start, request.Amount);
                logger.LogInformation($"Result for {operation} = {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error processing {operation}");
                return StatusCode(500, "Error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("subtract")]
        public IActionResult Subtract(SubtractRequestDto request)
        {
            var operation = $"{request.Start} - { request.Amount}";
            try
            {
                logger.LogInformation($"Subtract request received: {operation}");
                var result = calcService.Subtract(request.Start, request.Amount);
                logger.LogInformation($"Result for {operation} = {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error processing {operation}");
                return StatusCode(500, "Error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("multiply")]
        public IActionResult Multiply(MultiplyRequestDto request)
        {
            var operation = $"{request.Start} * { request.By}";
            try
            {
                logger.LogInformation($"Multiply request received: {operation}");
                var result = calcService.Multiply(request.Start, request.By);
                logger.LogInformation($"Result for {operation} = {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error processing {operation}");
                return StatusCode(500, "Error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("divide")]
        public IActionResult Divide(DivideRequestDto request)
        {
            var operation = $"{request.Numerator} / { request.Denominator}";
            try
            {
                logger.LogInformation($"Divide request received: {operation}");
                var result = calcService.Divide(request.Numerator, request.Denominator);
                logger.LogInformation($"Result for {operation} = {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error processing {operation}");
                return StatusCode(500, "Error: " + ex.Message);
            }
        }

    }
}
