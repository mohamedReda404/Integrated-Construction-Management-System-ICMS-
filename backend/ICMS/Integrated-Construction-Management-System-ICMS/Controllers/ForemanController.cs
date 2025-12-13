using Integrated_Construction_Management_System_ICMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForemanController(IForeman formamn) : ControllerBase
    {
        //private readonly IForeman _foreman= formamn;


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute]int id)
        //{
        //    var foreman = await _foreman.Get(id);
        //    if (foreman == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
                
        //        return Ok(foreman);
        //    }
        //}
    }
}
