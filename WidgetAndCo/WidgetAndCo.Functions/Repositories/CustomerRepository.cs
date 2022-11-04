using WidgetAndCo.Context;
using WidgetAndCo.Functions.Repositories.Abstract;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class CustomerRepository : BaseRepository<CustomerReadModel, CosmosReadModelContext>, ICustomerRepository
{
    public CustomerRepository(CosmosReadModelContext context) : base(context)
    {
    }
}