using Integrated_Construction_Management_System_ICMS.Services.Classes;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForemanController : ControllerBase
    {
        private readonly IForemanService _foreman;

        public ForemanController(IForemanService foreman)
        {
            _foreman = foreman;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var foreman = await _foreman.GetByIdAsync(id);

            if (foreman == null)
                return NotFound();

            return Ok(foreman);
        }
    }
}
