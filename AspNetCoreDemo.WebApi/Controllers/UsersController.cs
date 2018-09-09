using System.Threading.Tasks;
using AspNetCoreDemo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.WebApi.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            return new JsonResult(await _userRepository.FindAll());
        }
    }
}