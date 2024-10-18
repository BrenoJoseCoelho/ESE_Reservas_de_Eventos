using Microsoft.EntityFrameworkCore;
using Promocoes.Models;

namespace Promocoes.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Campaign> Campaign { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Promotion> Promotions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Campaign
        modelBuilder.Entity<Campaign>().HasKey(e => e.Id);

        //Coupon
        modelBuilder.Entity<Coupon>().HasKey(e => e.Id);

        //Promotion
        modelBuilder.Entity<Promotion>().HasKey(e => e.Id);
    }
}