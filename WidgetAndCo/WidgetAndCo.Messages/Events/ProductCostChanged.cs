namespace WidgetAndCo.Messages.Events;

public class ProductCostChanged : IEvent
{
    public Guid ProductId { get; set; }
    public double Price { get; set; }
}