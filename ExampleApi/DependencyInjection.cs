using ExampleApi.Application;

namespace ExampleApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        /*
         * Scoped life-time: Uses the same instance of InMemoryRepository for every object that was instantiated
         * for a single controller end-point request. This way, several classes can inject the IRepository in the
         * context of the same request, and therefore, share the same instance (which contains the same data in memory)
         */
        services.AddScoped<IRepository, InMemoryRepository>();
        services.AddScoped<IOrderShipmentService, OrderShipmentService>();

        return services;
    }
}