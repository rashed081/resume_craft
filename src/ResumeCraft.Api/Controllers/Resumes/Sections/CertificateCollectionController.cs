using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;

namespace ResumeCraft.Api.Controllers.Resumes.Sections
{
    [ApiController]
    [Route("api/v1/resumes/{resumeId}/certifications")]
    public class CertificateCollectionController : ControllerBase
    {
        private readonly ICertificationService _service;

        public CertificateCollectionController(ICertificationService certificationService)
        {
            _service = certificationService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<CertificationDTO>>> GetCertifications(Guid resumeId)
        {
            return Ok(await _service.GetListOfCertificateAsync(resumeId));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCertification(Guid resumeId, CertificationInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var newCertificate = await _service.AddIntoResumeAsync(resumeId, model);

                ModelState.Clear();
                return Created(string.Empty, newCertificate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{certificationId}")]
        public async Task<IActionResult> DeleteEducation(Guid resumeId, Guid certificationId)
        {
            try
            {
                await _service.DeleteFromResumeAsync(resumeId, certificationId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{certificationId}")]
        public async Task<IActionResult> UpdateCertification(Guid resumeId, Guid certificationId, CertificationInputModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var updatedCertificate = await _service.UpdateTheCertificateAsync(resumeId, certificationId, model);

                ModelState.Clear();
                return Created(string.Empty, updatedCertificate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
