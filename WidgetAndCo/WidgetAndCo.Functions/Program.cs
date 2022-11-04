using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WidgetAndCo.Context;
using WidgetAndCo.Functions.Projections;
using WidgetAndCo.Functions.Repositories;
using WidgetAndCo.Models.ReadModels;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(x =>
    {
        x.AddDbContext<CosmosReadModelContext>();
        x.AddScoped<IRepository<CustomerReadModel>, CustomerRepository>();
        x.AddScoped<IRepository<ProductReadModel>, ProductRepository>();
        x.AddScoped<IRepository<OrderReadModel>, OrderRepository>();
        x.AddScoped<IRepository<OrderShippingTimeReadModel>, OrderShippingTimeRepository>();
        x.AddScoped<IRepository<ReviewReadModel>, ReviewRepository>();

        x.AddScoped<IProjection, CustomerProjection>();        
        x.AddScoped<IProjection, ProductProjection>();
        x.AddScoped<IProjection, OrderProjection>();
        x.AddScoped<IProjection, OrderShippingTimeeProjection>();
        x.AddScoped<IProjection, ReviewProjection>();
    })
    .Build();

host.Run();