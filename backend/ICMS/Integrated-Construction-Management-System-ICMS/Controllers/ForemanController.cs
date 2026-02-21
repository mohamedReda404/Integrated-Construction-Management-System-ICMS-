using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ForemenController : ControllerBase
    {
        private readonly IForemanService _foremanService;

        public ForemenController(IForemanService foremanService)
        {
            _foremanService = foremanService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var response = await _foremanService.GetAll(cancellationToken);

            if (response != null)
            {
                var mapping = response.Adapt<List<ForemanResponse>>();
                return Ok(mapping);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var response = await _foremanService.GetId(id, cancellationToken);

            if (response != null)
            {
                var mapping = response.Adapt<ForemanResponse>();
                return Ok(mapping);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ForemanRequest request, CancellationToken cancellationToken)
        {
            var newForeman = await _foremanService
                .AddNew(request.Adapt<Foreman>(), cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = newForeman.ForemanId }, newForeman);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ForemanRequest request, CancellationToken cancellationToken)
        {
            var updated = await _foremanService
                .Update(id, request.Adapt<Foreman>(), cancellationToken);

            if (!updated)
                return NotFound();
            else
                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _foremanService.Delete(id, cancellationToken);

            if (!deleted)
                return NotFound();
            else
                return NoContent();
        }
    }
}