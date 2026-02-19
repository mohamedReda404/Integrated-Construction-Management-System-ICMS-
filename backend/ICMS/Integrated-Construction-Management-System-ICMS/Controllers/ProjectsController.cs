
using Microsoft.AspNetCore.Authorization;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var responce = await _projectService.GetAll(cancellationToken);
            if (responce != null){ var responceMapping = responce.Adapt<List<ProjectResponce>>();  return Ok(responceMapping); }
            else {return NotFound();}
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var responce = await _projectService.GetId(id, cancellationToken);

            if (responce != null){var responceMapping = responce.Adapt<ProjectResponce>();  return Ok(responceMapping);}
            else{ return NotFound();}
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(ProjectRequest projectRequest, CancellationToken cancellationToken)
        {
            var NewProject = await _projectService.AddNew(projectRequest.Adapt<Project>(), cancellationToken);
            return CreatedAtAction(nameof(Get), NewProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProjectRequest projectRequest, CancellationToken cancellationToken)
        {
            var editproject = await _projectService.Update(id, projectRequest.Adapt<Project>(), cancellationToken);
            if (!editproject) { return NotFound(); }
            else { return NoContent(); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isDelete=await _projectService.Delete(id, cancellationToken);
            if(!isDelete) { return NotFound(); } 
            else { return NoContent(); }   
        }
    }
}