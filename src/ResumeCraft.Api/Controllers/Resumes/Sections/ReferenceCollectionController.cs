using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/references")]
    public class ReferenceCollectionController : ControllerBase
    {
        private readonly IReferenceService _service;

        public ReferenceCollectionController(IReferenceService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<ReferenceDTO>>> GetReferences(Guid resumeId)
        {
            return Ok(await _service.GetListAsync(resumeId));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddReference(Guid resumeId, ReferenceInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var newReference = await _service.AddAsync(resumeId, model);

                ModelState.Clear();
                return Created(string.Empty, newReference);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{referenceId}")]
        public async Task<IActionResult> DeleteEducation(Guid resumeId, Guid referenceId)
        {
            try
            {
                await _service.DeleteAsync(resumeId, referenceId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{referenceId}")]
        public async Task<IActionResult> UpdateReference(Guid resumeId, Guid referenceId, ReferenceInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updatedReference = await _service.UpdateAsync(resumeId, referenceId, model);

                ModelState.Clear();
                return Created(string.Empty, updatedReference);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
