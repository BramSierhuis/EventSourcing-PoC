using WidgetAndCo.Messages.Commands;
using WidgetAndCo.Messages.Events;

namespace WidgetAndCo.Aggregates;

public class CustomerAggregate : AggregateRoot
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public CustomerAggregate()
    {
    }

    public CustomerAggregate(CreateCustomer command)
    {
        Apply<CustomerCreated>(e =>
        {
            e.CustomerId = Guid.NewGuid();
            e.FirstName = command.FirstName;
            e.LastName = command.LastName;
        });
    }
    
    protected override void Mutate(object e)
        => When((dynamic)e);

    private void When(CustomerCreated @event)
    {
        AggregateId = @event.CustomerId;
        FirstName = @event.FirstName;
        LastName = @event.LastName;
    }
}