using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi.Controllers;
using AspNetCoreDemo.WebApi.Models;
using AspNetCoreDemo.WebApi.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace AspNetCoreDemo.UnitTests.Controllers
{
    public class UsersControllerTest
    {
        [Fact]
        public async Task Index_return_users_when_has_been_called()
        {
            var mockUserRepository = new Mock<UserRepository>(null);
            var expectedUsers = new List<User>();
            mockUserRepository.Setup(repository => repository.FindAll()).ReturnsAsync(expectedUsers);
            var controller = new UsersController(mockUserRepository.Object);

            var result = await controller.Index();

            result.Should().BeSameAs(expectedUsers);
        }
    }
}