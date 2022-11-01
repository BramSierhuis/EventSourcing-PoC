using WidgetAndCo.Models.Commands;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests;

namespace WidgetAndCo.Services;

public interface IReviewService
{
    Task<IEnumerable<ReviewReadModel>> GetAllForProduct(Guid productId);
    Task<ReviewReadModel> GetById(Guid reviewId);
    Task CreateReview(CreateReviewRequest request, Guid productId);
}