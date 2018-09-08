using AspNetCoreDemo.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AspNetCoreDemo.Tests.UnitTests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_return_correct_message_when_call()
        {
            var controller = new HomeController();

            var actionResult = controller.Index();

            var jsonResult = Assert.IsType<JsonResult>(actionResult);
            var value = Assert.IsAssignableFrom<string>(jsonResult.Value);
            Assert.Equal("Hello World!", value);
        }
    }
}