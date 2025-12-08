using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManeger : ControllerBase
    {

        [HttpGet("GetAllProjects")]
       public IActionResult GetAll()
        {
            return Ok("200");
        }
    }
}
