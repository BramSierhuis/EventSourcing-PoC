namespace WidgetAndCo.Models.ReadModels;

public class OrderReadModel : ReadModel
{
    public Guid CustomerId { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShippingDate { get; set; }
}