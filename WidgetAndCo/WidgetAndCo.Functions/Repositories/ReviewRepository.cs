using WidgetAndCo.Context;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class ReviewRepository : BaseRepository<ReviewReadModel, CosmosReadModelContext>
{
    public ReviewRepository(CosmosReadModelContext context) : base(context)
    {
    }
}