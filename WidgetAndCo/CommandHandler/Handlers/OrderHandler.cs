using CommandHandler.Handlers.Abstract;
using CommandHandler.Repositories.Abstract;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models.Commands.Orders;

namespace CommandHandler.Handlers;

public class OrderHandler : IOrderHandler
{
    private readonly IAggregateStore<OrderAggregate> _store;

    public OrderHandler(IAggregateStore<OrderAggregate> store)
    {
        _store = store;
    }

    public async Task Handle(object command) => await Process((dynamic)command);

    private async Task Process(CreateOrder cmd)
    {
        var aggregate = new OrderAggregate(cmd);

        await _store.Save(aggregate);
    }

    private async Task Process(ShipOrder cmd)
    {
        var aggregate = await _store.Load(cmd.AggregateId);

        aggregate.Handle(cmd);
        
        await _store.Save(aggregate);
    }
}