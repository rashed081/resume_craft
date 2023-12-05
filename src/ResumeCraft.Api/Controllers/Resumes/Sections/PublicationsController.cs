using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/publications")]
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationService _service;

        public PublicationsController(IPublicationService publicationService)
        {
            _service = publicationService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<PublicationDTO>>> GetAll(Guid resumeId)
        {
            return Ok(await _service.GetListOfPublicationAsync(resumeId));
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(Guid resumeId, PublicationInputModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest();

                var newPublication = await _service.AddIntoResumeAsync(resumeId, model);

                ModelState.Clear();

                return Created(string.Empty, newPublication);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{publicationId}")]
        public async Task<IActionResult> Delete(Guid resumeId, Guid publicationId)
        {
            try
            {
                await _service.DeleteFromResumeAsync(resumeId, publicationId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{publicationId}")]
        public async Task<IActionResult> Update(Guid resumeId, Guid publicationId, PublicationInputModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest();

                var updatedpublication = await _service.UpdateThePublicationAsync(resumeId, publicationId, model);

                ModelState.Clear();

                return Created(string.Empty, updatedpublication);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
