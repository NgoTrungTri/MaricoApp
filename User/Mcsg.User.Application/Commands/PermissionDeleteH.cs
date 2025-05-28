using FluentValidation;
using MediatR;
using Persistence;
using Requests;
using Validators;

public class PermissionDeleteH : IRequestHandler<PermissionDeleteR, bool>
{
    private readonly UserDbContext _context;

    public PermissionDeleteH(UserDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(PermissionDeleteR request, CancellationToken cancellationToken)
    {
        var vr = new PermissionDeleteV().Validate(request);
        if (!vr.IsValid)
        {
            var errors = vr.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            throw new ValidationException(vr.Errors.ToString());
        }
        var permission = await _context.Permissions.FindAsync(request.PermissionId);
        if (permission == null)
            return false;

        _context.Permissions.Remove(permission);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
