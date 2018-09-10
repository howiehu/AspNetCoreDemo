using System;
using AspNetCoreDemo.WebApi;
using AspNetCoreDemo.WebApi.Configurations;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AspNetCoreDemo.E2ETests
{
    public abstract class ApiTestBase : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        internal readonly TestWebApplicationFactory<Startup> _factory;

        internal ApiTestBase(TestWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        internal WebApplicationFactory<Startup> InitializeDbForTest(Action<DemoContext> dbContextActions)
        {
            return _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(async services =>
                {
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