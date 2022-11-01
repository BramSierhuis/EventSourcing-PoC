namespace WidgetAndCo.Models.ReadModels;

public class OrderShippingTimeReadModel : ReadModel
{
    public DateTime OrderDate { get; set; }
    public DateTime? ShippingDate { get; set; }
}