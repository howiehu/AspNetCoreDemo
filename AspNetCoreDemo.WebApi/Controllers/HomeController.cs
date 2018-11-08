using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.WebApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController: ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Hello World!";
        }
    }
}