using CarvedRock.Admin.Data;

namespace CarvedRock.Admin.Repository;

public interface ICarvedRockRepository
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int productId);
    Task<Product> AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task RemoveProductAsync(int productIdToRemove);
}

