using FluentValidation;
using Requests;

namespace Validators
{
    public class PermissionCreateV : AbstractValidator<PermissionCreateR>
    {
        public PermissionCreateV()
        {
            RuleFor(x => x.Action)
                .NotEmpty().WithMessage("Action is required.");

            RuleFor(x => x.Resource)
                .NotEmpty().WithMessage("Resource is required.");

            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("Invalid Id.");
        }
    }
}
