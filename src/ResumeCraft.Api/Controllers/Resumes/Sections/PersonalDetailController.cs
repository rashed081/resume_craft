using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/contact")]
    public class PersonalDetailController : Controller
    {
        private readonly IPersonalDetailService _service;

        public PersonalDetailController(IPersonalDetailService personalDetailService)
        {
            _service = personalDetailService;
        }

        [HttpGet("")]
        public async Task<ActionResult<PersonalDetailsDTO>> GetPersonalDetail(Guid resumeId)
        {
            try
            {
                var personalDetail = await _service.GetDetialsOfUserAsync(resumeId);

                if (personalDetail == default)
                {
                    return NotFound();
                }

                return Ok(personalDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> AddPersonalDetail(Guid resumeId, PersonalDetailInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var personalDetail = await _service.AddIntoResumeAsync(resumeId, model);

                ModelState.Clear();
                return Created(string.Empty, personalDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeletePersonalDetail(Guid resumeId)
        {
            try
            {
                await _service.DeleteFromResumeAsync(resumeId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdatePersonalDetail(Guid resumeId, PersonalDetailInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updatedDetails = await _service.UpdateDetailsAsync(resumeId, model);

                ModelState.Clear();
                return Ok(updatedDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateDynamic")]
        public async Task<IActionResult> UpdateDynamic(Guid resumeId, ContactUpdateModel model)
        {
            if (model == null)
                return BadRequest();

            try
            {
                var updatedDetails = await _service.UpdateDynamic(resumeId, model);

                ModelState.Clear();
                return Ok(updatedDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
