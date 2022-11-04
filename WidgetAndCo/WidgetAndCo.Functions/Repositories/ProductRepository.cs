using WidgetAndCo.Context;
using WidgetAndCo.Functions.Repositories.Abstract;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class ProductRepository : BaseRepository<ProductReadModel, CosmosReadModelContext>, IProductRepository
{
    public ProductRepository(CosmosReadModelContext context) : base(context)
    {
    }
}