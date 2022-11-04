using WidgetAndCo.Contexts;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Repositories.Abstract;

namespace WidgetAndCo.Repositories;

public class CustomerRepository : BaseRepository<CustomerReadModel, CosmosReadModelContext>, ICustomerRepository
{
    public CustomerRepository(CosmosReadModelContext context) : base(context)
    {
    }
}