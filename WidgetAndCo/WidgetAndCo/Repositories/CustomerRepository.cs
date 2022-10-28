using WidgetAndCo.Contexts;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Repositories;

public class CustomerRepository : BaseRepository<CustomerReadModel, CosmosReadModelContext>
{
    public CustomerRepository(CosmosReadModelContext context) : base(context)
    {
    }
}