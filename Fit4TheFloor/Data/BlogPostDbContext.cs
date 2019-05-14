using Microsoft.EntityFrameworkCore;
using Fit4TheFloor.Models;
using System;

namespace Fit4TheFloor.Data
{
    // This class reflects the database context for the 'FitPosts' database. Its build relies on Entity Framework Core (ORM). Data seeding is used to manage application questions until the Admin feature to do same is ready to deploy.
    public class BlogPostDbContext : DbContext
    {
        public BlogPostDbContext(DbContextOptions<BlogPostDbContext> options) : base(options)
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
        public DbSet<BlogPost> BlogPosts { get; set; }

    }
}