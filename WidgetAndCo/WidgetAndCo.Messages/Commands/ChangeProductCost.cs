namespace WidgetAndCo.Messages.Commands;

public class ChangeProductCost : ICommand
{
    public Guid ProductId { get; set; }
    public double Price { get; set; }
}