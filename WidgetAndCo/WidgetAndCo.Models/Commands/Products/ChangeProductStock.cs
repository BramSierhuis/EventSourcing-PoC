namespace WidgetAndCo.Models.Commands.Products;

public class ChangeProductStock : ICommand
{
    public Guid AggregateId { get; set; }
    public int StockChange { get; set; }
}