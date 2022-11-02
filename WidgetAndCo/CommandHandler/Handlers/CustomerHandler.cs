using CommandHandler.Handlers.Abstract;
using CommandHandler.Repositories.Abstract;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models.Commands;
using WidgetAndCo.Models.Commands.Customers;

namespace CommandHandler.Handlers;

public class CustomerHandler : ICustomerHandler
{
    private readonly IAggregateStore<CustomerAggregate> _store;

    public CustomerHandler(IAggregateStore<CustomerAggregate> store)
    {
        _store = store;
    }

    public async Task Handle(object command) => await Process((dynamic)command);

    private async Task Process(CreateCustomer cmd)
    {
        var customer = new CustomerAggregate(cmd);

        await _store.Save(customer);
    }

    private async Task Process(ChangeCustomerFirstName cmd)
    {
        var customer = await _store.Load(cmd.AggregateId);

        customer.Handle(cmd);
        
        await _store.Save(customer);
    }
    private async Task Process(ChangeCustomerLastName cmd)
    {
        var customer = await _store.Load(cmd.AggregateId);

        customer.Handle(cmd);
        
        await _store.Save(customer);
    }
}