using System;
using AspNetCoreDemo.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AspNetCoreDemo.IntegrationTests.Controllers
{
    public abstract class ControllerTestBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        internal readonly WebApplicationFactory<Startup> _factory;

        internal ControllerTestBase(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        internal WebApplicationFactory<Startup> RegisterMockComponents(Action<IServiceCollection> serviceCollection)
        {
            return _factory.WithWebHostBuilder(builder => { builder.ConfigureTestServices(serviceCollection); });
        }
    }
}