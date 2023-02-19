using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            Name = "Samosa",
            Price = 15,
            Description = "Lorem",
            ImageUrl = string.Empty,
            CategoryName = "Appetizer"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id           = 2,
            Name         = "Paneer Tikka",
            Price        = 13.99,
            Description  = "Ipsum",
            ImageUrl     = string.Empty,
            CategoryName = "Appetizer"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id           = 3,
            Name         = "Sweet Pie",
            Price        = 10.99,
            Description  = "Dolor",
            ImageUrl     = string.Empty,
            CategoryName = "Entree"
        });
    }
}