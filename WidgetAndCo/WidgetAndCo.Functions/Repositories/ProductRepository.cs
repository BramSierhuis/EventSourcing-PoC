using WidgetAndCo.Context;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class ProductRepository : BaseRepository<ProductReadModel, CosmosReadModelContext>
{
    public ProductRepository(CosmosReadModelContext context) : base(context)
    {
    }
}