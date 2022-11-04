using WidgetAndCo.Contexts;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Repositories.Abstract;

namespace WidgetAndCo.Repositories;

public class ProductRepository : BaseRepository<ProductReadModel, CosmosReadModelContext>, IProductRepository
{
    public ProductRepository(CosmosReadModelContext context) : base(context)
    {
    }
}