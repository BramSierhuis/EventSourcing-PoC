namespace WidgetAndCo.Models.Commands;

public class CreateProduct : ICommand
{
    public string ProductName { get; set; }
    public double Price { get; set; }
}