using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("minus/{firstNumber}/{secondNumber}")]
        public IActionResult Minus(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var minus = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);
                return Ok(minus.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("times/{firstNumber}/{secondNumber}")]
        public IActionResult Times(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var times = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                return Ok(times.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        public IActionResult avg(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                return Ok(((Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber)) / 2).ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult sqrt(string firstNumber)
        {
            if (isNumeric(firstNumber))
            {
                return Ok((Math.Sqrt((double)Convert.ToDecimal(firstNumber))).ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool isNumeric(string firstNumber)
        {
            return double.TryParse(firstNumber, out double number);
        }
    }
}
