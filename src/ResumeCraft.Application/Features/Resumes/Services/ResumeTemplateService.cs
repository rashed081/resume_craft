using AutoMapper;
using ResumeCraft.Application.Features.Resumes.DTOs;
using ResumeCraft.Application.Features.Resumes.Services.Interfaces;
using ResumeCraft.Application.Services.UnitOfWorks;

namespace ResumeCraft.Application.Features.Resumes.Services
{
    public class ResumeTemplateService : IResumeTemplateService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResumeTemplateService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResumeDTO> GetResumeOfUser(Guid userId, Guid resumeId)
        {
            var resume = await _unitOfWork.Resumes.GetResumeWithRelatedData(resumeId);

            if (resume?.UserId != userId)
            {
                throw new InvalidOperationException("User doesn't have requested resume");
            }

            return _mapper.Map<ResumeDTO>(resume);
        }
    }
}
