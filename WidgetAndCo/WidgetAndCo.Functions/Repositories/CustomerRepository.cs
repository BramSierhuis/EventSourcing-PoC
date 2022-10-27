using WidgetAndCo.Context;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class CustomerRepository : BaseRepository<CustomerReadModel, CosmosReadModelContext>
{
    public CustomerRepository(CosmosReadModelContext context) : base(context)
    {
    }
}