using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ExampleApi.e2e.tests.TestCommon;

public class CustomApplicationFactory
: WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // This is were we can do more advanced things like:
        /*
         * Get services from the DI Container
         * Set environments
         * Set environment variables
         * Etc.
         */
        base.ConfigureWebHost(builder);
    }
}