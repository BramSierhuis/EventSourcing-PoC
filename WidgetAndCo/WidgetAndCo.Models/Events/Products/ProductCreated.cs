namespace WidgetAndCo.Models.Events.Products;

public class ProductCreated : BaseEvent
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
}