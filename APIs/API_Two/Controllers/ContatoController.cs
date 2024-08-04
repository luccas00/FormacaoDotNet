using API_Two.Context;
using API_Two.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Two.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly MyContext context;

        public ContatoController(MyContext context)
        {
            this.context = context;
        }

        [HttpPost("CriarContato")]
        public IActionResult CreateContact(string cpf, string nome, string email, string telefone, string endereco)
        {
            Contato contato = new Contato(cpf, nome, email, telefone, endereco);
            context.Contatos.Add(contato);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetByCPF), new { nome = contato.CPF }, contato); ;
        }

        [HttpPost("CriarContatoPadrao")]
        public IActionResult CreateStandardContact()
        {
            Contato contato = new Contato();
            context.Contatos.Add(contato);
            context.SaveChanges();
            return Ok(contato);
        }

        [HttpGet("ListarContatos")]
        public IActionResult ListContacts()
        {
            return Ok(context.Contatos);
        }

        [HttpGet("BuscarContato/{id}")]
        public IActionResult GetContact(string id)
        {
            Contato contato = context.Contatos.Find(id);
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpPut("AtualizarContato/{id}")]
        public IActionResult UpdateContact(string id, string cpf, string nome, string email, string telefone, string endereco)
        {
            Contato contato = context.Contatos.Find(id);
            if (contato == null)
            {
                return NotFound();
            }
            contato.CPF = cpf;
            contato.Nome = nome;
            contato.Email = email;
            contato.Telefone = telefone;
            contato.Endereco = endereco;
            context.SaveChanges();
            return Ok(contato);
        }

        [HttpDelete("DeletarContato/{id}")]
        public IActionResult DeleteContact(string id)
        {
            Contato contato = context.Contatos.Find(id);
            if (contato == null)
            {
                return NotFound();
            }
            context.Contatos.Remove(contato);
            context.SaveChanges();
            return NoContent();
        }

        [HttpGet("BuscarPorCPF/{cpf}")]
        public IActionResult GetByCPF(string cpf)
        {
            var contato = context.Contatos.FirstOrDefault(c => c.CPF.Equals(cpf));
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public IActionResult GetByName(string nome)
        {
            var contato = context.Contatos.FirstOrDefault(c => c.Nome.Equals(nome));
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }


        //[HttpGet("BuscarPorCPF/{cpf}")]
        //public IActionResult GetByCPF(string cpf)
        //{
        //    var contato = context.Contatos.Where(contato => contato.CPF.Equals(cpf));
        //    if (contato == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(contato);
        //}

        //[HttpGet("BuscarPorNome/{nome}")]
        //public IActionResult GetByName(string nome)
        //{
        //    Contato contato = (Contato)context.Contatos.Where(contato => contato.Nome.Equals(nome));
        //    if (contato == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(contato);
        //}

    }
}
