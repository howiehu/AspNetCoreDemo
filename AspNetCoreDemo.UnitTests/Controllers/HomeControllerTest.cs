using AspNetCoreDemo.WebApi.Controllers;
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

            var jsonResult = Assert.IsType<JsonResult>(actionResult);
            var value = Assert.IsAssignableFrom<string>(jsonResult.Value);
            Assert.Equal("Hello World!", value);
        }
    }
}