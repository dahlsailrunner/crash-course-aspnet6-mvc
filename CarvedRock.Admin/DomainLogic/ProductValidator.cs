using CarvedRock.Admin.Models;
using CarvedRock.Admin.Repository;
using FluentValidation;

namespace CarvedRock.Admin.DomainLogic;

public class ProductValidator : AbstractValidator<ProductModel>
{
    public ProductValidator(ICarvedRockRepository repo)
    {
        RuleFor(p => p).MustAsync(async (productModel, cancellation) =>
        {
            if (productModel.CategoryId == 0) return true;
            var cat = await repo.GetCategoryByIdAsync(productModel.CategoryId);
            if (cat?.Name != "Footwear") return true;

            return productModel.Price <= 200.00M; // greater than 200 is a problem
        }).WithMessage("Price cannot be more than 200.00 for footwear.");
    }
}
