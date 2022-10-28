using WidgetAndCo.Models;
using WidgetAndCo.Models.Commands.Orders;
using WidgetAndCo.Models.Events.Orders;

namespace WidgetAndCo.Aggregates;

public class OrderAggregate : AggregateRoot
{
    public Guid CustomerId { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShippingDate { get; set; }

    public OrderAggregate()
    {
    }

    public OrderAggregate(CreateOrder command)
    {
        Apply<OrderCreated>(e =>
        {
            e.AggregateId = Guid.NewGuid();
            e.CustomerId = command.CustomerId;
            e.OrderItems = command.OrderItems;
            e.OrderDate = command.OrderDate;
            e.ShippingDate = command.ShippingDate;
        });
    }

    public void Handle(ShipOrder command)
    {
        Apply<OrderShipped>(e =>
        {
            e.AggregateId = command.AggregateId;
            e.ShippingDate = DateTime.Now;
        });
    }

    protected override void Mutate(object e)
        => When((dynamic)e);

    private void When(OrderCreated @event)
    {
        AggregateId = @event.AggregateId;
        CustomerId = @event.CustomerId;
        OrderItems = @event.OrderItems;
        OrderDate = @event.OrderDate;
        ShippingDate = @event.ShippingDate;
    }
    
    private void When(OrderShipped @event)
    {
        AggregateId = @event.AggregateId;
        ShippingDate = @event.ShippingDate;
    }
}