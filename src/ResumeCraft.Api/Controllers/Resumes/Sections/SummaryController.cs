using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/summary")]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryService _service;

        public SummaryController(ISummaryService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<SummaryDTO>> GetSummary(Guid resumeId)
        {
            return Ok(await _service.GetAsync(resumeId));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSummary(Guid resumeId, SummaryInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var newSummary = await _service.AddAsync(resumeId, model);

                ModelState.Clear();
                return Created(string.Empty, newSummary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteEducation(Guid resumeId)
        {
            try
            {
                await _service.DeleteAsync(resumeId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateSummary(Guid resumeId, [FromBody] string content)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updateSummary = await _service.UpdateAsync(resumeId, content);

                ModelState.Clear();
                return Created(string.Empty, updateSummary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
