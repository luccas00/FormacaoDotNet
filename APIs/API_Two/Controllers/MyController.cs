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

        [HttpGet("Now")]
        public IActionResult Now()
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

        private double Fatorial(double n)
        {
            return n == 0 ? 1 : n * Fatorial(n - 1);
        }

        [HttpGet("GerarCPF")]
        public IActionResult GetCPF()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString(),
                CPF = GerarCPF()
            };

            return Ok(obj);

        }

        public static string GerarCPF()
        {
            Random random = new Random();
            int[] cpf = new int[9];

            // Gera os 9 primeiros dígitos do CPF
            for (int i = 0; i < 9; i++)
            {
                cpf[i] = random.Next(0, 10);
            }

            // Calcula o dígito verificador 1
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += cpf[i] * (10 - i);
            }
            int digito1 = (soma % 11) < 2 ? 0 : 11 - (soma % 11);

            // Calcula o dígito verificador 2
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (i < 9 ? cpf[i] : digito1) * (11 - i);
            }
            int digito2 = (soma % 11) < 2 ? 0 : 11 - (soma % 11);

            return $"{cpf[0]}{cpf[1]}{cpf[2]}.{cpf[3]}{cpf[4]}{cpf[5]}.{cpf[6]}{cpf[7]}{cpf[8]}-{digito1}{digito2}";
        }


        [HttpGet("GerarCNPJ")]
        public IActionResult GetCNPJ()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString(),
                CNPJ = GerarCNPJ()
            };

            return Ok(obj);

        }

        public static string GerarCNPJ()
        {
            Random random = new Random();
            int[] cnpj = new int[12];

            // Gera os 12 primeiros dígitos do CNPJ
            for (int i = 0; i < 12; i++)
            {
                cnpj[i] = random.Next(0, 10);
            }

            // Calcula o dígito verificador 1
            int[] pesos1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma1 = 0;
            for (int i = 0; i < 12; i++)
            {
                soma1 += cnpj[i] * pesos1[i];
            }
            int digito1 = (soma1 % 11) < 2 ? 0 : 11 - (soma1 % 11);

            // Calcula o dígito verificador 2
            int[] pesos2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma2 = 0;
            for (int i = 0; i < 13; i++)
            {
                soma2 += (i < 12 ? cnpj[i] : digito1) * pesos2[i];
            }
            int digito2 = (soma2 % 11) < 2 ? 0 : 11 - (soma2 % 11);

            return $"{cnpj[0]}{cnpj[1]}.{cnpj[2]}{cnpj[3]}{cnpj[4]}.{cnpj[5]}{cnpj[6]}{cnpj[7]}/{cnpj[8]}{cnpj[9]}{cnpj[10]}{cnpj[11]}-{digito1}{digito2}";
        }

        [HttpGet("GerarTelefone")]
        public IActionResult GetTelefone()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString(),
                Telefone = GerarTelefone()
            };

            return Ok(obj);

        }

        public static string GerarTelefone()
        {
            Random random = new Random();
            int ddd = random.Next(11, 45); // DDD entre 11 e 44
            int primeiroNumero = random.Next(8, 10); // Primeiro número entre 8 e 9
            int numero = random.Next(10000000, 100000000); // Número entre 8 e 9 dígitos

            return $"({ddd}) {primeiroNumero}{numero:00000000}";
        }



    }
}
