using Models;

namespace Interfaces.Repositories
{
    public interface IPermissionRepository
    {
        Task<Permission> CreateAsync(Permission permission);
        Task<bool> ExistsAsync(Permission permission);
        Task<Permission?> GetByIdAsync(int permissionId);
        Task<bool> DeletePermission(Permission permission);

    }
}
