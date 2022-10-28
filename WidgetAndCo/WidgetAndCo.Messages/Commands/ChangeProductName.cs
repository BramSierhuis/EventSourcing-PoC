namespace WidgetAndCo.Messages.Commands;

public class ChangeProductName : ICommand
{
    public Guid AggregateId { get; set; }
    public string ProductName { get; set; }
}