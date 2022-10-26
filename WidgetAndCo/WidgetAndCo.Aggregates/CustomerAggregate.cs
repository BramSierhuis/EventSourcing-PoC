using WidgetAndCo.Messages.Commands;
using WidgetAndCo.Messages.Events;
using WidgetAndCo.Models;

namespace WidgetAndCo.Aggregates;

public class CustomerAggregate : AggregateRoot<CustomerId>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public CustomerAggregate(CreateCustomer command)
    {
        Apply<CustomerCreated>(e =>
        {
            e.FirstName = command.FirstName;
            e.LastName = command.LastName;
        });
    }
    
    protected override void Mutate(object e)
        => When((dynamic)e);

    private void When(CustomerCreated @event)
    {
        Id = @event.CustomerId;
        FirstName = @event.FirstName;
        LastName = @event.LastName;
    }
}