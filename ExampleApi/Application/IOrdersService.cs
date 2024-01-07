namespace ExampleApi.Application;

public interface IOrdersService
{
    /// <summary>
    /// Creates an order
    /// </summary>
    /// <param name="orderId"></param>
    void CreateOrder(Guid orderId);

    /// <summary>
    /// Deletes an order
    /// </summary>
    void DeleteOrder(Guid orderId);
}