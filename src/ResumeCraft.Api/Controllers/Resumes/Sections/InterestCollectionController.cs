using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/interests")]
    public class InterestCollectionController : ControllerBase
    {
        private readonly IInterestService _service;

        public InterestCollectionController(IInterestService interestService)
        {
            _service = interestService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<InterestDTO>>> GetCertifications(Guid resumeId)
        {
            return Ok(await _service.GetListOfInterestAsync(resumeId));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddInterest(Guid resumeId, InterestInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var newInterest = await _service.AddIntoResumeAsync(resumeId, model);

                ModelState.Clear();
                return Created(string.Empty, newInterest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{interestId}")]
        public async Task<IActionResult> DeleteInterest(Guid resumeId, Guid interestId)
        {
            try
            {
                await _service.DeleteFromResumeAsync(resumeId, interestId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{interestId}")]
        public async Task<IActionResult> UpdateInterest(Guid resumeId, Guid interestId, InterestInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updatedInterest = await _service.UpdateInterestAsync(resumeId, interestId, model);

                ModelState.Clear();
                return Created(string.Empty, updatedInterest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
