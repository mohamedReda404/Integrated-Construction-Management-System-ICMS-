using Microsoft.AspNetCore.Authorization;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectContractsController : ControllerBase
    {
        private readonly IProjectContractService _projectContractService;

        public ProjectContractsController(IProjectContractService projectContractService)
        {
            _projectContractService = projectContractService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var responce = await _projectContractService.GetAll(cancellationToken);

            if (responce != null)
            {
                var responceMapping = responce.Adapt<List<ProjectContractResponce>>();
                return Ok(responceMapping);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var responce = await _projectContractService.GetId(id, cancellationToken);

            if (responce != null)
            {
                var responceMapping = responce.Adapt<ProjectContractResponce>();
                return Ok(responceMapping);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(ProjectContractRequest request, CancellationToken cancellationToken)
        {
            var newContract = await _projectContractService
                .AddNew(request.Adapt<ProjectContract>(), cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = newContract.ProjectContractId }, newContract);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProjectContractRequest request, CancellationToken cancellationToken)
        {
            var editContract = await _projectContractService
                .Update(id, request.Adapt<ProjectContract>(), cancellationToken);

            if (!editContract)
                return NotFound();
            else
                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isDelete = await _projectContractService.Delete(id, cancellationToken);

            if (!isDelete)
                return NotFound();
            else
                return NoContent();
        }
    }
}