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
        optionsBuilder.UseCosmos("AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "ReadModels");
    }
    
    protected override void OnModelCreating( ModelBuilder builder ) {
        builder.Entity<CustomerReadModel>().ToContainer("CustomerReadModel");
        builder.Entity<CustomerReadModel>().Property(x => x.Id).ToJsonProperty("id");        
        
        builder.Entity<ProductReadModel>().ToContainer("ProductReadModel");
        builder.Entity<ProductReadModel>().Property(x => x.Id).ToJsonProperty("id");
        
        builder.Entity<OrderReadModel>().ToContainer("OrderReadModel");
        builder.Entity<OrderReadModel>().Property(x => x.Id).ToJsonProperty("id");
        
        builder.Entity<OrderShippingTimeReadModel>().ToContainer("OrderShippingTimeReadModel");
        builder.Entity<OrderShippingTimeReadModel>().Property(x => x.Id).ToJsonProperty("id");
        
        builder.Entity<ReviewReadModel>().ToContainer("ReviewReadModel");
        builder.Entity<ReviewReadModel>().Property(x => x.Id).ToJsonProperty("id");
    }
    
    public DbSet<CustomerReadModel> Customers { get; set; }
    public DbSet<ProductReadModel> Products { get; set; }
    public DbSet<OrderReadModel> Orders { get; set; }
    public DbSet<OrderShippingTimeReadModel> OrderShippingTimes { get; set; }
    public DbSet<OrderShippingTimeReadModel> Reviews { get; set; }
}