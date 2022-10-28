namespace WidgetAndCo.Models.Commands;

public class ChangeProductCost : ICommand
{
    public Guid AggregateId { get; set; }
    public double Price { get; set; }
}