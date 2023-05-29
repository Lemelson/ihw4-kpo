using FluentValidation;
using Shop.Requests.Order;

namespace Shop.Validators.Order;

public class GetInfoRequestValidator : AbstractValidator<GetInfoRequest>
{
    // https://docs.fluentvalidation.net/en/latest/
    public GetInfoRequestValidator()
    {
        RuleFor(x => x.OrderId).NotNull();
        RuleFor(x => x.OrderId).GreaterThan(0);
    }
}