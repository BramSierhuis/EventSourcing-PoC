namespace WidgetAndCo.Messages.Events;

public class ProductCostChanged : BaseEvent
{
    public double Price { get; set; }
}