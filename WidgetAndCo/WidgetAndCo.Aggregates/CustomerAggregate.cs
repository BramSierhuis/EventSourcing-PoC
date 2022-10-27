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

    public void Handle(ChangeCustomerFirstName command)
    {
        Apply<CustomerFirstNameChanged>(e =>
        {
            e.CustomerId = command.CustomerId;
            e.FirstName = command.FirstName;
        });
    }

    public void Handle(ChangeCustomerLastName command)
    {
        Apply<CustomerLastNameChanged>(e =>
        {
            e.CustomerId = command.CustomerId;
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
    
    private void When(CustomerFirstNameChanged @event)
    {
        AggregateId = @event.CustomerId;
        FirstName = @event.FirstName;
    }
    
    private void When(CustomerLastNameChanged @event)
    {
        AggregateId = @event.CustomerId;
        LastName = @event.LastName;
    }
}