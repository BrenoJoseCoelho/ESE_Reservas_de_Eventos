﻿using EventosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventosApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<Enterprise> Enterprises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // event
        modelBuilder.Entity<Event>().HasKey(e => e.Id);



        //enterprise
        modelBuilder.Entity<Enterprise>().HasKey(e => e.Id);
    }
}
