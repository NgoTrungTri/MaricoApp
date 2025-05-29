using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DeletePermission(Permission permission)
        {
            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> ExistsAsync(Permission permission)
        {
            return _context.Permissions.AnyAsync(p => p.Action == permission.Action &&
                                                p.Resource == permission.Resource &&
                                                p.RoleId == permission.RoleId);
        }

        public async Task<Permission?> GetByIdAsync(int permissionId)
        {
            return await _context.Permissions.FindAsync(permissionId);
        }
    }
}