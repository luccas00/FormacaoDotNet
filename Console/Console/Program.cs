using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace MyGenerator
{

    public class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 1)
            {
                if (args[0].ToLower().Equals("cpf"))
                {
                    var result = GetCPF();

                    // Serializa o objeto para uma string JSON
                    string jsonString = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

                    // Imprime o JSON resultante no console
                    Console.WriteLine(jsonString);

                }
                else if (args[0].ToLower().Equals("cnpj"))
                {
                    var result = GetCNPJ();

                    string jsonString = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

                    // Imprime o JSON resultante no console
                    Console.WriteLine(jsonString);
                }
                else if (args[0].ToLower().Equals("senha"))
                {
                    var result = GetSENHA();

                    string jsonString = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

                    // Imprime o JSON resultante no console
                    Console.WriteLine(jsonString);
                }
                else if (args[0].ToLower().Equals("guid"))
                {
                    var result = GetGUID();

                    string jsonString = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

                    // Imprime o JSON resultante no console
                    Console.WriteLine(jsonString);
                }
                else
                {
                    Console.WriteLine("Argumento invalido.");
                }
            }
            else
            {
                Console.WriteLine("Numero de argumentos invalidos.");
            }

        }

        public static Object GetCPF()
        {
            var obj = new
            {
                Data = DateTime.Now.ToShortDateString(),
                Hora = DateTime.Now.ToShortTimeString(),
                CPF = GerarCPF()
            };

            return obj;

        }

        private static string GerarCPF()
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

        public static Object GetCNPJ()
        {
            var obj = new
            {
                Data = DateTime.Now.ToShortDateString(),
                Hora = DateTime.Now.ToShortTimeString(),
                CNPJ = GerarCNPJ()
            };

            return obj;

        }

        private static string GerarCNPJ()
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

        public static Object GetSENHA()
        {
            var obj = new
            {
                Data = DateTime.Now.ToShortDateString(),
                Hora = DateTime.Now.ToShortTimeString(),
                SENHA = GerarSenhaAleatoria()
            };

            return obj;

        }

        private static string GerarSenhaAleatoria()
        {

            int comprimento = 16;

            const string letrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
            const string numeros = "0123456789";
            const string caracteresEspeciais = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            string todosCaracteres = letrasMaiusculas + letrasMinusculas + numeros + caracteresEspeciais;

            Random random = new Random();

            StringBuilder senha = new StringBuilder();

            // Garante que a senha tenha pelo menos um caractere de cada tipo
            senha.Append(letrasMaiusculas[random.Next(letrasMaiusculas.Length)]);
            senha.Append(letrasMinusculas[random.Next(letrasMinusculas.Length)]);
            senha.Append(numeros[random.Next(numeros.Length)]);
            senha.Append(caracteresEspeciais[random.Next(caracteresEspeciais.Length)]);

            // Preenche o restante da senha com caracteres aleatórios
            for (int i = senha.Length; i < comprimento; i++)
            {
                senha.Append(todosCaracteres[random.Next(todosCaracteres.Length)]);
            }

            // Converte a senha em array para embaralhamento
            char[] senhaArray = senha.ToString().ToCharArray();

            // Embaralha o array usando o algoritmo Fisher-Yates
            for (int i = senhaArray.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (senhaArray[i], senhaArray[j]) = (senhaArray[j], senhaArray[i]);
            }

            // Retorna a senha como string
            return new string(senhaArray);
        }

        public static Object GetGUID()
        {
            var obj = new
            {
                Data = DateTime.Now.ToShortDateString(),
                Hora = DateTime.Now.ToShortTimeString(),
                GUID = Guid.NewGuid().ToString()
            };

            return obj;

        }

    }
}

