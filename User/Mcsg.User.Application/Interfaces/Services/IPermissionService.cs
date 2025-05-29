using Models;

namespace Interfaces.Services
{
    public interface IPermissionService
    {
        public Task<Permission> CreateAsync(Permission permission);
    }
}
