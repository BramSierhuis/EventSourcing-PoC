namespace WidgetAndCo.Messages.Commands;

public class CreateCustomer : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}