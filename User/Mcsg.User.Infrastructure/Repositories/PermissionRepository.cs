using Interfaces.Repositories;
using Models;

namespace Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IUserDbContext _context;

        public PermissionRepository(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<Permission> CreateAsync(Permission permission)
        {
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }
    }
}