namespace API_Two.Models
{
    public class Calculadora
    {
        private static Calculadora instance;

        private Calculadora() { }

        public static Calculadora GetInstance()
        {
            if (instance == null)
            {
                instance = new Calculadora();
            }
            return instance;
        }

        public double Somar(double a, double b)
        {
            return a + b;
        }

        public double Subtrair(double a, double b)
        {
            return a - b;
        }

        public double Multiplicar(double a, double b)
        {
            return a * b;
        }

        public double Dividir(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
        
            return a / b;

        }

        //Potencia
        public double Potencia(double a, double b)
        {
            return Math.Pow(a, b);
        }

        //Raiz quadrada
        public double RaizQuadrada(double a)
        {
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), "Numero negativo ou menor que 0");
            }

            return Math.Sqrt(a);
        }

        //Raiz cúbica
        public double RaizCubica(double a)
        {
            return Math.Pow(a, 1.0 / 3.0);
        }

        //Fatorial por recursão
        public double Fatorial(double a)
        {
            if (a == 0)
            {
                return 1;
            }
            return a * Fatorial(a - 1);
        }

        //Potencia de 3
        public double PotenciaDe3(double a)
        {
            return Math.Pow(a, 3);
        }

        //lista dos n primeiros números primos
        public List<int> ListaPrimos(int n)
        {
            List<int> primos = new List<int>();
            int i = 2;
            while (primos.Count < n)
            {
                if (EhPrimo(i))
                {
                    primos.Add(i);
                }
                i++;
            }
            return primos;
        }

        //EhPrimo
        public bool EhPrimo(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            if (n == 2)
            {
                return true;
            }
            if (n % 2 == 0)
            {
                return false;
            }
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
