using CommandHandler.Repositories;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models;
using WidgetAndCo.Models.Commands;

namespace CommandHandler.Services;

public class CustomerService : ICustomerService
{
    private readonly IAggregateStore<CustomerAggregate> _store;

    public CustomerService(IAggregateStore<CustomerAggregate> store)
    {
        _store = store;
    }

    public async Task Handle(object command) => await Handle((dynamic)command);

    private async Task Handle(CreateCustomer cmd)
    {
        var customer = new CustomerAggregate(cmd);

        await _store.Save(customer);
    }

    private async Task Handle(ChangeCustomerFirstName cmd)
    {
        var customer = await _store.Load(cmd.AggregateId);

        customer.Handle(cmd);
        
        await _store.Save(customer);
    }
    private async Task Handle(ChangeCustomerLastName cmd)
    {
        var customer = await _store.Load(cmd.AggregateId);

        customer.Handle(cmd);
        
        await _store.Save(customer);
    }
}