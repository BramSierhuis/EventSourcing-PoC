using WidgetAndCo.Models.Requests;

namespace WidgetAndCo.Services;

public interface ICustomerService
{
    Task CreateCustomer(CreateCustomerRequest request);
    Task ChangeFirstName(ChangeFirstNameRequest request, Guid customerId);
    Task ChangeLastName(ChangeLastNameRequest request, Guid customerId);
}