using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests.Reviews;

namespace WidgetAndCo.Services.Abstract;

public interface IReviewService
{
    Task<IEnumerable<ReviewReadModel>> GetAllForProduct(Guid productId);
    Task<ReviewReadModel> GetById(Guid reviewId);
    Task CreateReview(CreateReviewRequest request, Guid productId);
}