using Models;

namespace Interfaces.Repositories
{
    public interface IPermissionRepository
    {
        Task<Permission> CreateAsync(Permission permission);
    }
}
