using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes
{
    [ApiController]
    [Route("api/v1/{userId}/resumes/{resumeId}/template")]
    public class ResumeTemplateController : ControllerBase
    {
        private readonly IResumeTemplateService _templateService;

        public ResumeTemplateController(IResumeTemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet("")]
        public async Task<ActionResult<ResumeDTO>> GetFullResumeForTemplating(Guid userId, Guid resumeId)
        {
            var result = await _templateService.GetResumeOfUser(userId, resumeId);

            return Ok(result);
        }
    }
}
