using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/curricularActivities")]
    public class CurricularActivitiesController : ControllerBase
    {
        private readonly ICurricularActivityService _service;

        public CurricularActivitiesController(ICurricularActivityService curricularActivityService)
        {
            _service = curricularActivityService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<CurricularActivityDTO>>> GetAll(Guid resumeId)
        {
            return Ok(await _service.GetListOfCurricularActivityAsync(resumeId));
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(Guid resumeId, CurricularActivityInputModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest();

                var newCurricularActivity = await _service.AddIntoResumeAsync(resumeId, model);

                ModelState.Clear();

                return Created(string.Empty, newCurricularActivity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{curricularActivityId}")]
        public async Task<IActionResult> Delete(Guid resumeId, Guid curricularActivityId)
        {
            try
            {
                await _service.DeleteFromResumeAsync(resumeId, curricularActivityId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{curricularActivityId}")]
        public async Task<IActionResult> Update(Guid resumeId, Guid curricularActivityId, CurricularActivityInputModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest();

                var updatedcurricularActivity = await _service.UpdateTheCurricularActivityAsync(resumeId, curricularActivityId, model);

                ModelState.Clear();

                return Created(string.Empty, updatedcurricularActivity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
