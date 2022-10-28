using WidgetAndCo.Functions.Repositories;
using WidgetAndCo.Models.Events;
using WidgetAndCo.Models.Events.Products;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Projections;

public class ProductProjection : IProjection
{
    private readonly IRepository<ProductReadModel> _repository;

    public ProductProjection(IRepository<ProductReadModel> repository)
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

    private async Task Update(ProductCreated e)
    {
        var entity = new ProductReadModel()
        {
            Id = e.AggregateId,
            Price = e.Price,
            ProductName = e.ProductName
        };
        
        await _repository.AddEntity(entity);
    }

    private async Task Update(ProductNameChanged e)
    {
        await _repository.GetAndUpdateEntity(e.AggregateId, entity =>
        {
            entity.ProductName = e.ProductName;
        });
    }

    private async Task Update(ProductCostChanged e)
    {
        await _repository.GetAndUpdateEntity(e.AggregateId, entity =>
        {
            entity.Price = e.Price;
        });
    }

    private async Task Update(ProductStockChanged e)
    {
        await _repository.GetAndUpdateEntity(e.AggregateId, entity =>
        {
            entity.Stock += e.StockChange;
        });
    }
    
    //Discard any events not mapped
    private async Task Update(object e)
    {
        await Task.CompletedTask;
    }
}