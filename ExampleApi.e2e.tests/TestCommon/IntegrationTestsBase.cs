using Microsoft.Extensions.DependencyInjection;

namespace ExampleApi.e2e.tests.TestCommon;

public abstract class IntegrationTestsBase : IDisposable
{
    /*
     * This is a mechanism to easily skip/run integration tests.
     * To Skip, COMMENT the first line, UNCOMMENT the second one.
     * To Run, UNCOMMENT the first line, COMMENT the second one.
     * If you look at the tests, they have the Fact attribute like this: [Fact(Skip = IntegrationTestsBase.SKIP_INTEGRATION_TESTS)]
     */
    public const string? SKIP_INTEGRATION_TESTS = null;
    //public const string? SKIP_INTEGRATION_TESTS = "Integration tests are off.";

    private readonly CustomApplicationFactory _applicationFactory;

    public HttpClient Client { get; }

    protected IntegrationTestsBase()
    {
        _applicationFactory = new CustomApplicationFactory();

        Client = _applicationFactory.CreateClient();
        
    }
    
    /// <summary>
    /// Allows extracting a service from the DI Container
    /// </summary>
    protected IServiceScope GetService<TService>(out TService? service)
    {
        var scope = _applicationFactory.Services.CreateScope();

        service = scope.ServiceProvider.GetService<TService>();

        return scope;
    }
    
    public void Dispose()
    {
        // In a real project, here I would drop or delete the database (so each test can start with a clean instance)
    }
}