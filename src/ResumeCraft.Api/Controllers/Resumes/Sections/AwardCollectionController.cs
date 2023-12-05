using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/awards")]
    public class AwardCollectionController : ControllerBase
    {
        private readonly IAwardService _service;

        public AwardCollectionController(IAwardService awardService)
        {
            _service = awardService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<AwardDTO>>> GetAwards(Guid resumeId)
        {
            return Ok(await _service.GetListAsync(resumeId));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAward(Guid resumeId, AwardInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var newAward = await _service.AddAsync(resumeId, model);

                ModelState.Clear();
                return Created(string.Empty, newAward);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{awardId}")]
        public async Task<IActionResult> DeleteAward(Guid resumeId, Guid awardId)
        {
            try
            {
                await _service.DeleteAsync(resumeId, awardId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{awardId}")]
        public async Task<IActionResult> UpdateAward(Guid resumeId, Guid awardId, AwardInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updatedAward = await _service.UpdateAsync(resumeId, awardId, model);

                ModelState.Clear();
                return Created(string.Empty, updatedAward);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
