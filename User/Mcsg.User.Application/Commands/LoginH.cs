using DTO;
using Interfaces.Services;
using MediatR;
using Requests;
using Services;
using System.ComponentModel.DataAnnotations;
using Validators;

namespace Commands
{
    public class LoginH : IRequestHandler<LoginR, LoginDTO>
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public LoginH(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        public async Task<LoginDTO> Handle(LoginR request, CancellationToken cancellationToken)
        {
            var vr = new LoginV().Validate(request);
            if (!vr.IsValid)
            {
                var errors = vr.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                throw new ValidationException(string.Join("; ", errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}")));
            }

            var user = await _userService.GetActiveUserByUsernameAsync(request);

            if (user == null || request.Password != "1")
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

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
