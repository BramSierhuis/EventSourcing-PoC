using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Messages.Commands;
using WidgetAndCo.Models;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Services;

namespace WidgetAndCo.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;
    
    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Create([FromBody] CreateProductRequest request)
    {
        var command = new CreateProduct()
        {
            ProductName = request.ProductName,
            Price = request.Price
        };

        await _productService.Handle(command);
    }
    
    [HttpPut("{productId:guid}/productName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ChangeProductName(Guid productId, [FromBody] ChangeProductNameRequest request)
    {
        var command = new ChangeProductName()
        {
            ProductId = productId,
            ProductName = request.ProductName,
        };

        await _productService.Handle(command);
    }
    
    [HttpPut("{productId:guid}/price")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ChangeProductCost(Guid productId, [FromBody] ChangeProductCostRequest request)
    {
        var command = new ChangeProductCost()
        {
            ProductId = productId,
            Price = request.Price
        };

        await _productService.Handle(command);
    }
}