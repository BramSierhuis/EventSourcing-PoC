namespace WidgetAndCo.Messages.Commands;

public class ChangeCustomerLastName : ICommand
{
    public Guid CustomerId { get; set; }
    public string LastName { get; set; }
}