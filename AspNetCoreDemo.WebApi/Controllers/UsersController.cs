using System.Threading.Tasks;
using AspNetCoreDemo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.WebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new JsonResult(await _userRepository.FindAll());
        }
    }
}