namespace WidgetAndCo.Models.Events.Products;

public class ProductStockChanged : BaseEvent
{
    public int StockChange { get; set; }
}