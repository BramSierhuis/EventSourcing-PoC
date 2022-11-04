using WidgetAndCo.Contexts;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Repositories.Abstract;

namespace WidgetAndCo.Repositories;

public class OrderRepository : BaseRepository<OrderReadModel, CosmosReadModelContext>, IOrderRepository
{
    public OrderRepository(CosmosReadModelContext context) : base(context)
    {
    }
}