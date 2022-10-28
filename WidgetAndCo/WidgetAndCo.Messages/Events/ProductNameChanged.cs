namespace WidgetAndCo.Messages.Events;

public class ProductNameChanged : IEvent
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
}