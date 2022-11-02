namespace WidgetAndCo.Models.Events.Products;

public class ProductNameChanged : BaseEvent
{
    public string ProductName { get; set; }
}