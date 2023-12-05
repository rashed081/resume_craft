using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/skills")]
    public class SkillCollectionController : ControllerBase
    {
        private readonly ISkillService _service;

        public SkillCollectionController(ISkillService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<SkillDTO>>> GetSkills(Guid resumeId)
        {
            return Ok(await _service.GetListAsync(resumeId));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSkill(Guid resumeId, SkillInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var newSkill = await _service.AddAsync(resumeId, model);

                ModelState.Clear();
                return Created(string.Empty, newSkill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{skillId}")]
        public async Task<IActionResult> DeleteEducation(Guid resumeId, Guid skillId)
        {
            try
            {
                await _service.DeleteAsync(resumeId, skillId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{skillId}")]
        public async Task<IActionResult> UpdateSkill(Guid resumeId, Guid skillId, SkillInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updatedSkill = await _service.UpdateAsync(resumeId, skillId, model);

                ModelState.Clear();
                return Created(string.Empty, updatedSkill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
