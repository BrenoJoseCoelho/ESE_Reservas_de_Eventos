using Feedback.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<FeedbackNote> FeedbackNotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Feedback
        modelBuilder.Entity<FeedbackNote>().HasKey(e => e.Id);
        modelBuilder.Entity<FeedbackNote>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

    }
}
