using Interfaces.Repositories;
using Interfaces.Services;
using Models;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly IUserDbContext _context;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IUserDbContext context, IRoleRepository roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
        }

        public Task<Role?> GetByIdAsync(int roleId)
        {
            return _roleRepository.GetByIdAsync(roleId);
        }

        public Task<bool> UserHasRoleAsync(int userId, int roleId)
        {
            return _roleRepository.UserHasRoleAsync(userId, roleId);
        }
    }
}
