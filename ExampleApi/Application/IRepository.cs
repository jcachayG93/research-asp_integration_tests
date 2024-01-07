using ExampleApi.Domain;

namespace ExampleApi.Application;

/// <summary>
/// Abstracts the underlying data storage technology
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Upserts (inserts or replaces) an Order
    /// </summary>
    void UpsertOrder(Order order);
    
    /// <summary>
    /// Upserts (inserts or replaces) a Shipment
    /// </summary>
    void UpsertShipment(Shipment shipment);
    
    /// <summary>
    /// Deletes an Order
    /// </summary>
    void DeleteOrder(Guid id);
    
    /// <summary>
    /// Deletes a Shipment
    /// </summary>
    void DeleteShipmentByOrderId(Guid orderId);

    /// <summary>
    /// Gets all items for a given type
    /// </summary>
    IEnumerable<T> GetAll<T>();
}