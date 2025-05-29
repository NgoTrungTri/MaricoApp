using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IUserDbContext _context;

        public RoleRepository(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetByIdAsync(int roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        public async Task<bool> UserHasRoleAsync(int userId, int roleId)
        {
            return await _context.UserRoles.AnyAsync(ur => ur.UsId == userId && ur.RoleId == roleId);
        }
    }
}
