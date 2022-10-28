namespace WidgetAndCo.Messages.Events;

public class CustomerCreated : BaseEvent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}