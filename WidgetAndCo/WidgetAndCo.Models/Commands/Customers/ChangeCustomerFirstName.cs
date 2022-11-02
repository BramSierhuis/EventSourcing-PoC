namespace WidgetAndCo.Models.Commands.Customers;

public class ChangeCustomerFirstName : ICommand
{
    public Guid AggregateId { get; set; }
    public string FirstName { get; set;}
}