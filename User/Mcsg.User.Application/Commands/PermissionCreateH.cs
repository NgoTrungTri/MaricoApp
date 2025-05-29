using DTO;
using FluentValidation;
using MediatR;
using Models;
using Persistence;
using Requests;
using Validators;

public class PermissionCreateH : IRequestHandler<PermissionCreateR, PermissionCreateDTO>
{
    private readonly IUserDbContext _context;

    public PermissionCreateH(UserDbContext context)
    {
        _context = context;
    }

    public async Task<PermissionCreateDTO> Handle(PermissionCreateR request, CancellationToken cancellationToken)
    {
        var vr = new PermissionCreateV().Validate(request);
        if (!vr.IsValid)
        {
            var errors = vr.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            throw new ValidationException(vr.Errors.ToString());
        }

        var role = await _context.Roles.FindAsync(request.RoleId);
        if (role == null)
        {
            throw new Exception("Role does not exist");
        }

        var permission = new Permission
        {
            Action = request.Action,
            Resource = request.Resource,
            RoleId = request.RoleId
        };

        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync(cancellationToken);

        return new PermissionCreateDTO
        {
            Action = permission.Action,
            Resource = permission.Resource,
            RoleId = (int)permission.RoleId
        };
    }
}
