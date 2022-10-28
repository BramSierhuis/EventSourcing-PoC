namespace WidgetAndCo.Models.Events.Orders;

public class OrderShipped : BaseEvent
{
    public DateTime? ShippingDate { get; set; }
}