# About
This is a tutorial on how to use Integration / End-to-end testing In ASP.net Core

## Technologies
Net 8

## How to Run
### Make sure you have net 8 installed
> dotnet --list-sdks
If you don't have it, install it from [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Clone and run this repo
First, Clone the repo
You can run and test using the Dotnet CLI or tools in your IDE (Visual Studio, Rider, etc)

To use the CLI:
Open a terminal (like Powershell) and go to the same folder were the Solution is created (Rd_Asp_IntegrationTests.sln)

To run:
> dotnet run

#### To run, in the root (same folder as ExampleApi.csproj), run this:
> dotnet run --project ExampleApi
#### To test:
> dotnet test

## Follow the tutorial
### Delete the test project
Delete the **ExampleApi.e2e.test.csproj** project and all its files

### Follow along the tutorial in the WIKI
[Wiki](https://github.com/jcachayG93/research-asp_integration_tests/wiki)

# About the Example Api Application
This is intended to present the context of the application being tested.
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

