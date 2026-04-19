using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DrawingsController(IDrawingService drawingService) : ControllerBase
    {
        private readonly IDrawingService _drawingService = drawingService;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var response = await _drawingService.GetAll(cancellationToken);
            if (response is null)
                return NotFound();

            var mapping = response.Adapt<List<DrawingResponse>>();
            return Ok(mapping);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var response = await _drawingService.GetId(id, cancellationToken);

            if (response != null)
            {
                var mapping = response.Adapt<DrawingResponse>();
                return Ok(mapping);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(DrawingRequest drawingRequest, CancellationToken cancellationToken)
        {
            var newDrawing = await _drawingService.AddNew(drawingRequest, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = newDrawing.Id }, newDrawing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DrawingRequest drawingRequest, CancellationToken cancellationToken)
        {
            var updated = await _drawingService.Update(id, drawingRequest, cancellationToken);

            if (!updated)
                return NotFound();
            else
                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isDeleted = await _drawingService.Delete(id, cancellationToken);

            if (!isDeleted)
                return NotFound();
            else
                return NoContent();
        }
    }
}