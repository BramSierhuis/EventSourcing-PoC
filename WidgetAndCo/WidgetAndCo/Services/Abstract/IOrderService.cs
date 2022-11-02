using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests.Orders;

namespace WidgetAndCo.Services.Abstract;

public interface IOrderService
{
    public Task CreateOrder(CreateOrderRequest request);
    public Task ShipOrder(Guid orderId);
    Task<IEnumerable<OrderReadModel>> GetAll();
    Task<OrderReadModel> GetById(Guid orderId);
    Task<OrderShippingTimeReadModel> GetShippingTimeForOrder(Guid orderId);
}