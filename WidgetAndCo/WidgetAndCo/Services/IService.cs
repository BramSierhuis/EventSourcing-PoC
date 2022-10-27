using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Models;

namespace WidgetAndCo.Services;

public interface IService
{
    Task Handle(object command);
    Task<ActionResult<CustomerDto>> GetByIdAsync(Guid customerId);
}