using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestUnit_API_Two.CalculadoraTests
{
    public class CalculadoraControllerIntegrationTests : IClassFixture<WebApplicationFactory<API_Two.Program>>
    {
        private readonly HttpClient _client;

        public CalculadoraControllerIntegrationTests(WebApplicationFactory<API_Two.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData(3, 2)]
        public async Task SomaCorreta(double a, double b)
        {
            var response = await _client.GetAsync($"/Calculadora/Somar/{a}/{b}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Response Content: {content}");

            var json = JObject.Parse(content);

            Assert.NotNull(json["resultado"]);
            Assert.Equal(a + b, json["resultado"].ToObject<double>(), 5); // Considerando precisão decimal
        }

        [Theory]
        [InlineData(5, 3)]
        public async Task Subtract_ReturnsCorrectResult(double a, double b)
        {
            var response = await _client.GetAsync($"/Calculadora/Subtrair/{a}/{b}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Subtract Response Content: {content}");

            var json = JObject.Parse(content);

            Assert.NotNull(json["resultado"]);
            Assert.Equal(a - b, json["resultado"].ToObject<double>(), 5); // Considerando precisão decimal
        }

        [Theory]
        [InlineData(4, 2)]
        public async Task Multiply_ReturnsCorrectResult(double a, double b)
        {
            var response = await _client.GetAsync($"/Calculadora/Multiplicar/{a}/{b}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Multiply Response Content: {content}");

            var json = JObject.Parse(content);

            Assert.NotNull(json["resultado"]);
            Assert.Equal(a * b, json["resultado"].ToObject<double>(), 5); // Considerando precisão decimal
        }

        [Theory]
        [InlineData(6, 2)]
        public async Task Divide_ReturnsCorrectResult(double a, double b)
        {
            var response = await _client.GetAsync($"/Calculadora/Dividir/{a}/{b}");
            if (b == 0)
            {
                Assert.Equal("Divisão por zero não é permitida.", await response.Content.ReadAsStringAsync());
                Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            }
            else
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Divide Response Content: {content}");

                var json = JObject.Parse(content);

                Assert.NotNull(json["resultado"]);
                Assert.Equal(a / b, json["resultado"].ToObject<double>(), 5); // Considerando precisão decimal
            }
        }

        [Theory]
        [InlineData(2, 3)]
        public async Task Power_ReturnsCorrectResult(double a, double b)
        {
            var response = await _client.GetAsync($"/Calculadora/Potencia/{a}/{b}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Power Response Content: {content}");

            var json = JObject.Parse(content);

            Assert.NotNull(json["resultado"]);
            Assert.Equal(Math.Pow(a, b), json["resultado"].ToObject<double>(), 5); // Considerando precisão decimal
        }

        [Theory]
        [InlineData(9)]
        public async Task SquareRoot_ReturnsCorrectResult(double a)
        {
            var response = await _client.GetAsync($"/Calculadora/RaizQuadrada/{a}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"SquareRoot Response Content: {content}");

            var json = JObject.Parse(content);

            Assert.NotNull(json["resultado"]);
            Assert.Equal(Math.Sqrt(a), json["resultado"].ToObject<double>(), 5); // Considerando precisão decimal
        }

        [Theory]
        [InlineData(27)]
        public async Task CubicRoot_ReturnsCorrectResult(double a)
        {
            var response = await _client.GetAsync($"/Calculadora/RaizCubica/{a}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"CubicRoot Response Content: {content}");

            var json = JObject.Parse(content);

            Assert.NotNull(json["resultado"]);
            Assert.Equal(Math.Pow(a, 1.0 / 3.0), json["resultado"].ToObject<double>(), 5); // Considerando precisão decimal
        }

        [Theory]
        [InlineData(5)]
        public async Task Factorial_ReturnsCorrectResult(double a)
        {
            var response = await _client.GetAsync($"/Calculadora/Fatorial/{a}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Factorial Response Content: {content}");

            var json = JObject.Parse(content);

            Assert.NotNull(json["resultado"]);
            Assert.Equal(Fatorial(a), json["resultado"].ToObject<double>(), 5); // Considerando precisão decimal
        }

        private double Fatorial(double n)
        {
            if (n < 0) throw new ArgumentException("Fatorial não definido para números negativos.");
            if (n == 0) return 1;
            return n * Fatorial(n - 1);
        }


    }
}
