using WidgetAndCo.Contexts;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Repositories.Abstract;

namespace WidgetAndCo.Repositories;

public class OrderShippingTimeRepository : BaseRepository<OrderShippingTimeReadModel, CosmosReadModelContext>, IOrderShippingTimeRepository
{
    public OrderShippingTimeRepository(CosmosReadModelContext context) : base(context)
    {
    }
}