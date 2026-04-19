using Integrated_Construction_Management_System_ICMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterRequest = Integrated_Construction_Management_System_ICMS.Contracts.Requests.RegisterRequest;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemebersController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        [HttpPost("AddMembers")]
        public async Task<IActionResult> Register(
                 [FromBody] AddMembersRequest request,
                CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterAsyncMember(request, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }
    }
}
