using FluentValidation;
using Requests;

namespace Validators
{
    public class PermissionDeleteV : AbstractValidator<PermissionDeleteR>
    {
        public PermissionDeleteV()
        {
            RuleFor(x => x.PermissionId).NotEmpty();
        }
    }
}
