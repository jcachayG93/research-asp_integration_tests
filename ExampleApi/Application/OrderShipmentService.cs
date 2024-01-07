using ExampleApi.Domain;

namespace ExampleApi.Application;

public class OrderShipmentService : IOrderShipmentService
{
    private readonly IRepository _repository;

    public OrderShipmentService(IRepository repository)
    {
        _repository = repository;
    }

    public void OnOrderCreated_CreateShipment(Guid orderId)
    {
        _repository.UpsertShipment(new Shipment
        {
            Id = Guid.NewGuid(),
            ForOrderId = orderId
        });
    }

    public void OnOrderDeleted_DeleteShipment(Guid orderId)
    {
        _repository.DeleteShipmentByOrderId(orderId);
    }
}