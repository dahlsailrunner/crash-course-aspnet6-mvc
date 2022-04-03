using CarvedRock.Admin.Models;
using CarvedRock.Admin.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarvedRock.Admin.DomainLogic;

public class ProductLogic : IProductLogic
{
    private readonly ICarvedRockRepository _repo;

    public ProductLogic(ICarvedRockRepository repo)
    {
        _repo = repo;
    }


    public async Task<List<ProductModel>> GetAllProducts()
    {
        var products = await _repo.GetAllProductsAsync();

        // converts products from DB to product models
        return products.Select(ProductModel.FromProduct).ToList();

        // the above is more terse syntax for:
        //var models = new List<ProductModel>();
        //foreach (var product in products)
        //{
        //    models.Add(ProductModel.FromProduct(product));
        //}
        //return models;
    }

    public async Task<ProductModel?> GetProductById(int id)
    {
        var product = await _repo.GetProductByIdAsync(id);
        return product == null ? null : ProductModel.FromProduct(product);
    }

    public async Task AddNewProduct(ProductModel productToAdd)
    {
        var productToSave = productToAdd.ToProduct();
        if (productToSave.CategoryId.HasValue)
        {
            productToSave.Category = await _repo.GetCategoryByIdAsync(productToSave.CategoryId.Value);
        }
        await _repo.AddProductAsync(productToSave);
    }

    public async Task RemoveProduct(int id)
    {
        await _repo.RemoveProductAsync(id);
    }

    public async Task UpdateProduct(ProductModel productToUpdate)
    {
        var productToSave = productToUpdate.ToProduct();
        if (productToSave.CategoryId.HasValue)
        {
            productToSave.Category = await _repo.GetCategoryByIdAsync(productToSave.CategoryId.Value);
        }
        await _repo.UpdateProductAsync(productToSave);
    }

    public async Task<ProductModel> InitializeProductModel()
    {
        return new ProductModel { AvailableCategories = await GetAvailableCategoriesFromDb() };
    }

    public async Task GetAvailableCategories(ProductModel productModel)
    {
        productModel.AvailableCategories = await GetAvailableCategoriesFromDb();
    }

    private async Task<List<SelectListItem>> GetAvailableCategoriesFromDb()
    {
        var cats = await _repo.GetAllCategoriesAsync();
        var returnList = new List<SelectListItem> { new("None", "") };
        var availCatList = cats.Select(cat => new SelectListItem(cat.Name, cat.Id.ToString())).ToList();
        returnList.AddRange(availCatList);
        return returnList;
    }
}

