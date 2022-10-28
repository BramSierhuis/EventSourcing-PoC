using Microsoft.AspNetCore.Mvc;
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
        await _orderService.CreateOrder(request);
    }
    
    [HttpPost("{orderId:guid}/ship")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ShipOrder(Guid orderId)
    {
        await _orderService.ShipOrder(orderId);
    }
}