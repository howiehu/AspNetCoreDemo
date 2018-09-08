using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AspNetCoreDemo.Tests.IntegrationTests.Controllers
{
    public class HomeControllerIntegrationTest: ControllerIntegrationTestBase
    {
        public HomeControllerIntegrationTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Index_return_correct_message_when_call()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/");

            response.EnsureSuccessStatusCode();
            Assert.Equal("Hello World!", response.Content.ReadAsAsync<string>().Result);
        }
    }
}