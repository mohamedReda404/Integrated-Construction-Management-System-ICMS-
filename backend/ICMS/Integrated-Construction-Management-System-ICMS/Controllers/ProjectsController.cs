
namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var responce = await _projectService.GetAll();
            if (responce != null){ var responceMapping = responce.Adapt<List<ProjectResponce>>();  return Ok(responceMapping); }
            else {return NotFound();}
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var responce = await _projectService.GetId(id);

            if (responce != null){var responceMapping = responce.Adapt<ProjectResponce>();  return Ok(responceMapping);}
            else{ return NotFound();}
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(ProjectRequest projectRequest)
        {
            var NewProject = await _projectService.AddNew(projectRequest.Adapt<Project>());
            return CreatedAtAction(nameof(Get), NewProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProjectRequest projectRequest)
        {
            var editproject = await _projectService.Update(id, projectRequest.Adapt<Project>());
            if (!editproject) { return NotFound(); }
            else { return NoContent(); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDelete=await _projectService.Delete(id);
            if(!isDelete) { return NotFound(); } 
            else { return NoContent(); }   
        }
    }
}