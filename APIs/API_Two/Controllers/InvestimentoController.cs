using API_Two.Context;
using API_Two.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Two.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private readonly MyContext context;

        public InvestimentoController(MyContext context)
        {
            this.context = context;
        }

        [HttpPost("CriarInvestimento")]
        public IActionResult CreateInvestment(string nome, double valor, double juros, int tempo)
        {
            Investimento investimento = new Investimento(nome, valor, juros, tempo);
            context.Investimentos.Add(investimento);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetByName), new { nome = investimento.Nome}, investimento);
        }

        [HttpPost("CriarInvestimentoPadrao")]
        public IActionResult CreateStandardInvestment()
        {
            Investimento investimento = new Investimento();
            context.Investimentos.Add(investimento);
            context.SaveChanges();
            return Ok(investimento);
        }

        [HttpGet("ListarInvestimentos")]
        public IActionResult ListInvestments()
        {
            return Ok(context.Investimentos);
        }

        [HttpGet("BuscarInvestimento/{id}")]
        public IActionResult GetInvestment(string id)
        {
            Investimento investimento = context.Investimentos.Find(id);
            if (investimento == null)
            {
                return NotFound();
            }
            return Ok(investimento);
        }

        [HttpPut("AtualizarInvestimento/{id}")]
        public IActionResult UpdateInvestment(string id, string nome, double valor, double juros, int tempo)
        {
            Investimento investimento = context.Investimentos.Find(id);
            if (investimento == null)
            {
                return NotFound();
            }
            investimento.Nome = nome;
            investimento.Valor = valor;
            investimento.Juros = juros;
            investimento.Tempo = tempo;
            context.SaveChanges();
            return Ok(investimento);
        }

        [HttpDelete("DeletarInvestimento/{id}")]
        public IActionResult DeleteInvestment(string id)
        {
            Investimento investimento = context.Investimentos.Find(id);
            if (investimento == null)
            {
                return NotFound();
            }
            context.Investimentos.Remove(investimento);
            context.SaveChanges();
            return NoContent();
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public IActionResult GetByName(string nome)
        {
            var investimento = context.Investimentos.Where(investimento => investimento.Nome.Equals(nome));
            if (investimento == null)
            {
                return NotFound();
            }
            return Ok(investimento);
        }



    }
}
