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
        x.AddScoped<IProjection, CustomerProjection>();
    })
    .Build();

host.Run();