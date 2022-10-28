using WidgetAndCo.Extensions;
using WidgetAndCo.Infrastructure;
using WidgetAndCo.Models.Commands;
using WidgetAndCo.Models.Requests;

namespace WidgetAndCo.Services;

public class ProductService : IProductService
{
    private readonly IMessageBusFactory _busFactory;
    private const string QueueName = "productqueue";
    
    public ProductService(IMessageBusFactory busFactory)
    {
        _busFactory = busFactory;
    }

    public async Task CreateProduct(CreateProductRequest request)
    {
        var command = new CreateProduct()
        {
            ProductName = request.ProductName,
            Price = request.Price
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task ChangeProductName(ChangeProductNameRequest request, Guid productId)
    {
        var command = new ChangeProductName()
        {
            AggregateId = productId,
            ProductName = request.ProductName,
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task ChangeProductCost(ChangeProductCostRequest request, Guid productId)
    {
        var command = new ChangeProductCost()
        {
            AggregateId = productId,
            Price = request.Price
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }
}