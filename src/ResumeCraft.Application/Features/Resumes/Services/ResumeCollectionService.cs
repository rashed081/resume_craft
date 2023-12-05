using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class ResumeCollectionService : IResumesService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResumeCollectionService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<ResumeListDto>> GetListOfResumeAsync(Guid userId)
        {
            var resumeList = await _unitOfWork.Resumes.GetListAsync(x => x.UserId == userId);

            return _mapper.Map<IList<ResumeListDto>>(resumeList);
        }

        public async Task<bool> ExistsAsync(Guid resumeId)
        {
            return await _unitOfWork.Resumes.FindAsync(resumeId) is not null;
        }

        public async Task<Guid> CreateEmptyResumeAsync(Guid userId)
        {
            var newResume = new Domain.Entities.Resume { UserId = userId };
            var createdResumeToReturn = await _unitOfWork.Resumes.AddAsync(newResume);

            await _unitOfWork.SaveAsync();

            return createdResumeToReturn.Id;
        }

        public async Task DeleteResumeAsync(Guid resumeId)
        {
            if (await _unitOfWork.Resumes.FindAsync(resumeId) is null)
            {
                return;
            }

            await _unitOfWork.Resumes.RemoveAsync(resumeId);
            await _unitOfWork.SaveAsync();
        }
    }
}
