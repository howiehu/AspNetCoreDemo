using System;
using System.Threading.Tasks;
using AspNetCoreDemo.WebApi.Configurations;
using AspNetCoreDemo.WebApi.Models;
using AspNetCoreDemo.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AspNetCoreDemo.IntegrationTests.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public async Task FindAll_return_expected_users_when_called()
        {
            var options = new DbContextOptionsBuilder<DemoContext>()
                .UseInMemoryDatabase(databaseName: "find_all_users")
                .Options;

            using (var context = new DemoContext(options))
            {
                context.Add(new User("Alex", new DateTime(1984, 06, 24)));
                await context.SaveChangesAsync();
            }

            using (var context = new DemoContext(options))
            {
                var repository = new UserRepository(context);

                var users = await repository.FindAll();

                Assert.Equal(1, users.Count);
                Assert.Contains(users, user => user.Name.Equals("Alex"));
            }
        }
    }
}