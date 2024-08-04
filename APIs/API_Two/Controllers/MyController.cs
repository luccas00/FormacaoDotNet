using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Two.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyController : ControllerBase
    {
        [HttpGet("MyIndex")]
        public IActionResult MyIndex()
        {
            var obj = new
            {
                Nome = "Luccas Carneiro",
                DataNascimento = new DateTime(1998, 11, 17),
                Telefone = "(31) 99631-9570",
                Email = "luccas.carneiro@hotmail.com",
                Endereco = new
                {
                    Cidade = "Belo Horizonte",
                    Estado = "Minas Gerais",
                    Pais = "Brasil"
                },
                Hobbies = new string[] { "Programar", "Jogar", "Estudar", "Ler" }
            };

            return Ok(obj);
        }
    }
}
