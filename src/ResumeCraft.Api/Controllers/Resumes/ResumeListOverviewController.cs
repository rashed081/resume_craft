using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes
{
    [ApiController]
    [Route("api/v1/{userId}/resumes")]
    public class ResumeListOverviewController : ControllerBase
    {
        private readonly IResumesService _service;

        public ResumeListOverviewController(IResumesService collectionService)
        {
            this._service = collectionService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<ResumeListDto>>> GetOverviewOfResumeList(Guid userId)
        {
            return Ok(await _service.GetListOfResumeAsync(userId));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateEmptyResumeResume(Guid userId)
        {
            var newResumeId = await _service.CreateEmptyResumeAsync(userId);

            return Created(string.Empty, new { Id = newResumeId });
        }

        [HttpDelete("{resumeId}")]
        public async Task<IActionResult> DeleteResume(Guid userId, Guid resumeId)
        {
            if (await _service.ExistsAsync(resumeId) is false)
            {
                return BadRequest();
            }

            await _service.DeleteResumeAsync(resumeId);

            return Ok();
        }
    }
}
