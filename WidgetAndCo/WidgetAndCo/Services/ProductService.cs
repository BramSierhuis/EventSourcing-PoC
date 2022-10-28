using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models;
using WidgetAndCo.Models.Commands;

namespace WidgetAndCo.Services;

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