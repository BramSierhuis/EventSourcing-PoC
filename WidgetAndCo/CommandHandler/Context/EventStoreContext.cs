using Microsoft.EntityFrameworkCore;
using Stream = WidgetAndCo.Models.Stream;

namespace CommandHandler.Context;

public class EventStoreContext : DbContext
{
    public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options)
    {
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos("AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "EventStore");
    }
    
    protected override void OnModelCreating( ModelBuilder builder ) {
        builder.HasDefaultContainer("Streams");
        builder.Entity<Stream>().ToContainer("Streams");
        builder.Entity<Stream>().Property(x => x.Id).ToJsonProperty("id");
    }
    
    public DbSet<Stream> Streams { get; set; }
}