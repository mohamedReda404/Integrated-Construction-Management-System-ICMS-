

using Integrated_Construction_Management_System_ICMS.Extentions;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectsController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
           
            var responce = await _projectService.GetAll(cancellationToken);
            if (responce is null ){ return NotFound(); }
            var responceMapping = responce.Adapt<List<ProjectResponce>>(); return Ok(responceMapping);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var responce = await _projectService.GetId(id, cancellationToken);

            if (responce != null){var responceMapping = responce.Adapt<ProjectResponce>();  return Ok(responceMapping);}
            else{ return NotFound();}
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] ProjectRequest request, CancellationToken cancellationToken)
        {
            var NewProject = await _projectService.AddNew(request, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = NewProject.Id }, NewProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProjectRequest projectRequest, CancellationToken cancellationToken)
        {
            var editproject = await _projectService.Update(id, projectRequest, cancellationToken);
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

        [HttpGet("Count")]
        public async Task<IActionResult> Count(CancellationToken cancellationToken)
        {
            var CountResult= await _projectService.NomberOfProjects(cancellationToken);
            if(CountResult == 0)
            {
                return NotFound("You Have not any projects Now");
            }
            return Ok(CountResult);
        }

        [HttpGet("Completed")]
        public async Task<IActionResult> Completed(int id,CancellationToken cancellationToken)
        {
            var CountResult = await _projectService.Conpleted(cancellationToken);
            if (CountResult == 0)
            {
                return NotFound("not projects Completed Now");
            }
            return Ok(CountResult);
        }

        [HttpGet("Active")]
        public async Task<IActionResult> Active(CancellationToken cancellationToken)
        {
            var activeProjects = await _projectService.ActiveProjects(cancellationToken);
            if (!activeProjects.Any())
            {
                return NotFound("not projects Active Now");
            }
            var response = activeProjects
             .Adapt<List<ProjectResponce>>()
             .Take(3);
            return Ok(response);
        }
    }
}