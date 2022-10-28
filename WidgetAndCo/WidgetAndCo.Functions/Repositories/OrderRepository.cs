using WidgetAndCo.Context;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class OrderRepository : BaseRepository<OrderReadModel, CosmosReadModelContext>
{
    public OrderRepository(CosmosReadModelContext context) : base(context)
    {
    }
}