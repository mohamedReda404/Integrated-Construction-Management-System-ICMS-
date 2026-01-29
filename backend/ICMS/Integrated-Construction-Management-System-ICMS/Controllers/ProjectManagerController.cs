using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagerController : ControllerBase
    {
        private readonly IProjectManagerService _manager;

        public ProjectManagerController(IProjectManagerService manager)
        {
            _manager = manager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var managerEntity = await _manager.GetByIdAsync(id);

            if (managerEntity == null)
                return NotFound();

            return Ok(managerEntity);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] ProjectManager manager)
        {
            var createdManager = await _manager.AddAsync(manager);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdManager.ProjectManagerId },
                createdManager
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _manager.DeleteAsync(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }
    }
}
