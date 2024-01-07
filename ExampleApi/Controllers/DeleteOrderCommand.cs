namespace ExampleApi.Controllers;

public class DeleteOrderCommand
{
    public required Guid OrderId { get; init; }
}