

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BOQsController(IBOQServices bOQServices) : ControllerBase
    {
        private readonly IBOQServices _BOQServices = bOQServices;


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var responce = await _BOQServices.GetAll(cancellationToken);
            if (responce is null) { return NotFound(); }
            var responceMapping = responce.Adapt<List<BOQResponce>>(); return Ok(responceMapping);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var responce = await _BOQServices.GetId(id, cancellationToken);

            if (responce != null) { var responceMapping = responce.Adapt<BOQResponce>(); return Ok(responceMapping); }
            else { return NotFound(); }
        }


        [HttpPost("")]
        public async Task<IActionResult> Add(BOQRequest bOQRequest, CancellationToken cancellationToken)
        {
            var NewBOQ = await _BOQServices.AddNew(bOQRequest, cancellationToken);
            return CreatedAtAction(nameof(Get), NewBOQ);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BOQRequest bOQRequest, CancellationToken cancellationToken)
        {
            var editboq = await _BOQServices.Update(id, bOQRequest, cancellationToken);
            if (!editboq) { return NotFound(); }
            else { return NoContent(); }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isDelete = await _BOQServices.Delete(id, cancellationToken);
            if (!isDelete) { return NotFound(); }
            else { return NoContent(); }
        }

    }
}
