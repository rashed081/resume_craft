using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/projects")]
    public class ProjectCollectionController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectCollectionController(IProjectService projectService)
        {
            _service = projectService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<ProjectDTO>>> GetProjects(Guid resumeId)
        {
            var listOfProjects = await _service?.GetAllProjectAsync(resumeId)!;

            return Ok(listOfProjects);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddProject(Guid resumeId, ProjectInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var newProject = await _service?.AddProjectAsync(resumeId, model)!;

                ModelState.Clear();
                return Created(string.Empty, newProject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(Guid resumeId, Guid projectId)
        {
            try
            {
                await _service?.DeleteProjectAsync(resumeId, projectId)!;

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(Guid resumeId, Guid projectId, ProjectInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updatedProject = await _service?.UpdateProjectAsync(resumeId, projectId, model)!;

                ModelState.Clear();
                return Ok(updatedProject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
