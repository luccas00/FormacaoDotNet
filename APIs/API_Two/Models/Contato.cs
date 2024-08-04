using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Two.Models
{
    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Contato()
        {
            CPF = "000.000.000-00";
            Nome = "Contato Padrão";
            Email = "contato@padrao.com";
            Telefone = "9988-0123";
            Endereco = "Rua do Contato, 123";
        }

        public Contato(string cpf, string nome, string email, string telefone, string endereco)
        {
            CPF = cpf;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

    }
}
