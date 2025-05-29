using Models;
using Requests;

namespace Interfaces.Services
{
    public interface IUserService
    {
        public Task<User> GetActiveUserByUsernameAsync(LoginR request);
    }
}