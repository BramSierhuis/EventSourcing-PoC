namespace WidgetAndCo.Models.Events;

public class ProductCostChanged : BaseEvent
{
    public double Price { get; set; }
}