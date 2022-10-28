using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Messages.Commands;
using WidgetAndCo.Models;
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
        var createCustomer = new CreateCustomer()
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        await _customerService.Handle(createCustomer);
    }
    
    [HttpPut("{customerId:guid}/firstname")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ChangeFirstName(Guid customerId, [FromBody] ChangeFirstNameRequest request)
    {
        var command = new ChangeCustomerFirstName()
        {
            CustomerId = customerId,
            FirstName = request.FirstName
        };

        await _customerService.Handle(command);
    }
    
    [HttpPut("{customerId:guid}/lastname")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task ChangeLastName(Guid customerId, [FromBody] ChangeLastNameRequest request)
    {
        var command = new ChangeCustomerLastName()
        {
            CustomerId = customerId,
            LastName = request.LastName
        };

        await _customerService.Handle(command);
    }
}