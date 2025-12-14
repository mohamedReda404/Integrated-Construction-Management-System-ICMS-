using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagerController(IProjectManager manager) : ControllerBase
    {
        private readonly IProjectManager _manager = manager;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var foreman = await _manager.Get(id);
            if (foreman == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foreman);
            }
        }


        [HttpPost(" ")]
        public async Task<IActionResult> AddNew([FromBody] ProjectManager manager)
        {
            var mmangaer = await _manager.AddNew(manager);
                    return CreatedAtAction(
                    nameof(GetById),
                    new { id = mmangaer.ProjectManagerId },
                    mmangaer
                     );

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _manager.Delete(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }


    }
}
