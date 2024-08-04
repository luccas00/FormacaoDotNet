using API_Two.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Two.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly Calculadora _calculadora;

        public CalculadoraController()
        {
            _calculadora = Calculadora.GetInstance();
        }

        [HttpGet("Somar/{a}/{b}")]
        public IActionResult Sum(double a, double b)
        {
            var obj = new
            {
                A = a,
                B = b,
                Resultado = _calculadora.Somar(a, b)
            };

            return Ok(obj);
        }

        [HttpGet("Subtrair/{a}/{b}")]
        public IActionResult Subtract(double a, double b)
        {
            var obj = new
            {
                A = a,
                B = b,
                Resultado = _calculadora.Subtrair(a, b)
            };

            return Ok(obj);
        }

        [HttpGet("Multiplicar/{a}/{b}")]
        public IActionResult Multiply(double a, double b)
        {
            var obj = new
            {
                A = a,
                B = b,
                Resultado = _calculadora.Multiplicar(a, b)
            };

            return Ok(obj);
        }

        [HttpGet("Dividir/{a}/{b}")]
        public IActionResult Divide(double a, double b)
        {
            try
            {
                var resultado = _calculadora.Dividir(a, b);
                var obj = new
                {
                    A = a,
                    B = b,
                    Resultado = resultado
                };
                return Ok(obj);
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Divisão por zero não é permitida.");
            }
        }

        [HttpGet("Potencia/{a}/{b}")]
        public IActionResult Power(double a, double b)
        {
            var obj = new
            {
                A = a,
                B = b,
                Resultado = _calculadora.Potencia(a, b)
            };

            return Ok(obj);
        }

        [HttpGet("RaizQuadrada/{a}")]
        public IActionResult SquareRoot(double a)
        {
            if (a < 0)
            {
                return BadRequest("Não é possível calcular a raiz quadrada de um número negativo.");
            }

            var obj = new
            {
                A = a,
                Resultado = _calculadora.RaizQuadrada(a)
            };

            return Ok(obj);
        }

        [HttpGet("RaizCubica/{a}")]
        public IActionResult CubicRoot(double a)
        {
            var obj = new
            {
                A = a,
                Resultado = _calculadora.RaizCubica(a)
            };

            return Ok(obj);
        }

        [HttpGet("Fatorial/{a}")]
        public IActionResult Factorial(double a)
        {
            if (a < 0)
            {
                return BadRequest("Não é possível calcular o fatorial de um número negativo.");
            }

            var obj = new
            {
                A = a,
                Resultado = _calculadora.Fatorial(a)
            };

            return Ok(obj);
        }
    }
}
