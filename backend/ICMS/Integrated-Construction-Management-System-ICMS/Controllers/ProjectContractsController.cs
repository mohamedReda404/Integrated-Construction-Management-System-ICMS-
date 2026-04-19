

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectContractsController(IProjectContractService projectContractService) : ControllerBase
    {
        private readonly IProjectContractService _projectContractService = projectContractService;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var responce = await _projectContractService.GetAll(cancellationToken);
            if (responce is null) { return NotFound(); }
            var responceMapping = responce.Adapt<List<ProjectContractResponce>>(); return Ok(responceMapping);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var responce = await _projectContractService.GetId(id, cancellationToken);

            if (responce != null) { var responceMapping = responce.Adapt<ProjectContractResponce>(); return Ok(responceMapping); }
            else { return NotFound(); }
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(ProjectContractRequest projectcontractRequest, CancellationToken cancellationToken)
        {
            var NewProject = await _projectContractService.AddNew(projectcontractRequest, cancellationToken);
            return CreatedAtAction(nameof(Get), NewProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProjectContractRequest projectcontractRequest, CancellationToken cancellationToken)
        {
            var editproject = await _projectContractService.Update(id, projectcontractRequest, cancellationToken);
            if (!editproject) { return NotFound(); }
            else { return NoContent(); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isDelete = await _projectContractService.Delete(id, cancellationToken);
            if (!isDelete) { return NotFound(); }
            else { return NoContent(); }
        }
    }
}