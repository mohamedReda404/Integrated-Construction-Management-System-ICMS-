using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceController(IInvoiceService invoiceService) : ControllerBase
    {
        private readonly IInvoiceService _invoiceService = invoiceService;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var response = await _invoiceService.GetAll(cancellationToken);

            if (response is null)
                return NotFound();

            var mapping = response.Adapt<List<InvoiceResponse>>();
            return Ok(mapping);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var response = await _invoiceService.GetById(id, cancellationToken);

            if (response != null)
            {
                var mapping = response.Adapt<InvoiceResponse>();
                return Ok(mapping);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(InvoiceRequest invoiceRequest, CancellationToken cancellationToken)
        {
            var newInvoice = await _invoiceService.AddNew(invoiceRequest, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = newInvoice.Id }, newInvoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InvoiceRequest invoiceRequest, CancellationToken cancellationToken)
        {
            var updated = await _invoiceService.Update(id, invoiceRequest, cancellationToken);

            if (!updated)
                return NotFound();
            else
                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isDeleted = await _invoiceService.Delete(id, cancellationToken);

            if (!isDeleted)
                return NotFound();
            else
                return NoContent();
        }
    }
}