using WidgetAndCo.Models;
using WidgetAndCo.Models.Commands.Orders;
using WidgetAndCo.Models.Commands.Reviews;
using WidgetAndCo.Models.Events.Orders;
using WidgetAndCo.Models.Events.Reviews;

namespace WidgetAndCo.Aggregates;

public class ReviewAggregate : AggregateRoot
{
    public Guid ProductId { get; set; }
    public string Review { get; set; }

    public ReviewAggregate()
    {
    }

    public ReviewAggregate(CreateReview command)
    {
        Apply<ReviewCreated>(e =>
        {
            e.AggregateId = Guid.NewGuid();
            e.ProductId = command.ProductId;
            e.Review = command.Review;
        });
    }

    protected override void Mutate(object e)
        => When((dynamic)e);

    private void When(ReviewCreated @event)
    {
        AggregateId = @event.AggregateId;
        ProductId = @event.ProductId;
        Review = @event.Review;
    }
}