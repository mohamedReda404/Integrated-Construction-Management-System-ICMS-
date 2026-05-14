using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly RagService _rag;

        public ChatController(RagService rag)
        {
            _rag = rag;
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody]GroqRequest request)
        {
            var result = await _rag.Ask(request.Message);
            return Ok(new { response = result });
        }
    }
}
