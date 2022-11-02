using WidgetAndCo.Clients;
using WidgetAndCo.Clients.Abstract;
using WidgetAndCo.Contexts;
using WidgetAndCo.Extensions;
using WidgetAndCo.Repositories;
using WidgetAndCo.Services;
using WidgetAndCo.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IKeyVaultClient, KeyVaultClient>();

builder.Services.AddDbContext<CosmosReadModelContext>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<OrderShippingTimeRepository>();
builder.Services.AddScoped<ReviewRepository>();

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