namespace WidgetAndCo.Models.Commands.Products;

public class CreateProduct : ICommand
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
}