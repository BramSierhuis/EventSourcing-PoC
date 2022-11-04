using WidgetAndCo.Context;
using WidgetAndCo.Functions.Repositories.Abstract;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class OrderRepository : BaseRepository<OrderReadModel, CosmosReadModelContext>, IOrderRepository
{
    public OrderRepository(CosmosReadModelContext context) : base(context)
    {
    }
}