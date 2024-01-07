using ExampleApi.Domain;

namespace ExampleApi.Application;

/// <summary>
/// Queries the underlying storage technology
/// </summary>
public interface IShipmentsQueryService
{
    /// <summary>
    /// Gets all shipments
    /// </summary>
    /// <returns></returns>
    IEnumerable<Shipment> GetAllShipments();
}