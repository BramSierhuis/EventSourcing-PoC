using WidgetAndCo;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Context;
using WidgetAndCo.Repositories;
using WidgetAndCo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EventStoreContext>();

builder.Services.AddTransient<IAggregateStore<CustomerAggregate>, EventStore<CustomerAggregate>>();
builder.Services.AddTransient<IAggregateStore<ProductAggregate>, EventStore<ProductAggregate>>();
builder.Services.AddTransient<IAggregateStore<OrderAggregate>, EventStore<OrderAggregate>>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();