using WidgetAndCo.Models.Commands;
using WidgetAndCo.Models.Commands.Products;
using WidgetAndCo.Models.Events;
using WidgetAndCo.Models.Events.Products;

namespace WidgetAndCo.Aggregates;

public class ProductAggregate : AggregateRoot
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    
    public string ImageUrl { get; set; }

    public ProductAggregate()
    {
    }

    public ProductAggregate(CreateProduct command)
    {
        Apply<ProductCreated>(e =>
        {
            e.AggregateId = Guid.NewGuid();
            e.ProductName = command.ProductName;
            e.Price = command.Price;
            e.ImageUrl = command.ImageUrl;
        });
    }

    public void Handle(ChangeProductName command)
    {
        Apply<ProductNameChanged>(e =>
        {
            e.AggregateId = command.AggregateId;
            e.ProductName = command.ProductName;
        });
    }

    public void Handle(ChangeProductCost command)
    {
        Apply<ProductCostChanged>(e =>
        {
            e.AggregateId = command.AggregateId;
            e.Price = command.Price;
        });
    }

    public void Handle(ChangeProductStock command)
    {
        Apply<ProductStockChanged>(e =>
        {
            e.AggregateId = command.AggregateId;
            e.StockChange = command.StockChange;
        });
    }
    
    protected override void Mutate(object e)
        => When((dynamic)e);

    private void When(ProductCreated @event)
    {
        AggregateId = @event.AggregateId;
        ProductName = @event.ProductName;
        Price = @event.Price;
        ImageUrl = @event.ImageUrl;
    }
    
    private void When(ProductNameChanged @event)
    {
        AggregateId = @event.AggregateId;
        ProductName = @event.ProductName;
    }
    
    private void When(ProductCostChanged @event)
    {
        AggregateId = @event.AggregateId;
        Price = @event.Price;
    }
    
    private void When(ProductStockChanged @event)
    {
        AggregateId = @event.AggregateId;
        Stock += @event.StockChange;
    }
}