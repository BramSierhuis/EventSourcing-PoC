namespace WidgetAndCo.Models.Events;

public class CustomerLastNameChanged : BaseEvent
{
    public string LastName { get; set;}
}