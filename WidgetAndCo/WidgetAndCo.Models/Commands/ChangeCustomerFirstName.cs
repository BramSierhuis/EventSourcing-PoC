namespace WidgetAndCo.Models.Commands;

public class ChangeCustomerFirstName : ICommand
{
    public Guid AggregateId { get; set; }
    public string FirstName { get; set;}
}