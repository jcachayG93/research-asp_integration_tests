using System.Net.Http.Json;
using ExampleApi.Application;
using ExampleApi.Controllers;
using ExampleApi.Domain;
using ExampleApi.e2e.tests.TestCommon;

namespace ExampleApi.e2e.tests.Controllers;

[Collection("Sequential")]
public class ApplicationControllerTests : IntegrationTestsBase
{
    [Fact(Skip = IntegrationTestsBase.SKIP_INTEGRATION_TESTS)]
    public async Task CanPing()
    {
        // ************ ARRANGE ************

        var ep = "api/ping";

        // ************ ACT ****************

        var response = await Client.GetAsync(ep);
        
        // ************ ASSERT *************
        
        Assert.True(response.IsSuccessStatusCode);

        var responseContent = await response.Content.ReadAsStringAsync();
        
        Assert.Equal("Pong", responseContent);
    }
    
    [Fact(Skip = IntegrationTestsBase.SKIP_INTEGRATION_TESTS)]
    public async Task WhenYouCreateAnOrder_ItAlsoCreatesAShipment()
    {
        // ************ ARRANGE ************

        var ep = "api/create-order";

        var payload = new CreateOrderCommand
        {
            OrderId = Guid.NewGuid()
        };

        // ************ ACT ****************

        var response = await Client.PostAsJsonAsync(ep, payload);
        
        // ************ ASSERT *************
        
        Assert.True(response.IsSuccessStatusCode);

        // Get the Repository so we can check if the Shipment was created in the database

        using var scope = GetService(out IRepository repository);

        var ordersFromDatabase = repository!.GetAll<Shipment>().ToArray();
        
        Assert.Equal(1, ordersFromDatabase.Length);

        Assert.Contains(ordersFromDatabase, x => x.ForOrderId == payload.OrderId);
    }
}
