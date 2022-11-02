namespace WidgetAndCo.Models.Events.Products;

public class ProductCostChanged : BaseEvent
{
    public double Price { get; set; }
}