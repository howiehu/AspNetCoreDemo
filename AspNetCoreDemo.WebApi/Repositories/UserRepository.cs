using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi.Configurations;
using AspNetCoreDemo.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemo.WebApi.Repositories
{
    public class UserRepository
    {
        private readonly DemoContext _context;

        public UserRepository(DemoContext context)
        {
            _context = context;
        }

        public virtual async Task<List<User>> FindAll()
        {
            using (_context)
            {
                return await _context.User.ToListAsync();
            }
        }
    }
}