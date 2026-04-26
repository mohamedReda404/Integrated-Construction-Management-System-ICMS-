using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("me")]
    [ApiController]
    public class AcountsController(UserManager<ApplicationUser> userManager) : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager= userManager;

        //[HttpGet("Info")]
        //public Task<IActionResult> info(int id)
        //{

        //}
    }
}
