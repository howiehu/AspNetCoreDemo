using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi;
using AspNetCoreDemo.WebApi.Models;
using Xunit;

namespace AspNetCoreDemo.E2ETests
{
    public class UsersApiTest : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private readonly TestWebApplicationFactory<Startup> _factory;

        public UsersApiTest(TestWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task GET_users_return_users_when_has_been_called()
        {
//            var expectedUsers = new List<User>
//            {
//                new User("Alex", new DateTime(1984, 6, 24))
//            };
//
//            var mockUserRepository = new Mock<UserRepository>(null);
//            mockUserRepository.Setup(repository => repository.FindAll()).ReturnsAsync(expectedUsers);

            var client = _factory.CreateClient();

            var response = await client.GetAsync("/users");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(MediaTypeNames.Application.Json, response.Content.Headers.ContentType.MediaType);
            Assert.Equal(Encoding.UTF8.HeaderName, response.Content.Headers.ContentType.CharSet);
            
            var actualUsers = response.Content.ReadAsAsync<List<User>>().Result;
            Assert.Empty(actualUsers);
        }
    }
}