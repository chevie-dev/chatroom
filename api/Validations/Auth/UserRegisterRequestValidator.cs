using api.Models.Auth;
using FluentValidation;

namespace api.Validations.Auth;

public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidator()
    {
        RuleFor(user => user.Username).NotNull();
        RuleFor(user => user.Username).MinimumLength(4);
        RuleFor(user => user.Username).MaximumLength(15);
        RuleFor(user => user.Password).NotNull();
        RuleFor(user => user.Password).MinimumLength(4);
    }
}
