namespace WidgetAndCo.Models.ReadModels;

public class ProductReadModel : ReadModel
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
}