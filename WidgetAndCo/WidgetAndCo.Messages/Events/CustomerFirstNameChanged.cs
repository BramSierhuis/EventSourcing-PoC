namespace WidgetAndCo.Messages.Events;

public class CustomerFirstNameChanged : IEvent
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set;}
}