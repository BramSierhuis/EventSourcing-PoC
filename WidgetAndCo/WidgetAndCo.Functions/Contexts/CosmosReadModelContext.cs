using Microsoft.EntityFrameworkCore;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Context;

public class CosmosReadModelContext : DbContext
{
    public CosmosReadModelContext(DbContextOptions<CosmosReadModelContext> options) : base(options)
    {
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("CosmosReadModelConnectionString") ??
                               throw new ArgumentNullException("CosmosReadModelConnectionString");
        optionsBuilder.UseCosmos(connectionString, "ReadModels");
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