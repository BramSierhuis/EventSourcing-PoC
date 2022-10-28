using WidgetAndCo.Contexts;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Repositories;

public class ProductRepository : BaseRepository<ProductReadModel, CosmosReadModelContext>
{
    public ProductRepository(CosmosReadModelContext context) : base(context)
    {
    }
}