namespace WidgetAndCo.Models.Commands;

public class ChangeCustomerLastName : ICommand
{
    public Guid AggregateId { get; set; }
    public string LastName { get; set; }
}