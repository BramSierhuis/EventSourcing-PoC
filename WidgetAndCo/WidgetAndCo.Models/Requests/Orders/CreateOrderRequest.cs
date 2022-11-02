namespace WidgetAndCo.Models.Requests.Orders;

public class CreateOrderRequest
{
    public Guid CustomerId { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
}