using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.WebApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController: ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult("Hello World!");
        }
    }
}