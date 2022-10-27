namespace WidgetAndCo.Messages.Events;

public class CustomerLastNameChanged : IEvent
{
    public Guid CustomerId { get; set; }
    public string LastName { get; set;}
}