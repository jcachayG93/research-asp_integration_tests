namespace ExampleApi.Domain;

/// <summary>
/// A shipment for some product
/// </summary>
public class Shipment
{
    public required Guid Id { get; init; }

    public required Guid ForOrderId { get; init; }
}