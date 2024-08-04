using Xunit;
using Microsoft.AspNetCore.Mvc;
using API_Two.Controllers;
using API_Two.Models;
using API_Two.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestUnit_API_Two
{
    public class ContatoControllerTests : IDisposable
    {
        private readonly ContatoController _controller;
        private readonly MyContext _context;

        public ContatoControllerTests()
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
        public void GetByCPF_ShouldReturnOkResult_WhenContatoExists()
        {
            // Arrange
            var contato = new Contato("123.456.789-06", "Contato 6", "contato6@teste.com", "9988-0123", "Rua 6");
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
