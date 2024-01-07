using ExampleApi.Domain;

namespace ExampleApi.Application;

public class OrdersService : IOrdersService
{
    private readonly IRepository _repository;
    private readonly IOrderShipmentIntegrationService _integrationService;

    public OrdersService(
        IRepository repository, 
        IOrderShipmentIntegrationService integrationService)
    {
        _repository = repository;
        _integrationService = integrationService;
    }
    
    public void CreateOrder(Guid orderId)
    {
        var order = new Order
        {
            Id = orderId
        };
        _repository.UpsertOrder(order);
        _integrationService.OnOrderCreated_CreateShipment(order.Id);
    }

    public void DeleteOrder(Guid orderId)
    {
        _repository.DeleteOrder(orderId);
        _integrationService.OnOrderDeleted_DeleteShipment(orderId);
    }
}