using DTO;
using MediatR;

namespace Requests
{
    public class LoginR : IRequest<LoginDTO>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
