using Microsoft.AspNetCore.Identity;
using ResumeCraft.Application.Features.CoverLetters.DTOs;
using ResumeCraft.Application.Features.CoverLetters.Models;
using ResumeCraft.Application.Features.CoverLetters.Services.Interface;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Api.Controllers.CoverLetters
{
    [ApiController]
    [Route("api/v1/{userId}/coverletters")]
    public class CoverLetterController : ControllerBase
    {
        private readonly IAsyncCoverLetterService _service;

        public CoverLetterController(IAsyncCoverLetterService coverLetterService, UserManager<ApplicationUser> userManager)
        {
            _service = coverLetterService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<CoverLetterDTO>>> GetAll()
        {
            return Ok(await _service.GetListOfCoverLetterAsync());
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(Guid userId, Guid CoverLetterTemplateId, [FromBody] CoverLetterInputModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest();
                return Ok(await _service.AddAsync(userId, CoverLetterTemplateId, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddEmptyCoverLetter")]
        public async Task<IActionResult> AddEmptyCoverLetter(Guid userId, Guid CoverLetterTemplateId)
        {
            var newResumeId = await _service.AddEmptyCoverLetter(userId, CoverLetterTemplateId);

            return Created(string.Empty, new { Id = newResumeId });
        }

        [HttpDelete("{coverLetterId}")]
        public async Task<IActionResult> Delete(Guid coverLetterId)
        {
            try
            {
                await _service.DeleteAsync(coverLetterId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{coverLetterId}")]
        public async Task<IActionResult> Update(Guid userId, Guid CoverLetterTemplateId, Guid coverLetterId, [FromBody] CoverLetterInputModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest();

                var updateCoverLetter = await _service.UpdateTheCoverLetterAsync(userId, CoverLetterTemplateId, coverLetterId, model);

                ModelState.Clear();

                return Created(string.Empty, updateCoverLetter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
