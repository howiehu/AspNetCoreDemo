using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AspNetCoreDemo.IntegrationTests.Controllers
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

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(MediaTypeNames.Application.Json, response.Content.Headers.ContentType.MediaType);
            Assert.Equal(Encoding.UTF8.HeaderName, response.Content.Headers.ContentType.CharSet);
            Assert.Equal("Hello World!", response.Content.ReadAsAsync<string>().Result);
        }
    }
}