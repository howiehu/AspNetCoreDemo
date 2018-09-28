using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi.Models;
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
        public async Task<List<User>> Index()
        {
            return await _userRepository.FindAll();
        }
    }
}