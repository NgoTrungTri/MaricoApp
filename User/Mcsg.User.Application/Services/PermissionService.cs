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
    }
}
