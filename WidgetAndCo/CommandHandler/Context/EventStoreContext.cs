using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stream = WidgetAndCo.Models.Stream;

namespace CommandHandler.Context;

public class EventStoreContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public EventStoreContext(DbContextOptions<EventStoreContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetValue<string>("CosmosEventStoreConnectionString") ??
                               throw new ArgumentNullException("CosmosEventStoreConnectionString");
        
        optionsBuilder.UseCosmos(connectionString, "EventStore");
    }
    
    protected override void OnModelCreating( ModelBuilder builder ) {
        builder.HasDefaultContainer("Streams");
        builder.Entity<Stream>().ToContainer("Streams");
        builder.Entity<Stream>().Property(x => x.Id).ToJsonProperty("id");
    }
    
    public DbSet<Stream> Streams { get; set; }
}