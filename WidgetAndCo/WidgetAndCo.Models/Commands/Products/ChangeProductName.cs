namespace WidgetAndCo.Models.Commands.Products;

public class ChangeProductName : ICommand
{
    public Guid AggregateId { get; set; }
    public string ProductName { get; set; }
}