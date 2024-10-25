using Microsoft.EntityFrameworkCore;
using Promocoes.Models;

namespace Promocoes.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Promotion> Promotions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Campaign
        modelBuilder.Entity<Campaign>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Campaign>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        // Coupon
        modelBuilder.Entity<Coupon>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Coupon>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        // Promotion
        modelBuilder.Entity<Promotion>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Promotion>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}