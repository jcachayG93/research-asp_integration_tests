using ExampleApi.Application;
using ExampleApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers;

[ApiController]
[Route("api")]
public class ApplicationController : ControllerBase
{
    private readonly IOrdersService _ordersService;
    private readonly IShipmentsQueryService _shipmentsQueryService;

    public ApplicationController(
        IOrdersService ordersService,
        IShipmentsQueryService shipmentsQueryService
        )
    {
        _ordersService = ordersService;
        _shipmentsQueryService = shipmentsQueryService;
    }
    
    [HttpGet("ping")]
    public ActionResult Ping()
    {
        return Ok("Pong");
    }

    [HttpPost("create-order")]
    public ActionResult CreateOrder(CreateOrderCommand command)
    {
        _ordersService.CreateOrder(command.OrderId);
        return Ok();
    }

    [HttpDelete("delete-order")]
    public ActionResult DeleteOrder(DeleteOrderCommand command)
    {
        _ordersService.DeleteOrder(command.OrderId);
        return Ok();
    }
    
    /*
     * In a real app, you would never expose an entity in a controller, you would map it to a view-model instead. But
     * this app is intended to show how to make integration tests.
     */
    [HttpGet("get-all-shipments")]
    public ActionResult<IEnumerable<Shipment>> GetShipments()
    {
        return Ok(_shipmentsQueryService.GetAllShipments());
    }

}