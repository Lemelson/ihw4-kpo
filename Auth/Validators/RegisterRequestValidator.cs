using Auth.Requests.Account;
using FluentValidation;

namespace Auth.Validators;

/// <summary>
/// Register request validator
/// </summary>
public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    // https://docs.fluentvalidation.net/en/latest/
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Username).NotNull();
        RuleFor(x => x.Username).MaximumLength(50);
        RuleFor(x => x.Email).NotNull();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Email).MaximumLength(100);
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotNull();
        RuleFor(x => x.Password).MinimumLength(8);
        RuleFor(x => x.Role).MaximumLength(10);
    }
}