using Models;

namespace Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Role?> GetByIdAsync(int roleId);
        Task<bool> UserHasRoleAsync(int userId, int roleId);
    }
}
