using WidgetAndCo.Extensions;
using WidgetAndCo.Infrastructure;
using WidgetAndCo.Models.Commands.Orders;
using WidgetAndCo.Models.Requests;

namespace WidgetAndCo.Services;

public class OrderService : IOrderService
{
    private readonly IMessageBusFactory _busFactory;
    private const string QueueName = "orderqueue";

    public OrderService(IMessageBusFactory busFactory)
    {
        _busFactory = busFactory;
    }
    
    public async Task CreateOrder(CreateOrderRequest request)
    {
        var command = new CreateOrder()
        {
            CustomerId = request.CustomerId,
            OrderItems = request.OrderItems,
            OrderDate = DateTime.Now,
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task ShipOrder(Guid orderId)
    {
        var command = new ShipOrder()
        {
            AggregateId = orderId,
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }
}