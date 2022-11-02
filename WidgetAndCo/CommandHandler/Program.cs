using CommandHandler.Clients;
using CommandHandler.Context;
using CommandHandler.Handlers;
using CommandHandler.Handlers.Abstract;
using CommandHandler.Repositories;
using CommandHandler.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WidgetAndCo.Aggregates;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(x =>
    {
        x.AddScoped<IKeyVaultClient, KeyVaultClient>();
        x.AddDbContext<EventStoreContext>();

        x.AddTransient<ICustomerHandler, CustomerHandler>();
        x.AddTransient<IOrderHandler, OrderHandler>();
        x.AddTransient<IProductHandler, ProductHandler>();
        x.AddTransient<IReviewHandler, ReviewHandler>();
        
        x.AddTransient<IAggregateStore<CustomerAggregate>, EventStore<CustomerAggregate>>();
        x.AddTransient<IAggregateStore<ProductAggregate>, EventStore<ProductAggregate>>();
        x.AddTransient<IAggregateStore<OrderAggregate>, EventStore<OrderAggregate>>();
        x.AddTransient<IAggregateStore<ReviewAggregate>, EventStore<ReviewAggregate>>();
    })
    .Build();

host.Run();