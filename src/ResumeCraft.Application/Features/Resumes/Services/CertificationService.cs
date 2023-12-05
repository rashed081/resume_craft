using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CertificationService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<CertificationDTO>> GetListOfCertificateAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Certifications);

            return _mapper.Map<IList<CertificationDTO>>(resume?.Certifications);
        }

        public async Task<CertificationDTO> AddIntoResumeAsync(Guid resumeId, CertificationInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Certifications);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToSave = new Certification
            {
                InstituteName = model.InstituteName,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Title = model.Title
            };

            resume?.Certifications.Add(itemToSave);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CertificationDTO>(itemToSave);
        }

        public async Task DeleteFromResumeAsync(Guid resumeId, Guid certificateIdToDelete)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Certifications);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToDelete = resume?.Certifications.FirstOrDefault(y => y.Id == certificateIdToDelete);
            if (itemToDelete == null)
            {
                return;
            }

            resume?.Certifications?.Remove(itemToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CertificationDTO> UpdateTheCertificateAsync(Guid resumeId, Guid certificateIdToUpdate, CertificationInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Certifications);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToUpdate = resume?.Certifications.FirstOrDefault(y => y.Id == certificateIdToUpdate);
            if (itemToUpdate is null)
            {
                throw new ArgumentNullException("Certification data is not valid");
            }

            itemToUpdate.InstituteName = model.InstituteName;
            itemToUpdate.StartDate = model.StartDate;
            itemToUpdate.EndDate = model.EndDate;
            itemToUpdate.Title = model.Title;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<CertificationDTO>(itemToUpdate);
        }
    }
}
