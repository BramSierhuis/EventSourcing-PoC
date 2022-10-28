using WidgetAndCo.Messages.Commands;
using WidgetAndCo.Messages.Events;

namespace WidgetAndCo.Aggregates;

public class ProductAggregate : AggregateRoot
{
    public string ProductName { get; set; }
    public double Price { get; set; }

    public ProductAggregate()
    {
    }

    public ProductAggregate(CreateProduct command)
    {
        Apply<ProductCreated>(e =>
        {
            e.ProductId = Guid.NewGuid();
            e.ProductName = command.ProductName;
            e.Price = command.Price;
        });
    }

    public void Handle(ChangeProductName command)
    {
        Apply<ProductNameChanged>(e =>
        {
            e.ProductId = command.ProductId;
            e.ProductName = command.ProductName;
        });
    }

    public void Handle(ChangeProductCost command)
    {
        Apply<ProductCostChanged>(e =>
        {
            e.ProductId = command.ProductId;
            e.Price = command.Price;
        });
    }
    
    protected override void Mutate(object e)
        => When((dynamic)e);

    private void When(ProductCreated @event)
    {
        AggregateId = @event.ProductId;
        ProductName = @event.ProductName;
        Price = @event.Price;
    }
    
    private void When(ProductNameChanged @event)
    {
        AggregateId = @event.ProductId;
        ProductName = @event.ProductName;
    }
    
    private void When(ProductCostChanged @event)
    {
        AggregateId = @event.ProductId;
        Price = @event.Price;
    }
}