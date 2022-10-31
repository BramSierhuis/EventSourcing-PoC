using System.Web;
using WidgetAndCo.Clients;
using WidgetAndCo.Exceptions;
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
    private readonly IProductImageClient _productImageClient;
    private const string QueueName = "productqueue";
    
    public ProductService(IMessageBusFactory busFactory, ProductRepository productRepository, IProductImageClient productImageClient)
    {
        _busFactory = busFactory;
        _productRepository = productRepository;
        _productImageClient = productImageClient;
    }

    public async Task CreateProduct(CreateProductRequest request)
    {
        var filename = $"{Guid.NewGuid()}.{Path.GetExtension(request.Image.FileName)}";
        var imageBytes = await request.Image.GetBytes();
        
        await _productImageClient.AddAsync("productimages", imageBytes, filename);
        var imageUrl = _productImageClient.GetUri("productimages", filename);
        
        var command = new CreateProduct()
        {
            ProductName = request.ProductName,
            Price = request.Price,
            ImageUrl = imageUrl.ToString()
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task ChangeProductName(ChangeProductNameRequest request, Guid productId)
    {
        if (! await _productRepository.Exists(productId)) throw new ProductNotFoundException();

        var command = new ChangeProductName()
        {
            AggregateId = productId,
            ProductName = request.ProductName,
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task ChangeProductCost(ChangeProductCostRequest request, Guid productId)
    {
        if (! await _productRepository.Exists(productId)) throw new ProductNotFoundException();

        var command = new ChangeProductCost()
        {
            AggregateId = productId,
            Price = request.Price
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task ChangeProductStock(ChangeProductStockRequest request, Guid productId)
    {
        if (! await _productRepository.Exists(productId)) throw new ProductNotFoundException();

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

    public async Task<ProductReadModel> GetById(Guid productId)
    {
        var product = await _productRepository.TryGetById(productId);
        if (product == null) throw new ProductNotFoundException();
        return product;
    }
}