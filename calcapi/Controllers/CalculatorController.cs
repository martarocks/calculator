
using CaclApi;
using Calculator.ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Calculator.Controllers
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


        [HttpPost]
        public IActionResult Post([FromBody] CalculatorParams calculatorParams)
        {
            var results = 0;
            int totalNumbers = calculatorParams.Numbers.Length;
            int numbersIndex = 0;
            try
            {
                foreach (string operand in calculatorParams.Operands)
                {
                    var numbers = calculatorParams.Numbers;
                    if (numbersIndex < totalNumbers)
                    {
                        switch (operand)
                        {
                            case "+":
                                {
                                    if (results > 0)
                                    {
                                        results = new Sum().Calculate(numbers[numbersIndex], results);
                                        numbersIndex++;
                                    }
                                    else
                                    {
                                        if (numbersIndex + 1 < totalNumbers)
                                        {

                                            results = new Sum().Calculate(numbers[numbersIndex], numbers[numbersIndex + 1]);
                                            numbersIndex = numbersIndex + 2;
                                        }

                                    }

                                    break;
                                }
                            case "/":
                                {
                                    if (results > 0)
                                    {
                                        results = new Division().Calculate(results, numbers[numbersIndex]);
                                        numbersIndex++;
                                    }
                                    else
                                    {
                                        results = new Division().Calculate(numbers[numbersIndex], numbers[numbersIndex + 1]);
                                        numbersIndex = numbersIndex + 2;
                                    }
                                    break;
                                }
                            case "*":
                                {
                                    if (results > 0)
                                    {
                                        results = new Multiply().Calculate(results, numbers[numbersIndex]);
                                        numbersIndex++;
                                    }
                                    else
                                    {
                                        results = new Multiply().Calculate(numbers[numbersIndex], numbers[numbersIndex + 1]);
                                        numbersIndex = numbersIndex + 2;
                                    }
                                    break;
                                }
                            case "-":
                                {
                                    if (results > 0)
                                    {
                                        results = new Substract().Calculate(results, numbers[numbersIndex]);
                                        numbersIndex++;
                                    }
                                    else
                                    {
                                        results = new Substract().Calculate(numbers[numbersIndex], numbers[numbersIndex + 1]);
                                        numbersIndex = numbersIndex + 2;
                                    }
                                    break;
                                }
                            default:
                                break;

                        }
                    }

                }
            }

            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(results);
        }
    }
}