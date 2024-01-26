using Application.Interfaces;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [SwaggerTag("Mantenimiento del proyecto")]
    public class ProjectController : BaseApiController
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                //return Ok(await Mediator.Send(new GetByIdProjectsQuery() { Id = id}));
                return Ok(await _projectRepository.GetByIdAsync(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound("Proyect not found");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            return Ok(await _projectRepository.AddAsync(project));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Project project)
        {
            try
            {
                return Ok(await _projectRepository.UpdateProjectAsync(project));
            }
            catch (KeyNotFoundException ex)
            {

                return BadRequest("Project could not be updated");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _projectRepository.GetAllAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _projectRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {

                return BadRequest("Project could not be deleted");
            }
        }
    }
}
