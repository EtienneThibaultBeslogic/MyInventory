using Microsoft.EntityFrameworkCore;
using MyInventory.API.Models;

namespace MyInventory.API.Services.Settings
{
  public partial class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.ShoppingCart)
            .WithOne(d => d.Order)
            .HasForeignKey<Order>(d => d.ShoppingCartId);
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasMany(d => d.Products)
            .WithOne(d => d.ShoppingCart)
            .HasForeignKey<Order>(d => d.ShoppingCartId);
        });*/
    }
  }
}
