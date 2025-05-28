using DTO;
using MediatR;

namespace Requests
{
    public class PermissionCreateR : IRequest<PermissionCreateDTO>
    {
        public string Action { get; set; } = null!;
        public string Resource { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
