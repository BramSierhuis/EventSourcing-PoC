using WidgetAndCo.Functions.Repositories;
using WidgetAndCo.Messages.Events;
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
            Id = e.ProductId,
            Price = e.Price,
            ProductName = e.ProductName
        };
        
        await _repository.AddEntity(entity);
    }

    private async Task Update(ProductNameChanged e)
    {
        await _repository.GetAndUpdateEntity(e.ProductId, entity =>
        {
            entity.ProductName = e.ProductName;
        });
    }

    private async Task Update(ProductCostChanged e)
    {
        await _repository.GetAndUpdateEntity(e.ProductId, entity =>
        {
            entity.Price = e.Price;
        });
    }
    
    //Discard any events not mapped
    private async Task Update(object e)
    {
        await Task.CompletedTask;
    }
}