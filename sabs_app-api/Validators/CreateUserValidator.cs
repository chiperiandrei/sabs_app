using FluentValidation;
using sabs_app_api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sabs_app_api.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Password).NotEmpty()
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
                .WithMessage("Password should not be empty")
                .Length(10)
                .WithMessage("Password should haave 10 characters")
            
                .Must(BeAValidPhoneNumber)
                .WithMessage("Password should haave 10 numbers");


        }
        protected bool BeAValidPhoneNumber(string input)
        {
            Regex ip = new Regex(@"\b\d{10}\b");
            MatchCollection result = ip.Matches(input);
            return result.Count > 0;
        }
    }
}
