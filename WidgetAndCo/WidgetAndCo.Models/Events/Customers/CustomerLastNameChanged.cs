namespace WidgetAndCo.Models.Events.Customers;

public class CustomerLastNameChanged : BaseEvent
{
    public string LastName { get; set;}
}