using Xunit;
using Microsoft.AspNetCore.Mvc;
using API_Two.Controllers;
using API_Two.Models;
using API_Two.Context;
using API_Two;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace TestUnit_API_Two
{
    public class ContatoControllerTeste : IDisposable
    {
        private readonly ContatoController _controller;
        private readonly MyContext _context;

        public ContatoControllerTeste()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(databaseName: "ContatoTestDatabase")
                .Options;

            _context = new MyContext(options);
            _controller = new ContatoController(_context);
        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted(); // Limpa o banco de dados após cada teste
            _context.Dispose();
        }

        [Fact]
        public void GetByCPF_DeveRetornarOk_ContatoExiste()
        {
            // Arrange
            var contato = new Contato("111.444.777-09", "Contato Teste1", "contatoTeste1@teste.com", "9988-0123", "Rua Teste1");
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            // Act
            var result = _controller.GetByCPF(contato.CPF);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedContato = Assert.IsType<Contato>(okResult.Value);
            Assert.Equal(contato.CPF, returnedContato.CPF);
        }

        [Fact]
        public void GetByCPF_ShouldReturnNotFoundResult_WhenContatoDoesNotExist()
        {
            // Act
            var result = _controller.GetByCPF("non-existing-cpf");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetByName_ShouldReturnOkResult_WhenContatoExists()
        {
            // Arrange
            var contato = new Contato("123.456.789-07", "Contato 7", "contato7@teste.com", "9988-0123", "Rua 7");
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            // Act
            var result = _controller.GetByName(contato.Nome);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedContato = Assert.IsType<Contato>(okResult.Value);
            Assert.Equal(contato.Nome, returnedContato.Nome);
        }

        [Fact]
        public void GetByName_ShouldReturnNotFoundResult_WhenContatoDoesNotExist()
        {
            // Act
            var result = _controller.GetByName("non-existing-name");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}


//[Fact]
//public async Task GetFatorial_DeveRetornarOk()
//{
//    // Act
//    var response = await _client.GetAsync("/Home/GetFatorial/5");

//    // Assert
//    response.EnsureSuccessStatusCode(); // Verifica se o status da resposta é 2xx
//    Assert.Equal("application/json; charset=utf-8",
//        response.Content.Headers.ContentType.ToString());
//}

//[Fact]
//public async Task GetFatorial_DeveRetornarFatorialCorreto()
//{
//    // Act
//    var response = await _client.GetAsync("/Home/GetFatorial/5");
//    var content = await response.Content.ReadAsStringAsync();

//    // Assert
//    response.EnsureSuccessStatusCode();
//    Assert.Contains("\"Resultado\":120", content); // Verifica se o resultado esperado está presente
//}

//[Fact]
//public async Task GetFibonacci_DeveRetornarOk()
//{
//    // Act
//    var response = await _client.GetAsync("/Home/GetFibonacci/7");

//    // Assert
//    response.EnsureSuccessStatusCode();
//    Assert.Equal("application/json; charset=utf-8",
//        response.Content.Headers.ContentType.ToString());
//}

//[Fact]
//public async Task GetFibonacci_DeveRetornarFibonacciCorreto()
//{
//    // Act
//    var response = await _client.GetAsync("/Home/GetFibonacci/7");
//    var content = await response.Content.ReadAsStringAsync();

//    // Assert
//    response.EnsureSuccessStatusCode();
//    Assert.Contains("\"Resultado\":13", content); // Verifica se o resultado esperado está presente
//}