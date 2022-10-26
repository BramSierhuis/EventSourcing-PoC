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
    public async Task TestLoad()
    {
        var guid = Guid.Parse("94d339f9-e4f1-4414-862a-e022aecf2792");
        await _store.Load(guid);
    }

    private async Task Handle(CreateCustomer cmd)
    {
        //TODO: Implement exists check

        var customer = new CustomerAggregate(cmd);

        await _store.Save(customer);
    }
}