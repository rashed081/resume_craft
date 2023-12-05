using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/educations")]
    public class EducationCollectionController : ControllerBase
    {
        private readonly IEducationService _service;

        public EducationCollectionController(IEducationService educationService)
        {
            _service = educationService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<EducationDTO>>> GetEducationList(Guid resumeId)
        {
            var listOfEducation = await _service.GetListOfEducationAsync(resumeId);

            return Ok(listOfEducation);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddEducation(Guid resumeId, EducationInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var addedEducation = await _service.AddIntoResumeAsync(resumeId, model);

                ModelState.Clear();
                return Created(string.Empty, addedEducation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{educationId}")]
        public async Task<IActionResult> DeleteEducation(Guid resumeId, Guid educationId)
        {
            try
            {
                await _service.DeleteFromResumeAsync(resumeId, educationId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{educationId}")]
        public async Task<IActionResult> UpdateEducation(Guid resumeId, Guid educationId, EducationInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updatedEducation = await _service.UpdateEducationAsync(resumeId, educationId, model);

                ModelState.Clear();
                return Ok(updatedEducation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
