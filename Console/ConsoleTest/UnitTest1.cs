using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using Xunit;
using MyGenerator;

namespace ConsoleTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestCPFGeneration()
        {
            var result = MyGenerator.Program.GetCPF();

            Assert.NotNull(result);

            var cpf = result.GetType().GetProperty("CPF").GetValue(result, null) as string;
            Assert.NotNull(cpf);
            Assert.Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", cpf); // Verifica o formato do CPF
        }

        [Fact]
        public void TestCNPJGeneration()
        {
            var result = MyGenerator.Program.GetCNPJ();

            Assert.NotNull(result);

            var cnpj = result.GetType().GetProperty("CNPJ").GetValue(result, null) as string;
            Assert.NotNull(cnpj);
            Assert.Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", cnpj); // Verifica o formato do CNPJ
        }

        [Fact]
        public void TestPasswordGeneration()
        {
            var result = MyGenerator.Program.GetSENHA();

            Assert.NotNull(result);

            var senha = result.GetType().GetProperty("SENHA").GetValue(result, null) as string;
            Assert.NotNull(senha);
            Assert.Equal(16, senha.Length); // Verifica se a senha tem 16 caracteres

            // Verifica se a senha contém pelo menos uma letra maiúscula, uma minúscula, um número e um caractere especial
            Assert.Matches(@"[A-Z]", senha);
            Assert.Matches(@"[a-z]", senha);
            Assert.Matches(@"\d", senha);
            Assert.Matches(@"[!@#$%^&*()\-_=+\[\]{}|;:,.<>?]", senha);
        }

        [Fact]
        public void TestGUIDGeneration()
        {
            var result = MyGenerator.Program.GetGUID();

            Assert.NotNull(result);

            var guid = result.GetType().GetProperty("GUID").GetValue(result, null) as string;
            Assert.NotNull(guid);
            Assert.Matches(@"^[\da-f]{8}-([\da-f]{4}-){3}[\da-f]{12}$", guid); // Verifica o formato do GUID
        }
    }
}