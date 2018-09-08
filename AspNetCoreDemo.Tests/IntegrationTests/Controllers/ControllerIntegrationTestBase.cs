using AspNetCoreDemo.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AspNetCoreDemo.Tests.IntegrationTests.Controllers
{
    public abstract class ControllerIntegrationTestBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        internal readonly WebApplicationFactory<Startup> _factory;

        internal ControllerIntegrationTestBase(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
    }
}