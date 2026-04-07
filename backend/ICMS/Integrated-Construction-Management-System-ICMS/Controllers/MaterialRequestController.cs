using Integrated_Construction_Management_System_ICMS.Contracts.Responces;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BOQPricingController(IMaterialRequestServices IMaterialRequestServices) : ControllerBase
    {
        private readonly IMaterialRequestServices _IMaterialRequestServices = IMaterialRequestServices;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var responce = await _IMaterialRequestServices.GetAll(cancellationToken);
            if (responce is null) { return NotFound(); }
            var responceMapping = responce.Adapt<List<MaterialRequestReponse>>();
            return Ok(responceMapping);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var responce = await _IMaterialRequestServices.GetId(id, cancellationToken);

            if (responce != null)
            {
                var responceMapping = responce.Adapt<MaterialRequestReponse>();
                return Ok(responceMapping);
            }
            else { return NotFound(); }
        }


        [HttpPost("")]
        public async Task<IActionResult> Add(MaterialRequestRequest materialRequestRequest, CancellationToken cancellationToken)
        {
            var New = await _IMaterialRequestServices.AddNew(materialRequestRequest, cancellationToken);
            return CreatedAtAction(nameof(Get), New);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MaterialRequestRequest materialRequestRequest, CancellationToken cancellationToken)
        {
            var edit = await _IMaterialRequestServices.Update(id, materialRequestRequest, cancellationToken);
            if (!edit) { return NotFound(); }
            else { return NoContent(); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isDelete = await _IMaterialRequestServices.Delete(id, cancellationToken);
            if (!isDelete) { return NotFound(); }
            else { return NoContent(); }
        }
    }
}
