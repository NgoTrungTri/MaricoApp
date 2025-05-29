using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDbContext _context;

        public UserRepository(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetActiveUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UsName == username && u.UsIsActive);
        }
    }
}