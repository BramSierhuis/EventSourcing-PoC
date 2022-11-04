using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Models.Requests.Customers;

namespace WidgetAndCo.Services.Abstract;

public interface ICustomerService : IService<CustomerReadModel>
{
    Task CreateCustomer(CreateCustomerRequest request);
    Task ChangeFirstName(ChangeFirstNameRequest request, Guid customerId);
    Task ChangeLastName(ChangeLastNameRequest request, Guid customerId);
}