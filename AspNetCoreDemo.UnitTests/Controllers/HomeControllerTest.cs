using AspNetCoreDemo.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AspNetCoreDemo.UnitTests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_return_correct_message_when_has_been_called()
        {
            var controller = new HomeController();

            var actionResult = controller.Index();

            actionResult.Should().Be("Hello World!");
        }
    }
}