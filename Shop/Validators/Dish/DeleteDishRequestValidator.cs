using FluentValidation;
using Shop.Requests.Dish;

namespace Shop.Validators.Dish;

public class DeleteDishRequestValidator : AbstractValidator<DeleteDishRequest>
{
    // https://docs.fluentvalidation.net/en/latest/
    public DeleteDishRequestValidator()
    {
        RuleFor(x => x.Signature).NotNull();
        RuleFor(x => x.Signature).MaximumLength(255);
        RuleFor(x => x.DishId).NotNull();
        RuleFor(x => x.DishId).GreaterThan(0);
    }
}