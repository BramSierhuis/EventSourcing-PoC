using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Models;
using WidgetAndCo.Models.Commands.Orders;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Services;

namespace WidgetAndCo.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;
    
    public OrderController(ILogger<OrderController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Create([FromBody] CreateOrderRequest request)
    {
        var command = new CreateOrder()
        {
            CustomerId = request.CustomerId,
            OrderItems = request.OrderItems,
            OrderDate = DateTime.Now,
        };

        await _orderService.Handle(command);
    }
    
    [HttpPost("{orderId:guid}/ship")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ShipOrder(Guid orderId)
    {
        var command = new ShipOrder()
        {
            AggregateId = orderId,
        };

        await _orderService.Handle(command);
    }
}