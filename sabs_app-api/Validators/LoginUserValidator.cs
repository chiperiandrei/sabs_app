using FluentValidation;
using sabs_app_api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sabs_app_api.Validators
{
    public class LoginUserValidator:AbstractValidator<LoginUser>
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
