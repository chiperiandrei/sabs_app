using FluentValidation;
using sabs_app_api.DTOs;
using System.Text.RegularExpressions;

namespace sabs_app_api.Validators
{
    public class AddIPAdressValidator : AbstractValidator<AddIPAdress>
    {
        public AddIPAdressValidator()
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
            return result.Count > 0;
        }
    }
}
