using WidgetAndCo.Aggregates;
using WidgetAndCo.Messages.Commands;

namespace WidgetAndCo.Services;

public class CustomerService : IService
{
    private readonly IAggregateStore<CustomerAggregate> _store;

    public CustomerService(IAggregateStore<CustomerAggregate> store)
    {
        _store = store;
    }
    
    public async Task Handle(object command) => await Handle((dynamic)command);

    private async Task Handle(CreateCustomer cmd)
    {
        //TODO: Implement exists check

        var customer = new CustomerAggregate(cmd);

        await _store.Save(customer);
    }

    private async Task Handle(ChangeCustomerFirstName cmd)
    {
        var customer = await _store.Load(cmd.CustomerId);

        customer.Handle(cmd);
        
        await _store.Save(customer);
    }
    private async Task Handle(ChangeCustomerLastName cmd)
    {
        var customer = await _store.Load(cmd.CustomerId);

        customer.Handle(cmd);
        
        await _store.Save(customer);
    }
}