using FluentValidation;
using Requests;

namespace Validators
{
    public class LoginV : AbstractValidator<LoginR>
    {
        public LoginV()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
