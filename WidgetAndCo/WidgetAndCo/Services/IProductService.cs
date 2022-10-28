using WidgetAndCo.Models.Commands;
using WidgetAndCo.Models.Requests;

namespace WidgetAndCo.Services;

public interface IProductService
{
    Task CreateProduct(CreateProductRequest request);
    Task ChangeProductName(ChangeProductNameRequest request, Guid productId);
    Task ChangeProductCost(ChangeProductCostRequest request, Guid productId);
}