using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestUnit_API_Two.ContatoControllerTests
{
    public class ContatoControllerIntegrationTests : IClassFixture<WebApplicationFactory<API_Two.Program>>
    {
        private readonly HttpClient _client;

        public ContatoControllerIntegrationTests(WebApplicationFactory<API_Two.Program> factory)
        {
            _client = factory.CreateClient();
        }

    }
}
