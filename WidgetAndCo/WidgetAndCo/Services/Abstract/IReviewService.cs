using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests.Reviews;

namespace WidgetAndCo.Services.Abstract;

public interface IReviewService : IService<ReviewReadModel>
{
    Task<IEnumerable<ReviewReadModel>> GetAllForProduct(Guid productId);
    Task CreateReview(CreateReviewRequest request, Guid productId);
}