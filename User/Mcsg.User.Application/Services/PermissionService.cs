using Interfaces.Repositories;
using Interfaces.Services;
using Models;

namespace Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            this._permissionRepository = permissionRepository;
        }

        public Task<Permission> CreateAsync(Permission permission)
        {
            return _permissionRepository.CreateAsync(permission);
        }

        public async Task<bool> DeletePermission(Permission permission)
        {
            return await _permissionRepository.DeletePermission(permission);
        }

        public Task<bool> ExistsAsync(Permission permission)
        {
            return _permissionRepository.ExistsAsync(permission);
        }

        public Task<Permission?> GetByIdAsync(int permissionId)
        {
            return _permissionRepository.GetByIdAsync(permissionId);
        }
    }
}
