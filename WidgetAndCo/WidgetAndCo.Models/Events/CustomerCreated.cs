namespace WidgetAndCo.Models.Events;

public class CustomerCreated : BaseEvent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
}