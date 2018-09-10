using System;
using AspNetCoreDemo.WebApi;
using AspNetCoreDemo.WebApi.Configurations;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
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
                builder.ConfigureTestServices(async services =>
                {
                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var context = scopedServices.GetRequiredService<DemoContext>();

                        dbContextActions(context);
                        await context.SaveChangesAsync();
                    }
                });
            });
        }
    }
}