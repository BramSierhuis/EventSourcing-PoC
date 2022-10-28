using Microsoft.EntityFrameworkCore;
using WidgetAndCo.Models.ReadModels;
using Stream = WidgetAndCo.Models.Stream;

namespace WidgetAndCo.Context;

public class CosmosReadModelContext : DbContext
{
    public CosmosReadModelContext(DbContextOptions<CosmosReadModelContext> options) : base(options)
    {
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos("AccountEndpoint=https://cosmoseventstore.documents.azure.com:443/;AccountKey=fqtFVjixL67Ot5JsLUbZFUwy5LCi9oUThXrFKOgt4BCIxPbpRrwtN3x7tFULM30PfTJjTsxv9gXmCpqCWRcqQg==;", "EventStore");
    }
    
    protected override void OnModelCreating( ModelBuilder builder ) {
        builder.Entity<CustomerReadModel>().ToContainer("CustomerReadModel");
        builder.Entity<CustomerReadModel>().Property(x => x.Id).ToJsonProperty("id");        
        
        builder.Entity<CustomerReadModel>().ToContainer("ProductReadModel");
        builder.Entity<ProductReadModel>().Property(x => x.Id).ToJsonProperty("id");
    }
    
    public DbSet<CustomerReadModel> Customers { get; set; }
    public DbSet<ProductReadModel> Products { get; set; }
}