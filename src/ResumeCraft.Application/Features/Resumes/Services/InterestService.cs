using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class InterestService : IInterestService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InterestService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<InterestDTO>> GetListOfInterestAsync(Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Interests);

            return _mapper.Map<IList<InterestDTO>>(resume?.Interests);
        }

        public async Task<InterestDTO> AddIntoResumeAsync(Guid resumeId, InterestInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Interests);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToSave = new Interest { Name = model.Name };

            resume?.Interests.Add(itemToSave);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<InterestDTO>(itemToSave);
        }

        public async Task DeleteFromResumeAsync(Guid resumeId, Guid interestId)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Interests);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToDelete = resume?.Interests.FirstOrDefault(y => y.Id == interestId);
            if (itemToDelete == null)
            {
                throw new ArgumentException("Interest doesn't exist");
            }

            resume?.Interests?.Remove(itemToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<InterestDTO> UpdateInterestAsync(Guid resumeId, Guid interestIdToUpdate, InterestInputModel model)
        {
            var resume = await _unitOfWork.Resumes.GetByIncludingAsync(x => x.Id == resumeId, x => x.Interests);
            if (resume is null)
            {
                throw new ArgumentNullException("Resume doesn't exist");
            }

            var itemToUpdate = resume?.Interests.FirstOrDefault(y => y.Id == interestIdToUpdate);
            if (itemToUpdate is null)
            {
                throw new ArgumentNullException("Updating interest doesn't exist");
            }

            itemToUpdate.Name = model.Name;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<InterestDTO>(itemToUpdate);
        }
    }
}
