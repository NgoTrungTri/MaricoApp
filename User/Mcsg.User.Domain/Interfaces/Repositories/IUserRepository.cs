using Models;

namespace Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetActiveUserByUsernameAsync(string username);
    }
}
