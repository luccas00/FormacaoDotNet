using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Two.Models
{
    public class Investimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public double Juros { get; set; }
        public int Tempo { get; set; }

        public Investimento()
        {
            Nome = "Investimento Padrão";
            Valor = 1000;
            Juros = 0.25;
            Tempo = 12;
        }

        public Investimento(string nome, double valor, double juros, int tempo)
        {
            Nome = nome;
            Valor = valor;
            Juros = juros;
            Tempo = tempo;
        }
    }
}
