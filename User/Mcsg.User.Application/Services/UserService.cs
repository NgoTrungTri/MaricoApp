using Interfaces.Repositories;
using Interfaces.Services;
using Models;
using Requests;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetActiveUserByUsernameAsync(LoginR request)
        {
            return await _userRepository.GetActiveUserByUsernameAsync(request.Username);
        }
    }
}
