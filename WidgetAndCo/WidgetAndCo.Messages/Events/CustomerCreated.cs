namespace WidgetAndCo.Messages.Events;

public class CustomerCreated : IEvent
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}