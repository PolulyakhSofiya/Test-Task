using HotlineParcer.Data;
using Microsoft.EntityFrameworkCore;

namespace HotlineParcer
{
  public class Context : DbContext
    {
    public DbSet<Product> Products { get; set; }

    public Context(DbContextOptions<Context> options)
      : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Product>(etb =>
      {
        etb.HasKey(e => e.Id);
        etb.Property(e => e.Id).ValueGeneratedOnAdd();
        etb.ToTable("Products");
      }
      );
    }
  }
}