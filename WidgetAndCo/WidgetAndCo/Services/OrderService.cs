using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models;
using WidgetAndCo.Models.Commands.Orders;

namespace WidgetAndCo.Services;

public class OrderService : IOrderService
{
    private readonly IAggregateStore<OrderAggregate> _store;

    public OrderService(IAggregateStore<OrderAggregate> store)
    {
        _store = store;
    }

    public async Task Handle(object command) => await Handle((dynamic)command);

    private async Task Handle(CreateOrder cmd)
    {
        var aggregate = new OrderAggregate(cmd);

        await _store.Save(aggregate);
    }

    private async Task Handle(ShipOrder cmd)
    {
        var aggregate = await _store.Load(cmd.AggregateId);

        aggregate.Handle(cmd);
        
        await _store.Save(aggregate);
    }
}