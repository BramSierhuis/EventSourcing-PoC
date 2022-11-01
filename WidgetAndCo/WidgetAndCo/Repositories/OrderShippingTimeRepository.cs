using WidgetAndCo.Contexts;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Repositories;

public class OrderShippingTimeRepository : BaseRepository<OrderShippingTimeReadModel, CosmosReadModelContext>
{
    public OrderShippingTimeRepository(CosmosReadModelContext context) : base(context)
    {
    }
}