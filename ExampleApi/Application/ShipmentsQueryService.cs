using ExampleApi.Domain;

namespace ExampleApi.Application;

public class ShipmentsQueryService : IShipmentsQueryService
{
    private readonly IRepository _repository;

    public ShipmentsQueryService(
        IRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<Shipment> GetAllShipments()
    {
        return _repository.GetAll<Shipment>();
    }
}