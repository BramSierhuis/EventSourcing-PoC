namespace WidgetAndCo.Models.Events;

public class ProductCreated : BaseEvent
{
    public string ProductName { get; set; }
    public double Price { get; set; }
}