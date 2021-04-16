using FluentValidation;
using sabs_app_api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        }
    }
}
