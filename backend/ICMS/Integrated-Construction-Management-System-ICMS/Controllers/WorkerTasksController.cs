using Integrated_Construction_Management_System_ICMS.Contracts.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerTasksController (IWorkerTasks WorkerTasks): ControllerBase
    {
        private readonly IWorkerTasks _WorkerTasks = WorkerTasks;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var response = await _WorkerTasks.GetAll(cancellationToken);

            if (response is null)
                return NotFound();

            var mapping = response.Adapt<List<WorkerTasksResponce>>();
            return Ok(mapping);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var response = await _WorkerTasks.GetId(id, cancellationToken);

            if (response != null)
            {
                var mapping = response.Adapt<WorkerTasksResponce>();
                return Ok(mapping);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> Add(WworkerTasksRequest workerTasksRequest, CancellationToken cancellationToken)
        {
            var newWorkerTask = await _WorkerTasks.AddNew(workerTasksRequest, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = newWorkerTask.Id }, newWorkerTask);
        }

    }
}
