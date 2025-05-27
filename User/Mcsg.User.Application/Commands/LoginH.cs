using DTO;
using Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Requests;
using System.ComponentModel.DataAnnotations;
using Validators;

namespace Commands
{
    public class LoginH : IRequestHandler<LoginR, LoginDTO>
    {
        private readonly UserDbContext _context;
        private readonly IJwtService _jwtService;

        public LoginH(UserDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<LoginDTO> Handle(LoginR request, CancellationToken cancellationToken)
        {
            var vr = new LoginV().Validate(request);
            if (!vr.IsValid)
            {
                var errors = vr.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                throw new ValidationException(vr.Errors.ToString());
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UsName == request.Username && u.UsIsActive);
            if (user == null || request.Password != "1")
                throw new UnauthorizedAccessException("Invalid credentials");

            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            return new LoginDTO
            {
                UsFullName = user.UsFullName,
                UsJob = user.UsJob,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
