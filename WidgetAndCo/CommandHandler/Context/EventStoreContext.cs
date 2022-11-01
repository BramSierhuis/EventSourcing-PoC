using CommandHandler.Clients;
using Microsoft.EntityFrameworkCore;
using Stream = WidgetAndCo.Models.Stream;

namespace CommandHandler.Context;

public class EventStoreContext : DbContext
{
    private readonly IKeyVaultClient _keyVaultClient;
    
    public EventStoreContext(DbContextOptions<EventStoreContext> options, IKeyVaultClient keyVaultClient) : base(options)
    {
        _keyVaultClient = keyVaultClient;
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(_keyVaultClient.GetKey("CosmosDbEventStoreConnectionString"), "EventStore");
    }
    
    protected override void OnModelCreating( ModelBuilder builder ) {
        builder.HasDefaultContainer("Streams");
        builder.Entity<Stream>().ToContainer("Streams");
        builder.Entity<Stream>().Property(x => x.Id).ToJsonProperty("id");
    }
    
    public DbSet<Stream> Streams { get; set; }
}