using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests.Products;

namespace WidgetAndCo.Services.Abstract;

public interface IProductService : IService<ProductReadModel>
{
    Task CreateProduct(CreateProductRequest request);
    Task ChangeProductName(ChangeProductNameRequest request, Guid productId);
    Task ChangeProductCost(ChangeProductCostRequest request, Guid productId);
    Task ChangeProductStock(ChangeProductStockRequest request, Guid productId);
}