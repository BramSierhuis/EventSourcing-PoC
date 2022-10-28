using CommandHandler.Repositories;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models.Commands;

namespace CommandHandler.Services;

public class ProductService : IProductService
{
    private readonly IAggregateStore<ProductAggregate> _store;

    public ProductService(IAggregateStore<ProductAggregate> store)
    {
        _store = store;
    }

    public async Task Handle(object command) => await Handle((dynamic)command);

    private async Task Handle(CreateProduct cmd)
    {
        var aggregate = new ProductAggregate(cmd);

        await _store.Save(aggregate);
    }

    private async Task Handle(ChangeProductName cmd)
    {
        var aggregate = await _store.Load(cmd.AggregateId);

        aggregate.Handle(cmd);
        
        await _store.Save(aggregate);
    }
    
    private async Task Handle(ChangeProductCost cmd)
    {
        var aggregate = await _store.Load(cmd.AggregateId);

        aggregate.Handle(cmd);
        
        await _store.Save(aggregate);
    }
}