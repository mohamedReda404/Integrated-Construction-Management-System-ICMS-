using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceItemsController(IInvoiceItemService invoiceItemService) : ControllerBase
    {
        private readonly IInvoiceItemService _invoiceItemService = invoiceItemService;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var response = await _invoiceItemService.GetAll(cancellationToken);

            if (response is null)
                return NotFound();

            var mapping = response.Adapt<List<InvoiceItemResponse>>();
            return Ok(mapping);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var response = await _invoiceItemService.GetId(id, cancellationToken);

            if (response != null)
            {
                var mapping = response.Adapt<InvoiceItemResponse>();
                return Ok(mapping);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(InvoiceItemRequest request, CancellationToken cancellationToken)
        {
            var newItem = await _invoiceItemService.AddNew(request, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InvoiceItemRequest request, CancellationToken cancellationToken)
        {
            var updated = await _invoiceItemService.Update(id, request, cancellationToken);

            if (!updated)
                return NotFound();
            else
                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isDeleted = await _invoiceItemService.Delete(id, cancellationToken);

            if (!isDeleted)
                return NotFound();
            else
                return NoContent();
        }
    }
}