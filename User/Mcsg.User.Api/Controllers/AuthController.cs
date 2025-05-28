using DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Requests;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginDTO>> Login([FromBody] LoginR request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("permission")]
        public async Task<ActionResult<PermissionCreateDTO>> PermissionCreate([FromBody] PermissionCreateR request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("permission")]
        public async Task<IActionResult> RemovePermission([FromBody] PermissionDeleteR request)
        {
            var result = await _mediator.Send(request);
            if (!result)
                return NotFound("Permission not found");
            return Ok();
        }

    }
}
