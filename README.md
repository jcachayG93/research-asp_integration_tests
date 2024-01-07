# What will we do
Use integration tests to verify two different entities are synchronized via a 
mechanism like Integration Events. These tests will be running against the real API from an external test project.

## About the Example Api Application
There are two entities:

### Order
Some customer placed an order for something (details irrelevant)

### Shipment
Somehow, the order results in a shipment, but, they do not belong to the same
bounded context.

### Integration
So, in this example, the shipments and orders must be synchronized,
following these rules:

> When an order is created, a shipment is also created.

> When an order is deleted, a shipment is also deleted.

### Endpoints
| API                   | Verb   | Description                                                      | Request body             | Response                                               |
|-----------------------|--------|------------------------------------------------------------------|--------------------------|--------------------------------------------------------|
| api/ping              | GET    | Used to verify the API is working                                | None                     | Ok / "Pong"                                            |
| api/create-order      | POST   | Creates an order, which has a side effect of creating a shipment | {<br/>&nbsp;OrderId:guid<br/>} | Ok                                                     |
| api/delete-order      | DELETE | Deletes an order, which has a side effect of deleting a shipment | {<br/>&nbsp;OrderId:guid<br/>} | Ok                                                     |
| api/get-all-shipments | GET    | Gets all shipments                                               | None                     | [<br/>&nbsp;{<br/>&nbsp;&nbsp;id:guid, <br/>&nbsp;&nbsp;forOrderId:guid<br/>&nbsp;}<br/>] |

