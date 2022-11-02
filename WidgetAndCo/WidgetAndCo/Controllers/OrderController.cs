using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Exceptions;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Models.Requests.Orders;
using WidgetAndCo.Services;
using WidgetAndCo.Services.Abstract;

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
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrderReadModel>>> GetAll()
    {
        return Ok(await _orderService.GetAll());
    }
    
    [HttpGet("{orderId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrderReadModel>>> GetById(Guid orderId)
    {
        return Ok(await _orderService.GetById(orderId));
    }
    
    [HttpGet("{orderId:guid}/shippingTime")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrderShippingTimeReadModel>> GetShippingTimeForOrder(Guid orderId)
    {
        return Ok(await _orderService.GetShippingTimeForOrder(orderId));
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