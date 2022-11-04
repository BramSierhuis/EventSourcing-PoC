using WidgetAndCo.Context;
using WidgetAndCo.Functions.Repositories.Abstract;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public class ReviewRepository : BaseRepository<ReviewReadModel, CosmosReadModelContext>, IReviewRepository
{
    public ReviewRepository(CosmosReadModelContext context) : base(context)
    {
    }
}