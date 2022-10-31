using WidgetAndCo.Extensions;
using WidgetAndCo.Infrastructure;
using WidgetAndCo.Models.Commands.Orders;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Repositories;

namespace WidgetAndCo.Services;

public class OrderService : IOrderService
{
    private readonly IMessageBusFactory _busFactory;
    private readonly OrderRepository _orderRepository;
    private const string QueueName = "orderqueue";

    public OrderService(IMessageBusFactory busFactory, OrderRepository orderRepository)
    {
        _busFactory = busFactory;
        _orderRepository = orderRepository;
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
    
    public async Task<IEnumerable<OrderReadModel>> GetAll()
    {
        return await _orderRepository.GetAll();
    }
}