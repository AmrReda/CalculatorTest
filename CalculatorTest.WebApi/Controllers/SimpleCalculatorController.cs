using Microsoft.AspNetCore.Mvc;

namespace CalculatorTest.WebApi.Controllers
{
    [ApiController]
    [Route("calculator")]
    public class SimpleCalculatorController : ControllerBase
    { 
        private readonly ISimpleCalculator _simpleCalculator;

        public SimpleCalculatorController(ISimpleCalculator simpleCalculator)
        {
            _simpleCalculator = simpleCalculator;
        }

        [HttpGet("/add")]
        public IActionResult Add(int start, int amount)
        {
            var result = _simpleCalculator.Add(start, amount);
            return Ok(result);
        }
        [HttpGet("/subtract")]
        public IActionResult Subtract(int start, int amount)
        {
            var result = _simpleCalculator.Subtract(start, amount);

            return Ok(result);
        }
        [HttpGet("/multiply")]
        public IActionResult Multiply(int start, int amount)
        {
            var result = _simpleCalculator.Multiply(start, amount);

            return Ok(result);
        }
        [HttpGet("/divide")]
        public IActionResult Divide(int start, int amount)
        {
            var result = _simpleCalculator.Divide(start, amount);

            return Ok(result);
        }
    }
}
