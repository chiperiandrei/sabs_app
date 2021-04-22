using FluentValidation;
using sabs_app_api.DTOs;

namespace sabs_app_api.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUser>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password should not be empty");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email should not be empty")
                .EmailAddress()
                .WithMessage("Insert a valid email address");

        }
    }
}
