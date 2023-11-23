using CarvedRock.Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Admin.Repository;

// modified to use primary constructor
public class CarvedRockRepository(ProductContext context) : ICarvedRockRepository
{
    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await context.Products
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(m => m.Id == productId);
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product; // will have updated ID value
    }

    public async Task UpdateProductAsync(Product product)
    {
        try
        {
            context.Update(product);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (context.Products.Any(e => e.Id == product.Id))
            {
                // product exists and update exception is real
                throw;
            }
            // caught and swallowed exception can occur if the other update was a delete
        }
    }

    public async Task RemoveProductAsync(int productIdToRemove)
    {
        if (productIdToRemove == 3)
        {
            throw new Exception("Simulated exception trying to remove product!");
        }

        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productIdToRemove);
        if (product != null)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }

    public async Task<Category?> GetCategoryByIdAsync(int categoryId)
    {
        return await context.Categories.FirstOrDefaultAsync(m => m.Id == categoryId);
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await context.Categories.ToListAsync();
    }
}
