using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Services;

namespace WidgetAndCo.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;
    
    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Create([FromBody] CreateCustomerRequest request)
    {
        await _customerService.CreateCustomer(request);
    }
    
    [HttpPut("{customerId:guid}/firstname")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ChangeFirstName(Guid customerId, [FromBody] ChangeFirstNameRequest request)
    {
        await _customerService.ChangeFirstName(request, customerId);
    }
    
    [HttpPut("{customerId:guid}/lastname")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ChangeLastName(Guid customerId, [FromBody] ChangeLastNameRequest request)
    {
        await _customerService.ChangeLastName(request, customerId);
    }
}