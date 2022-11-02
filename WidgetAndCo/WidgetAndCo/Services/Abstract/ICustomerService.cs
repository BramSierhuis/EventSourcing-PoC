using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests.Customers;

namespace WidgetAndCo.Services.Abstract;

public interface ICustomerService
{
    Task CreateCustomer(CreateCustomerRequest request);
    Task ChangeFirstName(ChangeFirstNameRequest request, Guid customerId);
    Task ChangeLastName(ChangeLastNameRequest request, Guid customerId);
    Task<IEnumerable<CustomerReadModel>> GetAll();
    Task<CustomerReadModel> GetById(Guid customerId);
}