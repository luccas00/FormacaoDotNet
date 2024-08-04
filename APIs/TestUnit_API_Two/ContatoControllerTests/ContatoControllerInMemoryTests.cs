using API_Two.Context;
using API_Two.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Two.Controllers;

namespace TestUnit_API_Two.ContatoControllerTests
{
    public class ContatoControllerInMemoryTests
    {
        private readonly ContatoController _controller;
        private readonly MyContext _context;

        public ContatoControllerInMemoryTests()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(databaseName: "ContatoTestDatabase")
                .Options;

            _context = new MyContext(options);
            _controller = new ContatoController(_context);
        }

        [Fact]
        public void GetByCPF_ShouldReturnOk_WhenContatoExists()
        {
            // Arrange
            var contato = new Contato("111.444.777-09", "Contato Teste", "contato@teste.com", "9988-0123", "Rua Teste");
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
        public void GetByCPF_ShouldReturnNotFound_WhenContatoDoesNotExist()
        {
            // Act
            var result = _controller.GetByCPF("non-existing-cpf");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // Adicione outros testes conforme necessário
    }
}