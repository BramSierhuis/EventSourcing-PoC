using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests.Orders;

namespace WidgetAndCo.Services.Abstract;

public interface IOrderService : IService<OrderReadModel>
{
    public Task CreateOrder(CreateOrderRequest request);
    public Task ShipOrder(Guid orderId);
    Task<OrderShippingTimeReadModel> GetShippingTimeForOrder(Guid orderId);
}