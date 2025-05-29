using FluentValidation;
using Interfaces.Services;
using MediatR;
using Persistence;
using Requests;
using Validators;

public class PermissionDeleteH : IRequestHandler<PermissionDeleteR, bool>
{
    private readonly IUserDbContext _context;
    private readonly IPermissionService _permissionService;

    public PermissionDeleteH(UserDbContext context, IPermissionService permissionService)
    {
        _context = context;
        _permissionService = permissionService;
    }

    public async Task<bool> Handle(PermissionDeleteR request, CancellationToken cancellationToken)
    {
        var vr = new PermissionDeleteV().Validate(request);
        if (!vr.IsValid)
        {
            var errors = vr.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            throw new ValidationException(vr.Errors.ToString());
        }

        var permission = await _permissionService.GetByIdAsync(request.PermissionId);
        if (permission == null)
            return false;

        var hasDelete = await _permissionService.DeletePermission(permission);
        if (!hasDelete)
            return false;

        return true;
    }
}
