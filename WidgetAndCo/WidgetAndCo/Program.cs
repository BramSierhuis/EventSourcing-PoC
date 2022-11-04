using Microsoft.Extensions.Azure;
using WidgetAndCo.Clients;
using WidgetAndCo.Clients.Abstract;
using WidgetAndCo.Contexts;
using WidgetAndCo.Extensions;
using WidgetAndCo.Repositories;
using WidgetAndCo.Repositories.Abstract;
using WidgetAndCo.Services;
using WidgetAndCo.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

builder.AddKeyVaultSecrets();

builder.Services.AddDbContext<CosmosReadModelContext>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderShippingTimeRepository, OrderShippingTimeRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IProductImageClient, BlobClient>();

builder.Services.AddAzureServiceBusFactory();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IReviewService, ReviewService>();

builder.Services.AddControllers();

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