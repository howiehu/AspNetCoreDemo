using System;
using AspNetCoreDemo.WebApi;
using AspNetCoreDemo.WebApi.Configurations;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AspNetCoreDemo.E2ETests
{
    public abstract class ApiTestBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        internal readonly WebApplicationFactory<Startup> _factory;

        internal ApiTestBase(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        internal WebApplicationFactory<Startup> InitializeDbForTest(Action<DemoContext> dbContextActions)
        {
            return _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(async services =>
                {
                    var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();
                    
                    services.AddDbContext<DemoContext>(options => 
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.UseInternalServiceProvider(serviceProvider);
                    });
                    
                    var sc = services.BuildServiceProvider();

                    using (var scope = sc.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var context = scopedServices.GetRequiredService<DemoContext>();
                        
                        await context.Database.EnsureCreatedAsync();

                        dbContextActions(context);
                        await context.SaveChangesAsync();
                    }
                });
            });
        }
    }
}