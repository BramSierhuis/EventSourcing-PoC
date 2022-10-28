using WidgetAndCo.Functions.Repositories;
using WidgetAndCo.Messages.Events;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Projections;

public class CustomerProjection : IProjection
{
    private readonly IRepository<CustomerReadModel> _repository;

    public CustomerProjection(IRepository<CustomerReadModel> repository)
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
            Id = e.CustomerId,
            FirstName = e.FirstName,
            LastName = e.LastName
        };
        
        await _repository.AddEntity(customer);
    }

    private async Task Update(CustomerFirstNameChanged e)
    {
        await _repository.GetAndUpdateEntity(e.CustomerId, customer =>
        {
            customer.FirstName = e.FirstName;
        });
    }

    private async Task Update(CustomerLastNameChanged e)
    {
        await _repository.GetAndUpdateEntity(e.CustomerId, customer =>
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