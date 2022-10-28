using WidgetAndCo.Models.Requests;

namespace WidgetAndCo.Services;

public interface IOrderService
{
    public Task CreateOrder(CreateOrderRequest request);
    public Task ShipOrder(Guid orderId);
}