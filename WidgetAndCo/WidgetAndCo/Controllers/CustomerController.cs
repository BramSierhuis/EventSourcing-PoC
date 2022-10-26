using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Messages.Commands;
using WidgetAndCo.Services;

namespace WidgetAndCo.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IService _customerService;
    
    public CustomerController(ILogger<CustomerController> logger, IService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }
    
    [HttpPost(Name = "Post")]
    public async Task Post()
    {
        var createCustomer = new CreateCustomer()
        {
            FirstName = "bram",
            LastName = "Sierhuis"
        };

        await _customerService.Handle(createCustomer);
    }
    
    [HttpGet(Name = "Get")]
    public async Task Get()
    {
        await _customerService.TestLoad();
    }
}