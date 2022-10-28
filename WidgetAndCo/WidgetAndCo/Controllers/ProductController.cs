using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Models;
using WidgetAndCo.Models.Commands;
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
        await _productService.CreateProduct(request);
    }
    
    [HttpPut("{productId:guid}/productName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ChangeProductName(Guid productId, [FromBody] ChangeProductNameRequest request)
    {
        await _productService.ChangeProductName(request, productId);
    }
    
    [HttpPut("{productId:guid}/price")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ChangeProductCost(Guid productId, [FromBody] ChangeProductCostRequest request)
    {
        await _productService.ChangeProductCost(request, productId);
    }
}