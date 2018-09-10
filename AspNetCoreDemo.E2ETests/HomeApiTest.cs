using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AspNetCoreDemo.E2ETests
{
    public class HomeApiTest : ApiTestBase
    {
        public HomeApiTest(TestWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GET_users_return_users_when_has_been_called()
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