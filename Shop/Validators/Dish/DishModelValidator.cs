using FluentValidation;
using Shop.Models;

namespace Shop.Validators.Dish;

public class DishModelValidator : AbstractValidator<DishModel>
{
    // https://docs.fluentvalidation.net/en/latest/
    public DishModelValidator()
    {
        RuleFor(x => x.DishId).NotNull();
        RuleFor(x => x.DishId).GreaterThan(0);
        RuleFor(x => x.Quantity).NotNull();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}