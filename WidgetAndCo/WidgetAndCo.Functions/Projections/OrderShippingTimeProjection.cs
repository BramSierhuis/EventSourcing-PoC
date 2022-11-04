using WidgetAndCo.Functions.Repositories;
using WidgetAndCo.Functions.Repositories.Abstract;
using WidgetAndCo.Models.Events.Orders;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Projections;

public class OrderShippingTimeeProjection : IProjection
{
    private readonly IOrderShippingTimeRepository _repository;

    public OrderShippingTimeeProjection(IOrderShippingTimeRepository repository)
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

    private async Task Update(OrderCreated e)
    {
        var entity = new OrderShippingTimeReadModel()
        {
            Id = e.AggregateId,
            OrderDate = e.OrderDate
        };
        
        await _repository.AddEntity(entity);
    }

    private async Task Update(OrderShipped e)
    {
        await _repository.GetAndUpdateEntity(e.AggregateId, entity =>
        {
            entity.ShippingDate = e.ShippingDate;
        });
    }

    //Discard any events not mapped
    private async Task Update(object e)
    {
        await Task.CompletedTask;
    }
}