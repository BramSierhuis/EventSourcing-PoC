using CommandHandler.Repositories;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models.Commands.Orders;
using WidgetAndCo.Models.Commands.Reviews;

namespace CommandHandler.Services;

public class ReviewHandler : IReviewHandler
{
    private readonly IAggregateStore<ReviewAggregate> _store;

    public ReviewHandler(IAggregateStore<ReviewAggregate> store)
    {
        _store = store;
    }

    public async Task Handle(object command) => await Process((dynamic)command);

    private async Task Process(CreateReview cmd)
    {
        var aggregate = new ReviewAggregate(cmd);

        await _store.Save(aggregate);
    }
}