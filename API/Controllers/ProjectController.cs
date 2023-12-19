using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService companyService)
        {
            _projectService = companyService;
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IQueryable<Company>>> GetProjects()
        {
            var result = await _projectService.GetProjects().ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetProject(Guid id)
        {
            var result = await _projectService.GetProjectByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> InsertProject([FromBody] Project project)
        {
            return Ok(await _projectService.InsertProjectAsync(project));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProject(Guid id)
        {
            return Ok( await _projectService.DeleteProject(id));
        }
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProject([FromBody] Project project)
        {
            return Ok(await _projectService.UpdateProject(project));
        }
    }
}
