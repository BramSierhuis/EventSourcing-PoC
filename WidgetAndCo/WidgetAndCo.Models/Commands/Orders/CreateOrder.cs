namespace WidgetAndCo.Models.Commands.Orders;

public class CreateOrder : ICommand
{
    public Guid CustomerId { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShippingDate { get; set; }
}