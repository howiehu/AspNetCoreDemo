using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi;
using AspNetCoreDemo.WebApi.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AspNetCoreDemo.E2ETests
{
    public class UsersApiTest : ApiTestBase
    {
        public UsersApiTest(TestWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GET_users_return_users_when_has_been_called()
        {
            var client = InitializeDbForTest(context => context.User.Add(new User("Alex", new DateTime(1984, 6, 24))))
                .CreateClient();

            var response = await client.GetAsync("/users");
            
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Application.Json);
                response.Content.Headers.ContentType.CharSet.Should().Be(Encoding.UTF8.HeaderName);
                response.Content.ReadAsAsync<List<User>>().Result
                    .Should().ContainSingle(user => user.Name.Equals("Alex"));
            }
        }
    }
}