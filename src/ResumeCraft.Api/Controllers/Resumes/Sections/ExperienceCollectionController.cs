using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/experiences")]
    public class ExperienceCollectionController : Controller
    {
        private readonly IExperienceService _service;

        public ExperienceCollectionController(IExperienceService experienceService)
        {
            _service = experienceService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<ExperienceDTO>>> GetExperiences(Guid resumeId)
        {
            var experiences = await _service.GetListAsync(resumeId);

            return Ok(experiences);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddExperience(Guid resumeId, ExperienceInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var newExperience = await _service.AddAsync(resumeId, model);

                ModelState.Clear();
                return Created(string.Empty, newExperience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{experienceId}")]
        public async Task<IActionResult> DeleteExperience(Guid resumeId, Guid experienceId)
        {
            try
            {
                await _service.DeleteAsync(resumeId, experienceId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{experienceId}")]
        public async Task<IActionResult> UpdateExperience(Guid resumeId, Guid experienceId, ExperienceInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updatedExperience = await _service.UpdateAsync(resumeId, experienceId, model);

                ModelState.Clear();
                return Created(string.Empty, updatedExperience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
