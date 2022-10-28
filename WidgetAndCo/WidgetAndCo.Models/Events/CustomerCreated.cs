namespace WidgetAndCo.Models.Events;

public class CustomerCreated : BaseEvent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}