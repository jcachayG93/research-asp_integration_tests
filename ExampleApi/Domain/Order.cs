namespace ExampleApi.Domain;

/// <summary>
/// An order for some product (details irrelevant to this project)
/// </summary>
public class Order
{
    /*
     * Not a real domain entity. A real one would be well encapsulated with several features. This one is
     * just to demo the Integration Tests explained in this project.
     */

    public required Guid Id { get; init; }
    
}