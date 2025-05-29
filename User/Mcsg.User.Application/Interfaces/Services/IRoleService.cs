using Models;

namespace Interfaces.Services
{
    public interface IRoleService
    {
        Task<Role?> GetByIdAsync(int roleId);
        Task<bool> UserHasRoleAsync(int userId, int roleId);
    }
}
