using Microsoft.EntityFrameworkCore;
using Fit4TheFloor.Models;
using System;

namespace Fit4TheFloor.Data
{
    // This class reflects the database context for the 'FitSales' database. Its build relies on Entity Framework Core (ORM). Data seeding is used to manage application questions until the Admin feature to do same is ready to deploy.
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {

        }

        // Seed data
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Question>().HasData(
        //    new Object { ID = 1, ... }
        //);
        //}

        // build tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Print> Prints { get; set; }

    }
}