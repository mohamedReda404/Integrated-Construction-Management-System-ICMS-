using Integrated_Construction_Management_System_ICMS.Contracts.Responces;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Integrated_Construction_Management_System_ICMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var responce = await _projectService.GetAll();
            if (responce != null)
            {
                var responceMapping = responce.Adapt<List<ProjectResponce>>();
                return Ok(responceMapping);
            }
            else
            {
                return NotFound();
            }
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var responce=await _projectService.GetId(id);
            
            if (responce != null)
            {
                var responceMapping = responce.Adapt<ProjectResponce>();
                return Ok(responceMapping);
            }
            else
            {
                return NotFound();
            }

        }

    }
}