using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests;

namespace WidgetAndCo.Services;

public interface IOrderService
{
    public Task CreateOrder(CreateOrderRequest request);
    public Task ShipOrder(Guid orderId);
    Task<IEnumerable<OrderReadModel>> GetAll();
}