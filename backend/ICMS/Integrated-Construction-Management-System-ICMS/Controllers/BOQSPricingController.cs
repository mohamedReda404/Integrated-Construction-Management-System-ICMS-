using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BOQSPricingController(IBOQPricingServices boqPricingService) : ControllerBase
    {
        private readonly IBOQPricingServices _boqPricingService = boqPricingService;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var responce = await _boqPricingService.GetAll(cancellationToken);
            if (responce is null) { return NotFound(); }
            var responceMapping = responce.Adapt<List<BOQPricingReponce>>();
            return Ok(responceMapping);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var responce = await _boqPricingService.GetId(id, cancellationToken);

            if (responce != null)
            {
                var responceMapping = responce.Adapt<BOQPricingReponce>();
                return Ok(responceMapping);
            }
            else { return NotFound(); }
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(BOQPricingRequest boqPricingRequest, CancellationToken cancellationToken)
        {
            var NewBOQPricing = await _boqPricingService.AddNew(boqPricingRequest, cancellationToken);
            return CreatedAtAction(nameof(Get), NewBOQPricing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BOQPricingRequest boqPricingRequest, CancellationToken cancellationToken)
        {
            var editBOQPricing = await _boqPricingService.Update(id, boqPricingRequest, cancellationToken);
            if (!editBOQPricing) { return NotFound(); }
            else { return NoContent(); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isDelete = await _boqPricingService.Delete(id, cancellationToken);
            if (!isDelete) { return NotFound(); }
            else { return NoContent(); }
        }
    }
}
