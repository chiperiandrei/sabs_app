using FluentValidation;
using sabs_app_api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sabs_app_api.Validators
{
    public class AddPendingIPAdressValidator : AbstractValidator<AddPendingIPAdress>
    {
        public AddPendingIPAdressValidator()
        {
            RuleFor(e => e.IPAdress)
                .NotEmpty()
                .WithMessage("Ip should not be empty")
                .Must(BeAValidIPAdress)
                .WithMessage("Must be a valid ip adress");
        }
        protected bool BeAValidIPAdress(string input)
        {
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection result = ip.Matches(input);
            return result.Count>0;
        }
    }
}
