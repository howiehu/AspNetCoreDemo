using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi;
using AspNetCoreDemo.WebApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AspNetCoreDemo.E2ETests
{
    public class UsersApiTest : ApiTestBase
    {
        public UsersApiTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GET_users_return_users_when_has_been_called()
        {
            var client = InitializeDbForTest(context =>
                {
                    context.User.Add(new User("Alex", new DateTime(1984, 6, 24)));
                })
                .CreateClient();

            var response = await client.GetAsync("/users");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(MediaTypeNames.Application.Json, response.Content.Headers.ContentType.MediaType);
            Assert.Equal(Encoding.UTF8.HeaderName, response.Content.Headers.ContentType.CharSet);

            var actualUsers = response.Content.ReadAsAsync<List<User>>().Result;
            Assert.Contains(actualUsers, user => user.Name.Equals("Alex"));
        }
    }
}