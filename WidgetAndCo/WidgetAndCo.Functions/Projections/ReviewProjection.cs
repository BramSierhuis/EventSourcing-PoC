using WidgetAndCo.Functions.Repositories;
using WidgetAndCo.Models.Events;
using WidgetAndCo.Models.Events.Products;
using WidgetAndCo.Models.Events.Reviews;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Projections;

public class ReviewProjection : IProjection
{
    private readonly IRepository<ReviewReadModel> _repository;

    public ReviewProjection(IRepository<ReviewReadModel> repository)
    {
        _repository = repository;
    }

    public async Task Handle(IEnumerable<object> events)
    {
        foreach (var e in events)
        {
            await Update((dynamic)e);
        }
    }

    private async Task Update(ReviewCreated e)
    {
        var entity = new ReviewReadModel()
        {
            Id = e.AggregateId,
            ProductId = e.ProductId,
            Review = e.Review
        };
        
        await _repository.AddEntity(entity);
    }

    //Discard any events not mapped
    private async Task Update(object e)
    {
        await Task.CompletedTask;
    }
}