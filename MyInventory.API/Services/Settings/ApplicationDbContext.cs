using Microsoft.EntityFrameworkCore;
using MyInventory.API.Models;
using MyInventory.API.Models.Dtos;

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

    public virtual DbSet<Shape> Shapes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}
