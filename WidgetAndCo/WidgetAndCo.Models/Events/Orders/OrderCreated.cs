namespace WidgetAndCo.Models.Events.Orders;

public class OrderCreated : BaseEvent
{
    public Guid CustomerId { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShippingDate { get; set; }
}