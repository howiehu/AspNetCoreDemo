using AspNetCoreDemo.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
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
    }
}