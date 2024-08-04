using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Two.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);

        }

        [HttpGet("GetFatorial/{n}")]
        public IActionResult GetFatorial(double n)
        {
            var obj = new
            {
                Valor = n,
                Resultado = Fatorial(n)
            };
            return Ok(obj);
        }

        [HttpGet("GetFibonacci/{n}")]
        public IActionResult GetFibonacci(double n)
        {
            var obj = new
            {
                Valor = n,
                Resultado = Fibonacci(n)
            };
            return Ok(obj);
        }

        private double Fibonacci(double n)
        {
            return n == 0 ? 0 : n == 1 ? 1 : Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private double Fatorial(double n)
        {
            return n == 0 ? 1 : n * Fatorial(n - 1);
        }


    }
}
