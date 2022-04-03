using CarvedRock.Admin.Models;

namespace CarvedRock.Admin.DomainLogic;

public interface IProductLogic
{
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel?> GetProductById(int id);
    Task AddNewProduct(ProductModel productToAdd);
    Task RemoveProduct(int id);
    Task UpdateProduct(ProductModel productToUpdate);
    Task<ProductModel> InitializeProductModel();
    Task GetAvailableCategories(ProductModel productModel);
}
