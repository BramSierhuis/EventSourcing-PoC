namespace WidgetAndCo.Messages.Events;

public class ProductCreated : IEvent
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
}