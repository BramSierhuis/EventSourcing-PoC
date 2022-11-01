using Microsoft.EntityFrameworkCore;
using WidgetAndCo.Clients;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Contexts;

public class CosmosReadModelContext : DbContext
{
    private readonly IKeyVaultClient _keyVaultClient;
    public CosmosReadModelContext(DbContextOptions<CosmosReadModelContext> options, IKeyVaultClient keyVaultClient) : base(options)
    {
        _keyVaultClient = keyVaultClient;
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(_keyVaultClient.GetKey("CosmosReadModelConnectionString"), "ReadModels");
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
    public DbSet<OrderShippingTimeReadModel> OrderShippingTime { get; set; }
    public DbSet<ReviewReadModel> Reviews { get; set; }
}