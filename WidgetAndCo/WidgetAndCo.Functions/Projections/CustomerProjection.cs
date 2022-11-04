using WidgetAndCo.Functions.Repositories;
using WidgetAndCo.Functions.Repositories.Abstract;
using WidgetAndCo.Models.Events;
using WidgetAndCo.Models.Events.Customers;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Projections;

public class CustomerProjection : IProjection
{
    private readonly ICustomerRepository _repository;

    public CustomerProjection(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(IEnumerable<object> events)
    {
        foreach (var e in events)
        {
            await Update((dynamic)e);
        }
    }

    private async Task Update(CustomerCreated e)
    {
        var customer = new CustomerReadModel()
        {
            Id = e.AggregateId,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email,
            ShippingAddress = e.ShippingAddress
        };
        
        await _repository.AddEntity(customer);
    }

    private async Task Update(CustomerFirstNameChanged e)
    {
        await _repository.GetAndUpdateEntity(e.AggregateId, customer =>
        {
            customer.FirstName = e.FirstName;
        });
    }

    private async Task Update(CustomerLastNameChanged e)
    {
        await _repository.GetAndUpdateEntity(e.AggregateId, customer =>
        {
            customer.LastName = e.LastName;
        });
    }
    
    //Discard any events not mapped
    private async Task Update(object e)
    {
        await Task.CompletedTask;
    }
}