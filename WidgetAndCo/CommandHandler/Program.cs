using CommandHandler.Context;
using CommandHandler.Repositories;
using CommandHandler.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WidgetAndCo.Aggregates;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(x =>
    {
        x.AddDbContext<EventStoreContext>();

        x.AddTransient<ICustomerHandler, CustomerHandler>();
        x.AddTransient<IOrderHandler, OrderHandler>();
        x.AddTransient<IProductHandler, ProductHandler>();
        
        x.AddTransient<IAggregateStore<CustomerAggregate>, EventStore<CustomerAggregate>>();
        x.AddTransient<IAggregateStore<ProductAggregate>, EventStore<ProductAggregate>>();
        x.AddTransient<IAggregateStore<OrderAggregate>, EventStore<OrderAggregate>>();
    })
    .Build();

host.Run();