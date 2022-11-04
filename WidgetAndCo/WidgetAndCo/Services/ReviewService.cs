using WidgetAndCo.Exceptions;
using WidgetAndCo.Extensions;
using WidgetAndCo.Infrastructure;
using WidgetAndCo.Models.Commands.Reviews;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Models.Requests.Reviews;
using WidgetAndCo.Repositories;
using WidgetAndCo.Services.Abstract;

namespace WidgetAndCo.Services;

public class ReviewService : IReviewService
{
    private readonly ReviewRepository _reviewRepository;
    private readonly ProductRepository _productRepository;
    private readonly IMessageBusFactory _busFactory;
    private const string QueueName = "reviewqueue";
    
    public ReviewService(ReviewRepository reviewRepository, ProductRepository productRepository, IMessageBusFactory busFactory)
    {
        _reviewRepository = reviewRepository;
        _busFactory = busFactory;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ReviewReadModel>> GetAllForProduct(Guid productId)
    {
        return await _reviewRepository.GetAllForProduct(productId);
    }

    public async Task<ReviewReadModel> GetById(Guid reviewId)
    {
        var review = await _reviewRepository.TryGetById(reviewId);
        if(review == null) throw new ReviewNotFoundException();
        return review;
    }

    public async Task CreateReview(CreateReviewRequest request, Guid productId)
    {
        if (! await _productRepository.Exists(productId)) throw new ProductNotFoundException();

        var command = new CreateReview()
        {
            ProductId = productId,
            Review = request.Review
        };
        
        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }
}