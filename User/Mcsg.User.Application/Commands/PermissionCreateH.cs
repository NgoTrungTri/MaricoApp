using DTO;
using FluentValidation;
using Interfaces.Services;
using MediatR;
using Models;
using Persistence;
using Requests;
using Validators;

public class PermissionCreateH : IRequestHandler<PermissionCreateR, PermissionCreateDTO>
{
    private readonly IUserDbContext _context;
    private readonly IPermissionService _permissionService;
    private readonly IRoleService _roleService;

    public PermissionCreateH(UserDbContext context, IPermissionService permissionService, IRoleService roleService)
    {
        _context = context;
        _permissionService = permissionService;
        _roleService = roleService;
    }

    public async Task<PermissionCreateDTO> Handle(PermissionCreateR request, CancellationToken cancellationToken)
    {
        var vr = new PermissionCreateV().Validate(request);
        if (!vr.IsValid)
        {
            var errors = vr.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            throw new ValidationException(vr.Errors.ToString());
        }

        var role = await _roleService.GetByIdAsync(request.RoleId);
        if (role == null)
        {
            throw new Exception("Role does not exist");
        }
        var hasRole = await _roleService.UserHasRoleAsync(request.UsId, request.RoleId);
        if (!hasRole)
        {
            throw new Exception("Invalid Role!");
        }

        var permission = new Permission
        {
            Action = request.Action,
            Resource = request.Resource,
            RoleId = request.RoleId
        };

        await _permissionService.CreateAsync(permission);

        return new PermissionCreateDTO
        {
            UserId = request.UsId,
            Action = permission.Action,
            Resource = permission.Resource,
            RoleId = (int)permission.RoleId
        };
    }
}
