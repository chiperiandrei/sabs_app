using FluentValidation;
using sabs_app_api.DTOs;
using System.Text.RegularExpressions;

namespace sabs_app_api.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password should not be empty")
                .MinimumLength(6)
                .WithMessage("Password should haave minimum 6 characters");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Firstname should not be empty");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Firstname should not be empty");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email should not be empty")
                .EmailAddress()
                .WithMessage("Insert a valid email address");
            RuleFor(x => x.Phone).NotEmpty()
                .WithMessage("Phone should not be empty")
                .Length(10)
                .WithMessage("Phone should haave 10 characters")

                .Must(BeAValidPhoneNumber)
                .WithMessage("Phone should be a valid phone number");


        }
        protected bool BeAValidPhoneNumber(string input)
        {
            Regex ip = new Regex(@"\b\d{10}\b");
            MatchCollection result = ip.Matches(input);
            return result.Count > 0;
        }
    }
}
