namespace ExampleApi.Application;

/// <summary>
/// This is not an integration events mechanism, but for the purpose of this project, works like it.
/// </summary>
public interface IOrderShipmentIntegrationService
{
    /*
     * In a real scenario, you would publish an integration event and this will be handled some were else in the system.
     * This one hard-codes that integration.
     */

    /// <summary>
    /// When you create an order, call this so It can also create a shipment
    /// </summary>
    void OnOrderCreated_CreateShipment(Guid orderId);

    /// <summary>
    /// When you delete an order, call this so It can also delete the associated shipment.
    /// </summary>
    void OnOrderDeleted_DeleteShipment(Guid orderId);
}