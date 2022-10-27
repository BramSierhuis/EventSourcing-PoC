namespace WidgetAndCo.Messages.Commands;

public class ChangeCustomerFirstName : ICommand
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set;}
}