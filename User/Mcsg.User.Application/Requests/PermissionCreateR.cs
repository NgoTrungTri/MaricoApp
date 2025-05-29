using DTO;
using MediatR;

namespace Requests
{
    public class PermissionCreateR : IRequest<PermissionCreateDTO>
    {
        public int UsId { get; set; }
        public string Action { get; set; }
        public string Resource { get; set; }
        public int RoleId { get; set; }
    }
}
