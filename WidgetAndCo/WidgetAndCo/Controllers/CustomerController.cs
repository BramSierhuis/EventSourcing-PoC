using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Models.Requests.Customers;
using WidgetAndCo.Services;
using WidgetAndCo.Services.Abstract;

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
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CustomerReadModel>>> GetAll()
    {
        return Ok(await _customerService.GetAll());
    }
    
    [HttpGet("{customerId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CustomerReadModel>> GetById(Guid customerId)
    {
        return Ok(await _customerService.GetById(customerId));
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