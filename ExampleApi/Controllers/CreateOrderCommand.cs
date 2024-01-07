namespace ExampleApi.Controllers;

public class CreateOrderCommand
{
    public required Guid OrderId { get; init; }
}