using Models;

namespace Interfaces.Services
{
    public interface IPermissionService
    {
        public Task<Permission> CreateAsync(Permission permission);
        public Task<bool> ExistsAsync(Permission permission);
        public Task<Permission?> GetByIdAsync(int permissionId);
        Task<bool> DeletePermission(Permission permission);
    }
}
