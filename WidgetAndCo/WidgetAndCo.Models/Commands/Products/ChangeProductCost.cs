namespace WidgetAndCo.Models.Commands.Products;

public class ChangeProductCost : ICommand
{
    public Guid AggregateId { get; set; }
    public double Price { get; set; }
}