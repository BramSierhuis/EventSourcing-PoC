namespace WidgetAndCo.Models.Commands.Orders;

public class ShipOrder : ICommand
{
    public Guid AggregateId { get; set; }
}