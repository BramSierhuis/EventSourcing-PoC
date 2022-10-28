namespace WidgetAndCo.Models.Events;

public class ProductNameChanged : BaseEvent
{
    public string ProductName { get; set; }
}