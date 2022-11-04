using WidgetAndCo.Context;
using WidgetAndCo.Functions.Repositories.Abstract;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class OrderShippingTimeRepository : BaseRepository<OrderShippingTimeReadModel, CosmosReadModelContext>, IOrderShippingTimeRepository
{
    public OrderShippingTimeRepository(CosmosReadModelContext context) : base(context)
    {
    }
}