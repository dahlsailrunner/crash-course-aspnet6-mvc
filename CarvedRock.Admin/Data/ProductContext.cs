using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Admin.Data;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    public string DbPath { get; set; }

    public ProductContext(IConfiguration config)
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(path, config.GetConnectionString("ProductDbFilename"));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public void SeedInitialData()
    {
        if (Products.Any())
        {
            Products.RemoveRange(Products);
            SaveChanges();
        }

        if (Categories.Any())
        {
            Categories.RemoveRange(Categories);
            SaveChanges();
        }

        var footwearCat = new Category { Id = 1000, Name = "Footwear" };
        var equipmentCat = new Category { Id = 2000, Name = "Equipment" };

        Products.Add(new Product
        {
            Id = 1, Name = "Trailblazer", Price = 69.99M, IsActive = true, Category = footwearCat,
            Description = "Great support in this high-top to take you to great heights and trails."
        });
        Products.Add(new Product
        {
            Id = 2, Name = "Coastliner", Price = 49.99M, IsActive = true, Category = footwearCat,
            Description =
                "Easy in and out with this lightweight but rugged shoe with great ventilation to get your around shores, beaches, and boats."
        });
        Products.Add(new Product
        {
            Id = 3, Name = "Woodsman", Price = 64.99M, IsActive = true, Category = footwearCat,
            Description =
                "All the insulation and support you need when wandering the rugged trails of the woods and backcountry."
        });
        Products.Add(new Product
        {
            Id = 4, Name = "Basecamp", Price = 249.99M, IsActive = true, Category = equipmentCat,
            Description = "Great insulation and plenty of room for 2 in this spacious but highly-portable tent."
        });
        Categories.Add(footwearCat);
        Categories.Add(equipmentCat);

        SaveChanges();
    }
}

