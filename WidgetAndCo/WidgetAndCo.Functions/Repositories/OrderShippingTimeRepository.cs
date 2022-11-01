using WidgetAndCo.Context;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class OrderShippingTimeRepository : BaseRepository<OrderShippingTimeReadModel, CosmosReadModelContext>
{
    public OrderShippingTimeRepository(CosmosReadModelContext context) : base(context)
    {
    }
}