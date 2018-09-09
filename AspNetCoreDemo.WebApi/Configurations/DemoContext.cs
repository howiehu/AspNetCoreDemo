using AspNetCoreDemo.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemo.WebApi.Configurations
{
    public class DemoContext: DbContext
    {
        public DemoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}