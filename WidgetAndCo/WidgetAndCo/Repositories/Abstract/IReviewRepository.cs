using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Repositories.Abstract;

public interface IReviewRepository : IRepository<ReviewReadModel>
{
    Task<IEnumerable<ReviewReadModel>> GetAllForProduct(Guid productId);
}