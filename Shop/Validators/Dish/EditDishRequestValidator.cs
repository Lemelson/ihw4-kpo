using FluentValidation;
using Shop.Requests.Dish;

namespace Shop.Validators.Dish;

public class EditDishRequestValidator : AbstractValidator<EditDishRequest>
{
    // https://docs.fluentvalidation.net/en/latest/
    public EditDishRequestValidator()
    {
        RuleFor(x => x.Signature).NotNull();
        RuleFor(x => x.Signature).MaximumLength(255);
        RuleFor(x => x.Name).MaximumLength(100);
    }
}