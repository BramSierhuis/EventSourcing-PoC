using CommandHandler.Context;
using CommandHandler.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WidgetAndCo.Aggregates;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(x =>
    {
        x.AddDbContext<EventStoreContext>();

        x.AddTransient<IAggregateStore<CustomerAggregate>, EventStore<CustomerAggregate>>();
        x.AddTransient<IAggregateStore<ProductAggregate>, EventStore<ProductAggregate>>();
        x.AddTransient<IAggregateStore<OrderAggregate>, EventStore<OrderAggregate>>();
    })
    .Build();

host.Run();