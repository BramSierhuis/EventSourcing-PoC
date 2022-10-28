namespace WidgetAndCo.Messages.Commands;

public class ChangeProductName : ICommand
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
}