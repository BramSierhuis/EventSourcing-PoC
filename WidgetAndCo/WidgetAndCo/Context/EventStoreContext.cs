using Microsoft.EntityFrameworkCore;
using Stream = WidgetAndCo.Models.Stream;

namespace WidgetAndCo.Context;

public class EventStoreContext : DbContext
{
    public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options)
    {
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos("AccountEndpoint=https://cosmoseventstore.documents.azure.com:443/;AccountKey=fqtFVjixL67Ot5JsLUbZFUwy5LCi9oUThXrFKOgt4BCIxPbpRrwtN3x7tFULM30PfTJjTsxv9gXmCpqCWRcqQg==;", "EventStore");
    }
    
    protected override void OnModelCreating( ModelBuilder builder ) {
        builder.HasDefaultContainer("Streams");
        builder.Entity<Stream>().ToContainer("Streams");

        builder.Entity<Stream>().HasPartitionKey("Id");
    }
    
    public DbSet<Stream> Streams { get; set; }
}