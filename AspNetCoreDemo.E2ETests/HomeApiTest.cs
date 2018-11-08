using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi;
using FluentAssertions;
using FluentAssertions.Execution;
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

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Plain);
                response.Content.Headers.ContentType.CharSet.Should().Be(Encoding.UTF8.HeaderName);
                response.Content.ReadAsStringAsync().Result.Should().Be("Hello World!");
            }
        }
    }
}