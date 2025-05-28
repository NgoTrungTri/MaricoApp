using MediatR;

namespace Requests
{
    public class PermissionDeleteR : IRequest<bool>
    {
        public int PermissionId { get; set; }
    }
}
