using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReferenceService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<ReferenceDTO>> GetListAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.References);

            return _mapper.Map<IList<ReferenceDTO>>(resume?.References);
        }

        public async Task<ReferenceDTO> AddAsync(Guid resumeId, ReferenceInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.References);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToSave = new Reference
            {
                //SupervisorAddress = model.SupervisorAddress,
                SupervisorDesignation = model.SupervisorDesignation,
                SupervisorEmail = model.SupervisorEmail,
                SupervisorInstituteName = model.SupervisorInstituteName,
                SupervisorName = model.SupervisorName,
                SupervisorPhone = model.SupervisorPhone
            };

            resume?.References.Add(itemToSave);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ReferenceDTO>(itemToSave);
        }

        public async Task DeleteAsync(Guid resumeId, Guid referenceIdToDelete)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.References);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToDelete = resume?.References.FirstOrDefault(y => y.Id == referenceIdToDelete);
            if (itemToDelete == null)
            {
                return;
            }

            resume?.References?.Remove(itemToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ReferenceDTO> UpdateAsync(Guid resumeId, Guid referenceIdToUpdate, ReferenceInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.References);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToUpdate = resume?.References.FirstOrDefault(y => y.Id == referenceIdToUpdate);
            if (itemToUpdate is null)
            {
                throw new ArgumentNullException("Reference data is not valid");
            }

            itemToUpdate.SupervisorInstituteName = model.SupervisorInstituteName;
            itemToUpdate.SupervisorEmail = model.SupervisorEmail;
            itemToUpdate.SupervisorPhone = model.SupervisorPhone;
            //itemToUpdate.SupervisorAddress = model.SupervisorAddress;
            itemToUpdate.SupervisorName = model.SupervisorName;
            itemToUpdate.SupervisorDesignation = model.SupervisorDesignation;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<ReferenceDTO>(itemToUpdate);
        }
    }
}
