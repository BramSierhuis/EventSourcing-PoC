using WidgetAndCo.Extensions;
using WidgetAndCo.Infrastructure;
using WidgetAndCo.Models.Commands;
using WidgetAndCo.Models.Commands.Products;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Repositories;

namespace WidgetAndCo.Services;

public class ProductService : IProductService
{
    private readonly IMessageBusFactory _busFactory;
    private readonly ProductRepository _productRepository;
    private const string QueueName = "productqueue";
    
    public ProductService(IMessageBusFactory busFactory, ProductRepository productRepository)
    {
        _busFactory = busFactory;
        _productRepository = productRepository;
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

    public async Task ChangeProductStock(ChangeProductStockRequest request, Guid productId)
    {
        var command = new ChangeProductStock()
        {
            AggregateId = productId,
            StockChange = request.StockChange
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task<IEnumerable<ProductReadModel>> GetAll()
    {
        return await _productRepository.GetAll();
    }
}