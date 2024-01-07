using System.Text.Json;
using ExampleApi.Domain;

namespace ExampleApi.Application;

public class InMemoryRepository : IRepository
{
    private Dictionary<Guid, string> _data;

    public InMemoryRepository()
    {
        _data = new();
    }

    private void WriteRaw<T>(Guid key, T entity)
    {
        var json = JsonSerializer.Serialize(entity);
        if (!_data.TryAdd(key, json))
        {
            _data[key] = json;
        }
    }

    private T? ReadRaw<T>(Guid key)
    {
        if (_data.TryGetValue(key, out var json))
        {
            var payload = JsonSerializer.Deserialize<T>(json);
            return payload;
        }

        return default;
    }

    private void Remove(Guid key)
    {
        _data.Remove(key);
    }

    public void UpsertOrder(Order order)
    {
        WriteRaw(order.Id, order);
    }

    public void UpsertShipment(Shipment shipment)
    {
        WriteRaw(shipment.Id, shipment);
    }

    public void DeleteOrder(Guid id)
    {
        Remove(id);
    }

    public void DeleteShipmentByOrderId(Guid orderId)
    {
        var keys = _data.Select(x => x.Key).ToArray();

        foreach (var k in keys)
        {
            var item = ReadRaw<Shipment>(k);
            if (item is not null && item.ForOrderId == orderId)
            {
                Remove(item.Id);
                break;
            }
        }
    }
}