using Microsoft.AspNetCore.Mvc;

namespace MicroService.Controllers
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

        #region Get Methods
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(AreNumerics(firstNumber, secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return SendBadRequest();
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if(AreNumerics(firstNumber, secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return SendBadRequest();
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if(AreNumerics(firstNumber, secondNumber))
            {
                decimal mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return SendBadRequest();
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if(AreNumerics(firstNumber, secondNumber))
            {
                decimal div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return SendBadRequest();
        }

        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult Med(string firstNumber, string secondNumber)
        {
            if(AreNumerics(firstNumber, secondNumber))
            {
                decimal med = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(med.ToString());
            }
            return SendBadRequest();
        }

        [HttpGet("raiz/{number}")]
        public IActionResult Raiz(string number)
        {
            if(IsNumeric(number))
            {
                double raiz = Math.Sqrt(ConvertToDouble(number));
                return Ok(raiz.ToString());
            }
            return SendBadRequest();
        }
        #endregion

        #region Privates Methods
        private static bool AreNumerics(string firstNumber, string secondNumber)
        {
            return IsNumeric(firstNumber) && IsNumeric(secondNumber);
        }

        private BadRequestObjectResult SendBadRequest() => BadRequest("Input Invalid");

        private static bool IsNumeric(string strNumber) =>
            double.TryParse(strNumber,
                            System.Globalization.NumberStyles.Any,
                            System.Globalization.NumberFormatInfo.InvariantInfo,
                            out _);

        private static decimal ConvertToDecimal(string strNumber)  => 
            decimal.TryParse(strNumber, out decimal decimalValue) ? decimalValue : 0;

        private static double ConvertToDouble(string strNumber) =>
            double.TryParse(strNumber, out double doubleValue) ? doubleValue : 0;
        #endregion
    }
}
