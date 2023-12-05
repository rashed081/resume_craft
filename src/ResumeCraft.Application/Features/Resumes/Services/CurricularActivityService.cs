using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class CurricularActivityService : ICurricularActivityService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CurricularActivityService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<CurricularActivityDTO>> GetListOfCurricularActivityAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.CurricularActivities);

            return _mapper.Map<IList<CurricularActivityDTO>>(resume?.CurricularActivities);
        }

        public async Task<CurricularActivityDTO> AddIntoResumeAsync(Guid resumeId, CurricularActivityInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.CurricularActivities);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToSave = new CurricularActivity
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Organization = model.Organization,
                Title = model.Title
            };

            resume?.CurricularActivities.Add(itemToSave);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<CurricularActivityDTO>(itemToSave);
        }

        public async Task DeleteFromResumeAsync(Guid resumeId, Guid curricularActivityIdToDelete)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.CurricularActivities);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToDelete = resume?.CurricularActivities.FirstOrDefault(y => y.Id == curricularActivityIdToDelete);
            if (itemToDelete == null)
            {
                return;
            }

            resume?.CurricularActivities?.Remove(itemToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CurricularActivityDTO> UpdateTheCurricularActivityAsync(
            Guid resumeId,
            Guid curricularActivityIdToUpdate,
            CurricularActivityInputModel model
        )
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.CurricularActivities);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToUpdate = resume?.CurricularActivities.FirstOrDefault(y => y.Id == curricularActivityIdToUpdate);
            if (itemToUpdate is null)
            {
                throw new ArgumentNullException("CurricularActivity data is not valid");
            }

            itemToUpdate.StartDate = model.StartDate;
            itemToUpdate.EndDate = model.EndDate;
            itemToUpdate.Organization = model.Organization;
            itemToUpdate.Title = model.Title;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<CurricularActivityDTO>(itemToUpdate);
        }
    }
}
