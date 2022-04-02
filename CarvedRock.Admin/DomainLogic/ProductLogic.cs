using CarvedRock.Admin.Models;
using CarvedRock.Admin.Repository;

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
        await _repo.AddProductAsync(productToAdd.ToProduct());
    }

    public async Task RemoveProduct(int id)
    {
        await _repo.RemoveProductAsync(id);
    }

    public async Task UpdateProduct(ProductModel productToUpdate)
    {
        await _repo.UpdateProductAsync(productToUpdate.ToProduct());
    }
}

