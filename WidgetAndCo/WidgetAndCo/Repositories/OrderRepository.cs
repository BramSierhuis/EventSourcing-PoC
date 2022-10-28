using WidgetAndCo.Contexts;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Repositories;

public class OrderRepository : BaseRepository<OrderReadModel, CosmosReadModelContext>
{
    public OrderRepository(CosmosReadModelContext context) : base(context)
    {
    }
}