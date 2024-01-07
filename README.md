# What will we do
Use integration tests to verify two different entities are synchronized via a 
mechanism like Integration Events.

## Entities
There are two entities:

### Order
Some customer placed an order for something (details irrelevant)

### Shipment
Somehow, the order results in a shipment, but, they do not belong to the same
bounded context.

## Integration
So, in this example, the shipments and orders must be synchronized,
following these rules:

> When an order is created, a shipment is also created.

> When an order is deleted, a shipment is also deleted.
