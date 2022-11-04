using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WidgetAndCo.Context;
using WidgetAndCo.Functions.Projections;
using WidgetAndCo.Functions.Repositories;
using WidgetAndCo.Functions.Repositories.Abstract;
using WidgetAndCo.Models.ReadModels;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(x =>
    {
        x.AddDbContext<CosmosReadModelContext>();
        x.AddScoped<ICustomerRepository, CustomerRepository>();
        x.AddScoped<IProductRepository, ProductRepository>();
        x.AddScoped<IOrderRepository, OrderRepository>();
        x.AddScoped<IOrderShippingTimeRepository, OrderShippingTimeRepository>();
        x.AddScoped<IReviewRepository, ReviewRepository>();

        x.AddScoped<IProjection, CustomerProjection>();        
        x.AddScoped<IProjection, ProductProjection>();
        x.AddScoped<IProjection, OrderProjection>();
        x.AddScoped<IProjection, OrderShippingTimeeProjection>();
        x.AddScoped<IProjection, ReviewProjection>();
    })
    .Build();

host.Run();