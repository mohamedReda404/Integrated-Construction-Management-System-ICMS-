using Azure.Core;
using Integrated_Construction_Management_System_ICMS.Extentions;
using Integrated_Construction_Management_System_ICMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("me")]
    [ApiController]
    [Authorize]
    public class AcountsController(UserManager<ApplicationUser> userManager
        , IAuthService authService) : ControllerBase

    {   private readonly UserManager<ApplicationUser> _userManager= userManager;
        private readonly IAuthService _authService= authService;

        [HttpGet("Info")]
        public async Task<IActionResult> info()
        {
            var result = await _authService.Getprofile(User.GetUserId()!);
            return Ok(result);
        }

        [HttpGet("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateAccountUserRequest request)
        {
            await _authService.UpdateUserprofile(User.GetUserId()!, request);
            return NoContent();
        }
    }
}
