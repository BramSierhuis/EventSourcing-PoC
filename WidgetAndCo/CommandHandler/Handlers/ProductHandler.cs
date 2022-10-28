using CommandHandler.Repositories;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models.Commands;

namespace CommandHandler.Services;

public class ProductHandler : IProductHandler
{
    private readonly IAggregateStore<ProductAggregate> _store;

    public ProductHandler(IAggregateStore<ProductAggregate> store)
    {
        _store = store;
    }

    public async Task Handle(object command) => await Process((dynamic)command);

    private async Task Process(CreateProduct cmd)
    {
        var aggregate = new ProductAggregate(cmd);

        await _store.Save(aggregate);
    }

    private async Task Process(ChangeProductName cmd)
    {
        var aggregate = await _store.Load(cmd.AggregateId);

        aggregate.Handle(cmd);
        
        await _store.Save(aggregate);
    }
    
    private async Task Process(ChangeProductCost cmd)
    {
        var aggregate = await _store.Load(cmd.AggregateId);

        aggregate.Handle(cmd);
        
        await _store.Save(aggregate);
    }
}