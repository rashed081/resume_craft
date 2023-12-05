using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface ICertificationService
    {
        Task<CertificationDTO> AddIntoResumeAsync(Guid resumeId, CertificationInputModel model);
        Task DeleteFromResumeAsync(Guid resumeId, Guid certificateIdToDelete);
        Task<IList<CertificationDTO>> GetListOfCertificateAsync(Guid resumeId);
        Task<CertificationDTO> UpdateTheCertificateAsync(Guid resumeId, Guid certificateIdToUpdate, CertificationInputModel model);
    }
}
