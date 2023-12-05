using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class AwardService : IAwardService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AwardService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<AwardDTO>> GetListAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Awards);

            return _mapper.Map<IList<AwardDTO>>(resume?.Awards);
        }

        public async Task<AwardDTO> AddAsync(Guid resumeId, AwardInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Awards);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToSave = new Award { InstituteName = model.InstituteName, Title = model.Title };

            resume?.Awards.Add(itemToSave);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<AwardDTO>(itemToSave);
        }

        public async Task DeleteAsync(Guid resumeId, Guid awardIdToDelete)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Awards);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToDelete = resume?.Awards.FirstOrDefault(y => y.Id == awardIdToDelete);
            if (itemToDelete == null)
            {
                return;
            }

            resume?.Awards?.Remove(itemToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<AwardDTO> UpdateAsync(Guid resumeId, Guid awardIdToUpdate, AwardInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Awards);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToUpdate = resume?.Awards.FirstOrDefault(y => y.Id == awardIdToUpdate);
            if (itemToUpdate is null)
            {
                throw new ArgumentNullException("Award data is not valid");
            }

            itemToUpdate.InstituteName = model.InstituteName;
            itemToUpdate.Title = model.Title;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<AwardDTO>(itemToUpdate);
        }
    }
}
