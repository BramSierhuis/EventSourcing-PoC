using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Exceptions;
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
    private readonly ProductRepository _productRepository;
    private readonly CustomerRepository _customerRepository;
    private const string QueueName = "orderqueue";

    public OrderService(IMessageBusFactory busFactory, OrderRepository orderRepository, ProductRepository productRepository, CustomerRepository customerRepository)
    {
        _busFactory = busFactory;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _customerRepository = customerRepository;
    }
    
    public async Task CreateOrder(CreateOrderRequest request)
    {
        //Make sure customer exists
        var customer = await _customerRepository.TryGetById(request.CustomerId);
        if (customer == null) throw new CustomerNotFoundException();
        
        //Make sure product exists and is in stock
        foreach (var item in request.OrderItems)
        {
            var product = await _productRepository.TryGetById(item.ProductId);

            if (product == null) throw new ProductNotFoundException();
            if (product.Stock < item.Quantity) throw new ProductNotInStockException();
        }
        
        //Send the verified command
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
        //Make sure order exists
        var order = await _orderRepository.TryGetById(orderId);
        if(order == null) throw new OrderNotFoundException();
        
        //Make sure order isn't yet shipped
        if (order.ShippingDate != null) throw new OrderAlreadyShippedException();
        
        //Send command
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
    
    public async Task<OrderReadModel> GetById(Guid orderId)
    {
        var order = await _orderRepository.TryGetById(orderId);
        if(order == null) throw new OrderNotFoundException();
        return order;
    }
}