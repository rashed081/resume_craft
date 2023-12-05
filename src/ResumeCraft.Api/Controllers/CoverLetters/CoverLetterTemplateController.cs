using ResumeCraft.Application.Features.CoverLetters.DTOs;
using ResumeCraft.Application.Features.CoverLetters.Models;
using ResumeCraft.Application.Features.CoverLetters.Services.Interface;

namespace ResumeCraft.Api.Controllers.CoverLetters
{
    [ApiController]
    [Route("api/v1/CoverLettertemplate")]
    public class CoverLetterTemplateController : Controller
    {
        private readonly IAsyncCoverLetterTemplateService _service;

        public CoverLetterTemplateController(IAsyncCoverLetterTemplateService coverLetterTemplateService)
        {
            _service = coverLetterTemplateService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<CoverLetterTemplateDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] CoverLetterTemplateModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest();
                return Ok(await _service.AddAsync(model.TemplateName, model.Path));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{coverLetterTemplateId}")]
        public async Task<IActionResult> Delete(Guid coverLetterTemplateId)
        {
            try
            {
                await _service.DeleteAsync(coverLetterTemplateId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{coverLetterTemplateId}")]
        public async Task<IActionResult> Update(Guid coverLetterTemplateId, [FromBody] CoverLetterTemplateModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest();

                var updateCoverLetterTemplate = await _service.UpdateAsync(coverLetterTemplateId, model.TemplateName, model.Path);

                ModelState.Clear();

                return Created(string.Empty, updateCoverLetterTemplate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
