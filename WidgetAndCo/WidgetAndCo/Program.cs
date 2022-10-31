using WidgetAndCo;
using WidgetAndCo.Contexts;
using WidgetAndCo.Extensions;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Repositories;
using WidgetAndCo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CosmosReadModelContext>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductRepository>();

builder.Services.AddAzureServiceBusFactory();

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