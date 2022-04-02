using CarvedRock.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Admin.Controllers;

public class ProductsController : Controller
{
    private List<ProductModel> Products { get; set; }
    public ProductsController()
    {
        Products = GetSampleProducts();
    }

    public IActionResult Index()
    {
        return View(Products);
    }

    public IActionResult Details(int id)
    {
        var product = Products.Find(p => p.Id == id);
        return product == null ? NotFound() : View(product);        
    }

    private List<ProductModel>? GetSampleProducts()
    {
        return new List<ProductModel> 
        {
            new ProductModel {Id = 1, Name = "Trailblazer", Price = 69.99M, IsActive = true,
                Description = "Great support in this high-top to take you to great heights and trails." },
            new ProductModel {Id = 2, Name = "Coastliner", Price = 49.99M, IsActive = true,
                Description = "Easy in and out with this lightweight but rugged shoe with great ventilation to get your around shores, beaches, and boats."},
            new ProductModel {Id = 3, Name = "Woodsman", Price = 64.99M, IsActive = true,
                Description = "All the insulation and support you need when wandering the rugged trails of the woods and backcountry." },
            new ProductModel {Id = 4, Name = "Basecamp", Price = 249.99M, IsActive = true,
                Description = "Great insulation and plenty of room for 2 in this spacious but highly-portable tent."},                            
        };
    }

}