using WidgetAndCo;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Context;
using WidgetAndCo.Repositories;
using WidgetAndCo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EventStoreContext>();

builder.Services.AddTransient<IAggregateStore<CustomerAggregate>, EventStore<CustomerAggregate>>();
builder.Services.AddTransient<IService, CustomerService>();

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